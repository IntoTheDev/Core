using System;
using System.Linq;
#if UNITY_EDITOR
using ToolBox.Loader.Editor;
#endif
using UnityEngine;

[Serializable]
public sealed class AssetLookup<K, V> : Lookup<K, V> where K : ScriptableObject
{
	protected override K[] GetKeys()
	{
#if UNITY_EDITOR
		var keys = EditorStorage.GetAllAssetsOfType<K>().ToArray();
#else
		var keys = new K[0];
#endif
		return keys;
	}

	protected override void Process(SerializedDictionary<K, V> lookup)
	{
		for (int i = lookup.Count - 1; i >= 0; i--)
		{
			var key = lookup.Keys.ElementAt(i);

			if (key == null)
				lookup.Remove(key);
		}
	}
}
