using Sirenix.OdinInspector;
using System.Collections.Generic;
using ToolBox.Serialization;
using ToolBox.Extensions;
using UnityEngine;
using Sirenix.Serialization;
using ToolBox.Observer;
using System.Diagnostics;
using UnityEngine.Events;
using UnityEngine.Profiling;
using ToolBox.Pools;
using System;
using MEC;
using PlayFab;
using PlayFab.ClientModels;
using System.Security.Cryptography;

namespace ToolBox.Test
{
	public class ToolBoxTest : SerializedMonoBehaviour
	{
		private void Awake()
		{
			DataSerializer.CreateFile(0, false);
			DataSerializer.LoadFile();
		}
	}
}
