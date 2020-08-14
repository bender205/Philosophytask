using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Philosoph4._0
{
    class Philosopher
    {
        public const int PhilosopherCount = 5;
        public string name;
        public Fork leftFork;
        public Fork rightFork;
        public int id;

        public int leftForkId;
        public int rightForkId;
        Philosopher()
        {
            if (id == 1)
            {
                leftForkId = PhilosopherCount;
                rightForkId = id;
            }
            else
            {
                leftForkId = id - 1;
                rightForkId = id;
            }
            
        }

        public Philosopher(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public void getForks(object oForks)
        {
            while (true)
            {
                List<Fork> forks = (List<Fork>)oForks;
                if (Monitor.TryEnter(forks[leftForkId], TimeSpan.FromMilliseconds(2000)))
                {
                    this.leftFork = forks[leftForkId];
                    /* forks[leftForkId - 1].PhilosopherID = id;*/
                    Console.WriteLine($"{id} take a left fork");

                    if (Monitor.TryEnter(forks[rightForkId], TimeSpan.FromMilliseconds(2000)))
                    {
                        this.rightFork = forks[rightForkId];

                        Console.WriteLine($"{id} take a right fork");

                        this.Eat();

                        Console.WriteLine($"{id} finished eating");

                        Monitor.Exit(rightFork);
                        Console.WriteLine($"{id} put right fork ");
                    }
                    else
                    {
                        Console.WriteLine($"{id}  failed to take a right ");
                    }

                    Monitor.Exit(leftFork);
                    Console.WriteLine($"{id} put left fork ");
                }
                else
                {
                    Console.WriteLine($"{id}  failed to take a leftFork  ");
                }

            }
        }

        public void Eat()
        {
            Console.WriteLine($"{id} is eating");
            Thread.Sleep(1000);
        }
    }
}
