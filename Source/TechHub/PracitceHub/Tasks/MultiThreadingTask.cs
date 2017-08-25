using PracitceHub.Factory;
using System;
using System.Threading;

namespace PracitceHub.Tasks
{
    public class MultithreadingTask : ITask
    {
        public void Execute()
        {
            Console.WriteLine(this.GetType());
            Alpha oAlpha = new Alpha();

            //ThreadStart ts = new ThreadStart(oAlpha.Beta2);
            //Thread thread = new Thread(ts);
            //thread.Start();

            //Thread thrd = new Thread(new ParameterizedThreadStart(Alpha.run));
            //thrd.IsBackground = true;
            //thrd.Start(10);

            //ThreadPool.QueueUserWorkItem(Alpha.run, 10);

            System.Threading.Timer thrdTimer = new System.Threading.Timer(Alpha.timerrun, 10,0,100);

            Thread.Sleep(1000);
            for (int t = 10; t > 0; t--)
            {
                Console.WriteLine("Main Thread value is :" + t);
                Thread.Sleep(100);
            }
            Console.WriteLine("Good Bye!!!I'm main Thread");
            Console.ReadLine();
        }
    }

    //public delegate void ParameterizedThreadStart(object obj);

    public class Alpha
    {
        public static void Beta()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Sub Thread value is : " + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("Good Bye!!!I'm Sub Thread");
        }

        public void Beta2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Sub Thread value is : " + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("Good Bye!!!I'm Sub Thread");
        }

        public static void run(object args)
        {
            // cast our parameter 
            int j = (int)args;

            for (int i = 0; i < j; i++)
            {
                Console.WriteLine("Sub Thread value is : " + i);
                Thread.Sleep(300);
            }
            Console.WriteLine("Good Bye!!!I'm Sub Thread");
        }

        public static void timerrun(object args)
        {
            // cast our parameter 
            int j = (int)args;

            Console.WriteLine("Hi I'm executing by timer you passed " + j);
        }

    };


}
