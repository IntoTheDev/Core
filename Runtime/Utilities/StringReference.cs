#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using ToolBox.Runtime.Attributes;
using UnityEngine;

namespace ToolBox.Runtime.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/String Reference"), ShowInMenu]
	public sealed class StringReference : ScriptableObject
	{
		[SerializeField] private string _value = string.Empty;

		public string Value => _value;
	}
}
