using System;
using System.Collections.Generic;
using System.Text;

namespace PhilosophTask_2._0
{
    class Fork
    {
        public Fork(bool isUsed, int id)
        {
            this.isUsed = isUsed;
            Id = id;
        }

        public bool isUsed { get; set; }
        public int Id { get; set; }
    }
}
