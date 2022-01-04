namespace RMSMENUIMPORT
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlmain = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.txtexcelfilepath = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnldata = new System.Windows.Forms.Panel();
            this.dtgdata = new System.Windows.Forms.DataGridView();
            this.pnlmain.SuspendLayout();
            this.pnldata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgdata)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlmain
            // 
            this.pnlmain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlmain.Controls.Add(this.label2);
            this.pnlmain.Controls.Add(this.btnbrowse);
            this.pnlmain.Controls.Add(this.txtexcelfilepath);
            this.pnlmain.Controls.Add(this.btnclear);
            this.pnlmain.Controls.Add(this.btnshow);
            this.pnlmain.Controls.Add(this.btnimport);
            this.pnlmain.Controls.Add(this.button2);
            this.pnlmain.Controls.Add(this.button4);
            this.pnlmain.Controls.Add(this.button1);
            this.pnlmain.Controls.Add(this.label1);
            this.pnlmain.Location = new System.Drawing.Point(1, 3);
            this.pnlmain.Name = "pnlmain";
            this.pnlmain.Size = new System.Drawing.Size(496, 139);
            this.pnlmain.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Menu (.xls File)";
            // 
            // btnbrowse
            // 
            this.btnbrowse.ForeColor = System.Drawing.Color.Blue;
            this.btnbrowse.Location = new System.Drawing.Point(418, 70);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(65, 26);
            this.btnbrowse.TabIndex = 3;
            this.btnbrowse.Text = ". . .";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // txtexcelfilepath
            // 
            this.txtexcelfilepath.Location = new System.Drawing.Point(8, 71);
            this.txtexcelfilepath.Name = "txtexcelfilepath";
            this.txtexcelfilepath.ReadOnly = true;
            this.txtexcelfilepath.Size = new System.Drawing.Size(405, 25);
            this.txtexcelfilepath.TabIndex = 2;
            // 
            // btnclear
            // 
            this.btnclear.ForeColor = System.Drawing.Color.Red;
            this.btnclear.Location = new System.Drawing.Point(91, 99);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(80, 31);
            this.btnclear.TabIndex = 1;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnshow
            // 
            this.btnshow.ForeColor = System.Drawing.Color.Blue;
            this.btnshow.Location = new System.Drawing.Point(8, 98);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(80, 31);
            this.btnshow.TabIndex = 1;
            this.btnshow.Text = "Show";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnimport
            // 
            this.btnimport.ForeColor = System.Drawing.Color.Green;
            this.btnimport.Location = new System.Drawing.Point(333, 100);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(80, 31);
            this.btnimport.TabIndex = 1;
            this.btnimport.Text = "Import";
            this.btnimport.UseVisualStyleBackColor = true;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(385, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Hide All Item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(270, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 31);
            this.button4.TabIndex = 1;
            this.button4.Text = "Delete All Group";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete All Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMPORT MENU";
            // 
            // pnldata
            // 
            this.pnldata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnldata.Controls.Add(this.dtgdata);
            this.pnldata.Location = new System.Drawing.Point(1, 146);
            this.pnldata.Name = "pnldata";
            this.pnldata.Size = new System.Drawing.Size(496, 344);
            this.pnldata.TabIndex = 1;
            // 
            // dtgdata
            // 
            this.dtgdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgdata.ColumnHeadersVisible = false;
            this.dtgdata.Location = new System.Drawing.Point(3, 3);
            this.dtgdata.MultiSelect = false;
            this.dtgdata.Name = "dtgdata";
            this.dtgdata.RowHeadersVisible = false;
            this.dtgdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgdata.Size = new System.Drawing.Size(488, 336);
            this.dtgdata.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(500, 497);
            this.Controls.Add(this.pnldata);
            this.Controls.Add(this.pnlmain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPORT MENU";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlmain.ResumeLayout(false);
            this.pnlmain.PerformLayout();
            this.pnldata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlmain;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.TextBox txtexcelfilepath;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Panel pnldata;
        private System.Windows.Forms.DataGridView dtgdata;
        private System.Windows.Forms.Button btnclear;
    }
}

