using ToolBox.Loader;
using ToolBox.Runtime.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToolBox.Runtime
{
	[ShowInMenu]
	public class AppConfig : ScriptableObject, ILoadable
	{
		[SerializeField] private SceneReference[] _additiveScenes = null;

		public void Init()
		{
			foreach (var scene in _additiveScenes)
				SceneManager.LoadSceneAsync(scene.Value, LoadSceneMode.Additive);
		}
	}
}
