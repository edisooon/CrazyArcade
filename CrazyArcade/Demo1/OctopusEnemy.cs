using System;
using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace CrazyArcade.Demo1
{
    public class OctopusEnemy : CAEntity
    {
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
        }

        public override void Load()
        {
            texture = TextureSingleton.GetOctoBoss();
            tint = Color.White;
        }


        

    }
}