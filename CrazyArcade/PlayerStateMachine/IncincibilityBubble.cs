using CrazyArcade.CAFramework;
using CrazyArcade.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    class IncincibilityBubble : CAEntity
    {
        public Character player;
        private SpriteAnimation sprite;
        private static readonly int bubbleWidthHeight = 72;
        private static readonly int secondBubbleStartXPos = 216;
        private static readonly float bubbleScale = 1.1f;
        private static readonly Point bubbleCenter = new(-18, -8);
        private int countdown;
        public override SpriteAnimation SpriteAnim => sprite;
        public IncincibilityBubble(Character player, int countdown)
        {
            this.countdown = countdown;
            this.player = player;
            sprite = new SpriteAnimation(TextureSingleton.GetBubble(), new Rectangle(secondBubbleStartXPos, 0, bubbleWidthHeight, bubbleWidthHeight));
            sprite.SetScale(bubbleScale);
            sprite.SetColor(new Color(255,0,0,100));
            this.countdown = countdown;
            DrawOrder = player.ActualDrawOrder + 1;
        }

        public override void Update(GameTime time)
        {
            X = player.X + bubbleCenter.X;
            Y = player.Y + bubbleCenter.Y;
            countdown--;
            if (countdown <= 0) SceneDelegate.ToRemoveEntity(this);
        }

        public override void Load()
        {
            
        }
    }
}
