using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using CrazyArcade.Enemies;
using CrazyArcade.GameGridSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Demo1
{
    public class OctopusEnemy : Enemy
    {
        private int size;
        float timer;
        float threshold;
        private Texture2D texture;
        private Color tint;
        public Rectangle outputFrame1;
        public SpriteAnimation spriteAnims;
        public override SpriteAnimation SpriteAnim => spriteAnims;


        public Rectangle inputFrame;



        public OctopusEnemy(int x, int y)
        {
            texture = TextureSingleton.GetOctoBoss();
            spriteAnims = new SpriteAnimation(texture,2,5);
            X = x;
            Y = y; 
            internalRectangle.X = X;
            internalRectangle.Y = Y;
            ScreenCoord = new Vector2(X, Y);
        }

        

        public override void Load()
        {
            size = 95;
            timer = 0;
            threshold = 120;
            texture = TextureSingleton.GetOctoBoss();
            tint = Color.White;
        }


        

    }
}