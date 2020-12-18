using System.Collections.Generic;
using System.Linq;
using ToolBox.Loader;
using UnityEngine;

namespace ToolBox.Editor
{
	public class LoadablesBranch : MultipleAssetBranch<ScriptableObject>
	{
		protected override string _path => "ToolBox/Assets/Loadables";

		protected override IEnumerable<ScriptableObject> FilterAssets(IEnumerable<ScriptableObject> assets)
		{
			assets = assets.Where(x => x is ILoadable);
			return assets;
		}
	}
}
