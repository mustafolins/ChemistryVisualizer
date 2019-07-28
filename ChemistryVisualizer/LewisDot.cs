using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryVisualizer
{
    public class LewisDot
    {
        public List<Element> Elements { get; set; } = new List<Element>();
        public int SymbolSize { get; set; } = 20;

        public LewisDot(string formula)
        {
            for (int i = 0; i < formula.Length; i++)
            {
                if (char.IsDigit(formula[i]))
                {
                    AddExtraElements(formula, i);
                }
                else if (char.IsUpper(formula[i]))
                {
                    if (i + 1 == formula.Length && char.IsLower(formula[i]))
                    {
                        var symbol = formula.Substring(i, 2);
                        Elements.Add(PTable.GetElement(symbol));
                    }
                    else
                    {
                        var symbol = formula.Substring(i, 1);
                        Elements.Add(PTable.GetElement(symbol));
                    }
                }
            }
        }

        private void AddExtraElements(string formula, int i)
        {
            for (int j = 0; j < int.Parse("" + formula[i]) - 1; j++)
            {
                var lastElement = Elements.Last();
                Elements.Add(PTable.GetElement(lastElement.Symbol));
            }
        }

        public void Draw(Graphics g, int xOffset, int yOffset)
        {
            var mostBondable = ClosestToFour(Elements);
            DrawSymbol(g, xOffset, yOffset, mostBondable);

            // symbol has been drawn place holder
            var used = new bool[Elements.Count];
            used[Elements.IndexOf(mostBondable)] = true;

            // available valence electrons
            var availableValence = new int[Elements.Count];
            for (int i = 0; i < Elements.Count; i++)
            {
                availableValence[i] = Elements[i].Valence;
            }

            // bonds 
            var bonds = new int[Elements.Count];

            for (int i = 0; i < Elements.Count; i++)
            {
                // draw symbol
                if (!used[i])
                {
                    DrawSymbol(
                        g,
                        xOffset + ((i + 1) * SymbolSize * 2),
                        yOffset,
                        Elements[i]
                        );
                }
                // draw bond
                if (i > 0 && availableValence[i - 1] >= 1 && availableValence[i] >= 1)
                {
                    DrawBond(
                        g,
                        xOffset + (i * SymbolSize) + 5,
                        yOffset,
                        Elements[i]
                        );
                    availableValence[i]--;
                    availableValence[i - 1]--;
                    bonds[i]++;
                    bonds[i - 1]++;
                }
                // draw charge
                else
                {
                    DrawCharge(
                        g,
                        xOffset + ((i + 1) * SymbolSize * 2) + 5,
                        yOffset,
                        Elements[i],
                        availableValence[i],
                        bonds[i]
                        );
                }
            }
        }

        private void DrawCharge(Graphics g, int xOffset, int yOffset, Element element, int availableValence, int bonds)
        {
            var charge = element.Protons - (element.Electrons + bonds);
            if (charge == 0)
                return;

            g.DrawString(
                $"{Math.Abs(charge)}{((charge >= 0) ?"+":"-")}",
                new Font("Times", SymbolSize * 1.0f),
                Brushes.Black,
                xOffset,
                yOffset
                );
        }

        private void DrawBond(Graphics g, int xOffset, int yOffset, Element element)
        {
            g.DrawLine(
                Pens.Black,
                xOffset,
                yOffset + (SymbolSize / 3) * 2,
                xOffset + SymbolSize - 5,
                yOffset + (SymbolSize / 3) * 2
                );
        }

        private void DrawSymbol(Graphics g, int xOffset, int yOffset, Element mostBondable)
        {
            g.DrawString(mostBondable.Symbol, new Font("Times", SymbolSize * 1.0f), Brushes.Black, xOffset, yOffset);
        }

        private Element ClosestToFour(List<Element> elements)
        {
            return elements.Aggregate((x, y) => Math.Abs(x.Valence - 4) < Math.Abs(y.Valence - 4) ? x : y);
        }
    }
}
