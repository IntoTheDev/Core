using Sirenix.OdinInspector;
using System.IO;
using ToolBox.Extensions;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class SharedDataGeneration : MultipleGeneration
		{
			protected override void SetData()
			{
				filesCount = 4;

				base.SetData();

				folders[0] = "Assets/ToolBox/Behaviour System/Shared Data";
				templates[0] = "Assets/ToolBox/Main/Editor/Templates/SharedTemplate.cs.txt";
				names[0] = $"Shared{fileName}";

				folders[1] = "Assets/ToolBox/Behaviour System/Context Keys";
				templates[1] = "Assets/ToolBox/Main/Editor/Templates/ContextTemplateKey.cs.txt";
				names[1] = $"Context{fileName}Key";

				folders[2] = "Assets/ToolBox/Behaviour System/Actions/Shared Data/Actions";
				templates[2] = "Assets/ToolBox/Main/Editor/Templates/SetSharedTemplate.cs.txt";
				names[2] = $"SetShared{fileName}";

				folders[3] = "Assets/ToolBox/Behaviour System/Conditions/Shared Data/Conditions";
				templates[3] = "Assets/ToolBox/Main/Editor/Templates/CompareSharedTemplate.cs.txt";
				names[3] = $"CompareShared{fileName}";
			}

			[Button("Generate Shared Data", ButtonSizes.Medium)]
			protected override void GenerateScript() =>
				base.GenerateScript();

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#FILENAME#", fileName);
				fileContent = ReplaceContent(path, fileContent, "#TYPENAME#", scriptName);

				return fileContent;
			}
		}
	}
}
