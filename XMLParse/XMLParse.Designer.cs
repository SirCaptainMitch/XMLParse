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
            this.txtResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(16, 155);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(112, 37);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtIn
            // 
            this.txtIn.Location = new System.Drawing.Point(16, 75);
            this.txtIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(447, 22);
            this.txtIn.TabIndex = 1;
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btnGetFiles.Location = new System.Drawing.Point(485, 74);
            this.btnGetFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(50, 25);
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
            "Backgrounds",
            "Classes",
            "Feats",
            "Items",
            "Monsters",
            "Races",
            "Spells",
            "Characters"});
            this.cboType.Location = new System.Drawing.Point(16, 26);
            this.cboType.Margin = new System.Windows.Forms.Padding(4);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(447, 24);
            this.cboType.TabIndex = 3;
            // 
            // btnOut
            // 
            this.btnOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.btnOut.Location = new System.Drawing.Point(485, 120);
            this.btnOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(50, 25);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "...";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(16, 123);
            this.txtOut.Margin = new System.Windows.Forms.Padding(4);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(447, 22);
            this.txtOut.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "OutPath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "FilePath";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "FileTpe";
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(20, 199);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(658, 380);
            this.txtResults.TabIndex = 9;
            // 
            // XMLParse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 597);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.txtIn);
            this.Controls.Add(this.btnGo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XMLParse";
            this.Text = "XML Parser";
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
        private System.Windows.Forms.TextBox txtResults;
    }
}

