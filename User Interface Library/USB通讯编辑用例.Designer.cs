
namespace User_Interface_Library
{
    partial class USB通讯编辑用例
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USB通讯编辑用例));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.编辑用例 = new System.Windows.Forms.Button();
            this.查找用例 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(236, 63);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(265, 353);
            this.propertyGrid1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(10, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 352);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "通讯用例汇总：";
            // 
            // 编辑用例
            // 
            this.编辑用例.Location = new System.Drawing.Point(392, 20);
            this.编辑用例.Name = "编辑用例";
            this.编辑用例.Size = new System.Drawing.Size(109, 31);
            this.编辑用例.TabIndex = 5;
            this.编辑用例.Text = "编辑用例";
            this.编辑用例.UseVisualStyleBackColor = true;
            this.编辑用例.Click += new System.EventHandler(this.编辑用例_Click);
            // 
            // 查找用例
            // 
            this.查找用例.Location = new System.Drawing.Point(236, 20);
            this.查找用例.Name = "查找用例";
            this.查找用例.Size = new System.Drawing.Size(115, 31);
            this.查找用例.TabIndex = 5;
            this.查找用例.Text = "查找用例";
            this.查找用例.UseVisualStyleBackColor = true;
            this.查找用例.Click += new System.EventHandler(this.查找用例_Click);
            // 
            // USB通讯编辑用例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::User_Interface_Library.Properties.Resources.激光器控制_USB;
            this.ClientSize = new System.Drawing.Size(509, 436);
            this.Controls.Add(this.查找用例);
            this.Controls.Add(this.编辑用例);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.propertyGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "USB通讯编辑用例";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB通讯编辑用例";
            this.Load += new System.EventHandler(this.USB通讯编辑用例_Load);
            this.Click += new System.EventHandler(this.USB通讯编辑用例_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 编辑用例;
        private System.Windows.Forms.Button 查找用例;
    }
}