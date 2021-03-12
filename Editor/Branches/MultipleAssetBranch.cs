using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Reflection;
using ToolBox.Loader;
using UnityEngine;

namespace ToolBox.Editor
{
	public class MultipleAssetBranch : IBranch
	{
		public string Path => "ToolBox/Assets/";

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
