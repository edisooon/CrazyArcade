using System;
namespace CrazyArcade.CAFramework
{
	public class CATimer: ITimer
	{
		public CATimer(TimeSpan start)
		{
            previous = start;
            totalMili = 0;
		}
        private int totalMili;
        public int TotalMili => totalMili;
        public TimeSpan previous;
        public TimeSpan Previous => previous;

        public TimeSpan frameDiff;
        public TimeSpan FrameDiff => frameDiff;

        public void Update(TimeSpan time)
        {
            frameDiff = time.Subtract(previous);
            totalMili += frameDiff.Milliseconds;
            previous = time;
        }
    }
}

