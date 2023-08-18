use std::vec;

// since only have at most 4 users 
// and user is only have 5 operations up down left right bomb
// We can use one byte to conclude all operations
// the first three bits indicates user id
// the last five byte is key mask
// say we have byte 0b01010001, 
//      the first three bits is 010, which is player 2
//      the last five shows key mask, means up and bomb


pub trait IInputListener {
    fn up(&mut self);
    fn down(&mut self);
    fn left(&mut self);
    fn right(&mut self);
    fn bomb(&mut self);
}

struct InputSystem {
    inputs: Vec<u8>
}