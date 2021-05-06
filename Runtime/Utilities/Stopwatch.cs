namespace ToolBox.Runtime.Utilities
{
	public sealed class Stopwatch : BaseStopwatch
	{
		protected override float Time => UnityEngine.Time.time;

		public Stopwatch(float duration) : base(duration) { }
	}
}
