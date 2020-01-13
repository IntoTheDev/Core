using Sirenix.OdinInspector;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class ConditionGeneration : ScriptGenerationWindow
		{
			[Button("Generate Condition", ButtonSizes.Medium)]
			protected override void GenerateScript() =>
				base.GenerateScript();

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", scriptName);
				return fileContent;
			}

			protected override void SetData()
			{
				template = "Assets/ToolBox/Main/Editor/Templates/ConditionTemplate.cs.txt";
				folder = "Assets/ToolBox/Behaviour System/Conditions";
			}
		}
	}
}
