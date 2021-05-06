namespace ToolBox.Runtime.Utilities
{
	public abstract class BaseStopwatch
	{
		private readonly float _duration = 0f;
		private float _timestamp = 0f;
		private bool _isEllapsed = false;

		protected abstract float Time { get; }

		public bool IsEllapsed 
		{
			get
			{
				// Preventing from using UnityEngine.Time which is quiet expensive performance wise
				if (_isEllapsed)
					return true;

				_isEllapsed = Time - _timestamp > _duration;

				return _isEllapsed;
			}
		}
		
		public BaseStopwatch(float duration) =>
			_duration = duration;

		public void Start()
		{
			_timestamp = Time;
			_isEllapsed = false;
		}
	}
}
