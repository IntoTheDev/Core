using Sirenix.OdinInspector;
using System.Diagnostics;
using System.IO;
using ToolBox.Extensions;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public abstract class MultipleGeneration : ScriptGenerationWindow
		{
			protected string[] _folders = null;
			protected string[] _templates = null;
			protected string[] _names = null;

			protected int _filesCount = 3;
			protected string _fileName = "";

			protected override void SetData()
			{
				_folders = new string[_filesCount];
				_templates = new string[_filesCount];
				_names = new string[_filesCount];

				_fileName = _scriptName.MakeFirstLetterUppercase();
				_fileName = _fileName.Replace("[]", "Array");
			}

			[Button("Generate Type", ButtonSizes.Medium)]
			protected override void GenerateScript()
			{
				SetData();
				string[] paths = new string[_filesCount];

				for (int i = 0; i < _filesCount; i++)
					paths[i] = InternalGenerateScript(i);

				SelectFile(paths[0]);

				string InternalGenerateScript(int index)
				{
					string path = GenerateFile(_folders[index], _names[index], _templates[index]);

					string fileContent = File.ReadAllText(path);
					fileContent = ReplaceText(path, fileContent);
					File.WriteAllText(path, fileContent);

					return path;
				}
			}

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", _scriptName);
				fileContent = ReplaceContent(path, fileContent, "#FILENAME#", _fileName);
				
				return fileContent;
			}
		}		

	}
}
