use std::cell::RefCell;
use std::rc::Rc;
use crate::Game::Entity::IEntity;

pub trait IGameSystem {
    fn setup(&self);
    fn update(&self);
    fn add(&self, entity: Rc<RefCell<dyn IEntity>>);
}