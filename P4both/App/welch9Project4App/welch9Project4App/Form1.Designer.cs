namespace welch9Project4App
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
      this.StudentListBox = new System.Windows.Forms.ListBox();
      this.ListStudentsButton = new System.Windows.Forms.Button();
      this.StudentDetailsListbox = new System.Windows.Forms.ListBox();
      this.StudentDetailsLabel = new System.Windows.Forms.Label();
      this.ListCoursesButton = new System.Windows.Forms.Button();
      this.CourseListBox = new System.Windows.Forms.ListBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.resetTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.EnrollButton = new System.Windows.Forms.Button();
      this.CourseDetailsListBox = new System.Windows.Forms.ListBox();
      this.DropButton = new System.Windows.Forms.Button();
      this.SwapButton = new System.Windows.Forms.Button();
      this.CourseTwoList = new System.Windows.Forms.ComboBox();
      this.StudentTwoList = new System.Windows.Forms.ComboBox();
      this.TimeDelayBox = new System.Windows.Forms.TextBox();
      this.DelayLabel = new System.Windows.Forms.Label();
      this.StudentTwoDetails = new System.Windows.Forms.ListBox();
      this.CourseTwoDetails = new System.Windows.Forms.ListBox();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // StudentListBox
      // 
      this.StudentListBox.FormattingEnabled = true;
      this.StudentListBox.ItemHeight = 25;
      this.StudentListBox.Location = new System.Drawing.Point(12, 104);
      this.StudentListBox.Name = "StudentListBox";
      this.StudentListBox.Size = new System.Drawing.Size(364, 379);
      this.StudentListBox.TabIndex = 0;
      this.StudentListBox.SelectedIndexChanged += new System.EventHandler(this.StudentListBox_SelectedIndexChanged);
      // 
      // ListStudentsButton
      // 
      this.ListStudentsButton.Location = new System.Drawing.Point(11, 40);
      this.ListStudentsButton.Name = "ListStudentsButton";
      this.ListStudentsButton.Size = new System.Drawing.Size(365, 58);
      this.ListStudentsButton.TabIndex = 1;
      this.ListStudentsButton.Text = "List Students";
      this.ListStudentsButton.UseVisualStyleBackColor = true;
      this.ListStudentsButton.Click += new System.EventHandler(this.ListStudentsButton_Click);
      // 
      // StudentDetailsListbox
      // 
      this.StudentDetailsListbox.FormattingEnabled = true;
      this.StudentDetailsListbox.ItemHeight = 25;
      this.StudentDetailsListbox.Location = new System.Drawing.Point(13, 541);
      this.StudentDetailsListbox.Name = "StudentDetailsListbox";
      this.StudentDetailsListbox.Size = new System.Drawing.Size(364, 254);
      this.StudentDetailsListbox.TabIndex = 2;
      this.StudentDetailsListbox.SelectedIndexChanged += new System.EventHandler(this.StudentDetailsListbox_SelectedIndexChanged);
      // 
      // StudentDetailsLabel
      // 
      this.StudentDetailsLabel.AutoSize = true;
      this.StudentDetailsLabel.Location = new System.Drawing.Point(13, 510);
      this.StudentDetailsLabel.Name = "StudentDetailsLabel";
      this.StudentDetailsLabel.Size = new System.Drawing.Size(84, 25);
      this.StudentDetailsLabel.TabIndex = 3;
      this.StudentDetailsLabel.Text = "Details:";
      // 
      // ListCoursesButton
      // 
      this.ListCoursesButton.Location = new System.Drawing.Point(383, 40);
      this.ListCoursesButton.Name = "ListCoursesButton";
      this.ListCoursesButton.Size = new System.Drawing.Size(358, 58);
      this.ListCoursesButton.TabIndex = 4;
      this.ListCoursesButton.Text = "List Courses";
      this.ListCoursesButton.UseVisualStyleBackColor = true;
      this.ListCoursesButton.Click += new System.EventHandler(this.ListCoursesButton_Click);
      // 
      // CourseListBox
      // 
      this.CourseListBox.FormattingEnabled = true;
      this.CourseListBox.ItemHeight = 25;
      this.CourseListBox.Location = new System.Drawing.Point(383, 104);
      this.CourseListBox.Name = "CourseListBox";
      this.CourseListBox.Size = new System.Drawing.Size(358, 379);
      this.CourseListBox.TabIndex = 5;
      this.CourseListBox.SelectedIndexChanged += new System.EventHandler(this.CourseListBox_SelectedIndexChanged);
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1422, 40);
      this.menuStrip1.TabIndex = 6;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetTablesToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(111, 36);
      this.optionsToolStripMenuItem.Text = "Options";
      // 
      // resetTablesToolStripMenuItem
      // 
      this.resetTablesToolStripMenuItem.Name = "resetTablesToolStripMenuItem";
      this.resetTablesToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
      this.resetTablesToolStripMenuItem.Text = "Reset Tables";
      this.resetTablesToolStripMenuItem.Click += new System.EventHandler(this.resetTablesToolStripMenuItem_Click);
      // 
      // EnrollButton
      // 
      this.EnrollButton.Location = new System.Drawing.Point(771, 121);
      this.EnrollButton.Name = "EnrollButton";
      this.EnrollButton.Size = new System.Drawing.Size(185, 58);
      this.EnrollButton.TabIndex = 7;
      this.EnrollButton.Text = "Enroll";
      this.EnrollButton.UseVisualStyleBackColor = true;
      this.EnrollButton.Click += new System.EventHandler(this.EnrollButton_Click);
      // 
      // CourseDetailsListBox
      // 
      this.CourseDetailsListBox.FormattingEnabled = true;
      this.CourseDetailsListBox.ItemHeight = 25;
      this.CourseDetailsListBox.Location = new System.Drawing.Point(384, 541);
      this.CourseDetailsListBox.Name = "CourseDetailsListBox";
      this.CourseDetailsListBox.Size = new System.Drawing.Size(357, 254);
      this.CourseDetailsListBox.TabIndex = 8;
      // 
      // DropButton
      // 
      this.DropButton.Location = new System.Drawing.Point(771, 185);
      this.DropButton.Name = "DropButton";
      this.DropButton.Size = new System.Drawing.Size(185, 58);
      this.DropButton.TabIndex = 9;
      this.DropButton.Text = "Drop";
      this.DropButton.UseVisualStyleBackColor = true;
      this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
      // 
      // SwapButton
      // 
      this.SwapButton.Location = new System.Drawing.Point(1039, 44);
      this.SwapButton.Name = "SwapButton";
      this.SwapButton.Size = new System.Drawing.Size(364, 58);
      this.SwapButton.TabIndex = 10;
      this.SwapButton.Text = "Swap";
      this.SwapButton.UseVisualStyleBackColor = true;
      this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
      // 
      // CourseTwoList
      // 
      this.CourseTwoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CourseTwoList.FormattingEnabled = true;
      this.CourseTwoList.Location = new System.Drawing.Point(1039, 147);
      this.CourseTwoList.Name = "CourseTwoList";
      this.CourseTwoList.Size = new System.Drawing.Size(362, 33);
      this.CourseTwoList.TabIndex = 11;
      this.CourseTwoList.SelectedIndexChanged += new System.EventHandler(this.CourseTwoList_SelectedIndexChanged);
      // 
      // StudentTwoList
      // 
      this.StudentTwoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.StudentTwoList.FormattingEnabled = true;
      this.StudentTwoList.Location = new System.Drawing.Point(1039, 108);
      this.StudentTwoList.Name = "StudentTwoList";
      this.StudentTwoList.Size = new System.Drawing.Size(362, 33);
      this.StudentTwoList.TabIndex = 12;
      this.StudentTwoList.SelectedIndexChanged += new System.EventHandler(this.StudentTwoList_SelectedIndexChanged);
      // 
      // TimeDelayBox
      // 
      this.TimeDelayBox.Location = new System.Drawing.Point(771, 71);
      this.TimeDelayBox.Name = "TimeDelayBox";
      this.TimeDelayBox.Size = new System.Drawing.Size(185, 31);
      this.TimeDelayBox.TabIndex = 13;
      this.TimeDelayBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // DelayLabel
      // 
      this.DelayLabel.AutoSize = true;
      this.DelayLabel.Location = new System.Drawing.Point(766, 43);
      this.DelayLabel.Name = "DelayLabel";
      this.DelayLabel.Size = new System.Drawing.Size(115, 25);
      this.DelayLabel.TabIndex = 14;
      this.DelayLabel.Text = "Delay(ms):";
      // 
      // StudentTwoDetails
      // 
      this.StudentTwoDetails.FormattingEnabled = true;
      this.StudentTwoDetails.ItemHeight = 25;
      this.StudentTwoDetails.Location = new System.Drawing.Point(1039, 207);
      this.StudentTwoDetails.Name = "StudentTwoDetails";
      this.StudentTwoDetails.Size = new System.Drawing.Size(364, 254);
      this.StudentTwoDetails.TabIndex = 15;
      this.StudentTwoDetails.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // CourseTwoDetails
      // 
      this.CourseTwoDetails.FormattingEnabled = true;
      this.CourseTwoDetails.ItemHeight = 25;
      this.CourseTwoDetails.Location = new System.Drawing.Point(1039, 467);
      this.CourseTwoDetails.Name = "CourseTwoDetails";
      this.CourseTwoDetails.Size = new System.Drawing.Size(364, 329);
      this.CourseTwoDetails.TabIndex = 16;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1422, 831);
      this.Controls.Add(this.CourseTwoDetails);
      this.Controls.Add(this.StudentTwoDetails);
      this.Controls.Add(this.DelayLabel);
      this.Controls.Add(this.TimeDelayBox);
      this.Controls.Add(this.StudentTwoList);
      this.Controls.Add(this.CourseTwoList);
      this.Controls.Add(this.SwapButton);
      this.Controls.Add(this.DropButton);
      this.Controls.Add(this.CourseDetailsListBox);
      this.Controls.Add(this.EnrollButton);
      this.Controls.Add(this.CourseListBox);
      this.Controls.Add(this.ListCoursesButton);
      this.Controls.Add(this.StudentDetailsLabel);
      this.Controls.Add(this.StudentDetailsListbox);
      this.Controls.Add(this.ListStudentsButton);
      this.Controls.Add(this.StudentListBox);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox StudentListBox;
    private System.Windows.Forms.Button ListStudentsButton;
    private System.Windows.Forms.ListBox StudentDetailsListbox;
    private System.Windows.Forms.Label StudentDetailsLabel;
    private System.Windows.Forms.Button ListCoursesButton;
    private System.Windows.Forms.ListBox CourseListBox;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem resetTablesToolStripMenuItem;
    private System.Windows.Forms.Button EnrollButton;
    private System.Windows.Forms.ListBox CourseDetailsListBox;
    private System.Windows.Forms.Button DropButton;
    private System.Windows.Forms.Button SwapButton;
    private System.Windows.Forms.ComboBox CourseTwoList;
    private System.Windows.Forms.ComboBox StudentTwoList;
    private System.Windows.Forms.TextBox TimeDelayBox;
    private System.Windows.Forms.Label DelayLabel;
    private System.Windows.Forms.ListBox StudentTwoDetails;
    private System.Windows.Forms.ListBox CourseTwoDetails;
  }
}

