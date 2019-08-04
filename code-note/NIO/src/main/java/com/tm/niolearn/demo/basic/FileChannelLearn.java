package com.tm.niolearn.demo.basic;

import java.io.IOException;
import java.io.RandomAccessFile;
import java.nio.Buffer;
import java.nio.ByteBuffer;
import java.nio.channels.Channel;
import java.nio.channels.FileChannel;

public class FileChannelLearn {
    public void readFile() throws Exception{
        RandomAccessFile aFile = new RandomAccessFile("D:/data/nio-data.txt", "rw");
        FileChannel fileChannel = aFile.getChannel();

        ByteBuffer byteBuffer = ByteBuffer.allocate(48);
        int byteRead = fileChannel.read(byteBuffer);
        while (byteRead!=-1){
            byteBuffer.flip();

            while(byteBuffer.hasRemaining()){
                System.out.print((char) byteBuffer.get());
            }
            byteBuffer.clear();
            byteRead = fileChannel.read(byteBuffer);
        }
        aFile.close();
    }

    public void transferFromLearn() throws IOException {
        RandomAccessFile fromFile = new RandomAccessFile("D:/data/from.txt","rw");
        FileChannel fromChannel = fromFile.getChannel();

        RandomAccessFile toFile = new RandomAccessFile("D:/data/from.txt","rw");
        FileChannel toChannel = toFile.getChannel();

        int position = 0;
        long count = fromChannel.size();
        toChannel.transferFrom(fromChannel,position,count);
    }

    public void writeFile() throws IOException{
        RandomAccessFile writeFile = new RandomAccessFile("D:/test.txt","rw");
        FileChannel channel = writeFile.getChannel();
        String msg = "Hello Java File NIO! " + System.currentTimeMillis();
        ByteBuffer writeBuffer = ByteBuffer.allocate(48);
        writeBuffer.clear();
        writeBuffer.put(msg.getBytes());
        writeBuffer.flip();

        while (writeBuffer.hasRemaining()){
            channel.write(writeBuffer);
        }
        channel.close();
    }
}
