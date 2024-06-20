
namespace User_Interface_Library
{
    partial class USB通讯载入用例
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USB通讯载入用例));
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.载入用例 = new System.Windows.Forms.Button();
            this.查找用例 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "通讯用例汇总：";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(16, 73);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 352);
            this.listBox1.TabIndex = 6;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Enabled = false;
            this.propertyGrid1.Location = new System.Drawing.Point(242, 73);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(265, 353);
            this.propertyGrid1.TabIndex = 5;
            // 
            // 载入用例
            // 
            this.载入用例.Location = new System.Drawing.Point(398, 33);
            this.载入用例.Name = "载入用例";
            this.载入用例.Size = new System.Drawing.Size(109, 31);
            this.载入用例.TabIndex = 8;
            this.载入用例.Text = "载入用例";
            this.载入用例.UseVisualStyleBackColor = true;
            this.载入用例.Click += new System.EventHandler(this.载入用例_Click);
            // 
            // 查找用例
            // 
            this.查找用例.Location = new System.Drawing.Point(242, 33);
            this.查找用例.Name = "查找用例";
            this.查找用例.Size = new System.Drawing.Size(109, 31);
            this.查找用例.TabIndex = 8;
            this.查找用例.Text = "查找用例";
            this.查找用例.UseVisualStyleBackColor = true;
            this.查找用例.Click += new System.EventHandler(this.查找用例_Click);
            // 
            // USB通讯载入用例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::User_Interface_Library.Properties.Resources.激光器控制_USB;
            this.ClientSize = new System.Drawing.Size(528, 450);
            this.Controls.Add(this.查找用例);
            this.Controls.Add(this.载入用例);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.propertyGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "USB通讯载入用例";
            this.Text = "通讯载入用例";
            this.Load += new System.EventHandler(this.通讯载入用例_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button 载入用例;
        private System.Windows.Forms.Button 查找用例;
    }
}