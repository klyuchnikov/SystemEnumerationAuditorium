namespace SystemEnumerationAuditorium
{
    partial class Viewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PodElemLabel = new System.Windows.Forms.Label();
            this.PodElem = new System.Windows.Forms.ComboBox();
            this.Period = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Elem = new System.Windows.Forms.ComboBox();
            this.ElemLabel = new System.Windows.Forms.Label();
            this.Main = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Shcedule = new System.Windows.Forms.DataGridView();
            this.day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Shcedule)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.PodElemLabel);
            this.splitContainer2.Panel1.Controls.Add(this.PodElem);
            this.splitContainer2.Panel1.Controls.Add(this.Period);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.Elem);
            this.splitContainer2.Panel1.Controls.Add(this.ElemLabel);
            this.splitContainer2.Panel1.Controls.Add(this.Main);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Shcedule);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(925, 435);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 1;
            // 
            // PodElemLabel
            // 
            this.PodElemLabel.Location = new System.Drawing.Point(195, 3);
            this.PodElemLabel.Name = "PodElemLabel";
            this.PodElemLabel.Size = new System.Drawing.Size(111, 23);
            this.PodElemLabel.TabIndex = 7;
            this.PodElemLabel.Text = "label2";
            this.PodElemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PodElemLabel.Visible = false;
            // 
            // PodElem
            // 
            this.PodElem.DropDownHeight = 300;
            this.PodElem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PodElem.FormattingEnabled = true;
            this.PodElem.IntegralHeight = false;
            this.PodElem.Location = new System.Drawing.Point(312, 3);
            this.PodElem.Name = "PodElem";
            this.PodElem.Size = new System.Drawing.Size(121, 21);
            this.PodElem.Sorted = true;
            this.PodElem.TabIndex = 6;
            this.PodElem.Visible = false;
            this.PodElem.SelectedIndexChanged += new System.EventHandler(this.PodElem_SelectedIndexChanged);
            // 
            // Period
            // 
            this.Period.DropDownHeight = 300;
            this.Period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Period.Enabled = false;
            this.Period.FormattingEnabled = true;
            this.Period.IntegralHeight = false;
            this.Period.Location = new System.Drawing.Point(739, 3);
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(121, 21);
            this.Period.TabIndex = 5;
            this.Period.SelectedIndexChanged += new System.EventHandler(this.Period_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(688, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Неделя";
            // 
            // Elem
            // 
            this.Elem.DropDownHeight = 300;
            this.Elem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Elem.Enabled = false;
            this.Elem.FormattingEnabled = true;
            this.Elem.IntegralHeight = false;
            this.Elem.Location = new System.Drawing.Point(546, 3);
            this.Elem.Name = "Elem";
            this.Elem.Size = new System.Drawing.Size(121, 21);
            this.Elem.Sorted = true;
            this.Elem.TabIndex = 3;
            this.Elem.SelectedIndexChanged += new System.EventHandler(this.Elem_SelectedIndexChanged);
            // 
            // ElemLabel
            // 
            this.ElemLabel.Location = new System.Drawing.Point(440, 1);
            this.ElemLabel.Name = "ElemLabel";
            this.ElemLabel.Size = new System.Drawing.Size(100, 23);
            this.ElemLabel.TabIndex = 2;
            this.ElemLabel.Text = "Содержимое";
            this.ElemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Main
            // 
            this.Main.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Main.FormattingEnabled = true;
            this.Main.Items.AddRange(new object[] {
            "Преподаватели",
            "Аудитории",
            "Группы"});
            this.Main.Location = new System.Drawing.Point(68, 3);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(121, 21);
            this.Main.TabIndex = 1;
            this.Main.SelectedIndexChanged += new System.EventHandler(this.Main_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вкладка";
            // 
            // Shcedule
            // 
            this.Shcedule.AllowDrop = true;
            this.Shcedule.AllowUserToAddRows = false;
            this.Shcedule.AllowUserToDeleteRows = false;
            this.Shcedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Shcedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.day,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.Shcedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Shcedule.Location = new System.Drawing.Point(0, 0);
            this.Shcedule.MultiSelect = false;
            this.Shcedule.Name = "Shcedule";
            this.Shcedule.ReadOnly = true;
            this.Shcedule.RowHeadersWidth = 10;
            this.Shcedule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Shcedule.Size = new System.Drawing.Size(925, 406);
            this.Shcedule.TabIndex = 2;
            this.Shcedule.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Shcedule_CellPainting);
            this.Shcedule.Resize += new System.EventHandler(this.Shcedule_Resize);
            // 
            // day
            // 
            this.day.Frozen = true;
            this.day.HeaderText = "Дни недели";
            this.day.Name = "day";
            this.day.ReadOnly = true;
            this.day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "1 пара";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "2 пара";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "3 пара";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "4 пара";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "5 пара";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "6 пара";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "7 пара";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "8 пара";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "Viewer";
            this.Size = new System.Drawing.Size(925, 435);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Shcedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label PodElemLabel;
        private System.Windows.Forms.ComboBox PodElem;
        private System.Windows.Forms.ComboBox Period;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Elem;
        private System.Windows.Forms.Label ElemLabel;
        private System.Windows.Forms.ComboBox Main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public System.Windows.Forms.DataGridView Shcedule;
    }
}
