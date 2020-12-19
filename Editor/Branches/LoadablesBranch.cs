using System.Collections.Generic;
using System.Linq;
using ToolBox.Loader;
using UnityEngine;

namespace ToolBox.Editor
{
	public class LoadablesBranch : MultipleAssetBranch<ScriptableObject>
	{
		protected override string LocalPath => "ToolBox/Assets/Loadables";

		protected override IEnumerable<ScriptableObject> FilterAssets(IEnumerable<ScriptableObject> assets) =>
			assets.Where(x => x is ILoadable);
	}
}
