package com.company;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
class Thread1 implements Runnable
{
    public void run()
    {
        try {
            Main.FindingPasswords('a', 'l', "первом");
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }
}
class Thread2 implements Runnable
{
    public void run()
    {
        try {
            Main.FindingPasswords('m', 't', "втором");
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }
}
public class Main {
    static Thread1 thread1;
    static Thread2 thread2;
    public static void main(String[]args) throws NoSuchAlgorithmException {
        thread1 = new Thread1();
        thread2 = new Thread2();
        Thread sThread1 = new Thread(thread1);
        Thread sThread2 = new Thread(thread2);
        sThread1.start();
        sThread2.start();
        try {
            Main.FindingPasswords('u', 'z', "основном");
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }
    public static String Haash (String pass) throws NoSuchAlgorithmException {
        MessageDigest md = MessageDigest.getInstance("SHA-256");
        byte[] hashInBytes = md.digest(pass.getBytes(StandardCharsets.UTF_8));

        //bytes to hex
        StringBuilder sb = new StringBuilder();
        for (byte b : hashInBytes) {
            sb.append(String.format("%02x", b));
        }
        String haash_pass = sb.toString();
        return haash_pass;

    }
    public static void FindingPasswords(char rangeA, char rangeB, String threadName) throws NoSuchAlgorithmException{
        String haash1 = "1115dd800feaacefdf481f1f9070374a2a81e27880f187396db67958b207cbad";
        String haash2 = "3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b";
        String haash3 = "74e1bb62f8dabb8125a58852b63bdf6eaef667cb56ac7f7cdba6d7305c50a22f";
        for (char i = rangeA; i <= rangeB; i++) {
            {
                for (char j = 'a'; j <= 'z'; j++) {
                    for (char k = 'a'; k <= 'z'; k++) {
                        for (char l = 'a'; l <= 'z'; l++) {
                            for (char m = 'a'; m <= 'z'; m++) {
                                String pass = Character.toString(i) + Character.toString(j) + Character.toString(k) + Character.toString(l) + Character.toString(m);
                                String hashPassword = Haash(pass);
                                if (hashPassword.equals(haash1)) {
                                    System.out.println("Пароль1 найден в " + threadName + " потоке" + '\n' + "пароль: " + pass);
                                    System.out.println("Хеш: " + haash1);
                                }
                                if (hashPassword.equals(haash2)) {
                                    System.out.println("Пароль2 найден в " + threadName + " потоке" + '\n' + "пароль: " + pass);
                                    System.out.println("Хеш: " + haash2);
                                }
                                if (hashPassword.equals(haash3)) {
                                    System.out.println("Пароль3 найден в " + threadName + " потоке" + '\n' + "пароль: " + pass);
                                    System.out.println("Хеш: " + haash3);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}