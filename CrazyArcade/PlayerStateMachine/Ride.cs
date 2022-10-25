using CrazyArcade.Blocks;
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
        Character player;
        public SpriteAnimation[] spriteAnims { get; set; }

 
        int dir;
        //int rideType; // 0 - 3, turtle, pirate turtle, ufo, owl


        public Ride(Character character, int ride) {
            player = character;
            generateRide(ride%4);
            if (character != null) {
                X = character.X;
                Y = character.Y;
                dir = ((int)character.direction);//might break
            }
        }
        public override void Load()
        {
            
        }

        public override void Update(GameTime time)
        {
            //does nothing
        }

        public void generateRide(int ride) {
            spriteAnims = new SpriteAnimation[4];
            //rows = ride
            //columns = x off, y off-ydiff, width, height, ydiff
            //int[,] sprites = new int[4,5] {{5,3,96,31,2},{111, 3, 42, 31,2},{ 218, 5, 50, 30, 1},{333, 4, 36, 35,6}};
            //get the right one for the selected ride
            //int[] rideSprite = new int[5] { sprites[ride, 0], sprites[ride, 1], sprites[ride, 2], sprites[ride, 3], sprites[ ride, 4]};
            
            for (int i = 0; i < 4; i++) {
                /**spriteAnims[i] = new SpriteAnimation(TextureSingleton.GetRides(), //texture
                    2, //frames
                    rideSprite[0], //xoff
                    rideSprite[1] + i * (rideSprite[3] + rideSprite[4]), //yoff
                    rideSprite[2], //width
                    rideSprite[3], //height
                    3);//fps**/
                spriteAnims[i] = new SpriteAnimation(TextureSingleton.GetRides(), //texture
                    2, //frames
                    0, //xoff
                    72*i, //yoff
                    48*2, //width
                    72, //height
                    3);//fps
            }
            //vertOffset = rideSprite[3];
            //spriteAnims[0] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 4, 96, 32, 3); //back
            //spriteAnims[1] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 37, 96, 32, 3); //forward
            //spriteAnims[2] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 68, 96, 32, 3); //left
            //spriteAnims[3] = new SpriteAnimation(TextureSingleton.GetRides(), 12, 4, 100, 96, 32, 3); //right
        }
    }
}
