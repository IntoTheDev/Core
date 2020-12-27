using System.Collections.Generic;
using UnityEngine;

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

		public static int RoundRobin(this int value, int max)
		{
			value++;

			if (value == max)
				value = 0;

			return value;
		}

		public static int Circle(int value, int min, int max)
		{
			if (value == max)
			{
				value = min + 1;
				return value;
			}

			if (value == min)
			{
				value = max - 1;
				return value;
			}

			return value;
		}

		public static bool PercentChance(float chance) =>
			UnityEngine.Random.value <= chance;

		public static void Swap<T>(this T[] array, int a, int b)
		{
			T x = array[a];
			array[a] = array[b];
			array[b] = x;
		}

		public static string MakeFirstLetterUppercase(this string text) =>
			text.Substring(0, 1).ToUpper() + text.Substring(1);
	}
}
