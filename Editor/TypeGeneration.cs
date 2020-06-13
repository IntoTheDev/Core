namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{		
		public class TypeGeneration : MultipleGeneration
		{
			protected override void SetData()
			{
				filesCount = 3;

				base.SetData();

				folders[0] = "Assets/ToolBox/Signals/Signals/Generics";
				templates[0] = "Assets/ToolBox/Main/Editor/Templates/SignalTemplate.cs.txt";
				names[0] = $"{fileName}Signal";

				folders[1] = "Assets/ToolBox/Signals/Receivers/Generics";
				templates[1] = "Assets/ToolBox/Main/Editor/Templates/ReceiverTemplate.cs.txt";
				names[1] = $"{fileName}Receiver";

				folders[2] = "Assets/ToolBox/Reactors/Generics";
				templates[2] = "Assets/ToolBox/Main/Editor/Templates/ReactorHelperTemplate.cs.txt";
				names[2] = $"{fileName}Helper";
			}
		}
	}
}
