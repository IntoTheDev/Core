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
		public class ReactorGeneration : ScriptGenerationWindow
		{
			[SerializeField, ValueDropdown(nameof(GetInterfaces))] private string _interfaceToInherit = null;
			[SerializeField] private string _parameterName = null;

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

				_template = _interfaceToInherit == "IReactor" 
					? "Assets/[1]ToolBox/Main/Editor/Templates/ReactorTemplate.cs.txt" 
					: "Assets/[1]ToolBox/Main/Editor/Templates/GenericReactorTemplate.cs.txt";
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

				for (int i = interfaces.Count - 1; i >= 0; i--)
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
