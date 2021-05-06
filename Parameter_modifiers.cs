﻿using System;

namespace Modificators_in_out_ref
{
    //Модфикаторы для параметров { in, out, ref }
    //В метод можно передавать параметры извне. Существуют различия при передаче параметра ссылочного типа и значимого типа.
    //Когда в метод передаётся параметр значимого типа, то создаётся его копия, и внутри метода будет использоваться именно копия(локальная).
    /*Когда метод закончит работу, эта локальная копия удалится. Сама же переменная, которую мы передавали в метод(оригинал) останется без изменений.
     * При передаче в метод параметра ссылочного типа, метод получает КОПИЮ ССЫЛКИ на этот объект в памяти. То есть, метод получает копию адреса этого объекта.
     * Это значит, что мы можем менять сам объект, его свойства, поля, методы. Но мы не можем никак изменить САМУ ССЫЛКУ.
     * Она неизменно будет указывать на конкретный участок памяти в куче.
     * Также, при передаче ссылочного типа в метод по значению (без модификаторов), то можно создать копию этого объекта, с помощью оператора new.
     * С этой копией можно будет безопасно работать, а после того как метод завершит свою работу, эта копия удалится, сам объект, который мы передали в метод,
     * Останется без изменений
     * 
     */
    class Programm
    {
        public static void Main (string[] args)
        {
            int x = 5;

            Person Kok = new Person { Name = "Helly" };
            

            SomeMethod(x, Kok);

            Console.WriteLine($"Переменная x = {x}, а свойство внутри объекта = {Kok.Name}"); // Переменная x = 5, а свойство внутри объекта = Karl

            // С переменной ничего не случилось, потому что метод работал с её копией. а вот свойство объекта изменилось. 
            /* Однако, если возникнет необходимость получить не копию параметра, а ссылку на него (даже не копию ссылки),
             * то на помощь приходит модификатор ref
             */

            Person Kok2 = new Person { Name = "NOT Helly" };

            SomeMethod(ref x, ref Kok, ref Kok2);

            Console.WriteLine($"Переменная x = {x}, а свойство внутри объекта = {Kok.Name}, свойства второго объекта = {Kok2.Name}");

            /* Как видишь, переменная изменилась, а ссылка "Kok" теперь указывает на другой объект в памяти.
             * 
             * Но что если, нам нужно прочитать значения, при этом никак их не изменяя?
             * В таком случае мы можем передать ссылку на параметр, но только для чтения, то есть изменить его не получится.
             * Это делается с помощью модификатора in
             */

            SomeMethod(in x, in Kok);

            /*А что насчёт модификатора out? Чем-то он похож на return но позволяет вернуть из метода более чем одно значение, не используя кортежи.
             * Чтобы этот оператор возможно было корректно применить, метод обязан присваивать определённое значение параметрам с модификатором out.
             * Также, мы можем инициализировать эти параметры как внутри метода, так и при вызове.
             */

            int c; //Объявим переменную до вызова метода

            SomeMethod(out int a, out int b, out c); //Объявим несколько переменных при вызове метода

            Console.WriteLine($"Таким образом, наши новые переменные будут иметь значения: a = {a}, b = {b}, c = {c}");

        }

        public static void SomeMethod(int value, Person linkType)
        {
            value = 11; 
            //linkType = new Person { Name = "Sam" }; Если сделать так(создать копию объекта ссылочного типа, то с оригиналом ничего не случится, а все изменения
            //будут затрагивать только копию. После того как метод отработает она просто удалится.
            linkType.Name = "Karl";

            
        }

        public static void SomeMethod(ref int value, ref Person linkType, ref Person linkType2)
        {
            value = 11; //Переназначим переменную т.к. теперь мы имеем доступ к ней в памяти

            linkType = linkType2; //А здесь переназначим ссылку, она теперь будет указывать на другой объект в памяти
        }

        public static void SomeMethod(in int value, in Person linkType)
        {
            //value == 10;  -- Эту инструкцию среда разбработки не позволит выполнить т.к. объект только для чтения.

            

            //linkType = new Person(); -- Это тоже будет ошибкой. т.к. мы можем читать ссылку но не изменять её
            //а вот доступ к объекту она всё равно предоставляет.

            linkType.Name = "Adam";

            Console.WriteLine($"Но мы можем использовать значение в выражении. x + 10 = {value + 10}, имя поменять удалось, теперь оно = {linkType.Name}");
        }

        public static void SomeMethod(out int a, out int b, out int c)
        {
            a = 10;
            b = 15;
            c = 150;
        }
    }

    class Person
    {
        public string Name { get; set;}
        public int Age { get; set; }
    }
    

}
