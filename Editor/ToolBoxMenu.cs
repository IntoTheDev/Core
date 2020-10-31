using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Reactors;
using UnityEditor;

namespace ToolBox.Editor
{
    public class ToolBoxMenu : OdinMenuEditorWindow
    {
        [MenuItem("Window/ToolBox")]
        private static void Open() =>
            GetWindow<GameMenu>().Show();

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(supportsMultiSelect: false);
            IEnumerable<Type> branches = AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes)
                .Where(x => x.IsClass && x.InheritsFrom<IBranch>());

            foreach (Type item in branches)
            {
                var obj = Activator.CreateInstance(item);
                IBranch branch = obj as IBranch;
                branch.Setup();
                tree.Add(branch.Path, obj);
            }

            return tree;
        }
    }

    public interface IBranch : ISetupable
    { 
        string Path { get; }
    }
}
