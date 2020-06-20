namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{		
		public class TypeGenerator : MultipleGeneration
		{
			protected override void SetData()
			{
				_filesCount = 3;

				base.SetData();

				_folders[0] = "Assets/[1]ToolBox/Signals/Signals/Generics";
				_templates[0] = "Assets/[1]ToolBox/Main/Editor/Templates/SignalTemplate.cs.txt";
				_names[0] = $"{_fileName}Signal";

				_folders[1] = "Assets/[1]ToolBox/Signals/Receivers/Generics";
				_templates[1] = "Assets/[1]ToolBox/Main/Editor/Templates/ReceiverTemplate.cs.txt";
				_names[1] = $"{_fileName}Receiver";

				_folders[2] = "Assets/[1]ToolBox/Reactors/Generics";
				_templates[2] = "Assets/[1]ToolBox/Main/Editor/Templates/ReactorHelperTemplate.cs.txt";
				_names[2] = $"{_fileName}Helper";
			}
		}
	}
}
