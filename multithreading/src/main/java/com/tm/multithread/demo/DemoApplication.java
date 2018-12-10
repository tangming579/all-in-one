package com.tm.multithread.demo;

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
        Callable<Integer> callable = new MyCallable();
        FutureTask<Integer> task = new FutureTask<Integer>(callable);
        for (int i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
            if (i == 30) {
               /* MyRunable runable = new MyRunable();
                MyThread thread = new MyThread(runable);
                thread.start();*/

                Thread thread = new Thread(task);
                thread.start();
            }
        }
        try {
            int sum = task.get();
            System.out.println("Sum is " + sum);
        } catch (InterruptedException e) {

        } catch (ExecutionException e) {

        }
    }
}

