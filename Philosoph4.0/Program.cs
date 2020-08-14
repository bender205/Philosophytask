using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Philosoph4._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fork> forks = new List<Fork>
            {
                new Fork(1),
                new Fork(2),
                new Fork(3),
                new Fork(4),
                new Fork(5)
            };
            /*
               public string name;
        
        public int id;*/
            List<Philosopher> philosophs = new List<Philosopher>
            {
                new Philosopher("Adam",1),
                new Philosopher("Nick",2),
                new Philosopher("Jackson",3),
                new Philosopher("Batman",4),
                new Philosopher("Vasyl",5)
            };

            List<Task> tasks = new List<Task>();
            foreach (var v in philosophs)
            {
                /*Thread thread = new Thread(v.getForks);
                thread.Start(forks);*/

                var task = Task.Run(() => v.getForks(forks));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            
           /* foreach(var v in philosophs)
            {
                var newTask = new Task(v.getForks);
                    
                    Task.Run(()=>v.getForks(forks));
            }

            Task task = Task.Run(() => MakeHungry(philosophs));
            Task task1 = Task.Run(() => MakeSatisfied(philosophs, forks));
            //task.Wait();
            //task1.Wait();
            Task.WaitAll(task, task1);*/
        }
    }
}
