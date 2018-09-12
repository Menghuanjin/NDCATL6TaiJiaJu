namespace Util.Controls
{
    partial class StatusPage
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.comBoB = new System.Windows.Forms.ComboBox();
            this.comBoA = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.Location = new System.Drawing.Point(29, 16);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(89, 20);
            this.labName.TabIndex = 3;
            this.labName.Text = "1#真空炉";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(128, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "B层";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.Location = new System.Drawing.Point(128, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "A层";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // PicBox
            // 
            this.PicBox.Image = global::Util.Controls.Properties.Resources.redlight;
            this.PicBox.Location = new System.Drawing.Point(131, 5);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(38, 33);
            this.PicBox.TabIndex = 2;
            this.PicBox.TabStop = false;
            // 
            // comBoB
            // 
            this.comBoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoB.FormattingEnabled = true;
            this.comBoB.Items.AddRange(new object[] {
            "烘烤中",
            "维修中",
            "待机中",
            "不可用"});
            this.comBoB.Location = new System.Drawing.Point(22, 64);
            this.comBoB.Name = "comBoB";
            this.comBoB.Size = new System.Drawing.Size(102, 20);
            this.comBoB.TabIndex = 8;
            // 
            // comBoA
            // 
            this.comBoA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoA.FormattingEnabled = true;
            this.comBoA.Items.AddRange(new object[] {
            "烘烤中",
            "维修中",
            "待机中",
            "不可用"});
            this.comBoA.Location = new System.Drawing.Point(22, 115);
            this.comBoA.Name = "comBoA";
            this.comBoA.Size = new System.Drawing.Size(102, 20);
            this.comBoA.TabIndex = 9;
            // 
            // StatusPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.comBoA);
            this.Controls.Add(this.comBoB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.PicBox);
            this.Name = "StatusPage";
            this.Size = new System.Drawing.Size(175, 169);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comBoB;
        private System.Windows.Forms.ComboBox comBoA;
    }
}
