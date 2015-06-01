namespace XMLParse
{
    partial class XMLParse
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtIn = new System.Windows.Forms.TextBox();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 126);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(113, 42);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtIn
            // 
            this.txtIn.Location = new System.Drawing.Point(12, 61);
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(270, 20);
            this.txtIn.TabIndex = 1;
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btnGetFiles.Location = new System.Drawing.Point(288, 60);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(48, 20);
            this.btnGetFiles.TabIndex = 2;
            this.btnGetFiles.Text = "...";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // cboType
            // 
            this.cboType.AutoCompleteCustomSource.AddRange(new string[] {
            "Race",
            "Class",
            "Spells",
            "Monster"});
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Race",
            "Class",
            "Spell",
            "Monster"});
            this.cboType.Location = new System.Drawing.Point(12, 21);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(113, 21);
            this.cboType.TabIndex = 3;
            // 
            // btnOut
            // 
            this.btnOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btnOut.Location = new System.Drawing.Point(288, 99);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(48, 20);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "...";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(12, 100);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(270, 20);
            this.txtOut.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "OutPath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "FilePath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "FileTpe";
            // 
            // XMLParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 180);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.txtIn);
            this.Controls.Add(this.btnGo);
            this.Name = "XMLParse";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

