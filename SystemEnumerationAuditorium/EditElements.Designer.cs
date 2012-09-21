namespace SystemEnumerationAuditorium {
  partial class EditElements {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private readonly System.ComponentModel.IContainer _components;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (_components != null)) {
        _components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.list = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Add = new System.Windows.Forms.Button();
			this.Edit = new System.Windows.Forms.Button();
			this.Delete = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.list);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Size = new System.Drawing.Size(306, 266);
			this.splitContainer1.SplitterDistance = 230;
			this.splitContainer1.TabIndex = 0;
			// 
			// list
			// 
			this.list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.list.FormattingEnabled = true;
			this.list.Location = new System.Drawing.Point(0, 0);
			this.list.Name = "list";
			this.list.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.list.Size = new System.Drawing.Size(306, 225);
			this.list.Sorted = true;
			this.list.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.Add, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.Edit, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.Delete, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 32);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// Add
			// 
			this.Add.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Add.Location = new System.Drawing.Point(3, 3);
			this.Add.Name = "Add";
			this.Add.Size = new System.Drawing.Size(96, 26);
			this.Add.TabIndex = 0;
			this.Add.Text = "Добавить";
			this.Add.UseVisualStyleBackColor = true;
			this.Add.Click += new System.EventHandler(this.Add_Click);
			// 
			// Edit
			// 
			this.Edit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Edit.Location = new System.Drawing.Point(105, 3);
			this.Edit.Name = "Edit";
			this.Edit.Size = new System.Drawing.Size(96, 26);
			this.Edit.TabIndex = 1;
			this.Edit.Text = "Редактировать";
			this.Edit.UseVisualStyleBackColor = true;
			this.Edit.Click += new System.EventHandler(this.Edit_Click);
			// 
			// Delete
			// 
			this.Delete.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Delete.Location = new System.Drawing.Point(207, 3);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(96, 26);
			this.Delete.TabIndex = 2;
			this.Delete.Text = "Удалить";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// EditElements
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(306, 266);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "EditElements";
			this.Text = "Редактирование";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ListBox list;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button Add;
    private System.Windows.Forms.Button Edit;
    private System.Windows.Forms.Button Delete;
  }
}