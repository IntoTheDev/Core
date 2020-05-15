using Sirenix.OdinInspector;
using Sirenix.Serialization;
using ToolBox.Modules;
using ToolBox.Serialization;
using UnityEngine;

namespace ToolBox.Test
{
	public class ToolBoxTest : SerializedMonoBehaviour
	{
		[OdinSerialize] private ModulesContainer modulesContainer = default;

		private void Awake()
		{
			DataSerializer.CreateFile(0, false);
			DataSerializer.LoadFile();
		}
	}
}
