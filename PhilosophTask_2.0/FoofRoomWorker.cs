using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PhilosophTask_2._0
{
    class FoofRoomWorker
    {
        private readonly List<Philosoph> _philosophs;
        private readonly List<Fork> _forks;

        public FoofRoomWorker(List<Philosoph> philosophs, List<Fork> forks)
        {
            _philosophs = philosophs;
            _forks = forks;
        }

        public List<Philosoph> Philosophs { get => _philosophs; }
        public  List<Fork> Forks { get => _forks; }

        public void FeedPhilosophWithLowestHp()
        {
            var minHealthPhilosoph = Philosophs.Aggregate<Philosoph>((min, x) => x.Heatpoint < min.Heatpoint ? x : min);
            Feed(minHealthPhilosoph);
        }
        public void Feed(Philosoph philosoph)
        {
            philosoph.Heal(1);
        }

        public void HungryKick(Philosoph philosoph)
        {
            philosoph.HeatPointKick(1);
        }
        
        public void Start(object obj)
        {

        }
    }
}
