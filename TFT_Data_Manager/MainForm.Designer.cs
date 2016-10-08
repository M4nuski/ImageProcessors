namespace TFT_Data_Manager
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("i1", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("12", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("i3", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("i4", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("55", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("666", 5);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("lucky7", 6);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("5, 6, 7, 8!", 7);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlashMemoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.loadSourceButton = new System.Windows.Forms.Button();
            this.fitAllButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.previewLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.keepARcheckBox = new System.Windows.Forms.CheckBox();
            this.topTextBox = new System.Windows.Forms.TextBox();
            this.LeftTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.leftTrackBar = new System.Windows.Forms.TrackBar();
            this.fitMostButton = new System.Windows.Forms.Button();
            this.rightTrackBar = new System.Windows.Forms.TrackBar();
            this.bottomTrackBar = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenDataMenuItem,
            this.SaveAsMenuItem,
            this.FlashMemoryMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1265, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenDataMenuItem
            // 
            this.OpenDataMenuItem.Name = "OpenDataMenuItem";
            this.OpenDataMenuItem.Size = new System.Drawing.Size(48, 20);
            this.OpenDataMenuItem.Text = "Open";
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.Size = new System.Drawing.Size(59, 20);
            this.SaveAsMenuItem.Text = "Save As";
            // 
            // FlashMemoryMenuItem
            // 
            this.FlashMemoryMenuItem.Name = "FlashMemoryMenuItem";
            this.FlashMemoryMenuItem.Size = new System.Drawing.Size(46, 20);
            this.FlashMemoryMenuItem.Text = "Flash";
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(157, 714);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.VirtualListSize = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "70605_Front_360x203.jpg");
            this.imageList1.Images.SetKeyName(1, "ghostbusters-2016-images-melissa-mccarthy-kristen-wiigkate-mckinnon.jpg");
            this.imageList1.Images.SetKeyName(2, "ghostbusters-2016-images-melissa-mccarthy-kristen-wiigkate-mckinnon.jpg");
            this.imageList1.Images.SetKeyName(3, "Screen-Shot-2016-06-07-at-8.07_.02-AM_.jpg");
            this.imageList1.Images.SetKeyName(4, "01-lego-movies.jpg");
            this.imageList1.Images.SetKeyName(5, "the-lego-movie.jpg");
            this.imageList1.Images.SetKeyName(6, "qGVj7Xl.jpg");
            this.imageList1.Images.SetKeyName(7, "the-lego-movie-image10.jpg");
            this.imageList1.Images.SetKeyName(8, "the-lego-movie-movie-still-28.jpg");
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(197, 27);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadSourceButton
            // 
            this.loadSourceButton.Location = new System.Drawing.Point(372, 32);
            this.loadSourceButton.Name = "loadSourceButton";
            this.loadSourceButton.Size = new System.Drawing.Size(156, 23);
            this.loadSourceButton.TabIndex = 3;
            this.loadSourceButton.Text = "Load Source Image";
            this.loadSourceButton.UseVisualStyleBackColor = true;
            // 
            // fitAllButton
            // 
            this.fitAllButton.Location = new System.Drawing.Point(372, 83);
            this.fitAllButton.Name = "fitAllButton";
            this.fitAllButton.Size = new System.Drawing.Size(156, 23);
            this.fitAllButton.TabIndex = 4;
            this.fitAllButton.Text = "Fit All";
            this.fitAllButton.UseVisualStyleBackColor = true;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(197, 85);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 5;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(197, 56);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(75, 23);
            this.moveUpButton.TabIndex = 6;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(197, 143);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // previewLabel
            // 
            this.previewLabel.BackColor = System.Drawing.Color.Black;
            this.previewLabel.Location = new System.Drawing.Point(194, 304);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(320, 256);
            this.previewLabel.TabIndex = 8;
            this.previewLabel.Text = "label1";
            this.previewLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewLabel_Paint);
            // 
            // sourceLabel
            // 
            this.sourceLabel.BackColor = System.Drawing.Color.Black;
            this.sourceLabel.Location = new System.Drawing.Point(577, 80);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(640, 480);
            this.sourceLabel.TabIndex = 9;
            this.sourceLabel.Text = "label1";
            // 
            // keepARcheckBox
            // 
            this.keepARcheckBox.AutoSize = true;
            this.keepARcheckBox.Checked = true;
            this.keepARcheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keepARcheckBox.Location = new System.Drawing.Point(372, 60);
            this.keepARcheckBox.Name = "keepARcheckBox";
            this.keepARcheckBox.Size = new System.Drawing.Size(115, 17);
            this.keepARcheckBox.TabIndex = 10;
            this.keepARcheckBox.Text = "Keep Aspect Ratio";
            this.keepARcheckBox.UseVisualStyleBackColor = true;
            // 
            // topTextBox
            // 
            this.topTextBox.Location = new System.Drawing.Point(428, 155);
            this.topTextBox.Name = "topTextBox";
            this.topTextBox.ReadOnly = true;
            this.topTextBox.Size = new System.Drawing.Size(100, 20);
            this.topTextBox.TabIndex = 11;
            this.topTextBox.Text = "0";
            // 
            // LeftTextBox
            // 
            this.LeftTextBox.Location = new System.Drawing.Point(428, 181);
            this.LeftTextBox.Name = "LeftTextBox";
            this.LeftTextBox.ReadOnly = true;
            this.LeftTextBox.Size = new System.Drawing.Size(100, 20);
            this.LeftTextBox.TabIndex = 12;
            this.LeftTextBox.Text = "0";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(428, 207);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.ReadOnly = true;
            this.WidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthTextBox.TabIndex = 13;
            this.WidthTextBox.Text = "0";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(428, 233);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.ReadOnly = true;
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 14;
            this.HeightTextBox.Text = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RGB666 - 3 Bytes / Pixel",
            "RGB565 - 2 Bytes / Pixel"});
            this.comboBox1.Location = new System.Drawing.Point(197, 116);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "RGB666 - 3 Bytes / Pixel";
            // 
            // leftTrackBar
            // 
            this.leftTrackBar.Location = new System.Drawing.Point(565, 32);
            this.leftTrackBar.Maximum = 100;
            this.leftTrackBar.Name = "leftTrackBar";
            this.leftTrackBar.Size = new System.Drawing.Size(662, 45);
            this.leftTrackBar.TabIndex = 16;
            // 
            // fitMostButton
            // 
            this.fitMostButton.Location = new System.Drawing.Point(372, 116);
            this.fitMostButton.Name = "fitMostButton";
            this.fitMostButton.Size = new System.Drawing.Size(156, 23);
            this.fitMostButton.TabIndex = 17;
            this.fitMostButton.Text = "Fit Most";
            this.fitMostButton.UseVisualStyleBackColor = true;
            // 
            // rightTrackBar
            // 
            this.rightTrackBar.Location = new System.Drawing.Point(565, 563);
            this.rightTrackBar.Maximum = 100;
            this.rightTrackBar.Name = "rightTrackBar";
            this.rightTrackBar.Size = new System.Drawing.Size(662, 45);
            this.rightTrackBar.TabIndex = 18;
            this.rightTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.rightTrackBar.Value = 100;
            this.rightTrackBar.Scroll += new System.EventHandler(this.rightTrackBar_Scroll);
            // 
            // bottomTrackBar
            // 
            this.bottomTrackBar.Location = new System.Drawing.Point(1220, 71);
            this.bottomTrackBar.Maximum = 100;
            this.bottomTrackBar.Name = "bottomTrackBar";
            this.bottomTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.bottomTrackBar.Size = new System.Drawing.Size(45, 500);
            this.bottomTrackBar.TabIndex = 19;
            this.bottomTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(534, 71);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 500);
            this.trackBar1.TabIndex = 20;
            this.trackBar1.Value = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 753);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.bottomTrackBar);
            this.Controls.Add(this.rightTrackBar);
            this.Controls.Add(this.fitMostButton);
            this.Controls.Add(this.leftTrackBar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.LeftTextBox);
            this.Controls.Add(this.topTextBox);
            this.Controls.Add(this.keepARcheckBox);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.fitAllButton);
            this.Controls.Add(this.loadSourceButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TFT Data Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FlashMemoryMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button loadSourceButton;
        private System.Windows.Forms.Button fitAllButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.CheckBox keepARcheckBox;
        private System.Windows.Forms.TextBox topTextBox;
        private System.Windows.Forms.TextBox LeftTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar leftTrackBar;
        private System.Windows.Forms.Button fitMostButton;
        private System.Windows.Forms.TrackBar rightTrackBar;
        private System.Windows.Forms.TrackBar bottomTrackBar;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

