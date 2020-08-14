using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Philosophytask
{
    class Program
    {
        static void CheckHealth(Philosoph philosoph, int currentHealth)
        {
            if (currentHealth > 0)
            {
                Console.WriteLine($"current health = {currentHealth}\t {philosoph.Name} is alive!!!");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{philosoph.Name} died like a hero, from a hungry death!!!\t Health was {currentHealth}");
                Console.ResetColor();
                try
                {
                    Thread.CurrentThread.Abort();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }                
        }

        static void MakeHungry(List<Philosoph> philosophs)
        {
            while (true)
            {
                Thread.Sleep(1000);
                foreach (var v in philosophs)
                {
                    v.HungryKick();
                }
            }
        }
        static void MakeSatisfied(List<Philosoph> philosophs, List<Fork> forks)
        {
            while (true)
            {
               
                foreach (var v in philosophs)
                {
                    v.GetFork(forks);
                }
            }
        }

        static void Main(string[] args)
        {
            #region test
            /*  Philosoph Adam = new Philosoph("Adam", 10);
              Adam.change += CheckHealth;
              Adam.PrintHealth(() => Console.WriteLine(Adam.HealthPoints));
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.UseFood(1);
              Adam.UseFood(1);
              Adam.UseFood(1);
              Adam.UseFood(1);
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.HungryKick();
              Adam.UseFood(1);
              Adam.HungryKick();
              Adam.PrintHealth(() => Console.WriteLine(Adam.HealthPoints));
  */
            #endregion
            List<Fork> forks = new List<Fork>
            {
                new Fork(),
                new Fork(),
                new Fork(),
                new Fork(),
                new Fork()
            };

            List<Philosoph> philosophs = new List<Philosoph>
            {
                new Philosoph("Adam",10),
                new Philosoph("Nick",10),
                new Philosoph("Jackson",10),
                new Philosoph("Batman",10),
                new Philosoph("Vasyl",10)
            };
            
            foreach(var v in philosophs)
            {
                v.change += CheckHealth;
            }

            /*
                        MakeHungry(philosophs);
                        MakeSatisfied(philosophs, forks);*/

            Task task = Task.Run(()=> MakeHungry(philosophs));
            Task task1 = Task.Run(() => MakeSatisfied(philosophs, forks));
            //task.Wait();
            //task1.Wait();
            Task.WaitAll(task, task1);
        }
    }
}
