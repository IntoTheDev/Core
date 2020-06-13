using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public abstract class ScriptGenerationWindow
		{
			[SerializeField] protected string scriptName = "Task";

			protected string template = "";
			protected string folder = "";

			protected abstract void SetData();
			protected abstract string ReplaceText(string path, string fileContent);

			protected string ReplaceContent(string path, string fileContent, string from, string to)
			{
				fileContent = fileContent.Replace(from, to);
				return fileContent;
			}

			[Button("Generate Script", ButtonSizes.Medium)]
			protected virtual void GenerateScript()
			{
				SetData();
				string path = GenerateFile(folder, scriptName, template);

				string fileContent = File.ReadAllText(path);
				fileContent = ReplaceText(path, fileContent);
				File.WriteAllText(path, fileContent);

				SelectFile(path);
			}

			protected string GenerateFile(string folder, string scriptName, string template)
			{
				string path = Path.Combine(folder, scriptName + ".cs");
				path = AssetDatabase.GenerateUniqueAssetPath(path);
				File.Copy(template, path);
				return path;
			}

			protected void SelectFile(string path)
			{
				AssetDatabase.Refresh();
				EditorUtility.FocusProjectWindow();
				UnityEngine.Object script = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
				Selection.activeObject = script;
				EditorGUIUtility.PingObject(script);
				AssetDatabase.OpenAsset(script);
			}
		}

	}
}
