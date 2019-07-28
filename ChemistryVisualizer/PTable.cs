using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryVisualizer
{
    static class PTable
    {
        public static List<Element> Elements
        {
            get
            {
                return new List<Element> {
                    new Element
                    {
                        Name = "Hydrogen",
                        Symbol = "H",
                        Protons = 1,
                        Electrons = 1,
                        Period = 1
                    },
                    new Element
                    {
                        Name = "Helium",
                        Symbol = "He",
                        Protons = 2,
                        Electrons = 2,
                        Period = 2
                    }
                };
            }
        }

        public static Element GetElement(string symbol)
        {
            return (from element in Elements
                    where element.Symbol == symbol
                    select element).FirstOrDefault();
        }
    }
}
