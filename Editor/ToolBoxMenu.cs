using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu : OdinMenuEditorWindow
	{
		[MenuItem("Window/ToolBox/Generator")]
		private static void Open() =>
			GetWindow<ToolBoxMenu>().Show();

		protected override OdinMenuTree BuildMenuTree()
		{
			OdinMenuTree tree = new OdinMenuTree();
			tree.Selection.SupportsMultiSelect = false;

			tree.Add("Reactor Generation", new ReactorGenerator());
			tree.Add("Type Generation", new TypeGenerator());
			tree.Add("Tween Generation", new TweenGenerator());
			tree.Add("Collection Generation", new CollectionGenerator());
			tree.Add("Branch Generation", new BranchGenerator());
			tree.Add("Serializer Generation", new SerializerGenerator());

			return tree;
		}
	}
}
