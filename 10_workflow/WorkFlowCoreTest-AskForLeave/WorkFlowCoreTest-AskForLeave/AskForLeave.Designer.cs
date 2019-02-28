namespace WorkFlowCoreTest_AskForLeave
{
    partial class AskForLeave
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
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.reasonText = new System.Windows.Forms.TextBox();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.departmentNameText = new System.Windows.Forms.TextBox();
            this.departmentStateSelect = new System.Windows.Forms.ComboBox();
            this.departmentRemarkText = new System.Windows.Forms.TextBox();
            this.companyRemarkText = new System.Windows.Forms.TextBox();
            this.companyStateSelect = new System.Windows.Forms.ComboBox();
            this.companyNameText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.departmentApplyButton = new System.Windows.Forms.Button();
            this.companyApplyButton = new System.Windows.Forms.Button();
            this.infoText = new System.Windows.Forms.TextBox();
            this.editButton = new System.Windows.Forms.Button();
            this.giveupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(48, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "开始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(129, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "结束";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(93, 252);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "申请";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "开始时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "结束时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "请假原因";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(67, 53);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(137, 21);
            this.nameText.TabIndex = 8;
            // 
            // reasonText
            // 
            this.reasonText.Location = new System.Drawing.Point(67, 153);
            this.reasonText.Multiline = true;
            this.reasonText.Name = "reasonText";
            this.reasonText.Size = new System.Drawing.Size(137, 85);
            this.reasonText.TabIndex = 9;
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startTimePicker.Location = new System.Drawing.Point(67, 87);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(137, 21);
            this.startTimePicker.TabIndex = 10;
            this.startTimePicker.Value = new System.DateTime(2019, 2, 16, 0, 0, 0, 0);
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endTimePicker.Location = new System.Drawing.Point(67, 121);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(137, 21);
            this.endTimePicker.TabIndex = 11;
            this.endTimePicker.Value = new System.DateTime(2019, 2, 16, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "部门审批";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "审批人";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "结果";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "备注";
            // 
            // departmentNameText
            // 
            this.departmentNameText.Location = new System.Drawing.Point(294, 37);
            this.departmentNameText.Name = "departmentNameText";
            this.departmentNameText.Size = new System.Drawing.Size(155, 21);
            this.departmentNameText.TabIndex = 16;
            // 
            // departmentStateSelect
            // 
            this.departmentStateSelect.FormattingEnabled = true;
            this.departmentStateSelect.Items.AddRange(new object[] {
            "同意",
            "不同意"});
            this.departmentStateSelect.Location = new System.Drawing.Point(294, 68);
            this.departmentStateSelect.Name = "departmentStateSelect";
            this.departmentStateSelect.Size = new System.Drawing.Size(155, 20);
            this.departmentStateSelect.TabIndex = 17;
            // 
            // departmentRemarkText
            // 
            this.departmentRemarkText.Location = new System.Drawing.Point(294, 102);
            this.departmentRemarkText.Multiline = true;
            this.departmentRemarkText.Name = "departmentRemarkText";
            this.departmentRemarkText.Size = new System.Drawing.Size(155, 56);
            this.departmentRemarkText.TabIndex = 18;
            // 
            // companyRemarkText
            // 
            this.companyRemarkText.Location = new System.Drawing.Point(514, 102);
            this.companyRemarkText.Multiline = true;
            this.companyRemarkText.Name = "companyRemarkText";
            this.companyRemarkText.Size = new System.Drawing.Size(155, 56);
            this.companyRemarkText.TabIndex = 25;
            // 
            // companyStateSelect
            // 
            this.companyStateSelect.FormattingEnabled = true;
            this.companyStateSelect.Items.AddRange(new object[] {
            "同意",
            "不同意"});
            this.companyStateSelect.Location = new System.Drawing.Point(514, 68);
            this.companyStateSelect.Name = "companyStateSelect";
            this.companyStateSelect.Size = new System.Drawing.Size(155, 20);
            this.companyStateSelect.TabIndex = 24;
            // 
            // companyNameText
            // 
            this.companyNameText.Location = new System.Drawing.Point(514, 37);
            this.companyNameText.Name = "companyNameText";
            this.companyNameText.Size = new System.Drawing.Size(155, 21);
            this.companyNameText.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(479, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "备注";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(479, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "结果";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(467, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "审批人";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(545, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "公司审批";
            // 
            // departmentApplyButton
            // 
            this.departmentApplyButton.Location = new System.Drawing.Point(327, 164);
            this.departmentApplyButton.Name = "departmentApplyButton";
            this.departmentApplyButton.Size = new System.Drawing.Size(75, 23);
            this.departmentApplyButton.TabIndex = 26;
            this.departmentApplyButton.Text = "提交";
            this.departmentApplyButton.UseVisualStyleBackColor = true;
            this.departmentApplyButton.Click += new System.EventHandler(this.departmentApplyButton_Click);
            // 
            // companyApplyButton
            // 
            this.companyApplyButton.Location = new System.Drawing.Point(547, 164);
            this.companyApplyButton.Name = "companyApplyButton";
            this.companyApplyButton.Size = new System.Drawing.Size(75, 23);
            this.companyApplyButton.TabIndex = 27;
            this.companyApplyButton.Text = "提交";
            this.companyApplyButton.UseVisualStyleBackColor = true;
            this.companyApplyButton.Click += new System.EventHandler(this.companyApplyButton_Click);
            // 
            // infoText
            // 
            this.infoText.Location = new System.Drawing.Point(261, 199);
            this.infoText.Multiline = true;
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.Size = new System.Drawing.Size(408, 97);
            this.infoText.TabIndex = 28;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(48, 283);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 29;
            this.editButton.Text = "修改";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // giveupButton
            // 
            this.giveupButton.Location = new System.Drawing.Point(129, 283);
            this.giveupButton.Name = "giveupButton";
            this.giveupButton.Size = new System.Drawing.Size(75, 23);
            this.giveupButton.TabIndex = 30;
            this.giveupButton.Text = "放弃";
            this.giveupButton.UseVisualStyleBackColor = true;
            this.giveupButton.Click += new System.EventHandler(this.giveupButton_Click);
            // 
            // AskForLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 317);
            this.Controls.Add(this.giveupButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.companyApplyButton);
            this.Controls.Add(this.departmentApplyButton);
            this.Controls.Add(this.companyRemarkText);
            this.Controls.Add(this.companyStateSelect);
            this.Controls.Add(this.companyNameText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.departmentRemarkText);
            this.Controls.Add(this.departmentStateSelect);
            this.Controls.Add(this.departmentNameText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.reasonText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "AskForLeave";
            this.Text = "AskForLeave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox reasonText;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox departmentNameText;
        private System.Windows.Forms.ComboBox departmentStateSelect;
        private System.Windows.Forms.TextBox departmentRemarkText;
        private System.Windows.Forms.TextBox companyRemarkText;
        private System.Windows.Forms.ComboBox companyStateSelect;
        private System.Windows.Forms.TextBox companyNameText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button departmentApplyButton;
        private System.Windows.Forms.Button companyApplyButton;
        private System.Windows.Forms.TextBox infoText;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button giveupButton;
    }
}

