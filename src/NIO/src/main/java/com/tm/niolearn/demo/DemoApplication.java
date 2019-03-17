package com.tm.niolearn.demo;
import com.tm.niolearn.demo.basic.FileChannelLearn;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class DemoApplication {

    public static void main(String[] args) throws Exception {
        SpringApplication.run(DemoApplication.class, args);

        FileChannelLearn learn = new FileChannelLearn();
        //learn.readFile();
        learn.writeFile();
    }

}
