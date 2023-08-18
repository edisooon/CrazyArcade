mod game;
mod udp_server;

use crate::game::CAGame;
use crate::game::IGame;
use std::cell::RefCell;
use std::{vec, rc::Rc};

fn main() {
    println!("hello");
    let game: Rc<RefCell<dyn IGame>> = Rc::new(RefCell::new(CAGame::new(Vec::new())));
    game.borrow_mut();
    loop {
        game.borrow_mut().update();
    }
}

/*

xxxx xxxx //type (size)
xxxx xxxx
xxxx xxxx
xxxx xxxx
xxxx xxxx

xxxx xxxx









*/