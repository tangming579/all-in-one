package com.tm.multithread.demo;

import com.tm.multithread.demo.BackgroundThread.MyBGThread;
import com.tm.multithread.demo.CallableThread.MyCallable;
import com.tm.multithread.demo.RunnableThead.MyRunable;
import com.tm.multithread.demo.RunnableThead.MyThread;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.concurrent.Callable;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.FutureTask;

@SpringBootApplication
public class DemoApplication {

    public static void main(String[] args) {
        SpringApplication.run(DemoApplication.class, args);
        /*
        Callable<Integer> callable = new MyCallable();
        FutureTask<Integer> task = new FutureTask<Integer>(callable);
        for (int i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
            if (i == 30) {
                MyRunable runable = new MyRunable();
                MyBGThread thread = new MyBGThread(runable);
                thread.start();
                try{
                    thread.join();
                }catch (InterruptedException e){

                }

                Thread thread1 = new Thread(task);
                thread1.start();
            }
        }
        try {
            int sum = task.get();
            System.out.println("Sum is " + sum);
        } catch (InterruptedException e) {

        } catch (ExecutionException e) {

        }
       */
        MyBGThread thread=new MyBGThread();
        for (int i=0;i<100;i++){
            System.out.println("current Thread i is "+i);
            if(i==20){
                thread.setDaemon(true);
                thread.start();
            }
        }

    }
}

