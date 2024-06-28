
namespace User_Interface_Library
{
    partial class RS232通讯载入用例
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RS232通讯载入用例));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.查找用例 = new Sunny.UI.UIButton();
            this.载入用例 = new Sunny.UI.UIButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(507, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(433, 330);
            this.dataGridView1.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(15, 92);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(223, 328);
            this.listBox1.TabIndex = 14;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(240, 67);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(265, 355);
            this.propertyGrid1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "通讯用例汇总：";
            // 
            // 查找用例
            // 
            this.查找用例.Cursor = System.Windows.Forms.Cursors.Hand;
            this.查找用例.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.查找用例.Location = new System.Drawing.Point(165, 19);
            this.查找用例.MinimumSize = new System.Drawing.Size(1, 1);
            this.查找用例.Name = "查找用例";
            this.查找用例.Size = new System.Drawing.Size(112, 35);
            this.查找用例.TabIndex = 18;
            this.查找用例.Text = "查找用例";
            this.查找用例.Click += new System.EventHandler(this.查找用例_Click);
            // 
            // 载入用例
            // 
            this.载入用例.Cursor = System.Windows.Forms.Cursors.Hand;
            this.载入用例.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.载入用例.Location = new System.Drawing.Point(821, 24);
            this.载入用例.MinimumSize = new System.Drawing.Size(1, 1);
            this.载入用例.Name = "载入用例";
            this.载入用例.Size = new System.Drawing.Size(112, 35);
            this.载入用例.TabIndex = 19;
            this.载入用例.Text = "载入用例";
            this.载入用例.Click += new System.EventHandler(this.载入用例_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "[Channels: *, Values: #]";
            // 
            // RS232通讯载入用例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 427);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.载入用例);
            this.Controls.Add(this.查找用例);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.propertyGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RS232通讯载入用例";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RS232通讯载入用例";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIButton 查找用例;
        private Sunny.UI.UIButton 载入用例;
        private System.Windows.Forms.Label label5;
    }
}