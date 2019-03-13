package com.tm.niolearn.demo.basic;

import java.io.RandomAccessFile;
import java.nio.ByteBuffer;
import java.nio.channels.FileChannel;

public class FileChannelLearn {
    public void readFile() throws Exception{
        RandomAccessFile aFile = new RandomAccessFile("data/nio-data.txt", "rw");
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
}
