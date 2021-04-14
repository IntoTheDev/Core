﻿#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
#if UNITY_EDITOR
#endif
using UnityEngine;

namespace ToolBox.Runtime.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/String Reference")]
	public sealed class StringReference : ScriptableObject
	{
		[SerializeField] private string _value = string.Empty;

		public string Value => _value;
	}
}