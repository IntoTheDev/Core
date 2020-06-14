using System;
using ToolBox.Tags;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ToolBox.Extensions
{
	public static class Extensions
	{
		#region Transform Extensions
		public static void ResetTransform(this Transform transform)
		{
			transform.position = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}
		#endregion

		#region GameObject Extensions
		public static void ResetTag(this GameObject obj) =>
			obj.tag = "Untagged";

		public static void AddTag(this GameObject entity, Tag tag) =>
			tag.Add(entity.GetHashCode());

		public static void RemoveTag(this GameObject entity, Tag tag) =>
			tag.Remove(entity.GetHashCode());

		public static bool HasTag(this GameObject entity, Tag tag) =>
			tag.HasEntity(entity.GetHashCode());

		public static void AddTags(this GameObject entity, Tag[] tags)
		{
			int hash = entity.GetHashCode();

			for (int i = 0; i < tags.Length; i++)
				tags[i].Add(hash);
		}

		public static void RemoveTags(this GameObject entity, Tag[] tags)
		{
			int hash = entity.GetHashCode();

			for (int i = 0; i < tags.Length; i++)
				tags[i].Remove(hash);
		}

		public static bool HasTags(this GameObject entity, Tag[] tags, bool allRequired)
		{
			int hash = entity.GetHashCode();

			if (allRequired)
			{
				for (int i = 0; i < tags.Length; i++)
				{
					if (!tags[i].HasEntity(hash))
						return false;
				}

				return true;
			}
			else
			{
				for (int i = 0; i < tags.Length; i++)
				{
					if (tags[i].HasEntity(hash))
						return true;
				}

				return false;
			}
		}
		#endregion

		#region Vector3 Extensions
		public static Vector3 Multiply(this Vector3 vector, float multiplier)
		{
			vector.x *= multiplier;
			vector.y *= multiplier;
			vector.z *= multiplier;

			return vector;
		}

		public static Vector2 Multiply(this Vector2 vector, float multiplier)
		{
			vector.x *= multiplier;
			vector.y *= multiplier;

			return vector;
		}
		#endregion

		#region Quaternion Extensions
		public static Quaternion Rotate(this Quaternion quaternion, Vector3 destination, Vector3 origin, Vector3 axis)
		{
			Vector3 difference = destination - origin;
			float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			return Quaternion.AngleAxis(angle, axis);
		}

		public static float Rotate(Vector3 destination, Vector3 origin)
		{
			Vector3 difference = destination - origin;
			float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			return angle;
		}
		#endregion
		/// <summary>
		/// Return mouse position in world space
		/// </summary>
		public static Vector3 MousePositionInWorld(this Camera cam) =>
			cam.ScreenToWorldPoint(Input.mousePosition);

		public static Vector3 Clamp(this Camera camera, Vector3 position)
		{
			Vector3 clampPosition = camera.WorldToViewportPoint(position);
			clampPosition.x = Mathf.Clamp01(clampPosition.x);
			clampPosition.y = Mathf.Clamp01(clampPosition.y);
			clampPosition = camera.ViewportToWorldPoint(clampPosition);

			return clampPosition;
		}

		/// <summary>
		/// Return random element from params
		/// </summary>
		public static T Choose<T>(params T[] p) =>
			p[UnityEngine.Random.Range(0, p.Length)];

		public static T Random<T>(this T[] collection)
		{
			int index = UnityEngine.Random.Range(0, collection.Length);
			return collection[index];
		}

		/// <summary>
		/// Return true if percent chance success
		/// </summary>
		public static bool PercentChance(float chance) =>
			UnityEngine.Random.value <= chance;

		#region Tilemap Extensions
		public static void FixedBoxFill(this Tilemap tilemap, TileBase tile, RectInt rectSize)
		{
			for (int cellX = rectSize.x; cellX < rectSize.width; cellX++)
			{
				for (int cellY = rectSize.y; cellY < rectSize.height; cellY++)
				{
					Vector3Int tilePosition = new Vector3Int(cellX, cellY, 0);
					tilemap.SetTile(tilePosition, tile);
				}
			}
		}

		public static void FixedBoxFill(this Tilemap tilemap, TileBase[] tiles, RectInt rectSize)
		{
			for (int cellX = rectSize.x; cellX < rectSize.width; cellX++)
			{
				for (int cellY = rectSize.y; cellY < rectSize.height; cellY++)
				{
					Vector3Int tilePosition = new Vector3Int(cellX, cellY, 0);
					tilemap.SetRandomTile(tilePosition, tiles);
				}
			}
		}

		public static void FixedBoxFill(
			this Tilemap tilemap,
			TileBase mainTile,
			TileBase[] otherTiles,
			float chancheToOtherTiles,
			RectInt rectSize)
		{
			for (int cellX = rectSize.x; cellX < rectSize.width; cellX++)
			{
				for (int cellY = rectSize.y; cellY < rectSize.height; cellY++)
				{
					Vector3Int tilePosition = new Vector3Int(cellX, cellY, 0);
					tilemap.SetRandomMainTile(tilePosition, mainTile, otherTiles, chancheToOtherTiles);
				}
			}
		}

		public static void SetRandomTile(this Tilemap tilemap, Vector3Int position, TileBase[] tiles)
		{
			int tileIndex = UnityEngine.Random.Range(0, tiles.Length);
			TileBase tile = tiles[tileIndex];

			tilemap.SetTile(position, tile);
		}

		public static void SetRandomMainTile(
			this Tilemap tilemap,
			Vector3Int position,
			TileBase mainTile,
			TileBase[] otherTiles,
			float chancheToOtherTiles)
		{
			if (PercentChance(chancheToOtherTiles))
				tilemap.SetRandomTile(position, otherTiles);
			else
				tilemap.SetTile(position, mainTile);
		}
		#endregion

		public static void Swap<T>(this T[] array, int a, int b)
		{
			T x = array[a];
			array[a] = array[b];
			array[b] = x;
		}

		public static string MakeFirstLetterUppercase(this string text) =>
			text.Substring(0, 1).ToUpper() + text.Substring(1);

		public static void OverlapCircle(Vector2 position, float radius, LayerMask layerMask, Action<Collider2D[]> action)
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layerMask);

			if (colliders.Length == 0)
				return;

			action(colliders);
		}
	}
}
