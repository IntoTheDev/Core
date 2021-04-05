#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using ToolBox.Loader;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName = "ToolBox/Scene Reference")]
#if ODIN_INSPECTOR
[Required, AssetSelector]
#endif
public class SceneReference : ScriptableObject, ILoadable
{
#if UNITY_EDITOR
#if ODIN_INSPECTOR
	[Required, AssetSelector]
#endif
	[SerializeField] private SceneAsset _scene = null;
#endif

	[SerializeField, HideInInspector] private string _name = string.Empty;

	public string Value
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

#if UNITY_EDITOR
	public void Init() =>
		_name = _scene.name;
#endif
}
