using ToolBox.Loader;
using ToolBox.Runtime.Attributes;
using ToolBox.Runtime.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToolBox.Runtime.App
{
	[ShowInMenu]
	public class AppConfig : ScriptableObject, ILoadable
	{
		[SerializeField] private SceneReference[] _additiveScenes = new SceneReference[0];

		public void Init()
		{
			foreach (var scene in _additiveScenes)
				SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Additive);
		}
	}
}
