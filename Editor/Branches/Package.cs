#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Editor.Branches
{
	[CreateAssetMenu, InlineEditor(Expanded = true)]
	public sealed class Package : ScriptableObject
	{
		[SerializeField, DisableInInlineEditors] private string _url = null;

		[Button]
		private void Update() =>
			PackageUpdater.Update(_url);
	}
}
#endif