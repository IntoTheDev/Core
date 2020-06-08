﻿using Sirenix.OdinInspector;
using ToolBox.Pools;
using UnityEngine;

namespace ToolBox.Test
{
	public class ToolBoxTest : SerializedMonoBehaviour
	{
		[SerializeField] private Pool pool = null;

		private void Awake()
		{
			pool.Fill();
		}
	}
}
