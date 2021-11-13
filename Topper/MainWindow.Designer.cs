
namespace Topper
{
    partial class MainWindow
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
            this.BtnSwitchHotkeys = new System.Windows.Forms.Button();
            this.MakeTopMostLabel = new System.Windows.Forms.Label();
            this.UnmakeTopMostLabel = new System.Windows.Forms.Label();
            this.BtnMakeTopMost = new System.Windows.Forms.Button();
            this.BtnUnmakeTopMost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSwitchHotkeys
            // 
            this.BtnSwitchHotkeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSwitchHotkeys.Location = new System.Drawing.Point(12, 164);
            this.BtnSwitchHotkeys.Name = "BtnSwitchHotkeys";
            this.BtnSwitchHotkeys.Size = new System.Drawing.Size(180, 30);
            this.BtnSwitchHotkeys.TabIndex = 3;
            this.BtnSwitchHotkeys.Text = "Active";
            this.BtnSwitchHotkeys.UseVisualStyleBackColor = true;
            this.BtnSwitchHotkeys.Click += new System.EventHandler(this.BtnSwitchHotkeys_Click);
            // 
            // MakeTopMostLabel
            // 
            this.MakeTopMostLabel.AutoSize = true;
            this.MakeTopMostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MakeTopMostLabel.Location = new System.Drawing.Point(12, 9);
            this.MakeTopMostLabel.Name = "MakeTopMostLabel";
            this.MakeTopMostLabel.Size = new System.Drawing.Size(122, 20);
            this.MakeTopMostLabel.TabIndex = 4;
            this.MakeTopMostLabel.Text = "Make Top Most:";
            // 
            // UnmakeTopMostLabel
            // 
            this.UnmakeTopMostLabel.AutoSize = true;
            this.UnmakeTopMostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnmakeTopMostLabel.Location = new System.Drawing.Point(12, 74);
            this.UnmakeTopMostLabel.Name = "UnmakeTopMostLabel";
            this.UnmakeTopMostLabel.Size = new System.Drawing.Size(143, 20);
            this.UnmakeTopMostLabel.TabIndex = 5;
            this.UnmakeTopMostLabel.Text = "Unmake Top Most:";
            // 
            // BtnMakeTopMost
            // 
            this.BtnMakeTopMost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMakeTopMost.Location = new System.Drawing.Point(12, 34);
            this.BtnMakeTopMost.Name = "BtnMakeTopMost";
            this.BtnMakeTopMost.Size = new System.Drawing.Size(180, 30);
            this.BtnMakeTopMost.TabIndex = 1;
            this.BtnMakeTopMost.Text = "Hotkey1";
            this.BtnMakeTopMost.UseVisualStyleBackColor = true;
            this.BtnMakeTopMost.Click += new System.EventHandler(this.BtnMakeTopMost_Click);
            // 
            // BtnUnmakeTopMost
            // 
            this.BtnUnmakeTopMost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUnmakeTopMost.Location = new System.Drawing.Point(12, 99);
            this.BtnUnmakeTopMost.Name = "BtnUnmakeTopMost";
            this.BtnUnmakeTopMost.Size = new System.Drawing.Size(180, 30);
            this.BtnUnmakeTopMost.TabIndex = 2;
            this.BtnUnmakeTopMost.Text = "Hotkey2";
            this.BtnUnmakeTopMost.UseVisualStyleBackColor = true;
            this.BtnUnmakeTopMost.Click += new System.EventHandler(this.BtnUnmakeTopMost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hotkey Status:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnUnmakeTopMost);
            this.Controls.Add(this.BtnMakeTopMost);
            this.Controls.Add(this.UnmakeTopMostLabel);
            this.Controls.Add(this.MakeTopMostLabel);
            this.Controls.Add(this.BtnSwitchHotkeys);
            this.Name = "MainWindow";
            this.Text = "Topper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSwitchHotkeys;
        private System.Windows.Forms.Label MakeTopMostLabel;
        private System.Windows.Forms.Label UnmakeTopMostLabel;
        private System.Windows.Forms.Button BtnMakeTopMost;
        private System.Windows.Forms.Button BtnUnmakeTopMost;
        private System.Windows.Forms.Label label1;
    }
}

