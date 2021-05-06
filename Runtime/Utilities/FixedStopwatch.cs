namespace ToolBox.Runtime.Utilities
{
	public class FixedStopwatch : BaseStopwatch
	{
		protected override float Time => UnityEngine.Time.fixedTime;

		public FixedStopwatch(float duration) : base(duration) { }
	}
}

