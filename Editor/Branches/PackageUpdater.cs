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

		private static RemoveRequest _removeRequest = null;
		private static AddRequest _addRequest = null;
		private static bool _isLoading = false;
		private static string _url = string.Empty;

		public string Path => "ToolBox/Package Updater";

		public void Setup(OdinMenuTree tree) =>
			_packages = AssetUtilities.GetAllAssetsOfType<Package>().ToArray();

		public static void Update(string url)
		{
			if (!_isLoading)
			{
				_isLoading = true;
				_url = url;
				_removeRequest = Client.Remove(_url);
				EditorApplication.update += LoadPackage;
			}
		}

		private static void LoadPackage()
		{
			if (_removeRequest.IsCompleted)
			{
				if (_addRequest == null)
					_addRequest = Client.Add(_url);

				if (_addRequest.IsCompleted)
				{
					if (_addRequest.Status == StatusCode.Success)
						Debug.Log("Installed: " + _addRequest.Result.packageId);
					else if (_addRequest.Status >= StatusCode.Failure)
						Debug.Log(_addRequest.Error.message);

					EditorApplication.update -= LoadPackage;
					_addRequest = null;
					_isLoading = false;
				}
			}
		}
	}
}
#endif
