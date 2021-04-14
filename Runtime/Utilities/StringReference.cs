#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace ToolBox.Runtime.Utilities
{
#if ODIN_INSPECTOR
	[Required, AssetSelector, InlineEditor(InlineEditorModes.GUIOnly, Expanded = true)]
#endif
	[CreateAssetMenu(menuName = "ToolBox/String Reference")]
	public sealed class StringReference : ScriptableObject
	{
#if ODIN_INSPECTOR
		[DisableInInlineEditors]
#endif
		[SerializeField] private string _value = string.Empty;

		public string Value => _value;
	}
}
