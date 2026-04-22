namespace RemoteMonitor_GUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label2 = new Label();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        statusStrip2 = new StatusStrip();
        toolStripStatusLabel1 = new ToolStripStatusLabel();
        label7 = new Label();
        button8 = new Button();
        textBox1 = new TextBox();
        richTextBox1 = new RichTextBox();
        pictureBox1 = new PictureBox();
        label6 = new Label();
        button7 = new Button();
        button6 = new Button();
        button5 = new Button();
        button4 = new Button();
        button3 = new Button();
        label5 = new Label();
        label4 = new Label();
        listBox1 = new ListBox();
        button2 = new Button();
        button1 = new Button();
        numericUpDown1 = new NumericUpDown();
        label3 = new Label();
        tabPage2 = new TabPage();
        button13 = new Button();
        button12 = new Button();
        label12 = new Label();
        button11 = new Button();
        textBox3 = new TextBox();
        statusStrip1 = new StatusStrip();
        toolStripStatusLabel2 = new ToolStripStatusLabel();
        richTextBox2 = new RichTextBox();
        label11 = new Label();
        Status = new ListBox();
        User = new ListBox();
        Host = new ListBox();
        label10 = new Label();
        button10 = new Button();
        button9 = new Button();
        numericUpDown2 = new NumericUpDown();
        label9 = new Label();
        textBox2 = new TextBox();
        label8 = new Label();
        label1 = new Label();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        statusStrip2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        tabPage2.SuspendLayout();
        statusStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(120, 93);
        label2.Name = "label2";
        label2.Size = new Size(0, 20);
        label2.TabIndex = 1;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Location = new Point(0, 41);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(711, 693);
        tabControl1.TabIndex = 2;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(statusStrip2);
        tabPage1.Controls.Add(label7);
        tabPage1.Controls.Add(button8);
        tabPage1.Controls.Add(textBox1);
        tabPage1.Controls.Add(richTextBox1);
        tabPage1.Controls.Add(pictureBox1);
        tabPage1.Controls.Add(label6);
        tabPage1.Controls.Add(button7);
        tabPage1.Controls.Add(button6);
        tabPage1.Controls.Add(button5);
        tabPage1.Controls.Add(button4);
        tabPage1.Controls.Add(button3);
        tabPage1.Controls.Add(label5);
        tabPage1.Controls.Add(label4);
        tabPage1.Controls.Add(listBox1);
        tabPage1.Controls.Add(button2);
        tabPage1.Controls.Add(button1);
        tabPage1.Controls.Add(numericUpDown1);
        tabPage1.Controls.Add(label3);
        tabPage1.Location = new Point(4, 29);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(703, 660);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Server";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // statusStrip2
        // 
        statusStrip2.ImageScalingSize = new Size(20, 20);
        statusStrip2.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
        statusStrip2.Location = new Point(3, 631);
        statusStrip2.Name = "statusStrip2";
        statusStrip2.Size = new Size(697, 26);
        statusStrip2.TabIndex = 18;
        statusStrip2.Text = "statusStrip2";
        // 
        // toolStripStatusLabel1
        // 
        toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        toolStripStatusLabel1.Size = new Size(49, 20);
        toolStripStatusLabel1.Text = "Status";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(24, 539);
        label7.Name = "label7";
        label7.Size = new Size(93, 20);
        label7.TabIndex = 17;
        label7.Text = "Text To Send";
        // 
        // button8
        // 
        button8.Location = new Point(574, 536);
        button8.Name = "button8";
        button8.Size = new Size(98, 27);
        button8.TabIndex = 16;
        button8.Text = "Send";
        button8.UseVisualStyleBackColor = true;
        button8.Click += button8_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(123, 536);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(433, 27);
        textBox1.TabIndex = 15;
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new Point(24, 397);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(648, 117);
        richTextBox1.TabIndex = 14;
        richTextBox1.Text = "";
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(358, 134);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(272, 144);
        pictureBox1.TabIndex = 13;
        pictureBox1.TabStop = false;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(23, 359);
        label6.Name = "label6";
        label6.Size = new Size(87, 20);
        label6.TabIndex = 12;
        label6.Text = "Activity Log";
        // 
        // button7
        // 
        button7.Location = new Point(578, 309);
        button7.Name = "button7";
        button7.Size = new Size(94, 29);
        button7.TabIndex = 11;
        button7.Text = "List";
        button7.UseVisualStyleBackColor = true;
        button7.Click += button7_Click;
        // 
        // button6
        // 
        button6.Location = new Point(425, 309);
        button6.Name = "button6";
        button6.Size = new Size(94, 29);
        button6.TabIndex = 10;
        button6.Text = "Kick";
        button6.UseVisualStyleBackColor = true;
        button6.Click += button6_Click;
        // 
        // button5
        // 
        button5.Location = new Point(288, 309);
        button5.Name = "button5";
        button5.Size = new Size(94, 29);
        button5.TabIndex = 9;
        button5.Text = "Stream Off";
        button5.UseVisualStyleBackColor = true;
        button5.Click += button5_Click;
        // 
        // button4
        // 
        button4.Location = new Point(152, 309);
        button4.Name = "button4";
        button4.Size = new Size(94, 29);
        button4.TabIndex = 8;
        button4.Text = "Stream On";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // button3
        // 
        button3.Location = new Point(24, 309);
        button3.Name = "button3";
        button3.Size = new Size(94, 29);
        button3.TabIndex = 7;
        button3.Text = "Capture";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(448, 92);
        label5.Name = "label5";
        label5.Size = new Size(108, 20);
        label5.TabIndex = 6;
        label5.Text = "Screen Preview";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(76, 92);
        label4.Name = "label4";
        label4.Size = new Size(122, 20);
        label4.TabIndex = 5;
        label4.Text = "Connected Client";
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(53, 134);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(181, 144);
        listBox1.TabIndex = 4;
        // 
        // button2
        // 
        button2.Location = new Point(486, 18);
        button2.Name = "button2";
        button2.Size = new Size(120, 30);
        button2.TabIndex = 3;
        button2.Text = "Stop Service";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.Location = new Point(322, 18);
        button1.Name = "button1";
        button1.Size = new Size(120, 30);
        button1.TabIndex = 2;
        button1.Text = "Start Service";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(169, 21);
        numericUpDown1.Maximum = new decimal(new int[] { 125000, 0, 0, 0 });
        numericUpDown1.Minimum = new decimal(new int[] { 9000, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(77, 27);
        numericUpDown1.TabIndex = 1;
        numericUpDown1.Value = new decimal(new int[] { 9000, 0, 0, 0 });
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(53, 23);
        label3.Name = "label3";
        label3.Size = new Size(98, 20);
        label3.TabIndex = 0;
        label3.Text = "Listen on Port";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(button13);
        tabPage2.Controls.Add(button12);
        tabPage2.Controls.Add(label12);
        tabPage2.Controls.Add(button11);
        tabPage2.Controls.Add(textBox3);
        tabPage2.Controls.Add(statusStrip1);
        tabPage2.Controls.Add(richTextBox2);
        tabPage2.Controls.Add(label11);
        tabPage2.Controls.Add(Status);
        tabPage2.Controls.Add(User);
        tabPage2.Controls.Add(Host);
        tabPage2.Controls.Add(label10);
        tabPage2.Controls.Add(button10);
        tabPage2.Controls.Add(button9);
        tabPage2.Controls.Add(numericUpDown2);
        tabPage2.Controls.Add(label9);
        tabPage2.Controls.Add(textBox2);
        tabPage2.Controls.Add(label8);
        tabPage2.Location = new Point(4, 29);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(703, 660);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Client";
        tabPage2.UseVisualStyleBackColor = true;
        tabPage2.Click += tabPage2_Click;
        // 
        // button13
        // 
        button13.Location = new Point(370, 578);
        button13.Name = "button13";
        button13.Size = new Size(92, 35);
        button13.TabIndex = 22;
        button13.Text = "Exit";
        button13.UseVisualStyleBackColor = true;
        button13.Click += button13_Click;
        // 
        // button12
        // 
        button12.Location = new Point(217, 578);
        button12.Name = "button12";
        button12.Size = new Size(92, 35);
        button12.TabIndex = 21;
        button12.Text = "Clear Log";
        button12.UseVisualStyleBackColor = true;
        button12.Click += button12_Click;
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new Point(17, 530);
        label12.Name = "label12";
        label12.Size = new Size(93, 20);
        label12.TabIndex = 20;
        label12.Text = "Text To Send";
        // 
        // button11
        // 
        button11.Location = new Point(567, 527);
        button11.Name = "button11";
        button11.Size = new Size(98, 27);
        button11.TabIndex = 19;
        button11.Text = "Send";
        button11.UseVisualStyleBackColor = true;
        button11.Click += button11_Click;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(116, 527);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(433, 27);
        textBox3.TabIndex = 18;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2 });
        statusStrip1.Location = new Point(3, 631);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(697, 26);
        statusStrip1.TabIndex = 12;
        statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel2
        // 
        toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        toolStripStatusLabel2.Size = new Size(49, 20);
        toolStripStatusLabel2.Text = "Status";
        // 
        // richTextBox2
        // 
        richTextBox2.Location = new Point(48, 385);
        richTextBox2.Name = "richTextBox2";
        richTextBox2.Size = new Size(597, 112);
        richTextBox2.TabIndex = 11;
        richTextBox2.Text = "";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(49, 345);
        label11.Name = "label11";
        label11.Size = new Size(96, 20);
        label11.TabIndex = 10;
        label11.Text = "Massage Log";
        label11.Click += label11_Click;
        // 
        // Status
        // 
        Status.FormattingEnabled = true;
        Status.Location = new Point(495, 194);
        Status.Name = "Status";
        Status.Size = new Size(150, 104);
        Status.TabIndex = 9;
        // 
        // User
        // 
        User.FormattingEnabled = true;
        User.Location = new Point(273, 194);
        User.Name = "User";
        User.Size = new Size(150, 104);
        User.TabIndex = 8;
        // 
        // Host
        // 
        Host.FormattingEnabled = true;
        Host.Location = new Point(49, 194);
        Host.Name = "Host";
        Host.Size = new Size(150, 104);
        Host.TabIndex = 7;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(287, 142);
        label10.Name = "label10";
        label10.Size = new Size(114, 20);
        label10.TabIndex = 6;
        label10.Text = "Connection Info";
        // 
        // button10
        // 
        button10.Location = new Point(217, 76);
        button10.Name = "button10";
        button10.Size = new Size(94, 29);
        button10.TabIndex = 5;
        button10.Text = "Disconnect";
        button10.UseVisualStyleBackColor = true;
        button10.Click += button10_Click;
        // 
        // button9
        // 
        button9.Location = new Point(85, 76);
        button9.Name = "button9";
        button9.Size = new Size(94, 29);
        button9.TabIndex = 4;
        button9.Text = "Connect";
        button9.UseVisualStyleBackColor = true;
        button9.Click += button9_Click;
        // 
        // numericUpDown2
        // 
        numericUpDown2.Location = new Point(505, 24);
        numericUpDown2.Maximum = new decimal(new int[] { 125000, 0, 0, 0 });
        numericUpDown2.Name = "numericUpDown2";
        numericUpDown2.Size = new Size(120, 27);
        numericUpDown2.TabIndex = 3;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(448, 27);
        label9.Name = "label9";
        label9.Size = new Size(35, 20);
        label9.TabIndex = 2;
        label9.Text = "Port";
        // 
        // textBox2
        // 
        textBox2.Location = new Point(217, 23);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(128, 27);
        textBox2.TabIndex = 1;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(73, 26);
        label8.Name = "label8";
        label8.Size = new Size(126, 20);
        label8.TabIndex = 0;
        label8.Text = "Connect to Server";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(238, 18);
        label1.Name = "label1";
        label1.Size = new Size(228, 20);
        label1.TabIndex = 3;
        label1.Text = "🖥️  Remote Monitor Application";
        label1.TextAlign = ContentAlignment.TopCenter;
        label1.Click += label1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(712, 734);
        Controls.Add(label1);
        Controls.Add(tabControl1);
        Controls.Add(label2);
        Name = "Form1";
        Text = "Remote Monitor";
        Load += Form1_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        statusStrip2.ResumeLayout(false);
        statusStrip2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Label label2;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private Label label1;
    private NumericUpDown numericUpDown1;
    private Label label3;
    private ListBox listBox1;
    private Button button2;
    private Button button1;
    private Button button7;
    private Button button6;
    private Button button5;
    private Button button4;
    private Button button3;
    private Label label5;
    private Label label4;
    private PictureBox pictureBox1;
    private Label label6;
    private RichTextBox richTextBox1;
    private Label label7;
    private Button button8;
    private TextBox textBox1;
    private StatusStrip statusStrip2;
    private NumericUpDown numericUpDown2;
    private Label label9;
    private TextBox textBox2;
    private Label label8;
    private Label label11;
    private ListBox Status;
    private ListBox User;
    private ListBox Host;
    private Label label10;
    private Button button10;
    private Button button9;
    private RichTextBox richTextBox2;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private Label label12;
    private Button button11;
    private TextBox textBox3;
    private Button button13;
    private Button button12;
}
