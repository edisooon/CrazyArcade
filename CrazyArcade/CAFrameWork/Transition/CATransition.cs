using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyArcade.CAFrameWork.Transition
{
	public class CATransition: ITransition
	{
        private ISceneState oldState;
        private ISceneState newState;
        private Vector2 sceneShiftPixelSpeed;
        private TimeSpan previousTimeFrame;
        private TimeSpan totalTime;
        private TimeSpan countTime;
        public CATransition(ISceneState oldState, ISceneState newState, Vector2 sceneShiftPixel, GameTime start, TimeSpan totalTime)
		{
            this.previousTimeFrame = start.TotalGameTime;
            this.totalTime = totalTime;
            this.sceneShiftPixelSpeed = sceneShiftPixel/((float)(totalTime.TotalMilliseconds));
            this.oldState = oldState;
            this.newState = newState;
		}
        private ITransitionCompleteHandler handler;

        public ITransitionCompleteHandler Handler { get => handler; set => handler = value; }
        bool completed = false;
        public void Update(GameTime time)
        {
            if (completed)
            {
                Console.WriteLine("Completed");
                return;
            }
            if (countTime > totalTime)
            {
                Console.WriteLine("Complete transition");
                if (handler != null)
                {
                    Handler.Complete(oldState, newState);
                }
                oldState.EndAfterTransition();
                newState.LoadAfterTransition();
                completed = true;
                return;
            }
            Console.WriteLine("update transition");
            TimeSpan current = time.TotalGameTime;
            TimeSpan diff = current - previousTimeFrame;
            countTime += diff;
            if (countTime > totalTime)
            {
                diff -= countTime - totalTime;
            }
            oldState.Camera += sceneShiftPixelSpeed * (float)diff.TotalMilliseconds;
            newState.Camera += sceneShiftPixelSpeed * (float)diff.TotalMilliseconds;
            previousTimeFrame = current;
            oldState.Update(time);
            newState.Update(time);

        }

        public void Draw(GameTime time, SpriteBatch batch)
        {
            oldState.Draw(time, batch);
            newState.Draw(time, batch);
        }
    }
}

