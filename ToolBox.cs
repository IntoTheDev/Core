using UnityEngine;
using UnityEngine.Tilemaps;

namespace ToolBox.Extensions
{
	public static class Extensions
	{
		#region Transform Extensions
		public static void ResetTransform(this Transform trans)
		{
			trans.position = Vector3.zero;
			trans.localRotation = Quaternion.identity;
			trans.localScale = Vector3.one;
		}
		#endregion

		#region GameObject Extensions
		public static void ResetTag(this GameObject obj)
		{
			obj.tag = "Untagged";
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
		/// <summary>
		/// Finds the Z angle in degrees in direction from origin to destination
		/// </summary>
		public static Quaternion Rotate(this Quaternion quaternion, Vector3 destination, Vector3 origin, Vector3 axis)
		{
			Vector3 difference = Vector3.Normalize(destination - origin);
			float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
			return quaternion = Quaternion.AngleAxis(angle, axis);
		}
		#endregion
		/// <summary>
		/// Return mouse position in world space
		/// </summary>
		public static Vector3 MousePositionInWorld(this Camera cam) => cam.ScreenToWorldPoint(Input.mousePosition);

		/// <summary>
		/// Return random element from params
		/// </summary>
		public static T Choose<T>(params T[] p) => p[Random.Range(0, p.Length)];

		/// <summary>
		/// Return true if percent chance success
		/// </summary>
		public static bool PercentChance(float chance) => Random.value <= chance;

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
			int tileIndex = Random.Range(0, tiles.Length);
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
	}
}






