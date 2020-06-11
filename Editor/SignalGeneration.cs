namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{		
		public class SignalGeneration : MultipleGeneration
		{
			protected override void SetData()
			{
				filesCount = 4;

				base.SetData();

				folders[0] = "Assets/ToolBox/Signals/Global/Global Signals";
				templates[0] = "Assets/ToolBox/Main/Editor/Templates/GlobalSignalTemplate.cs.txt";
				names[0] = $"{fileName}GlobalSignal";

				folders[1] = "Assets/ToolBox/Signals/Global/Receivers";
				templates[1] = "Assets/ToolBox/Main/Editor/Templates/ReceiverTemplate.cs.txt";
				names[1] = $"{fileName}Receiver";

				folders[2] = "Assets/ToolBox/Signals/Local/Receivers";
				templates[2] = "Assets/ToolBox/Main/Editor/Templates/GlobalSignalDispatcherTemplate.cs.txt";
				names[2] = $"{fileName}GlobalSignalDispatcher";

				folders[3] = "Assets/ToolBox/Signals/Local/Generics";
				templates[3] = "Assets/ToolBox/Main/Editor/Templates/LocalSignalTemplate.cs.txt";
				names[3] = $"{fileName}LocalSignal";
			}
		}
	}
}
