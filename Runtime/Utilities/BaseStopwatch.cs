namespace ToolBox.Runtime.Utilities
{
	public abstract class BaseStopwatch
	{
		private readonly float _duration = 0f;
		private float _timestamp = 0f;
		private bool _isElapsed = false;

		protected abstract float Time { get; }

		public bool IsElapsed 
		{
			get
			{
				// Preventing from using UnityEngine.Time which is quiet expensive performance wise
				if (_isElapsed)
					return true;

				_isElapsed = Time - _timestamp > _duration;

				return _isElapsed;
			}
		}

		public void Reset()
		{
			_timestamp = Time;
			_isElapsed = false;
		}

		protected BaseStopwatch(float duration) =>
			_duration = duration;
	}
}
