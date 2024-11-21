namespace WinFormsApp1
{
    partial class Main
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
            MainMenu_p = new Panel();
            MainMenu_header = new Label();
            Join_btn = new Button();
            Host_btn = new Button();
            Host_p = new Panel();
            HostPort_tb = new TextBox();
            HostReturn_btn = new Button();
            HostIP_tb = new TextBox();
            HostPort_l = new Label();
            Host_header = new Label();
            HostIP_l = new Label();
            Start_btn = new Button();
            Join_p = new Panel();
            JoinPort_tb = new TextBox();
            JoinIP_tb = new TextBox();
            JoinPort_l = new Label();
            JoinIP_l = new Label();
            JoinReturn_btn = new Button();
            Join_header = new Label();
            Connect_btn = new Button();
            label1 = new Label();
            MainMenu_p.SuspendLayout();
            Host_p.SuspendLayout();
            Join_p.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu_p
            // 
            MainMenu_p.Controls.Add(MainMenu_header);
            MainMenu_p.Controls.Add(Join_btn);
            MainMenu_p.Controls.Add(Host_btn);
            MainMenu_p.Location = new Point(794, 12);
            MainMenu_p.Name = "MainMenu_p";
            MainMenu_p.Size = new Size(776, 426);
            MainMenu_p.TabIndex = 0;
            // 
            // MainMenu_header
            // 
            MainMenu_header.AutoSize = true;
            MainMenu_header.Location = new Point(299, 110);
            MainMenu_header.Name = "MainMenu_header";
            MainMenu_header.Size = new Size(177, 15);
            MainMenu_header.TabIndex = 2;
            MainMenu_header.Text = "Welcome to ChatBox have fun :)";
            // 
            // Join_btn
            // 
            Join_btn.Location = new Point(346, 200);
            Join_btn.Name = "Join_btn";
            Join_btn.Size = new Size(75, 23);
            Join_btn.TabIndex = 1;
            Join_btn.Text = "Join";
            Join_btn.UseVisualStyleBackColor = true;
            Join_btn.Click += Join_btn_Click;
            // 
            // Host_btn
            // 
            Host_btn.Location = new Point(346, 157);
            Host_btn.Name = "Host_btn";
            Host_btn.Size = new Size(75, 23);
            Host_btn.TabIndex = 0;
            Host_btn.Text = "Host";
            Host_btn.UseVisualStyleBackColor = true;
            Host_btn.Click += Host_btn_Click;
            // 
            // Host_p
            // 
            Host_p.Controls.Add(HostPort_tb);
            Host_p.Controls.Add(HostReturn_btn);
            Host_p.Controls.Add(HostIP_tb);
            Host_p.Controls.Add(HostPort_l);
            Host_p.Controls.Add(Host_header);
            Host_p.Controls.Add(HostIP_l);
            Host_p.Controls.Add(Start_btn);
            Host_p.Location = new Point(12, 444);
            Host_p.Name = "Host_p";
            Host_p.Size = new Size(776, 426);
            Host_p.TabIndex = 3;
            Host_p.Visible = false;
            // 
            // HostPort_tb
            // 
            HostPort_tb.Location = new Point(313, 179);
            HostPort_tb.MaxLength = 5;
            HostPort_tb.Name = "HostPort_tb";
            HostPort_tb.Size = new Size(100, 23);
            HostPort_tb.TabIndex = 10;
            HostPort_tb.KeyPress += HostPort_tb_KeyPress;
            // 
            // HostReturn_btn
            // 
            HostReturn_btn.Location = new Point(324, 208);
            HostReturn_btn.Name = "HostReturn_btn";
            HostReturn_btn.Size = new Size(75, 23);
            HostReturn_btn.TabIndex = 2;
            HostReturn_btn.Text = "Return";
            HostReturn_btn.UseVisualStyleBackColor = true;
            HostReturn_btn.Click += HostReturn_btn_Click;
            // 
            // HostIP_tb
            // 
            HostIP_tb.Location = new Point(313, 135);
            HostIP_tb.MaxLength = 15;
            HostIP_tb.Name = "HostIP_tb";
            HostIP_tb.Size = new Size(100, 23);
            HostIP_tb.TabIndex = 9;
            HostIP_tb.KeyPress += HostIP_tb_KeyPress;
            // 
            // HostPort_l
            // 
            HostPort_l.AutoSize = true;
            HostPort_l.Location = new Point(313, 161);
            HostPort_l.Name = "HostPort_l";
            HostPort_l.Size = new Size(32, 15);
            HostPort_l.TabIndex = 8;
            HostPort_l.Text = "Port:";
            // 
            // Host_header
            // 
            Host_header.AutoSize = true;
            Host_header.Location = new Point(326, 93);
            Host_header.Name = "Host_header";
            Host_header.Size = new Size(67, 15);
            Host_header.TabIndex = 1;
            Host_header.Text = "Host a chat";
            // 
            // HostIP_l
            // 
            HostIP_l.AutoSize = true;
            HostIP_l.Location = new Point(313, 117);
            HostIP_l.Name = "HostIP_l";
            HostIP_l.Size = new Size(20, 15);
            HostIP_l.TabIndex = 7;
            HostIP_l.Text = "IP:";
            // 
            // Start_btn
            // 
            Start_btn.Location = new Point(324, 237);
            Start_btn.Name = "Start_btn";
            Start_btn.Size = new Size(75, 23);
            Start_btn.TabIndex = 0;
            Start_btn.Text = "Start";
            Start_btn.UseVisualStyleBackColor = true;
            Start_btn.Click += Start_btn_Click;
            // 
            // Join_p
            // 
            Join_p.Controls.Add(JoinPort_tb);
            Join_p.Controls.Add(JoinIP_tb);
            Join_p.Controls.Add(JoinPort_l);
            Join_p.Controls.Add(JoinIP_l);
            Join_p.Controls.Add(JoinReturn_btn);
            Join_p.Controls.Add(Join_header);
            Join_p.Controls.Add(Connect_btn);
            Join_p.Location = new Point(12, 12);
            Join_p.Name = "Join_p";
            Join_p.Size = new Size(776, 426);
            Join_p.TabIndex = 4;
            Join_p.Visible = false;
            // 
            // JoinPort_tb
            // 
            JoinPort_tb.Location = new Point(313, 189);
            JoinPort_tb.MaxLength = 5;
            JoinPort_tb.Name = "JoinPort_tb";
            JoinPort_tb.Size = new Size(100, 23);
            JoinPort_tb.TabIndex = 6;
            JoinPort_tb.KeyPress += JoinPort_tb_KeyPress;
            // 
            // JoinIP_tb
            // 
            JoinIP_tb.Location = new Point(313, 145);
            JoinIP_tb.MaxLength = 15;
            JoinIP_tb.Name = "JoinIP_tb";
            JoinIP_tb.Size = new Size(100, 23);
            JoinIP_tb.TabIndex = 5;
            JoinIP_tb.KeyPress += JoinIP_tb_KeyPress;
            // 
            // JoinPort_l
            // 
            JoinPort_l.AutoSize = true;
            JoinPort_l.Location = new Point(313, 171);
            JoinPort_l.Name = "JoinPort_l";
            JoinPort_l.Size = new Size(32, 15);
            JoinPort_l.TabIndex = 4;
            JoinPort_l.Text = "Port:";
            // 
            // JoinIP_l
            // 
            JoinIP_l.AutoSize = true;
            JoinIP_l.Location = new Point(313, 127);
            JoinIP_l.Name = "JoinIP_l";
            JoinIP_l.Size = new Size(20, 15);
            JoinIP_l.TabIndex = 3;
            JoinIP_l.Text = "IP:";
            // 
            // JoinReturn_btn
            // 
            JoinReturn_btn.Location = new Point(324, 218);
            JoinReturn_btn.Name = "JoinReturn_btn";
            JoinReturn_btn.Size = new Size(75, 23);
            JoinReturn_btn.TabIndex = 2;
            JoinReturn_btn.Text = "Return";
            JoinReturn_btn.UseVisualStyleBackColor = true;
            JoinReturn_btn.Click += JoinReturn_btn_Click;
            // 
            // Join_header
            // 
            Join_header.AutoSize = true;
            Join_header.Location = new Point(330, 94);
            Join_header.Name = "Join_header";
            Join_header.Size = new Size(63, 15);
            Join_header.TabIndex = 1;
            Join_header.Text = "Join a chat";
            // 
            // Connect_btn
            // 
            Connect_btn.Location = new Point(324, 247);
            Connect_btn.Name = "Connect_btn";
            Connect_btn.Size = new Size(75, 23);
            Connect_btn.TabIndex = 0;
            Connect_btn.Text = "Connect";
            Connect_btn.UseVisualStyleBackColor = true;
            Connect_btn.Click += Connect_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1591, 875);
            Controls.Add(label1);
            Controls.Add(MainMenu_p);
            Controls.Add(Host_p);
            Controls.Add(Join_p);
            Name = "Main";
            Text = "Main";
            MainMenu_p.ResumeLayout(false);
            MainMenu_p.PerformLayout();
            Host_p.ResumeLayout(false);
            Host_p.PerformLayout();
            Join_p.ResumeLayout(false);
            Join_p.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel MainMenu_p;
        private Button Host_btn;
        private Button Join_btn;
        private Label MainMenu_header;
        private Panel Host_p;
        private Button Start_btn;
        private Label Host_header;
        private Panel Join_p;
        private Label Join_header;
        private Button Connect_btn;
        private Button HostReturn_btn;
        private Button JoinReturn_btn;
        private Label JoinIP_l;
        private Label label1;
        private Label JoinPort_l;
        private TextBox JoinPort_tb;
        private TextBox JoinIP_tb;
        private TextBox HostPort_tb;
        private TextBox HostIP_tb;
        private Label HostPort_l;
        private Label HostIP_l;
    }
}