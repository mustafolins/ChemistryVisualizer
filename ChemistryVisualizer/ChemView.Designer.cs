namespace ChemistryVisualizer
{
    partial class ChemView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormulaText = new System.Windows.Forms.TextBox();
            this.ProcessFormulaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormulaText
            // 
            this.FormulaText.Location = new System.Drawing.Point(303, 12);
            this.FormulaText.Name = "FormulaText";
            this.FormulaText.Size = new System.Drawing.Size(100, 20);
            this.FormulaText.TabIndex = 0;
            // 
            // ProcessFormulaButton
            // 
            this.ProcessFormulaButton.Location = new System.Drawing.Point(409, 12);
            this.ProcessFormulaButton.Name = "ProcessFormulaButton";
            this.ProcessFormulaButton.Size = new System.Drawing.Size(75, 23);
            this.ProcessFormulaButton.TabIndex = 1;
            this.ProcessFormulaButton.Text = "Process";
            this.ProcessFormulaButton.UseVisualStyleBackColor = true;
            this.ProcessFormulaButton.Click += new System.EventHandler(this.ProcessFormulaButton_Click);
            // 
            // ChemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProcessFormulaButton);
            this.Controls.Add(this.FormulaText);
            this.Name = "ChemView";
            this.Text = "Chemistry Visualizer";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChemView_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FormulaText;
        private System.Windows.Forms.Button ProcessFormulaButton;
    }
}

