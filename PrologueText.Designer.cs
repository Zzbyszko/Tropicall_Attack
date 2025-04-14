namespace Projekt_JPWP
{
    partial class PrologueText
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
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(162, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 250);
            this.label1.TabIndex = 5;
            this.label1.Text = "TEXT";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 16.2F);
            this.button3.Location = new System.Drawing.Point(437, 420);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 80);
            this.button3.TabIndex = 6;
            this.button3.Text = "Zamknij";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PrologueText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "PrologueText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prologue";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
    }
}