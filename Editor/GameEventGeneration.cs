namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{		
		public class GameEventGeneration : MultipleGeneration
		{
			protected override void SetData()
			{
				filesCount = 3;

				base.SetData();

				folders[0] = "Assets/ToolBox/Observer Pattern/Game Events";
				templates[0] = "Assets/ToolBox/Main/Editor/Templates/GameEventTemplate.cs.txt";
				names[0] = $"{fileName}GameEvent";

				folders[1] = "Assets/ToolBox/Observer Pattern/Listeners";
				templates[1] = "Assets/ToolBox/Main/Editor/Templates/GameEventListenerTemplate.cs.txt";
				names[1] = $"{fileName}GameEventListener";

				folders[2] = "Assets/ToolBox/Modules System/Modules/Observer";
				templates[2] = "Assets/ToolBox/Main/Editor/Templates/GameEventModuleTemplate.cs.txt";
				names[2] = $"{fileName}GameEventInvoker";
			}
		}
	}
}
