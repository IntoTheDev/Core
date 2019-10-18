using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public class ToolBoxEditor : MonoBehaviour
	{
		protected static void CreateAsset(string path, string newPath)
		{
			newPath = AssetDatabase.GenerateUniqueAssetPath(newPath);

			AssetDatabase.CopyAsset(path, newPath);

			EditorUtility.FocusProjectWindow();
			Object asset = AssetDatabase.LoadAssetAtPath(newPath, typeof(MonoScript));
			Selection.activeObject = asset;
		}
	}
}

