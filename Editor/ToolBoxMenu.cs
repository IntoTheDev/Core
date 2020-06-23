using Sirenix.OdinInspector.Editor;
using UnityEditor;

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

			tree.Add("Reactor Generation", new ReactorGenerator());
			tree.Add("Type Generation", new TypeGenerator());
			tree.Add("Tween Generation", new TweenGenerator());
			tree.Add("Collection Generation", new CollectionGenerator());

			return tree;
		}
	}
}
