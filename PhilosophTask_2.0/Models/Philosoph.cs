using System;
using System.Collections.Generic;
using System.Text;

namespace PhilosophTask_2._0
{
    enum PhilosophStatus
    {
        hungry,
        dead
    }

    class Philosoph
    {
        /// <summary>
        /// Show the philosopher status
        /// </summary>
        public PhilosophStatus PhilosophStatus { get; set; }
        public string PhilosopherName { get; set; }
        public int Heatpoint { get; set; }
        public int Id { get; set; }

        public void Heal(int healingpoint)
        {
            this.Heatpoint++;
        }

        public void HeatPointKick(int kickPoints)
        {
            this.Heatpoint -= kickPoints;
        }


    }
}
