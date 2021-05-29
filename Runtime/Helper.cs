using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ToolBox.Runtime.Extensions
{
	public static class Helper
	{
		public static Vector3 AdjustScale2D(this Transform transform, float angle)
		{
			var scale = transform.localScale;
			scale.y = angle <= 90f && angle >= -90f ? 1f : -1f;

			return scale;
		}

		public static Quaternion Rotate(Vector3 destination, Vector3 origin, Vector3 axis)
		{
			var difference = destination - origin;
			float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			return Quaternion.AngleAxis(angle, axis);
		}

		public static float Rotate(Vector3 destination, Vector3 origin)
		{
			var difference = destination - origin;
			float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

			return angle;
		}

		public static Vector3 Clamp(this Camera camera, Vector3 position)
		{
			var clampPosition = camera.WorldToViewportPoint(position);
			clampPosition.x = Mathf.Clamp01(clampPosition.x);
			clampPosition.y = Mathf.Clamp01(clampPosition.y);
			clampPosition = camera.ViewportToWorldPoint(clampPosition);

			return clampPosition;
		}

		public static T Choose<T>(params T[] p) =>
			p[UnityEngine.Random.Range(0, p.Length)];

		public static T Random<T>(this T[] collection)
		{
			int index = UnityEngine.Random.Range(0, collection.Length);
			return collection[index];
		}

		public static T Random<T>(this List<T> collection)
		{
			int index = UnityEngine.Random.Range(0, collection.Count);
			return collection[index];
		}

		public static float Remap(float iMin, float iMax, float oMin, float oMax, float value)
		{
			float t = Mathf.InverseLerp(iMin, iMax, value);
			return Mathf.Lerp(oMin, oMax, t);
		}

		public static bool PercentChance(float chance) =>
			UnityEngine.Random.value <= chance;

		public static void Swap<T>(this T[] array, int a, int b)
		{
			var x = array[a];
			array[a] = array[b];
			array[b] = x;
		}

		public static string MakeFirstLetterUppercase(this string text) =>
			text.Substring(0, 1).ToUpper() + text.Substring(1);

		public static Vector3 AngleToVector(float angle, Vector3 axis, Vector3 direction) =>
			Quaternion.AngleAxis(angle, axis) * direction;

		public static float VectorToAngle(float y, float x) =>
			Mathf.Atan2(y, x) * Mathf.Rad2Deg;

		public static T GetClosest<T>(this IEnumerable<T> targets, Vector3 position) where T : Component
		{
			float bestDistance = float.MaxValue;
			T closest = null;

			foreach (var target in targets)
			{
				float distance = Vector3.SqrMagnitude(target.transform.position - position);

				if (distance < bestDistance)
				{
					closest = target;
					bestDistance = distance;
				}
			}

			return closest;		
		}
		
		public static GameObject GetClosest(this IEnumerable<GameObject> targets, Vector3 position)
		{
			float bestDistance = float.MaxValue;
			GameObject closest = null;

			foreach (var target in targets)
			{
				float distance = Vector3.SqrMagnitude(target.transform.position - position);

				if (distance < bestDistance)
				{
					closest = target;
					bestDistance = distance;
				}
			}

			return closest;		
		}
	}
}
