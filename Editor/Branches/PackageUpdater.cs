#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Linq;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace ToolBox.Editor.Branches
{
	public sealed class PackageUpdater : IBranch
	{
		[ShowInInspector, ListDrawerSettings(Expanded = true, IsReadOnly = true)] private Package[] _packages = null;

		private static AddRequest _request = null;

		public string Path => "ToolBox/Package Updater";

		public void Setup(OdinMenuTree tree) =>
			_packages = AssetUtilities.GetAllAssetsOfType<Package>().ToArray();

		public static void Update(string url)
		{
			if (_request == null)
			{
				_request = Client.Add(url);
				EditorApplication.update += LoadPackage;
			}
		}

		private static void LoadPackage()
		{
			if (_request.IsCompleted)
			{
				if (_request.Status == StatusCode.Success)
					Debug.Log("Installed: " + _request.Result.packageId);
				else if (_request.Status >= StatusCode.Failure)
					Debug.Log(_request.Error.message);

				EditorApplication.update -= LoadPackage;
				_request = null;
			}
		}
	}
}
#endif