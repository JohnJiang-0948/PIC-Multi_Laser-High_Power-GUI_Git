
namespace User_Interface_Library
{
    partial class XML文件另存为
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XML文件另存为));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RS232_XML_Name = new System.Windows.Forms.TextBox();
            this.Confirm = new Sunny.UI.UIButton();
            this.Cancel = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(646, 22);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(78, 26);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = ".XML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "XML文件命名：";
            // 
            // RS232_XML_Name
            // 
            this.RS232_XML_Name.Location = new System.Drawing.Point(128, 22);
            this.RS232_XML_Name.Multiline = true;
            this.RS232_XML_Name.Name = "RS232_XML_Name";
            this.RS232_XML_Name.Size = new System.Drawing.Size(519, 26);
            this.RS232_XML_Name.TabIndex = 11;
            // 
            // Confirm
            // 
            this.Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Confirm.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Confirm.Location = new System.Drawing.Point(128, 70);
            this.Confirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(135, 35);
            this.Confirm.TabIndex = 14;
            this.Confirm.Text = "Confirm";
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Cancel
            // 
            this.Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Cancel.Location = new System.Drawing.Point(512, 70);
            this.Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(135, 35);
            this.Cancel.TabIndex = 14;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // XML文件另存为
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 117);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RS232_XML_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "XML文件另存为";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML File Save AS Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RS232_XML_Name;
        private Sunny.UI.UIButton Confirm;
        private Sunny.UI.UIButton Cancel;
    }
}