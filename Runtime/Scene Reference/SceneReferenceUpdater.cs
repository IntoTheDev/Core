using ToolBox.Loader;
#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
#endif

#if UNITY_EDITOR
public class SceneReferenceUpdater : IPreprocessBuildWithReport
{
	public int callbackOrder => 0;

	public void OnPreprocessBuild(BuildReport report)
	{
		var references = Storage.GetAll<SceneReference>();

		foreach (var reference in references)
			reference.Init();
	}
}
#endif
