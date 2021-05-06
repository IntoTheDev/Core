namespace ToolBox.Runtime.Utilities
{
	public sealed class FixedStopwatch : BaseStopwatch
	{
		protected override float Time => UnityEngine.Time.fixedTime;

		public FixedStopwatch(float duration) : base(duration) { }
	}
}

