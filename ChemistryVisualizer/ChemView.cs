using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChemistryVisualizer
{
    public partial class ChemView : Form
    {
        public LewisDot LewisDotStructure { get; set; }

        public ChemView()
        {
            InitializeComponent();
        }

        private void ProcessFormulaButton_Click(object sender, EventArgs e)
        {
            LewisDotStructure = new LewisDot(FormulaText.Text);
            Invalidate();
            Update();
        }

        private void ChemView_Paint(object sender, PaintEventArgs e)
        {
            if (LewisDotStructure != null)
            {
                LewisDotStructure.Draw(
                    e.Graphics, 
                    Width / 2 - (50 * (LewisDotStructure.Elements.Count - 1)), 
                    Height / 2
                    );
            }
        }
    }
}
