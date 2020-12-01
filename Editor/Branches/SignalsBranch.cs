using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System;
using System.Collections.Generic;
using ToolBox.Signals;
using UnityEngine;

namespace ToolBox.Editor
{
	public class SignalsBranch : IBranch
	{
		[ShowInInspector, TabGroup("Signals"), Searchable] private IReadOnlyDictionary<string, List<IReceiver>> _signals = null;
		[ShowInInspector, TextArea(1, 999), TabGroup("Logs"), HideLabel] private string _logs = "";

		public string Path => "ToolBox/Signals";

		public void Setup(OdinMenuTree tree)
		{
			_signals = Hub.ReadableSignals;
			Hub.OnSignalDispatched += Append;
		}

		public void Append(string signal, string info)
		{
			var date = DateTime.Now;
			var time = $"Time: {date.Hour}:{date.Minute}:{date.Second}";
			var newLine = Environment.NewLine;
			var finalString = "Signal: " + signal + newLine + time + newLine + "Info: " + info + newLine + newLine;

			_logs = string.IsNullOrEmpty(_logs) ? finalString : _logs.Replace(_logs, finalString + _logs);
		}
	}
}
