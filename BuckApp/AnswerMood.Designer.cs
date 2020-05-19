namespace BuckApp
{
    partial class AnswerMood
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btVeryGood = new System.Windows.Forms.Button();
            this.btGood = new System.Windows.Forms.Button();
            this.btNormal = new System.Windows.Forms.Button();
            this.btBad = new System.Windows.Forms.Button();
            this.btVeryBad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿COMO TE SIENTES HOY?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Muy mal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Normal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bien";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Muy bien";
            // 
            // btVeryGood
            // 
            this.btVeryGood.FlatAppearance.BorderSize = 0;
            this.btVeryGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVeryGood.Image = global::BuckApp.Properties.Resources.happy_2;
            this.btVeryGood.Location = new System.Drawing.Point(387, 77);
            this.btVeryGood.Name = "btVeryGood";
            this.btVeryGood.Size = new System.Drawing.Size(83, 82);
            this.btVeryGood.TabIndex = 10;
            this.btVeryGood.UseVisualStyleBackColor = true;
            this.btVeryGood.Click += new System.EventHandler(this.Botones);
            // 
            // btGood
            // 
            this.btGood.FlatAppearance.BorderSize = 0;
            this.btGood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGood.Image = global::BuckApp.Properties.Resources.happy;
            this.btGood.Location = new System.Drawing.Point(298, 77);
            this.btGood.Name = "btGood";
            this.btGood.Size = new System.Drawing.Size(83, 82);
            this.btGood.TabIndex = 9;
            this.btGood.UseVisualStyleBackColor = true;
            this.btGood.Click += new System.EventHandler(this.Botones);
            // 
            // btNormal
            // 
            this.btNormal.FlatAppearance.BorderSize = 0;
            this.btNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNormal.Image = global::BuckApp.Properties.Resources.surprised;
            this.btNormal.Location = new System.Drawing.Point(209, 77);
            this.btNormal.Name = "btNormal";
            this.btNormal.Size = new System.Drawing.Size(83, 82);
            this.btNormal.TabIndex = 8;
            this.btNormal.UseVisualStyleBackColor = true;
            this.btNormal.Click += new System.EventHandler(this.Botones);
            // 
            // btBad
            // 
            this.btBad.FlatAppearance.BorderSize = 0;
            this.btBad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBad.Image = global::BuckApp.Properties.Resources.sad1;
            this.btBad.Location = new System.Drawing.Point(120, 77);
            this.btBad.Name = "btBad";
            this.btBad.Size = new System.Drawing.Size(83, 82);
            this.btBad.TabIndex = 7;
            this.btBad.UseVisualStyleBackColor = true;
            this.btBad.Click += new System.EventHandler(this.Botones);
            // 
            // btVeryBad
            // 
            this.btVeryBad.FlatAppearance.BorderSize = 0;
            this.btVeryBad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btVeryBad.Image = global::BuckApp.Properties.Resources.sad_2;
            this.btVeryBad.Location = new System.Drawing.Point(31, 77);
            this.btVeryBad.Name = "btVeryBad";
            this.btVeryBad.Size = new System.Drawing.Size(83, 82);
            this.btVeryBad.TabIndex = 6;
            this.btVeryBad.UseVisualStyleBackColor = true;
            this.btVeryBad.Click += new System.EventHandler(this.Botones);
            // 
            // AnswerMood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(496, 229);
            this.Controls.Add(this.btVeryGood);
            this.Controls.Add(this.btGood);
            this.Controls.Add(this.btNormal);
            this.Controls.Add(this.btBad);
            this.Controls.Add(this.btVeryBad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AnswerMood";
            this.Text = "AnswerMood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btVeryBad;
        private System.Windows.Forms.Button btBad;
        private System.Windows.Forms.Button btNormal;
        private System.Windows.Forms.Button btGood;
        private System.Windows.Forms.Button btVeryGood;
    }
}