using ToolBox.Loader;
using UnityEngine;

namespace ToolBox.Runtime
{
	public static class AppStarter
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void Init()
		{
			Storage.Get<AppConfig>().Init();
		}
	}
}
