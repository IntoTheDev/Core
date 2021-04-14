#if ODIN_INSPECTOR
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Reflection;
using ToolBox.Runtime.Attributes;
using UnityEngine;

namespace ToolBox.Editor.Branches
{
	public class AssetViewer : IBranch
	{
		public string Path => "ToolBox/ASSETS/";

		public void Setup(OdinMenuTree tree)
		{
			var assets = AssetUtilities.GetAllAssetsOfType<ScriptableObject>();

			foreach (var asset in assets)
			{
				var type = asset.GetType();

				if (type.GetCustomAttribute<ShowInMenuAttribute>() != null)
					tree.AddObjectAtPath($"{Path}{type}/{asset.name}", asset);
			}
		}
	}
}
#endif
