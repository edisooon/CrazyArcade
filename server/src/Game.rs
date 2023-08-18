use std::vec;
use std::rc::Rc;
use std::cell::RefCell;

pub mod Entity;
pub mod GameSystem;
use crate::Game::Entity::IEntity;
use crate::Game::GameSystem::IGameSystem;

pub trait IGame {    
    fn setup(&mut self, entities: Vec<Rc<RefCell<dyn IEntity>>>);
    fn update(&mut self);
}

pub struct CAGame {
    pub mSystems: Vec<Rc<RefCell<dyn IGameSystem>>>,
}

impl IGame for CAGame {

    fn setup(&mut self,
        entities: Vec<Rc<RefCell<dyn IEntity>>>) {
        println!("setup")
        
    }
    fn update(&mut self) {
        println!("update")
        
    }
}

impl CAGame {
    fn add(&mut self, IEntity: Rc<RefCell<dyn IEntity>>) {
        let newIEntity = Rc::clone(&IEntity);
    } 
}
