#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor.Branches
{
	public class ScriptableObjectCreator : IBranch
	{
		[ShowInInspector, ValueDropdown(nameof(GetAssetTypes)), OnValueChanged(nameof(OnTypeChanged))] private Type _assetType = null;
		[SerializeField] private string _assetName = "Asset";
		[SerializeField, FolderPath(RequireExistingPath = true), OnValueChanged(nameof(OnPathChange))] private string _path = "";
		[ShowInInspector, InlineEditor(Expanded = true), ShowIf(nameof(_assetType))] private ScriptableObject _asset = null;

		private string _saveKey = "";

		public string Path => "ToolBox/Scriptable Object Creator";

		public virtual void Setup(OdinMenuTree tree) { }

		private IEnumerable<Type> GetAssetTypes() =>
			AssemblyUtilities.GetTypes(AssemblyTypeFlags.UserTypes)
				.Where(x => x.InheritsFrom<ScriptableObject>() && !x.IsAbstract);

		[Button(ButtonSizes.Medium)]
		private void CreateAsset()
		{
			if (_assetType == null)
				return;

			_asset.name = _assetName;
			string path = AssetDatabase.GenerateUniqueAssetPath($"{_path}/{_assetName}.asset");

			AssetDatabase.CreateAsset(_asset, path);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = _asset;
		}

		private void OnTypeChanged()
		{
			if (_asset != null)
				UnityEngine.Object.DestroyImmediate(_asset);

			_asset = ScriptableObject.CreateInstance(_assetType);
			_saveKey = $"AssetCreator{_assetType.Name}";
			_path = EditorPrefs.GetString(_saveKey, "");
		}

		private void OnPathChange() =>
			EditorPrefs.SetString(_saveKey, _path);
	}
}
#endif