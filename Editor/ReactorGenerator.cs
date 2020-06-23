using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using ToolBox.Reactors;
using UnityEngine;

namespace ToolBox.Editor
{
	public partial class ToolBoxMenu
	{
		public class ReactorGenerator : ScriptGenerationWindow
		{
			[SerializeField, ValueDropdown(nameof(GetInterfaces))] private string _interfaceToInherit = null;
			[SerializeField] private bool _isSetupable = false;
			[SerializeField, ShowIf("@this._interfaceToInherit != this._defaultReactor && this._interfaceToInherit != null")] private string _parameterName = null;

			private const string DEFAULT_REACTOR = "Assets/[1]ToolBox/Core/Editor/Templates/ReactorTemplate.cs.txt";
			private const string SETUPABLE_REACTOR = "Assets/[1]ToolBox/Core/Editor/Templates/SetupableReactorTemplate.cs.txt";
			private const string GENERIC_DEFAULT_REACTOR = "Assets/[1]ToolBox/Core/Editor/Templates/GenericReactorTemplate.cs.txt";
			private const string GENERIC_SETUPABLE_REACTOR = "Assets/[1]ToolBox/Core/Editor/Templates/SetupableGenericReactorTemplate.cs.txt";

			private string _defaultReactor = "IReactor";

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", _scriptName);
				fileContent = ReplaceContent(path, fileContent, "#REACTOR#", _interfaceToInherit);

				if (_parameterName == string.Empty || _parameterName == null)
					_parameterName = "value";

				fileContent = ReplaceContent(path, fileContent, "#PARAMETER#", _parameterName);

				string type = _interfaceToInherit.Remove(0, 1);
				type = type.Replace("Reactor", "");

				switch (type)
				{
					case "Int":
						type = "int";
						break;

					case "Float":
						type = "float";
						break;

					case "String":
						type = "string";
						break;

					case "Bool":
						type = "bool";
						break;
				}

				type = type.Replace("Array", "[]");

				fileContent = ReplaceContent(path, fileContent, "#TYPE#", type);
				return fileContent;
			}

			protected override void SetData()
			{
				if (_interfaceToInherit == null)
					_interfaceToInherit = "IReactor";

				if (_isSetupable)
				{
					_template = _interfaceToInherit == "IReactor"
						? SETUPABLE_REACTOR
						: GENERIC_SETUPABLE_REACTOR;
				}
				else
				{
					_template = _interfaceToInherit == "IReactor"
						? DEFAULT_REACTOR
						: GENERIC_DEFAULT_REACTOR;
				}

				_folder = "Assets/[1]ToolBox/Reactors/Generated";
			}

			private IEnumerable<string> GetInterfaces()
			{
				Type type = typeof(IBaseReactor);

				IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p));

				List<string> interfaces = new List<string>();

				foreach (Type interfaceImplementation in types)
				{
					if (interfaceImplementation.IsInterface)
						interfaces.Add(interfaceImplementation.Name);
				}

				int count = interfaces.Count;

				for (int i = count - 1; i >= 0; i--)
				{
					string item = interfaces[i];

					if (item == "IBaseReactor" || item == "IReactor`1")
						interfaces.Remove(item);
				}

				return interfaces;
			}
		}
	}
}
