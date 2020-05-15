using Sirenix.OdinInspector;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class ReactorGeneration : ScriptGenerationWindow
		{
			[Button("Generate Reactor", ButtonSizes.Medium)]
			protected override void GenerateScript() =>
				base.GenerateScript();

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", scriptName);
				return fileContent;
			}

			protected override void SetData()
			{
				template = "Assets/ToolBox/Main/Editor/Templates/ReactorTemplate.cs.txt";
				folder = "Assets/ToolBox/React/Reactors/";
			}
		}
	}
}
