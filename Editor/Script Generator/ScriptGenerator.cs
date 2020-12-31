using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public class ScriptGenerator : IBranch
	{
		[ShowInInspector, FolderPath, OnValueChanged(nameof(OnTemplatesPathChanged))] private string _templatesPath = null;
		[ShowInInspector, ShowIf(nameof(_templatesPath)), ValueDropdown(nameof(GetTemplates)), OnValueChanged(nameof(OnTemplateChanged))] private TextAsset _template = null;
		[ShowInInspector, ShowIf(nameof(_template))] private string _name = null;
		[ShowInInspector, FolderPath, OnValueChanged(nameof(OnSavePathChanged)), ShowIf(nameof(_template))] private string _savePath = null;

		public string Path => "ToolBox/Script Generator";

		private const string TEMPLATES_PATH_KEY = "TemplatesPath";

		public void Setup(OdinMenuTree tree) =>
			_templatesPath = EditorPrefs.GetString(TEMPLATES_PATH_KEY, null);

		[Button(ButtonSizes.Medium)]
		private void CreateScript()
		{
			var filePath = AssetDatabase.GenerateUniqueAssetPath(System.IO.Path.Combine(_savePath, _name + ".cs"));
			File.Copy(AssetDatabase.GetAssetPath(_template), filePath);
			var content = File.ReadAllText(filePath);
			content = content.Replace("#NAME#", _name);
			File.WriteAllText(filePath, content);

			AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
			var script = AssetDatabase.LoadAssetAtPath<Object>(filePath);
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = script;
			AssetDatabase.OpenAsset(script);
		}

		private void OnTemplatesPathChanged() =>
			EditorPrefs.SetString(TEMPLATES_PATH_KEY, _templatesPath);

		private void OnTemplateChanged() =>
			_savePath = EditorPrefs.GetString($"{_template.name}save_path", null);

		private void OnSavePathChanged() =>
			EditorPrefs.SetString($"{_template.name}save_path", _savePath);

		private IEnumerable GetTemplates()
		{
			var assets = AssetDatabase.FindAssets("t:TextAsset", new[] { _templatesPath });
			var templates = new List<ValueDropdownItem>();

			foreach (var asset in assets)
			{
				var path = AssetDatabase.GUIDToAssetPath(asset);
				var template = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
				var item = new ValueDropdownItem
				{
					Text = template.name,
					Value = template
				};

				templates.Add(item);
			}

			return templates;
		}
	}
}
