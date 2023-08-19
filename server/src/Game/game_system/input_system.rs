use std::vec;
use std::time::{Duration, SystemTime};
use std::sync::mpsc::Receiver;
use std::cell::RefCell;
use std::rc::Rc;

use crate::game::IGameSystem;
use crate::game::IEntity;

/* 
By default we only have 2 users, but say if we have 8, 
We would use three bits to store player id. We also have
4 directions and stand still, which two directions can't be at same time.
This means we would use another three bits on directions.
Finally we would use one bit to tell if player used a bomb or not.
That is, say the first three bit is used for player id. Last three used
for direction. And the fourth bit from right used for bomb, we would have
the following bit map:

|PID|PID|PID|   |B  |DIR|DIR|DIR|

(Dir stands for direction, B stands for bomb, PID stands for player id)
One empty bits may used in future or we can leave it used.
*/ 

const STAND_STILL:  u8 = 0;
const UP:           u8 = 1;
const DOWN:         u8 = 2;
const LEFT:         u8 = 3;
const RIGHT:        u8 = 4;
const BOMB_MASK:    u8 = 4;


pub trait IInputListener {
    fn up(&mut self);
    fn down(&mut self);
    fn left(&mut self);
    fn right(&mut self);
    fn bomb(&mut self);
}

pub struct InputSystem {
    inputs_time: Vec<SystemTime>,
    inputs: Vec<u8>,
    recv: Receiver<u8>,
    listeners: Vec<Rc<RefCell<dyn IInputListener>>>,
}

impl InputSystem {
    pub fn new(recver: Receiver<u8>) -> InputSystem {
        return InputSystem {
            inputs_time: vec![SystemTime::now(); 8],
            inputs: vec![0; 8],
            recv: recver,
            listeners: Vec::new(),
        };
    }
    fn updateListener(&self, id: usize) {
        let dir = self.inputs[id] & 0b00000111;
        match dir {
            UP => {
                self.listeners[id].borrow_mut().up();
            }
            DOWN => {
                self.listeners[id].borrow_mut().down();
            }
            LEFT => {
                self.listeners[id].borrow_mut().left();
            }
            RIGHT => {
                self.listeners[id].borrow_mut().right();
            }
            _ => {
                
            }
        }
        if (self.inputs[id] & BOMB_MASK) != 0 {
            self.listeners[id].borrow_mut().bomb();
        }
    }
}

impl IGameSystem for InputSystem {
    fn setup(&self) {
        
    }
    fn update(&mut self) {
        loop {
            match self.recv.try_recv() {
                Err(err) => {
                    break;
                }
                Ok(value) => {
                    let id = value >> 5;
                    let id: usize = id.try_into().unwrap();
                    self.inputs[id] = value;
                    self.inputs_time[id] = SystemTime::now();
                }
            }
        }
        for id in 0..self.listeners.len() {
            let id: usize = id.try_into().unwrap();
            match self.inputs_time[id].elapsed() {
                Ok(elapsed) => {
                    self.updateListener(id);
                }
                Err(err) => {
                    println!("time error: {}", err);
                }
            }
        }
    }
    fn add(&self, entity: Rc<RefCell<dyn IEntity>>) {
        
    }
}

