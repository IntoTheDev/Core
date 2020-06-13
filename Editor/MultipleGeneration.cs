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
			protected string[] folders = null;
			protected string[] templates = null;
			protected string[] names = null;

			protected int filesCount = 3;
			protected string fileName = "";

			protected override void SetData()
			{
				folders = new string[filesCount];
				templates = new string[filesCount];
				names = new string[filesCount];

				fileName = scriptName.MakeFirstLetterUppercase();
				fileName = fileName.Replace("[]", "Array");
			}

			[Button("Generate Type", ButtonSizes.Medium)]
			protected override void GenerateScript()
			{
				SetData();
				string[] paths = new string[filesCount];

				for (int i = 0; i < filesCount; i++)
					paths[i] = InternalGenerateScript(i);

				SelectFile(paths[0]);

				string InternalGenerateScript(int index)
				{
					string path = GenerateFile(folders[index], names[index], templates[index]);

					string fileContent = File.ReadAllText(path);
					fileContent = ReplaceText(path, fileContent);
					File.WriteAllText(path, fileContent);

					return path;
				}
			}

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", scriptName);
				fileContent = ReplaceContent(path, fileContent, "#FILENAME#", fileName);
				return fileContent;
			}
		}		

	}
}
