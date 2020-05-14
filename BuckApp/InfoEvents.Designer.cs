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
            this.tbLocalidad = new System.Windows.Forms.TextBox();
            this.tbNInscritos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMaxParticipantes = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Localidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nº inscristos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo";
            // 
            // btRegisterEvent
            // 
            this.btRegisterEvent.Location = new System.Drawing.Point(52, 258);
            this.btRegisterEvent.Name = "btRegisterEvent";
            this.btRegisterEvent.Size = new System.Drawing.Size(86, 23);
            this.btRegisterEvent.TabIndex = 6;
            this.btRegisterEvent.Text = "Register Event";
            this.btRegisterEvent.UseVisualStyleBackColor = true;
            this.btRegisterEvent.Click += new System.EventHandler(this.registerEvent);
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(178, 258);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(75, 23);
            this.btModify.TabIndex = 7;
            this.btModify.Text = "Modify";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.modifyEvent);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(284, 258);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.deleteEventClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(159, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 20);
            this.tbName.TabIndex = 9;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(159, 60);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(200, 34);
            this.tbDescription.TabIndex = 10;
            // 
            // tbLocalidad
            // 
            this.tbLocalidad.Location = new System.Drawing.Point(159, 104);
            this.tbLocalidad.Name = "tbLocalidad";
            this.tbLocalidad.Size = new System.Drawing.Size(200, 20);
            this.tbLocalidad.TabIndex = 11;
            // 
            // tbNInscritos
            // 
            this.tbNInscritos.Location = new System.Drawing.Point(159, 158);
            this.tbNInscritos.Name = "tbNInscritos";
            this.tbNInscritos.Size = new System.Drawing.Size(200, 20);
            this.tbNInscritos.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Nº max participantes";
            // 
            // tbMaxParticipantes
            // 
            this.tbMaxParticipantes.Location = new System.Drawing.Point(159, 188);
            this.tbMaxParticipantes.Name = "tbMaxParticipantes";
            this.tbMaxParticipantes.Size = new System.Drawing.Size(200, 20);
            this.tbMaxParticipantes.TabIndex = 16;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "MMMMdd, yyyy  |  hh:mm:ss";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(159, 131);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 17;
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(159, 216);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(200, 21);
            this.cbTipo.TabIndex = 18;
            // 
            // InfoEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 301);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.tbMaxParticipantes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbNInscritos);
            this.Controls.Add(this.tbLocalidad);
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
            this.Name = "InfoEvents";
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
        private System.Windows.Forms.TextBox tbLocalidad;
        private System.Windows.Forms.TextBox tbNInscritos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMaxParticipantes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbTipo;
    }
}