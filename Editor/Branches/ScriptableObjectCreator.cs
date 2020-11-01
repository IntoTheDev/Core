using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public abstract class ScriptableObjectCreator<T> where T : ScriptableObject
	{
		[SerializeField] private string _assetName = "Asset";
		[SerializeField, FolderPath, OnValueChanged(nameof(OnPathChange))] private string _path = "";

		private string _saveKey = "";

		public virtual void Setup(OdinMenuTree tree)
		{
			_saveKey = $"Creator{GetType()}";
			_path = EditorPrefs.GetString(_saveKey, "");
		}

		[Button(ButtonSizes.Medium)]
		private void CreatePool()
		{
			var asset = ScriptableObject.CreateInstance<T>();
			asset.name = _assetName;
			string path = $"{_path}/{_assetName}.asset";
			path = AssetDatabase.GenerateUniqueAssetPath(path);
			AssetDatabase.CreateAsset(asset, path);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		private void OnPathChange() =>
			EditorPrefs.SetString(_saveKey, _path);
	}
}
