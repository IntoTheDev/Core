using MEC;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ToolBox.Test
{
	public class ToolBoxTest : SerializedMonoBehaviour
	{
		[SerializeField, PageList] private List<int> numbers = null;
	}
}