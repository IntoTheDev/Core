#if UNITY_EDITOR && ODIN_INSPECTOR
using Sirenix.Utilities.Editor;
#endif
using System.Linq;
using UnityEngine;

namespace ToolBox.Runtime
{
	public static class AppStarter
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init()
		{
#if UNITY_EDITOR
#if ODIN_INSPECTOR
			var config = AssetUtilities.GetAllAssetsOfType<AppConfig>().First();
#else
			var config = Resources.FindObjectsOfTypeAll<AppConfig>().First();
#endif

#else
			var config = Resources.Load<AppConfig>("");
#endif
			config.Init();
		}
	}
}
