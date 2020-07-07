using UnityEngine;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class TaskGenerator : ScriptGenerationWindow
		{
			private enum TaskType
			{
				Action,
				Condition
			}

			[SerializeField] private TaskType _taskType = TaskType.Action;

			private const string ACTION_TEMPLATE = "Assets/[1]ToolBox/Core/Editor/Templates/ActionTemplate.cs.txt";
			private const string ACTION_FOLDER = "Assets/[0]Project/Scripts/Tasks/Actions";
			private const string CONDITION_TEMPLATE = "Assets/[1]ToolBox/Core/Editor/Templates/ConditionTemplate.cs.txt";
			private const string CONDITION_FOLDER = "Assets/[0]Project/Scripts/Tasks/Conditions";

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", _scriptName);
				return fileContent;
			}

			protected override void SetData()
			{
				bool isAction = _taskType == TaskType.Action;
				_template = isAction ? ACTION_TEMPLATE : CONDITION_TEMPLATE;
				_folder = isAction ? ACTION_FOLDER : CONDITION_FOLDER;
			}
		}
	}
}
