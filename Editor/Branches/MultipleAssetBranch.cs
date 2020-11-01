using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace ToolBox.Editor
{
	public abstract class MultipleAssetBranch<T> : IBranch where T : ScriptableObject
	{
		public string Path => _path;

		protected abstract string _path { get; }

		public void Setup(OdinMenuTree tree)
		{
			var assets = AssetUtilities.GetAllAssetsOfType<T>();
			var path = _path + "/";

			foreach (var asset in assets)
				tree.AddObjectAtPath(path + asset.name, asset);
		}
	}
}
