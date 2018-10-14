namespace program2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.ratioText = new System.Windows.Forms.TextBox();
            this.per1Text = new System.Windows.Forms.TextBox();
            this.per2Text = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(607, 12);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.Text = "button";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // ratioText
            // 
            this.ratioText.Location = new System.Drawing.Point(582, 41);
            this.ratioText.Name = "ratioText";
            this.ratioText.Size = new System.Drawing.Size(100, 25);
            this.ratioText.TabIndex = 1;
            this.ratioText.TextChanged += new System.EventHandler(this.ratioText_TextChanged_1);
            // 
            // per1Text
            // 
            this.per1Text.Location = new System.Drawing.Point(582, 134);
            this.per1Text.Name = "per1Text";
            this.per1Text.Size = new System.Drawing.Size(100, 25);
            this.per1Text.TabIndex = 4;
            this.per1Text.TextChanged += new System.EventHandler(this.per1Text_TextChanged);
            // 
            // per2Text
            // 
            this.per2Text.Location = new System.Drawing.Point(582, 166);
            this.per2Text.Name = "per2Text";
            this.per2Text.Size = new System.Drawing.Size(100, 25);
            this.per2Text.TabIndex = 5;
            this.per2Text.TextChanged += new System.EventHandler(this.per2Text_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(531, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 25);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "ratio";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(531, 134);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(45, 25);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "per1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(531, 166);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(45, 25);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "per2";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(685, 354);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.per2Text);
            this.Controls.Add(this.per1Text);
            this.Controls.Add(this.ratioText);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox ratioText;
        private System.Windows.Forms.TextBox per1Text;
        private System.Windows.Forms.TextBox per2Text;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}

