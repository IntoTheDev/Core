#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Editor.Branches
{
	[CreateAssetMenu, InlineEditor(Expanded = true)]
	public sealed class Package : ScriptableObject
	{
		[SerializeField, DisableInInlineEditors, HorizontalGroup, LabelWidth(25f)] private string _url = null;

		[Button, HorizontalGroup(Width = 100f)]
		private void Update() =>
			PackageUpdater.Update(_url);
	}
}
#endif
