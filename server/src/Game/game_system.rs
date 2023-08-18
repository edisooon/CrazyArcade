pub mod output_system;
pub mod input_system;

use std::cell::RefCell;
use std::rc::Rc;
use crate::game::entity::IEntity;

pub trait IGameSystem {
    fn setup(&self);
    fn update(&self);
    fn add(&self, entity: Rc<RefCell<dyn IEntity>>);
}