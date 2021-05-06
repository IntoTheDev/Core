namespace ToolBox.Runtime.Utilities
{
	public abstract class BaseStopwatch
	{
		private readonly float _duration = 0f;
		private float _timestamp = 0f;

		protected abstract float Time { get; }

		public bool IsEllapsed => Time - _timestamp > _duration;

		public void Reset() =>
			_timestamp = Time;

		public BaseStopwatch(float duration) =>
			_duration = duration;
	}
}