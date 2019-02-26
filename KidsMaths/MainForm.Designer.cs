namespace KidsMaths
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblOperator = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.txtFirstNumber = new System.Windows.Forms.TextBox();
            this.txtSecondNumber = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.txtPlus = new System.Windows.Forms.TextBox();
            this.txtMinus = new System.Windows.Forms.TextBox();
            this.sstStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslNumberOfQuestionsAnswered = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslNumWrongAnswers = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnWrong = new System.Windows.Forms.Button();
            this.lblEquals = new System.Windows.Forms.Label();
            this.txtHalfOf = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sstStatusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 76F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(199, 43);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(109, 115);
            this.lblOperator.TabIndex = 1;
            this.lblOperator.Text = "+";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(161, 184);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(186, 81);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswer.Location = new System.Drawing.Point(385, 184);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(186, 81);
            this.btnAnswer.TabIndex = 4;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // txtFirstNumber
            // 
            this.txtFirstNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 76F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstNumber.Location = new System.Drawing.Point(40, 43);
            this.txtFirstNumber.Name = "txtFirstNumber";
            this.txtFirstNumber.Size = new System.Drawing.Size(170, 122);
            this.txtFirstNumber.TabIndex = 6;
            this.txtFirstNumber.TabStop = false;
            this.txtFirstNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSecondNumber
            // 
            this.txtSecondNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 76F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondNumber.Location = new System.Drawing.Point(280, 43);
            this.txtSecondNumber.Name = "txtSecondNumber";
            this.txtSecondNumber.Size = new System.Drawing.Size(170, 122);
            this.txtSecondNumber.TabIndex = 7;
            this.txtSecondNumber.TabStop = false;
            this.txtSecondNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 76F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(522, 43);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(170, 122);
            this.txtAnswer.TabIndex = 8;
            this.txtAnswer.TabStop = false;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnswer.Visible = false;
            // 
            // txtPlus
            // 
            this.txtPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlus.Location = new System.Drawing.Point(506, 291);
            this.txtPlus.Name = "txtPlus";
            this.txtPlus.Size = new System.Drawing.Size(83, 83);
            this.txtPlus.TabIndex = 9;
            this.txtPlus.TabStop = false;
            this.txtPlus.Text = "+";
            this.txtPlus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlus.Click += new System.EventHandler(this.txtPlus_Click);
            // 
            // txtMinus
            // 
            this.txtMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinus.Location = new System.Drawing.Point(609, 291);
            this.txtMinus.Name = "txtMinus";
            this.txtMinus.Size = new System.Drawing.Size(83, 83);
            this.txtMinus.TabIndex = 10;
            this.txtMinus.TabStop = false;
            this.txtMinus.Text = "-";
            this.txtMinus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinus.Click += new System.EventHandler(this.txtMinus_Click);
            // 
            // sstStatusStrip
            // 
            this.sstStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.sslNumberOfQuestionsAnswered,
            this.toolStripStatusLabel2,
            this.sslNumWrongAnswers});
            this.sstStatusStrip.Location = new System.Drawing.Point(0, 395);
            this.sstStatusStrip.Name = "sstStatusStrip";
            this.sstStatusStrip.Size = new System.Drawing.Size(737, 22);
            this.sstStatusStrip.TabIndex = 11;
            this.sstStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 17);
            this.toolStripStatusLabel1.Text = "Number of Questions Answered:";
            // 
            // sslNumberOfQuestionsAnswered
            // 
            this.sslNumberOfQuestionsAnswered.Name = "sslNumberOfQuestionsAnswered";
            this.sslNumberOfQuestionsAnswered.Size = new System.Drawing.Size(13, 17);
            this.sslNumberOfQuestionsAnswered.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel2.Text = "Wrong Answer List:";
            this.toolStripStatusLabel2.Visible = false;
            // 
            // sslNumWrongAnswers
            // 
            this.sslNumWrongAnswers.Name = "sslNumWrongAnswers";
            this.sslNumWrongAnswers.Size = new System.Drawing.Size(13, 17);
            this.sslNumWrongAnswers.Text = "0";
            this.sslNumWrongAnswers.Visible = false;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(40, 205);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 81);
            this.btnRight.TabIndex = 12;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Visible = false;
            // 
            // btnWrong
            // 
            this.btnWrong.Location = new System.Drawing.Point(121, 205);
            this.btnWrong.Name = "btnWrong";
            this.btnWrong.Size = new System.Drawing.Size(75, 81);
            this.btnWrong.TabIndex = 13;
            this.btnWrong.Text = "Wrong";
            this.btnWrong.UseVisualStyleBackColor = true;
            this.btnWrong.Visible = false;
            this.btnWrong.Click += new System.EventHandler(this.btnWrong_Click);
            // 
            // lblEquals
            // 
            this.lblEquals.AutoSize = true;
            this.lblEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 76F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquals.Location = new System.Drawing.Point(437, 43);
            this.lblEquals.Name = "lblEquals";
            this.lblEquals.Size = new System.Drawing.Size(109, 115);
            this.lblEquals.TabIndex = 14;
            this.lblEquals.Text = "=";
            this.lblEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHalfOf
            // 
            this.txtHalfOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHalfOf.Location = new System.Drawing.Point(40, 55);
            this.txtHalfOf.Name = "txtHalfOf";
            this.txtHalfOf.Size = new System.Drawing.Size(410, 98);
            this.txtHalfOf.TabIndex = 17;
            this.txtHalfOf.TabStop = false;
            this.txtHalfOf.Text = "Half of ";
            this.txtHalfOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 417);
            this.Controls.Add(this.btnWrong);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.sstStatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtMinus);
            this.Controls.Add(this.txtPlus);
            this.Controls.Add(this.txtSecondNumber);
            this.Controls.Add(this.txtFirstNumber);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.txtHalfOf);
            this.Controls.Add(this.lblEquals);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matthew and Rebecca Maths";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sstStatusStrip.ResumeLayout(false);
            this.sstStatusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.TextBox txtFirstNumber;
        private System.Windows.Forms.TextBox txtSecondNumber;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.TextBox txtPlus;
        private System.Windows.Forms.TextBox txtMinus;
        private System.Windows.Forms.StatusStrip sstStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel sslNumberOfQuestionsAnswered;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnWrong;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel sslNumWrongAnswers;
        private System.Windows.Forms.Label lblEquals;
        private System.Windows.Forms.TextBox txtHalfOf;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

