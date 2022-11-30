using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework;
using CrazyArcade.Items;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyArcade.PlayerStateMachine
{
    //Interface for defining the functions of the character state machine
    public interface ICharacterState
    {
        //Main logic of the state machine, called by the update method in playercharacter
        public void ProcessState(GameTime time);
        //Returns the sprites the character will be represeted with
        public SpriteAnimation[] SetSprites();    //=======>
                                                          // ====> both is put in the constructor of CharacterState now (so that we don't have to do neither when switch to new state)
        //Sets the speed of the player character    =======> 
        //public int SetSpeed();
        //code for dealing with functionality of item upon current state
        public void ProcessItem();
        //Code for obtaining a rideable mount
        public void ProcessRide();
        //Code for dealing with attaction
        public void ProcessAttaction();
        // decide if the character could/could not put bomb at current state
        public bool CouldPutBomb { get; }
        // decide if the character could/could not get powerup at current state
        public bool CouldGetItem { get; }
    }
}