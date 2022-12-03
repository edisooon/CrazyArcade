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
        public SpriteAnimation[] SetSprites();
        //Sets the speed of the player character
        public int SetSpeed();
        //code for dealing with the obtaining of items (can be changed?)
        public void ProcessItem();
        //Code for obtaining a rideable mount
        public void ProcessRide();
        //Code for dealing with attacking, return true if bomb placed
        public bool ProcessAttaction();

    }
}