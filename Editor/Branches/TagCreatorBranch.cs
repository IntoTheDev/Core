using ToolBox.Tags;

namespace ToolBox.Editor
{
	public class TagCreatorBranch : ScriptableObjectCreator<Tag>, IBranch
	{
		public string Path => "ToolBox/Creators/Tag Creator";
	}
}
