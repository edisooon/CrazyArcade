using CrazyArcade.Demo1;
using CrazyArcade.Enemies;
using CrazyArcade.Boss;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace CrazyArcade.Enemies
{
    public class EnemyManager : IGameSystem

    {
        private int i = 1;
        private int length;
        private int X;
        private int Y;
        private CAEntity[] CAEntityList;
        private CAEntity currentSprite;
        private CAEntity oldSprite;
        private CAScene Scene;

        KeyboardState currentState;
        KeyboardState oldState;
        public EnemyManager(CAScene scene)
        {
            length = 6;
            this.Scene = scene;
            X = 300;
            Y = 100;
            CAEntityList = new CAEntity[length];
            CAEntityList[0] = new BombEnemySprite(X, Y);
            CAEntityList[1] = new SquidEnemySprite(X, Y);
            CAEntityList[2] = new BatEnemySprite(X, Y);
            CAEntityList[3] = new RobotEnemySprite(X, Y);
            CAEntityList[4] = new SunBoss(scene);
            CAEntityList[5] = new OctopusEnemy(X, Y);
            currentSprite = CAEntityList[0];
            Scene.AddSprite(currentSprite);
            oldSprite = currentSprite;


        }

        public void Update(GameTime time)
        {
            currentState = Keyboard.GetState();
            Key_o();
            Key_p();
            oldState = currentState;
        }
        public void AddSprite(IEntity sprite)
        {

        }
        public void RemoveSprite(IEntity sprite)
        {

        }
        public void RemoveAll()
        {

        }
        private void Key_p()
        {
            if (currentState.IsKeyDown(Keys.P) && !oldState.IsKeyDown(Keys.P))
            {
                currentSprite = CAEntityList[i];
                
                if (oldSprite != null)
                {
                    Scene.RemoveSprite(oldSprite);
                }
                Scene.AddSprite(currentSprite);
                oldSprite = currentSprite;
                i++;
                
                
                if (i == CAEntityList.Length)
                {
                    i = 0;
                }
                
            }
        }
        private void Key_o()
        {
            if (currentState.IsKeyDown(Keys.O) && !oldState.IsKeyDown(Keys.O))
            {

                currentSprite = CAEntityList[i];
                
                if (oldSprite != null)
                {
                    Scene.RemoveSprite(oldSprite);
                }
                Scene.AddSprite(currentSprite);
                oldSprite = currentSprite;
                i--;
                
                
                if (i == -1)
                {
                    i = CAEntityList.Length - 1;
                }
                currentSprite = CAEntityList[i];
            }
        }
       
    }
}
