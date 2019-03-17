package com.tm.niolearn.demo.basic;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.nio.channels.ServerSocketChannel;
import java.nio.channels.SocketChannel;

public class SocketChannelLearn {
    public void ServerSocket() throws IOException{
        ServerSocketChannel serverChannel = ServerSocketChannel.open();
        serverChannel.configureBlocking(false);
        serverChannel.socket().bind(new InetSocketAddress(8080));
        while (true){
            SocketChannel socketChannel = serverChannel.accept();
        }
    }
}
