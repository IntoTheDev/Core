namespace ToolBox.Runtime.Utilities
{
	public class Stopwatch : BaseStopwatch
	{
		protected override float Time => UnityEngine.Time.time;

		public Stopwatch(float duration) : base(duration) { }
	}
}
