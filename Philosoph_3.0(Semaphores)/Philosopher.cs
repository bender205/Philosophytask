using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Philosoph_3._0_Semaphores_
{
    class Philosopher
    {
        bool isHungry = false;
        string philosopherName;
        int philosophId;
        bool isDeath = false;

        public Philosopher(string name, int id)
        {
            philosopherName = name;
            philosophId = id;
        }

        void GetFork(List<Fork> fork)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            timer.Interval = 10000;
            Console.WriteLine("Philosopher {0} waiting forks", philosopherName);
            timer.Start();
           // Monitor.Enter(fork);
            try
            {
                if (isDeath)
                    return;
                int first = philosophId;
                int second = (philosophId == fork.Count - 1) ? 0 : philosophId + 1;
                if (!fork[first].IsUsing && !fork[second].IsUsing)
                {
                    Console.WriteLine("Philosopher {0} getting forks ", philosopherName);
                    timer.Stop();
                    timer.Dispose();
                    fork[first].IsUsing = true;
                    fork[second].IsUsing = true;
                    Console.WriteLine("Philosopher {0} eating.", philosopherName);
                    Console.WriteLine("Forks with numbers {0} and {1} are using.", first + 1, second + 1);
                    Thread.Sleep(250);
                    fork[first].IsUsing = false;
                    fork[second].IsUsing = false;
                }
            }
            finally
            {
            //    Monitor.Exit(fork);
            }
        }

        void OnTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("!!!!!\n Philosopher {0} is dead!!!!!!!! T_T", philosopherName);
            Console.ResetColor();
            isDeath = true;
            ((System.Timers.Timer)sender).Stop();
        }

        public void Start(object obj)
        {
            while (true)
            {
                Thread.Sleep(1000);
                ChangeStatus();
                if (isHungry)
                    GetFork((List<Fork>)obj);
                if (isDeath)
                {
                    return;
                }
            }
        }

        void ChangeStatus()
        {
            isHungry = !isHungry;
            if (!isHungry)
                Console.WriteLine("Philosopher {0} thinking.", philosopherName);
        }
    }
}
