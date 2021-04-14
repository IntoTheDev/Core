﻿#if ODIN_INSPECTOR
#endif
using System;
using System.Collections.Generic;
#if UNITY_EDITOR
#endif
using UnityEngine;

namespace ToolBox.Runtime.Lookups
{
	[Serializable]
	public class SerializedDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
	{
		[SerializeField] private List<K> _keys = new List<K>();
		[SerializeField] private List<V> _values = new List<V>();

		public void OnBeforeSerialize()
		{
			_keys.Clear();
			_values.Clear();
			using var enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				var current = enumerator.Current;
				_keys.Add(current.Key);
				_values.Add(current.Value);
			}
		}

		public void OnAfterDeserialize()
		{
			for (int i = 0; i < _keys.Count; i++)
				Add(_keys[i], _values[i]);

			_keys.Clear();
			_values.Clear();
		}
	}
}