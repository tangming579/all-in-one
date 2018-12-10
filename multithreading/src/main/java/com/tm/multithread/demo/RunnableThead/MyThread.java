package com.tm.multithread.demo.RunnableThead;

public class MyThread extends Thread {
    private int i = 0;

    public MyThread(Runnable runnable) {
        super(runnable);
    }

    @Override
    public void run() {
        System.out.println("in MyThread run");
        for (int i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
        }
    }
}
