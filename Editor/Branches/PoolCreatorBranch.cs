using Sirenix.OdinInspector.Editor;
using ToolBox.Pools;

namespace ToolBox.Editor
{
	public class PoolCreatorBranch : ScriptableObjectCreator<Pool>, IBranch
	{
		public string Path => "ToolBox/Creators/Pool Creator";
	}
}
