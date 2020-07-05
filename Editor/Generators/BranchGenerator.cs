using Sirenix.OdinInspector;
using System.IO;
using UnityEngine;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class BranchGenerator : ScriptGenerationWindow
		{
			[SerializeField] private string _path = "Branches";

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", _scriptName);
				fileContent = ReplaceContent(path, fileContent, "#PATH#", _path);

				return fileContent;
			}

			protected override void SetData()
			{
				_template = "Assets/[1]ToolBox/Core/Editor/Templates/BranchTemplate.cs.txt";
				_folder = "Assets/[1]ToolBox/Core/Editor/Branches";
			}

			[Button("Generate Branch", ButtonSizes.Medium)]
			protected override void GenerateScript()
			{
				SetData();

				string path = GenerateFile(_folder, $"{_scriptName}Branch", _template);

				string fileContent = File.ReadAllText(path);
				fileContent = ReplaceText(path, fileContent);
				File.WriteAllText(path, fileContent);

				SelectFile(path);
			}
		}
	}
}
