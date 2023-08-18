use std::sync::mpsc::{Receiver, channel};
use std::sync::{mpsc, Mutex};
use std::thread;
use std::{sync::mpsc::Sender, rc::Rc, io};
use std::net::{UdpSocket, SocketAddr};
use crate::game::game_system::output_system::serializable::Serializable;
use std::collections::HashMap;


struct CAUdpServer {
    m_sock: UdpSocket,
}

impl CAUdpServer {
    pub fn new(addr: String) -> Result<CAUdpServer, io::Error> {
        let udpsock = UdpSocket::bind(addr)?;
        Ok(CAUdpServer {
            m_sock: udpsock,
        })
    }
    fn run_udp_input(&self, out: Sender<u8>, socket_out: Sender<Vec<u8>>, prep_sender: Sender<SocketAddr>) {
        let sock = match self.m_sock.try_clone() {
            Ok(udpsock) => udpsock,
            Err(err) => panic!("Problem clone socket: {:?}", err),
        };
        thread::spawn(move || {
            //preparation state
            let mut count: u8 = 0;
            let mut players: HashMap<SocketAddr, u8> = HashMap::new();
            while (count < 2) {
                let mut buf: [u8; 1] = [0;1];
                let (number_of_bytes, src_addr) = sock.recv_from(&mut buf)
    .expect("Didn't receive data");
                
                if let Some(id) = players.get(&src_addr) {
                    socket_out.send(vec![*id]);
                } else {
                    players.insert(src_addr, count);
                    socket_out.send(vec![count]);
                    prep_sender.send(src_addr);
                    count += 1;
                }
            }
            //game starts here
            loop {
                let mut buf: [u8; 1] = [0;1];
                let (number_of_bytes, src_addr) = sock.recv_from(&mut buf)
    .expect("Didn't receive data");
                out.send(buf[0]).unwrap();
            }
        });
    }
    fn run_udp_output(&self, out: Sender<u8>, prep_recv: Receiver<SocketAddr>) -> Sender<Vec<u8>> {
        let sock = match self.m_sock.try_clone() {
            Ok(udpsock) => udpsock,
            Err(err) => panic!("Problem clone socket: {:?}", err),
        };
        let (sender, receiver) = channel::<Vec<u8>>();
       
        thread::spawn(move || {
            let mut playerlist: Vec<SocketAddr> = Vec::new();
            loop {
                let data = match receiver.recv() {
                    Ok(data) => data,
                    Err(err) => panic!("Problem clone socket: {:?}", err),
                };
                // preparation state
                if data.len() == 1 {
                    if let Ok(addr) = prep_recv.try_recv() {
                        playerlist.push(addr);
                    }
                    let idx: usize = data[0].into();
                    sock.send_to(&data[..], playerlist[idx]);
                } else {
                    // game state

                }
            }
        });
        return sender;
    }
    pub fn run(&self, out: Sender<u8>) -> Sender<Vec<u8>> {
        let (prep_sender, prep_receiver) = channel::<SocketAddr>();
        let res = self.run_udp_output(out.clone(), prep_receiver);
        self.run_udp_input(out, res.clone(), prep_sender);
        return res;
    }
    
}