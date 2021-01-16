
namespace Video_Integrity_Checker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSrc = new System.Windows.Forms.TextBox();
            this.txtFileTypes = new System.Windows.Forms.TextBox();
            this.btnBrowseSrc = new System.Windows.Forms.Button();
            this.chkMoveOkFiles = new System.Windows.Forms.CheckBox();
            this.txtOkFilesMove = new System.Windows.Forms.TextBox();
            this.btnBrowseOKFiles = new System.Windows.Forms.Button();
            this.btnBrowseFFMPEG = new System.Windows.Forms.Button();
            this.txtFF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblActivity = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOkFiles = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Types";
            // 
            // txtSrc
            // 
            this.txtSrc.Location = new System.Drawing.Point(102, 68);
            this.txtSrc.Multiline = true;
            this.txtSrc.Name = "txtSrc";
            this.txtSrc.Size = new System.Drawing.Size(362, 44);
            this.txtSrc.TabIndex = 2;
            this.txtSrc.Text = "D:\\vid test";
            // 
            // txtFileTypes
            // 
            this.txtFileTypes.Location = new System.Drawing.Point(102, 121);
            this.txtFileTypes.Multiline = true;
            this.txtFileTypes.Name = "txtFileTypes";
            this.txtFileTypes.Size = new System.Drawing.Size(195, 44);
            this.txtFileTypes.TabIndex = 3;
            this.txtFileTypes.Text = "avi,mp4,mkv";
            // 
            // btnBrowseSrc
            // 
            this.btnBrowseSrc.Location = new System.Drawing.Point(470, 66);
            this.btnBrowseSrc.Name = "btnBrowseSrc";
            this.btnBrowseSrc.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSrc.TabIndex = 4;
            this.btnBrowseSrc.Text = "Browse";
            this.btnBrowseSrc.UseVisualStyleBackColor = true;
            this.btnBrowseSrc.Click += new System.EventHandler(this.btnBrowseSrc_Click);
            // 
            // chkMoveOkFiles
            // 
            this.chkMoveOkFiles.AutoSize = true;
            this.chkMoveOkFiles.Location = new System.Drawing.Point(102, 180);
            this.chkMoveOkFiles.Name = "chkMoveOkFiles";
            this.chkMoveOkFiles.Size = new System.Drawing.Size(120, 17);
            this.chkMoveOkFiles.TabIndex = 5;
            this.chkMoveOkFiles.Text = "Move complete files";
            this.chkMoveOkFiles.UseVisualStyleBackColor = true;
            this.chkMoveOkFiles.CheckedChanged += new System.EventHandler(this.chkMoveOkFiles_CheckedChanged);
            // 
            // txtOkFilesMove
            // 
            this.txtOkFilesMove.Location = new System.Drawing.Point(102, 203);
            this.txtOkFilesMove.Multiline = true;
            this.txtOkFilesMove.Name = "txtOkFilesMove";
            this.txtOkFilesMove.Size = new System.Drawing.Size(362, 41);
            this.txtOkFilesMove.TabIndex = 6;
            // 
            // btnBrowseOKFiles
            // 
            this.btnBrowseOKFiles.Location = new System.Drawing.Point(470, 201);
            this.btnBrowseOKFiles.Name = "btnBrowseOKFiles";
            this.btnBrowseOKFiles.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOKFiles.TabIndex = 7;
            this.btnBrowseOKFiles.Text = "Browse";
            this.btnBrowseOKFiles.UseVisualStyleBackColor = true;
            this.btnBrowseOKFiles.Click += new System.EventHandler(this.btnBrowseOKFiles_Click);
            // 
            // btnBrowseFFMPEG
            // 
            this.btnBrowseFFMPEG.Location = new System.Drawing.Point(470, 10);
            this.btnBrowseFFMPEG.Name = "btnBrowseFFMPEG";
            this.btnBrowseFFMPEG.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFFMPEG.TabIndex = 10;
            this.btnBrowseFFMPEG.Text = "Browse";
            this.btnBrowseFFMPEG.UseVisualStyleBackColor = true;
            this.btnBrowseFFMPEG.Click += new System.EventHandler(this.btnBrowseFFMPEG_Click);
            // 
            // txtFF
            // 
            this.txtFF.Location = new System.Drawing.Point(102, 12);
            this.txtFF.Multiline = true;
            this.txtFF.Name = "txtFF";
            this.txtFF.ReadOnly = true;
            this.txtFF.Size = new System.Drawing.Size(362, 35);
            this.txtFF.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "FFMPEG";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(451, 260);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 62);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Activity";
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.Location = new System.Drawing.Point(156, 260);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(24, 13);
            this.lblActivity.TabIndex = 13;
            this.lblActivity.Text = "Idle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ok Files";
            // 
            // lblOkFiles
            // 
            this.lblOkFiles.AutoSize = true;
            this.lblOkFiles.Location = new System.Drawing.Point(156, 282);
            this.lblOkFiles.Name = "lblOkFiles";
            this.lblOkFiles.Size = new System.Drawing.Size(13, 13);
            this.lblOkFiles.TabIndex = 15;
            this.lblOkFiles.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(156, 305);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Total Files";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Threads";
            // 
            // nudThreads
            // 
            this.nudThreads.Location = new System.Drawing.Point(337, 283);
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(87, 20);
            this.nudThreads.TabIndex = 19;
            this.nudThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 344);
            this.Controls.Add(this.nudThreads);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblOkFiles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblActivity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowseFFMPEG);
            this.Controls.Add(this.txtFF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseOKFiles);
            this.Controls.Add(this.txtOkFilesMove);
            this.Controls.Add(this.chkMoveOkFiles);
            this.Controls.Add(this.btnBrowseSrc);
            this.Controls.Add(this.txtFileTypes);
            this.Controls.Add(this.txtSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Videos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSrc;
        private System.Windows.Forms.TextBox txtFileTypes;
        private System.Windows.Forms.Button btnBrowseSrc;
        private System.Windows.Forms.CheckBox chkMoveOkFiles;
        private System.Windows.Forms.TextBox txtOkFilesMove;
        private System.Windows.Forms.Button btnBrowseOKFiles;
        private System.Windows.Forms.Button btnBrowseFFMPEG;
        private System.Windows.Forms.TextBox txtFF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOkFiles;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudThreads;
    }
}

