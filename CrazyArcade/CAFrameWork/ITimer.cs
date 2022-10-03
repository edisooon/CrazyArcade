using System;
namespace CrazyArcade.CAFramework
{
	public interface ITimer
	{
        public int TotalMili { get; }
        public TimeSpan Previous { get; }
		public TimeSpan FrameDiff { get; }
        public void Update(TimeSpan time);
	}
}

