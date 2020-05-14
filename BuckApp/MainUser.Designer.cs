namespace BuckApp
{
    partial class MainUser
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
            this.tbCity = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultGraphicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewEvent = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumPart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumPartMax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIdUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Categoria";
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(62, 34);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(100, 20);
            this.tbCity.TabIndex = 2;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(264, 33);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbCategory.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(433, 32);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(80, 23);
            this.btSearch.TabIndex = 4;
            this.btSearch.Text = "Buscar";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.cargarListViewConFiltro);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.eventsToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultProfileToolStripMenuItem,
            this.consultGraphicToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.userToolStripMenuItem.Text = "Usuario";
            // 
            // consultProfileToolStripMenuItem
            // 
            this.consultProfileToolStripMenuItem.Name = "consultProfileToolStripMenuItem";
            this.consultProfileToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.consultProfileToolStripMenuItem.Text = "Consultar perfil";
            this.consultProfileToolStripMenuItem.Click += new System.EventHandler(this.consultProfileToolStripMenuItem_Click);
            // 
            // consultGraphicToolStripMenuItem
            // 
            this.consultGraphicToolStripMenuItem.Name = "consultGraphicToolStripMenuItem";
            this.consultGraphicToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.consultGraphicToolStripMenuItem.Text = "Consultar grafico de animo";
            // 
            // eventsToolStripMenuItem
            // 
            this.eventsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEventToolStripMenuItem});
            this.eventsToolStripMenuItem.Name = "eventsToolStripMenuItem";
            this.eventsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.eventsToolStripMenuItem.Text = "Eventos";
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addEventToolStripMenuItem.Text = "Añadir evento";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
            // 
            // listViewEvent
            // 
            this.listViewEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnDescripcion,
            this.columnLocation,
            this.columnDate,
            this.columnNumPart,
            this.columnNumPartMax,
            this.columnType,
            this.columnIdUser});
            this.listViewEvent.FullRowSelect = true;
            this.listViewEvent.GridLines = true;
            this.listViewEvent.HideSelection = false;
            this.listViewEvent.Location = new System.Drawing.Point(19, 61);
            this.listViewEvent.Name = "listViewEvent";
            this.listViewEvent.Size = new System.Drawing.Size(825, 261);
            this.listViewEvent.TabIndex = 6;
            this.listViewEvent.UseCompatibleStateImageBehavior = false;
            this.listViewEvent.View = System.Windows.Forms.View.Details;
            this.listViewEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewEvent_MouseClick);
            // 
            // columnName
            // 
            this.columnName.Text = "Nombre";
            this.columnName.Width = 120;
            // 
            // columnDescripcion
            // 
            this.columnDescripcion.Text = "Descripcion";
            this.columnDescripcion.Width = 150;
            // 
            // columnLocation
            // 
            this.columnLocation.Text = "Localidad";
            this.columnLocation.Width = 80;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Fecha";
            this.columnDate.Width = 80;
            // 
            // columnNumPart
            // 
            this.columnNumPart.Text = "N º participantes";
            this.columnNumPart.Width = 120;
            // 
            // columnNumPartMax
            // 
            this.columnNumPartMax.Text = "N º max  participantes";
            this.columnNumPartMax.Width = 120;
            // 
            // columnType
            // 
            this.columnType.Text = "Tipo";
            this.columnType.Width = 80;
            // 
            // columnIdUser
            // 
            this.columnIdUser.Text = "Id_user";
            this.columnIdUser.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Mis Actividades";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.listarActividadesDeUnaPersona);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // MainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 346);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewEvent);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainUser";
            this.Text = "PantallaPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultGraphicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private System.Windows.Forms.ListView listViewEvent;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnDescripcion;
        private System.Windows.Forms.ColumnHeader columnLocation;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.ColumnHeader columnNumPartMax;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnNumPart;
        private System.Windows.Forms.ColumnHeader columnIdUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
    }
}