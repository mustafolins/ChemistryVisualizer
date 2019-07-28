using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryVisualizer
{
    public class Element
    {
        public int Protons { get; set; }
        public int Electrons { get; set; }
        public int Neutrons { get; set; }
        public int Period { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Valence
        {
            get
            {
                return Protons % 10;
            }
        }
    }
}
