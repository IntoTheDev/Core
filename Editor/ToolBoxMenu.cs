using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Pools;
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
			var tree = new OdinMenuTree(supportsMultiSelect: false);
			IEnumerable<Type> branches = AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes)
				.Where(x => x.IsClass && x.InheritsFrom<IBranch>() && !x.IsAbstract);

			foreach (Type item in branches)
			{
				var obj = Activator.CreateInstance(item);
				IBranch branch = obj as IBranch;
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
