use std::vec;
use std::rc::Rc;
use std::cell::RefCell;

pub mod entity;
pub mod game_system;
use crate::game::entity::IEntity;
use crate::game::game_system::IGameSystem;

pub trait IGame {    
    fn setup(&mut self, entities: Vec<Rc<RefCell<dyn IEntity>>>);
    fn update(&mut self);
}

pub struct CAGame {
    pub m_systems: Vec<Rc<RefCell<dyn IGameSystem>>>,
    time_count: u64,
}

impl CAGame {
    pub fn new(systems: Vec<Rc<RefCell<dyn IGameSystem>>>) -> CAGame {
        return CAGame {
            m_systems: systems,
            time_count: 0,
        }
    }
}

impl IGame for CAGame {

    fn setup(&mut self,
        entities: Vec<Rc<RefCell<dyn IEntity>>>) {
        println!("setup");
        for entity in entities {
            for sys in &self.m_systems {
                sys.borrow_mut().add(entity.clone());
            }
        }
    }
    fn update(&mut self) {
        self.time_count += 1;
        println!("update {}", self.time_count);
        for sys in &self.m_systems {
            sys.borrow_mut().update();
        }
    }
}

impl CAGame {
    fn add(&mut self, IEntity: Rc<RefCell<dyn IEntity>>) {
        let newIEntity = Rc::clone(&IEntity);
    } 
}
