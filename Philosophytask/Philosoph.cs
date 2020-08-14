using System;
using System.Collections.Generic;
using System.Threading;

namespace Philosophytask
{

    class Philosoph
    {

        static object locker = new object();
        private const int MaxHealth = 10;
        private const int MinHealth = 0;
        private readonly int HealingPoints = 10;
        public delegate void HealthHandler(Philosoph sender, int health);
        public event HealthHandler change;
        public Fork RightFork { get; set; }
        public Fork LeftFork { get; set; }
        public string Name { get; set; }
        private int _healthPoints;
        #region constructors
        public Philosoph()
        {
        }

        public Philosoph(string name, int healthPoints)
        {
            Name = name;
            HealthPoints = healthPoints;
        }
        #endregion
        public int HealthPoints
        {
            get => _healthPoints;

            set
            {
                if (HealthPoints + value > MinHealth)
                {
                    if (HealthPoints + value >= MaxHealth)
                    {
                        _healthPoints = MaxHealth;
                    }
                    else
                    {
                        _healthPoints += value;
                    }
                }
                else
                {
                    _healthPoints = MinHealth;
                }
            }

        }
        #region methods
        public void HungryKick()
        {
            this._healthPoints--;
            change?.Invoke(this, HealthPoints);
        }

        public void UseFork(int foodHealthPoints)
        {
            Thread.Sleep(1000);
            this.HealthPoints += foodHealthPoints;
            change?.Invoke(this, HealthPoints);
        }


        public void PrintHealth(Action action)
        {
            action();
        }
        public void GetFork(List<Fork> forks)
        {
            //lock (locker)
            //  {
            foreach (var v in forks)
            {
                if (!Monitor.TryEnter(v))
                {
                    continue;
                }
                else
                {

                    if (this.LeftFork == null && v.IsUsing == false)
                    {
                        this.LeftFork = v;
                        this.LeftFork.IsUsing = true;
                        continue;
                    }
                    lock (LeftFork)
                    {
                        if (this.RightFork == null && v.IsUsing == false)
                        {
                            this.RightFork = v;
                            this.RightFork.IsUsing = true;
                        }
                        lock (RightFork)
                        {
                            if (RightFork != null && LeftFork != null)
                            {
                                this.UseFork(HealingPoints);
                                this.LeftFork.IsUsing = false;
                                this.RightFork.IsUsing = false;
                                this.LeftFork = null;
                                this.RightFork = null;
                                break;
                            }
                        }
                    }
                }

                //  }
            }
        }

        #endregion
    }
}
