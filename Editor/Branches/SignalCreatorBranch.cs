using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Signals;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public class SignalCreatorBranch : IBranch
	{
		[SerializeField] private string _signalName = "Signal";
		[ShowInInspector, ValueDropdown(nameof(GetTypes))] private Type _signalType = null;
		[SerializeField, FolderPath, OnValueChanged(nameof(OnPathChange))] private string _path = "";

		private const string SAVE_KEY = "SignalPath";

		public string Path => "ToolBox/Signal Creator";

		public void Setup() =>
			_path = EditorPrefs.GetString(SAVE_KEY, "");

		[Button(ButtonSizes.Medium)]
		private void CreateSignal()
		{
			var signal = ScriptableObject.CreateInstance(_signalType);
			signal.name = _signalName;
			string path = $"{_path}/{_signalName}.asset";
			path = AssetDatabase.GenerateUniqueAssetPath(path);
			AssetDatabase.CreateAsset(signal, path);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = signal;
		}

		private IEnumerable<Type> GetTypes()
		{
			IEnumerable<Type> types = AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes)
				.Where(x => x.IsClass && x.InheritsFrom<BaseSignal>() && !x.IsAbstract);

			return types;
		}

		private void OnPathChange() =>
			EditorPrefs.SetString(SAVE_KEY, _path);
	}
}
