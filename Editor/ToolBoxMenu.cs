using Sirenix.OdinInspector.Editor;
using UnityEditor;
using System.Collections.Generic;
using Sirenix.Utilities.Editor;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu : OdinMenuEditorWindow
	{
		[MenuItem("Window/ToolBox/Menu")]
		private static void OpenWindow() =>
			GetWindow<ToolBoxMenu>().Show();

		protected override OdinMenuTree BuildMenuTree()
		{
			OdinMenuTree tree = new OdinMenuTree();
			tree.Selection.SupportsMultiSelect = false;

			tree.Add("Action Generation", new ActionGeneration());
			tree.Add("Condition Generation", new ConditionGeneration());
			tree.Add("Game Event Generation", new GameEventGeneration());
			tree.Add("Collection Generation", new CollectionGeneration());
			tree.Add("Shared Data Generation", new SharedDataGeneration());

			return tree;
		}
	}
}
