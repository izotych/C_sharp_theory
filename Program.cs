﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Access_modifiers
{
    //Модификаторы доступа
    //Существуют несколько типов модификаторов доступа:
    /*
    public: публичный, общедоступный класс или член класса. Такой член класса доступен из любого места в коде, а также из других программ и сборок.

    private: закрытый класс или член класса. Представляет полную противоположность модификатору public. Такой закрытый класс или член класса доступен только из кода в том же классе или контексте.

    protected: такой член класса доступен из любого места в текущем классе или в производных классах. При этом производные классы могут располагаться в других сборках.

    internal: класс и члены класса с подобным модификатором доступны из любого места кода в той же сборке, однако он недоступен для других программ и сборок (как в случае с модификатором public).

    protected internal: совмещает функционал двух модификаторов. Классы и члены класса с таким модификатором доступны из текущей сборки и из производных классов.

    private protected: такой член класса доступен из любого места в текущем классе или в производных классах, которые определены в той же сборке.
    

    Модификаторы желательно расставлять явно, настройки по-умолчанию для разных методов и полей разные.
    Если для полей и методов не определен модификатор доступа, то по умолчанию для них применяется модификатор private.
    Классы и структуры, объявленные без модификатора, по умолчанию имеют доступ internal.
    Все классы и структуры, определенные напрямую в пространствах имен и не являющиеся вложенными в другие классы, могут иметь только модификаторы public или internal.
    */
    class Program
    {
        static void Main(string[] args)
        {
            State state1 = new State();

            // присвоить значение переменной defaultVar у нас не получится,
            // так как она имеет модификатор private и класс Program ее не видит
            // И данную строку среда подчеркнет как неправильную
            state1.defaultVar = 5; //Ошибка, получить доступ нельзя

            // то же самое относится и к переменной privateVar
            state1.privateVar = 5; // Ошибка, получить доступ нельзя

            // присвоить значение переменной protectedPrivateVar не получится,
            // так как класс Program не является классом-наследником класса State
            state1.protectedPrivateVar = 5; // Ошибка, получить доступ нельзя

            // присвоить значение переменной protectedVar тоже не получится,
            // так как класс Program не является классом-наследником класса State
            state1.protectedVar = 5; // Ошибка, получить доступ нельзя

            // переменная internalVar с модификатором internal доступна из любого места текущего проекта
            // поэтому спокойно присваиваем ей значение
            state1.internalVar = 5;

            // переменная protectedInternalVar так же доступна из любого места текущего проекта
            state1.protectedInternalVar = 5;

            // переменная publicVar общедоступна
            state1.publicVar = 5;
        }
    }
    public class State
    {
        // все равно, что private int defaultVar;
        int defaultVar;
        // поле доступно только из текущего класса
        private int privateVar;
        // доступно из текущего класса и производных классов, которые определены в этом же проекте
        protected private int protectedPrivateVar;
        // доступно из текущего класса и производных классов
        protected int protectedVar;
        // доступно в любом месте текущего проекта
        internal int internalVar;
        // доступно в любом месте текущего проекта и из классов-наследников в других проектах
        protected internal int protectedInternalVar;
        // доступно в любом месте программы, а также для других программ и сборок
        public int publicVar;

        // по умолчанию имеет модификатор private
        void defaultMethod() => Console.WriteLine($"defaultVar = {defaultVar}");

        // метод доступен только из текущего класса
        private void privateMethod() => Console.WriteLine($"privateVar = {privateVar}");

        // доступен из текущего класса и производных классов, которые определены в этом же проекте
        protected private void protectedPrivateMethod() => Console.WriteLine($"protectedPrivateVar = {protectedPrivateVar}");

        // доступен из текущего класса и производных классов
        protected void protectedMethod() => Console.WriteLine($"protectedVar = {protectedVar}");

        // доступен в любом месте текущего проекта
        internal void internalMethod() => Console.WriteLine($"internalVar = {internalVar}");

        // доступен в любом месте текущего проекта и из классов-наследников в других проектах
        protected internal void protectedInternalMethod() => Console.WriteLine($"protectedInternalVar = {protectedInternalVar}");

        // доступен в любом месте программы, а также для других программ и сборок
        public void publicMethod() => Console.WriteLine($"publicVar = {publicVar}");
    }

    //Как видишь, среда сама укажет на проблемы с доступом, из-за чего код не скомпилируется. (Ошибка CS0122)
}
