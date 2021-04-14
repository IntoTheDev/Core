using ToolBox.Loader;
using UnityEngine;

namespace ToolBox.Runtime.App
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
