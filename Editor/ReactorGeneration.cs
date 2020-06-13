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
			[SerializeField, ValueDropdown(nameof(GetInterfaces))] private string interfaceToInherit = null;
			[SerializeField] private string parameterName = null;

			protected override string ReplaceText(string path, string fileContent)
			{
				fileContent = ReplaceContent(path, fileContent, "#SCRIPTNAME#", scriptName);
				fileContent = ReplaceContent(path, fileContent, "#REACTOR#", interfaceToInherit);

				if (parameterName == string.Empty || parameterName == null)
					parameterName = "value";

				fileContent = ReplaceContent(path, fileContent, "#PARAMETER#", parameterName);

				string type = interfaceToInherit.Remove(0, 1);
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
				if (interfaceToInherit == null)
					interfaceToInherit = "IReactor";

				template = interfaceToInherit == "IReactor" 
					? "Assets/ToolBox/Main/Editor/Templates/ReactorTemplate.cs.txt" 
					: "Assets/ToolBox/Main/Editor/Templates/GenericReactorTemplate.cs.txt";
				folder = "Assets/ToolBox/Reactors/Generated";
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
