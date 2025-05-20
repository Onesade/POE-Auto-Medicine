namespace 自动喝药
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtKeyPressInterval;
        private System.Windows.Forms.Label lblKeyPressInterval;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private System.Windows.Forms.Button btnSelectRegion;
        private System.Windows.Forms.Label lblHealths;
        private System.Windows.Forms.Button btnStopCapture;
        private System.Windows.Forms.TrackBar trackBarHealthThreshold;
        private System.Windows.Forms.TextBox txtKeyInput;
        private System.Windows.Forms.Label lblKeyCode;

        private void InitializeComponent()
        {
            txtKeyPressInterval = new TextBox();
            lblKeyPressInterval = new Label();

            // 
            // txtKeyPressInterval
            // 
            txtKeyPressInterval.Location = new Point(12, 350); // 设置位置
            txtKeyPressInterval.Name = "txtKeyPressInterval";
            txtKeyPressInterval.Size = new Size(200, 30); // 设置大小
            txtKeyPressInterval.TabIndex = 12;
            txtKeyPressInterval.Text = "500"; // 默认值为 500 毫秒
            txtKeyPressInterval.TextChanged += TxtKeyPressInterval_TextChanged;

            // 
            // lblKeyPressInterval
            // 
            lblKeyPressInterval.AutoSize = true;
            lblKeyPressInterval.Location = new Point(220, 355); // 设置位置
            lblKeyPressInterval.Name = "lblKeyPressInterval";
            lblKeyPressInterval.Size = new Size(200, 30);
            lblKeyPressInterval.TabIndex = 13;
            lblKeyPressInterval.Text = "按键间隔 (毫秒)";

            // 
            // Form1
            // 
            Controls.Add(txtKeyPressInterval);
            Controls.Add(lblKeyPressInterval);
            txtKeyInput = new TextBox();
            lblKeyCode = new Label();

            // 
            // txtKeyInput
            // 
            txtKeyInput.Location = new Point(12, 300); // 设置位置
            txtKeyInput.Name = "txtKeyInput";
            txtKeyInput.Size = new Size(200, 30); // 设置大小
            txtKeyInput.TabIndex = 10;
            txtKeyInput.MaxLength = 1; // 限制只能输入单个字符
            txtKeyInput.TextChanged += TxtKeyInput_TextChanged;

            // 
            // lblKeyCode
            // 
            lblKeyCode.AutoSize = true;
            lblKeyCode.Location = new Point(220, 305); // 设置位置
            lblKeyCode.Name = "lblKeyCode";
            lblKeyCode.Size = new Size(200, 30);
            lblKeyCode.TabIndex = 11;
            lblKeyCode.Text = "KeyCode: None";

            // 
            // Form1
            // 
            Controls.Add(txtKeyInput);
            Controls.Add(lblKeyCode);
            trackBarHealthThreshold = new TrackBar();
            btnStopCapture = new Button();
            btnSelectRegion = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblHealthPercentage = new Label();
            lblHealths = new Label();
            autopercentage = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarHealthThreshold).BeginInit();
            SuspendLayout();
            // 
            // trackBarHealthThreshold
            // 
            trackBarHealthThreshold.Location = new Point(12, 160);
            trackBarHealthThreshold.Maximum = 100;
            trackBarHealthThreshold.Name = "trackBarHealthThreshold";
            trackBarHealthThreshold.Size = new Size(400, 56);
            trackBarHealthThreshold.TabIndex = 5;
            trackBarHealthThreshold.TickFrequency = 10;
            trackBarHealthThreshold.Value = 50;
            trackBarHealthThreshold.Scroll += trackBarHealthThreshold_Scroll;
            // 
            // btnStopCapture
            // 
            btnStopCapture.Location = new Point(638, 58);
            btnStopCapture.Name = "btnStopCapture";
            btnStopCapture.Size = new Size(100, 30);
            btnStopCapture.TabIndex = 0;
            btnStopCapture.Text = "停止监测";
            btnStopCapture.UseVisualStyleBackColor = true;
            btnStopCapture.Click += btnStopCapture_Click;
            // 
            // btnSelectRegion
            // 
            btnSelectRegion.Location = new Point(638, 12);
            btnSelectRegion.Name = "btnSelectRegion";
            btnSelectRegion.Size = new Size(150, 30);
            btnSelectRegion.TabIndex = 0;
            btnSelectRegion.Text = "选择监测区域";
            btnSelectRegion.UseVisualStyleBackColor = true;
            btnSelectRegion.Click += btnSelectRegion_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 24F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(208, 52);
            label1.TabIndex = 0;
            label1.Text = "[当前血量]";
            // 
            // label2
            // 
            label2.Location = new Point(377, 41);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 24F);
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(248, 52);
            label3.TabIndex = 2;
            label3.Text = "[百分比血量]";
            // 
            // lblHealthPercentage
            // 
            lblHealthPercentage.AutoSize = true;
            lblHealthPercentage.Font = new Font("Microsoft YaHei UI", 24F);
            lblHealthPercentage.Location = new Point(292, 87);
            lblHealthPercentage.Name = "lblHealthPercentage";
            lblHealthPercentage.Size = new Size(136, 52);
            lblHealthPercentage.TabIndex = 3;
            lblHealthPercentage.Text = "XXX%";
            // 
            // lblHealths
            // 
            lblHealths.AutoSize = true;
            lblHealths.Font = new Font("Microsoft YaHei UI", 24F);
            lblHealths.Location = new Point(292, 9);
            lblHealths.Name = "lblHealths";
            lblHealths.Size = new Size(195, 52);
            lblHealths.TabIndex = 1;
            lblHealths.Text = "XXX/XXX";
            // 
            // autopercentage
            // 
            autopercentage.AutoSize = true;
            autopercentage.Font = new Font("Microsoft YaHei UI", 24F);
            autopercentage.Location = new Point(418, 139);
            autopercentage.Name = "autopercentage";
            autopercentage.Size = new Size(136, 52);
            autopercentage.TabIndex = 6;
            autopercentage.Text = "XXX%";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(autopercentage);
            Controls.Add(trackBarHealthThreshold);
            Controls.Add(btnStopCapture);
            Controls.Add(lblHealths);
            Controls.Add(btnSelectRegion);
            Controls.Add(lblHealthPercentage);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBarHealthThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        public Label lblHealthPercentage;
        private Label autopercentage;
    }
}
