#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using ToolBox.Loader;
using ToolBox.Runtime.Attributes;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ToolBox.Runtime.Utilities
{
	[CreateAssetMenu(menuName = "ToolBox/Scene Reference")]
#if ODIN_INSPECTOR
[Required, AssetSelector, ShowInMenu]
#endif
	public sealed class SceneReference : ScriptableObject, ILoadable, IInitializableBeforeBuild
	{
#if ODIN_INSPECTOR
	[Required, AssetSelector]
#endif
#if UNITY_EDITOR
		[SerializeField] private SceneAsset _scene = null;
#endif

		[SerializeField, HideInInspector] private string _name = string.Empty;

		public string Name
		{
			get
			{
#if UNITY_EDITOR
				return _scene.name;
#else
			return _name;
#endif
			}
		}

		public void Init()
		{
#if UNITY_EDITOR
			_name = _scene.name;
#endif
		}
	}
}
