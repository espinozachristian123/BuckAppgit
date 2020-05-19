namespace BuckApp
{
    partial class InfoEvents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoEvents));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btRegisterEvent = new System.Windows.Forms.Button();
            this.btModify = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.tbNEnroll = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMaxParticipants = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDirection = new System.Windows.Forms.TextBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.tbMood = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ciudad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nº inscristos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo";
            // 
            // btRegisterEvent
            // 
            this.btRegisterEvent.Location = new System.Drawing.Point(52, 457);
            this.btRegisterEvent.Name = "btRegisterEvent";
            this.btRegisterEvent.Size = new System.Drawing.Size(79, 35);
            this.btRegisterEvent.TabIndex = 6;
            this.btRegisterEvent.Text = "Registrarse a evento";
            this.btRegisterEvent.UseVisualStyleBackColor = true;
            this.btRegisterEvent.Click += new System.EventHandler(this.registerEvent);
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(155, 457);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(93, 35);
            this.btModify.TabIndex = 7;
            this.btModify.Text = "Modificar evento";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.modifyEvent);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.Crimson;
            this.btDelete.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.ForeColor = System.Drawing.Color.Yellow;
            this.btDelete.Location = new System.Drawing.Point(272, 457);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(87, 35);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "Borrar evento";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.deleteEventClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(159, 65);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 20);
            this.tbName.TabIndex = 9;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(159, 93);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(200, 34);
            this.tbDescription.TabIndex = 10;
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(159, 137);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(200, 20);
            this.tbCity.TabIndex = 11;
            // 
            // tbNEnroll
            // 
            this.tbNEnroll.Location = new System.Drawing.Point(159, 310);
            this.tbNEnroll.Name = "tbNEnroll";
            this.tbNEnroll.Size = new System.Drawing.Size(200, 20);
            this.tbNEnroll.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nº max participantes";
            // 
            // tbMaxParticipants
            // 
            this.tbMaxParticipants.Location = new System.Drawing.Point(159, 340);
            this.tbMaxParticipants.Name = "tbMaxParticipants";
            this.tbMaxParticipants.Size = new System.Drawing.Size(200, 20);
            this.tbMaxParticipants.TabIndex = 16;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MMMMdd, yyyy ";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(159, 206);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 17;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(159, 368);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(200, 21);
            this.cbType.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Direccion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Hora";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Duracion";
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(159, 171);
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(200, 20);
            this.tbDirection.TabIndex = 22;
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(159, 246);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(200, 20);
            this.tbTime.TabIndex = 23;
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(159, 278);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(200, 20);
            this.tbDuration.TabIndex = 24;
            // 
            // tbMood
            // 
            this.tbMood.Location = new System.Drawing.Point(159, 405);
            this.tbMood.Name = "tbMood";
            this.tbMood.Size = new System.Drawing.Size(200, 20);
            this.tbMood.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 411);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Estado de animo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(142, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = " Datos actividad";
            // 
            // InfoEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(411, 516);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbMood);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.tbMaxParticipants);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbNEnroll);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btModify);
            this.Controls.Add(this.btRegisterEvent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoEvents";
            this.Load += new System.EventHandler(this.InfoEvents_Load);
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
        private System.Windows.Forms.Button btRegisterEvent;
        private System.Windows.Forms.Button btModify;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbNEnroll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMaxParticipants;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbDirection;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.TextBox tbMood;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}