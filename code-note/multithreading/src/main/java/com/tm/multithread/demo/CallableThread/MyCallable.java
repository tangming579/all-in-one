package com.tm.multithread.demo.CallableThread;

import java.util.concurrent.Callable;

public class MyCallable implements Callable<Integer> {
    int i = 0;

    @Override
    public Integer call() {
        int sum = 0;
        for (; i < 10; i++) {
            System.out.println(Thread.currentThread().getName() + i);
            sum += i;
        }
        return sum;
    }
}
