using CrazyArcade.CAFramework;
using CrazyArcade.CAFramework.Controller;
using CrazyArcade.Content;
using CrazyArcade.Demo1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    internal class Ride : CAEntity
    {
        PlayerCharacter player;
        public SpriteAnimation[] spriteAnims { get; set; }
        int vertOffset;
        int dir;
        //int rideType; // 0 - 3, turtle, pirate turtle, ufo, owl


        public Ride(PlayerCharacter character, int ride) {
            player = character;
            generateRide(ride%4);
            if (character != null) {
                X = character.X;
                Y = character.Y - vertOffset;
                dir = ((int)character.direction);//might break
            }
        }
        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime time)
        {
            if (player!= null)
            {
                X = player.X;
                Y = player.Y - vertOffset;
                dir = ((int)player.direction);//might break
            }
        }

        public void generateRide(int ride) {
            spriteAnims = new SpriteAnimation[4];
            int xcoord = 111 * ride;
            int ydiff = ride < 3 ? 32 : 40;
            for (int i = 0; i < 4; i++) {
                spriteAnims[i] = new SpriteAnimation(TextureSingleton.GetRides(), 2, xcoord, 0, 111, ydiff, 3);
            }
            vertOffset = ydiff;
            //spriteAnims[0] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 4, 96, 32, 3); //back
            //spriteAnims[1] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 37, 96, 32, 3); //forward
            //spriteAnims[2] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 68, 96, 32, 3); //left
            //spriteAnims[3] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 100, 96, 32, 3); //right
        }
    }
}
