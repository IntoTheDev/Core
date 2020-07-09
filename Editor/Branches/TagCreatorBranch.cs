using Sirenix.OdinInspector;
using System;
using ToolBox.Tags;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public class TagCreatorBranch : IBranch
	{
		private enum TagType
		{
			Default,
			Container
		}

		[SerializeField] private string _tagName = "Tag";
		[SerializeField, EnumToggleButtons] private TagType _tagType = TagType.Default;
		[SerializeField, FolderPath, OnValueChanged(nameof(OnPathChange))] private string _tagPath = "";
		[SerializeField, FolderPath, OnValueChanged(nameof(OnPathChange))] private string _tagContainerPath = "";

		private const string TAG_SAVE_KEY = "TagPath";
		private const string CONTAINER_SAVE_KEY = "ContainerPath";

		public string Path => "ToolBox/Tag Creator";

		public void Setup()
		{
			_tagPath = EditorPrefs.GetString(TAG_SAVE_KEY, "");
			_tagContainerPath = EditorPrefs.GetString(CONTAINER_SAVE_KEY, "");
		}

		[Button(ButtonSizes.Medium)]
		private void CreateTag()
		{
			Type type;
			string pathToSave;

			if (_tagType == TagType.Default)
			{
				type = typeof(Tag);
				pathToSave = _tagPath;
			}
			else
			{
				type = typeof(TagsContainer);
				pathToSave = _tagContainerPath;
			}

			var tag = ScriptableObject.CreateInstance(type);
			tag.name = _tagName;
			string path = $"{pathToSave}/{_tagName}.asset";
			path = AssetDatabase.GenerateUniqueAssetPath(path);
			AssetDatabase.CreateAsset(tag, path);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = tag;
		}

		private void OnPathChange()
		{
			EditorPrefs.SetString(TAG_SAVE_KEY, _tagPath);
			EditorPrefs.SetString(CONTAINER_SAVE_KEY, _tagContainerPath);
		}
	}
}
