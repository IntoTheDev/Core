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

			tree.Add("Reactor Generation", new ReactorGeneration());
			tree.Add("Type Generation", new TypeGeneration());
			tree.Add("Collection Generation", new CollectionGeneration());

			return tree;
		}
	}
}
