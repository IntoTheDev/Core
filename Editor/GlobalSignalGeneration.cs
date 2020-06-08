namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{		
		public class GlobalSignalGeneration : MultipleGeneration
		{
			protected override void SetData()
			{
				filesCount = 3;

				base.SetData();

				folders[0] = "Assets/ToolBox/Observer Pattern/Global Signals";
				templates[0] = "Assets/ToolBox/Main/Editor/Templates/GlobalSignalTemplate.cs.txt";
				names[0] = $"{fileName}GlobalSignal";

				folders[1] = "Assets/ToolBox/Observer Pattern/Receivers";
				templates[1] = "Assets/ToolBox/Main/Editor/Templates/ReceiverTemplate.cs.txt";
				names[1] = $"{fileName}Receiver";

				folders[2] = "Assets/ToolBox/Modules System/Modules/Observer";
				templates[2] = "Assets/ToolBox/Main/Editor/Templates/GlobalSignalModuleTemplate.cs.txt";
				names[2] = $"{fileName}GlobalSignalDispatcher";
			}
		}
	}
}
