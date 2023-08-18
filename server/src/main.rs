mod Game;

use crate::Game::CAGame;
use crate::Game::IGame;
use std::cell::RefCell;
use std::{vec, rc::Rc};

fn main() {
    println!("hello");
    let game: Rc<RefCell<dyn IGame>> = Rc::new(RefCell::new(CAGame {
        mSystems: Vec::new(),
    }));
    game.borrow_mut();
    loop {
        game.borrow_mut().update();
    }
}
/*

1xxx xxxx //begin point of object









*/