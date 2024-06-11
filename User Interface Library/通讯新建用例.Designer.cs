
namespace User_Interface_Library
{
    partial class 通讯新建用例
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(通讯新建用例));
            this.USB_XML_Name = new System.Windows.Forms.TextBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.新建用例 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // USB_XML_Name
            // 
            this.USB_XML_Name.Location = new System.Drawing.Point(10, 41);
            this.USB_XML_Name.Multiline = true;
            this.USB_XML_Name.Name = "USB_XML_Name";
            this.USB_XML_Name.Size = new System.Drawing.Size(227, 26);
            this.USB_XML_Name.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(10, 84);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(304, 353);
            this.propertyGrid1.TabIndex = 1;
            // 
            // 新建用例
            // 
            this.新建用例.Image = global::User_Interface_Library.Properties.Resources.script_add;
            this.新建用例.Location = new System.Drawing.Point(334, 84);
            this.新建用例.Name = "新建用例";
            this.新建用例.Size = new System.Drawing.Size(136, 43);
            this.新建用例.TabIndex = 2;
            this.新建用例.UseVisualStyleBackColor = true;
            this.新建用例.Click += new System.EventHandler(this.新建用例_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "XML文件命名：";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(236, 41);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 26);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = ".XML";
            // 
            // 通讯新建用例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::User_Interface_Library.Properties.Resources.激光器控制_USB1;
            this.ClientSize = new System.Drawing.Size(482, 459);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.新建用例);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.USB_XML_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "通讯新建用例";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯新建用例";
            this.Load += new System.EventHandler(this.USB通讯用例_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox USB_XML_Name;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button 新建用例;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}