
namespace User_Interface_Library
{
    partial class RS232通讯编辑用例
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.查找用例 = new Sunny.UI.UIButton();
            this.保存用例 = new Sunny.UI.UIButton();
            this.另存为用例 = new Sunny.UI.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "通讯用例汇总：";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 120);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(223, 328);
            this.listBox1.TabIndex = 7;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(237, 95);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(265, 355);
            this.propertyGrid1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(504, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(433, 330);
            this.dataGridView1.TabIndex = 12;
            // 
            // 查找用例
            // 
            this.查找用例.Cursor = System.Windows.Forms.Cursors.Hand;
            this.查找用例.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.查找用例.Location = new System.Drawing.Point(154, 15);
            this.查找用例.MinimumSize = new System.Drawing.Size(1, 1);
            this.查找用例.Name = "查找用例";
            this.查找用例.Size = new System.Drawing.Size(125, 35);
            this.查找用例.TabIndex = 13;
            this.查找用例.Text = "查找用例";
            this.查找用例.Click += new System.EventHandler(this.查找用例_Click);
            // 
            // 保存用例
            // 
            this.保存用例.Cursor = System.Windows.Forms.Cursors.Hand;
            this.保存用例.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.保存用例.Location = new System.Drawing.Point(655, 15);
            this.保存用例.MinimumSize = new System.Drawing.Size(1, 1);
            this.保存用例.Name = "保存用例";
            this.保存用例.Size = new System.Drawing.Size(121, 35);
            this.保存用例.TabIndex = 13;
            this.保存用例.Text = "保存用例";
            this.保存用例.Click += new System.EventHandler(this.保存用例_Click);
            // 
            // 另存为用例
            // 
            this.另存为用例.Cursor = System.Windows.Forms.Cursors.Hand;
            this.另存为用例.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.另存为用例.Location = new System.Drawing.Point(816, 15);
            this.另存为用例.MinimumSize = new System.Drawing.Size(1, 1);
            this.另存为用例.Name = "另存为用例";
            this.另存为用例.Size = new System.Drawing.Size(121, 35);
            this.另存为用例.TabIndex = 13;
            this.另存为用例.Text = "另存为用例";
            this.另存为用例.Click += new System.EventHandler(this.另存为用例_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "列表刷新";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "指令增加";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(645, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "指令删除";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::User_Interface_Library.Properties.Resources._041_remove;
            this.pictureBox2.Location = new System.Drawing.Point(590, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 50);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::User_Interface_Library.Properties.Resources._070_refresh;
            this.pictureBox3.Location = new System.Drawing.Point(12, 64);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 50);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.查找用例_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::User_Interface_Library.Properties.Resources._040_add;
            this.pictureBox1.Location = new System.Drawing.Point(508, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 50);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // RS232通讯编辑用例
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 447);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.另存为用例);
            this.Controls.Add(this.保存用例);
            this.Controls.Add(this.查找用例);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.propertyGrid1);
            this.MaximizeBox = false;
            this.Name = "RS232通讯编辑用例";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RS232通讯编辑用例";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Sunny.UI.UIButton 查找用例;
        private Sunny.UI.UIButton 保存用例;
        private Sunny.UI.UIButton 另存为用例;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}