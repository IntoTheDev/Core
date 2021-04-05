#if ODIN_INSPECTOR
using Sirenix.OdinInspector.Editor;

namespace ToolBox.Editor.Branches
{
	public interface IBranch
	{
		string Path { get; }

		void Setup(OdinMenuTree tree);
	}
}
#endif