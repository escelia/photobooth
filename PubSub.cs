// Publisher/Subscriber pattern using callback functions
// build: csc PubSub.cs
/*
using System;
using System.Threading;
using System.Collections.Generic;

namespace Photobooth
{
    class KeyPublisher
    {
        List<KeyCallbackFn> _cbs = new List<KeyCallbackFn>(); // a list of functions
        public delegate void KeyCallbackFn(char k); // this is a function type

        public KeyPublisher()
        {
        }

        public void Unsubscribe(KeyCallbackFn cb)
        {
            _cbs.Remove(cb);
        }

        public void Subscribe(KeyCallbackFn cb)
        {
            _cbs.Add(cb);
        }

        public void CheckKey()
        {
            if (Console.KeyAvailable)
            {
                char key = Console.ReadKey(true).KeyChar;
                foreach (KeyCallbackFn cb in _cbs)
                {
                    cb(key);
                }
            }
        }
    }

    class Example1
    {
    public Example1() {}
    public void PrintKey(char k)
    {
        Console.WriteLine("Example1 says! "+k);
    }
    }

    class Example2
    {
    public Example2() {}
    public void ProcessKey(char k)
    {
        Console.Write("Example2 says! ");
        for (int i = 0; i < 6; i++)
        {
            Console.Write(k);
        }
        Console.Write("\n");
    }
    }
    

    class ClassMain
    {
        public static void Main()
        {
            Example1 ex1 = new Example1();
            Example2 ex2 = new Example2();

            KeyPublisher pub = new KeyPublisher();
            pub.Subscribe(ex1.PrintKey);
            pub.Subscribe(ex2.ProcessKey);
            pub.Subscribe(delegate(char k) // anonymous function 
            { 
                Console.WriteLine("Anonymous "+k); 
            });

            bool timeToQuit = false;
            while(!timeToQuit)
            {
                pub.CheckKey();
                Thread.Sleep(100);
            }
        }
    
    }
}
*/