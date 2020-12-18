using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Editor
{
	public abstract class MultipleAssetBranch<T> : IBranch where T : ScriptableObject
	{
		public string Path => _path;

		protected abstract string _path { get; }

		public void Setup(OdinMenuTree tree)
		{
			var assets = FilterAssets(AssetUtilities.GetAllAssetsOfType<T>());
			var path = _path + "/";

			foreach (var asset in assets)
				tree.AddObjectAtPath(path + asset.name, asset);
		}

		protected virtual IEnumerable<ScriptableObject> FilterAssets(IEnumerable<ScriptableObject> assets) =>
			assets;
	}
}
