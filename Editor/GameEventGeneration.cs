using Sirenix.OdinInspector;
using System.IO;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class GameEventGeneration : ScriptGenerationWindow
		{
			private string[] folders = null;
			private string[] templates = null;
			private string[] names = null;

			private const int filesCount = 3;

			protected override void SetData()
			{
				folders = new string[filesCount];
				templates = new string[filesCount];
				names = new string[filesCount];

				folders[0] = "Assets/ToolBox/Observer Pattern/Game Events";
				templates[0] = "Assets/ToolBox/Main/Editor/Templates/GameEventTemplate.cs.txt";
				names[0] = $"{scriptName}GameEvent";

				folders[1] = "Assets/ToolBox/Observer Pattern/Listeners";
				templates[1] = "Assets/ToolBox/Main/Editor/Templates/GameEventListenerTemplate.cs.txt";
				names[1] = $"{scriptName}GameEventListener";

				folders[2] = "Assets/ToolBox/Observer Pattern/UnityEvents";
				templates[2] = "Assets/ToolBox/Main/Editor/Templates/UnityEventTemplate.cs.txt";
				names[2] = $"{scriptName}UnityEvent";
			}

			[Button("Generate Game Event", ButtonSizes.Medium)]
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
				return fileContent;
			}
		}

	}
}
