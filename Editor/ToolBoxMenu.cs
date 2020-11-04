using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using System;
using System.Linq;
using UnityEditor;

namespace ToolBox.Editor
{
	public class ToolBoxMenu : OdinMenuEditorWindow
	{
		[MenuItem("Window/ToolBox")]
		private static void Open() =>
			GetWindow<ToolBoxMenu>().Show();

		protected override OdinMenuTree BuildMenuTree()
		{
			var tree = new OdinMenuTree();
			var branches = AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes)
				.Where(x => x.InheritsFrom<IBranch>() && !x.IsAbstract);

			foreach (Type item in branches)
			{
				var obj = Activator.CreateInstance(item);
				var branch = obj as IBranch;

				branch.Setup(tree);
				tree.Add(branch.Path, obj);
			}

			return tree;
		}
	}

	public interface IBranch
	{
		string Path { get; }

		void Setup(OdinMenuTree tree);
	}
}
