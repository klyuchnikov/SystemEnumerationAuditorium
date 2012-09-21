namespace SystemEnumerationAuditorium
{
  partial class ViewTwo
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
        this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        this.viewer1 = new SystemEnumerationAuditorium.Viewer();
        this.viewer2 = new SystemEnumerationAuditorium.Viewer();
        this.splitContainer1.Panel1.SuspendLayout();
        this.splitContainer1.Panel2.SuspendLayout();
        this.splitContainer1.SuspendLayout();
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
        this.splitContainer1.Panel1.Controls.Add(this.viewer1);
        // 
        // splitContainer1.Panel2
        // 
        this.splitContainer1.Panel2.Controls.Add(this.viewer2);
        this.splitContainer1.Size = new System.Drawing.Size(965, 549);
        this.splitContainer1.SplitterDistance = 274;
        this.splitContainer1.TabIndex = 0;
        // 
        // viewer1
        // 
        this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.viewer1.Location = new System.Drawing.Point(0, 0);
        this.viewer1.Name = "viewer1";
        this.viewer1.Size = new System.Drawing.Size(965, 274);
        this.viewer1.TabIndex = 0;
        // 
        // viewer2
        // 
        this.viewer2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.viewer2.Location = new System.Drawing.Point(0, 0);
        this.viewer2.Name = "viewer2";
        this.viewer2.Size = new System.Drawing.Size(965, 271);
        this.viewer2.TabIndex = 0;
        // 
        // ViewTwo
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(965, 549);
        this.Controls.Add(this.splitContainer1);
        this.MinimumSize = new System.Drawing.Size(973, 576);
        this.Name = "ViewTwo";
        this.Text = "ViewTwo";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.splitContainer1.Panel1.ResumeLayout(false);
        this.splitContainer1.Panel2.ResumeLayout(false);
        this.splitContainer1.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private Viewer viewer1;
    private Viewer viewer2;
  }
}