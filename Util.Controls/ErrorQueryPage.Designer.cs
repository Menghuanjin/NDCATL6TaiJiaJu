namespace Util.Controls
{
    partial class ErrorQueryPage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.combSto = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.combMac = new System.Windows.Forms.ComboBox();
            this.buttOut = new System.Windows.Forms.Button();
            this.buttQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTBegin = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(9, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1114, 529);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "报警查询";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(305, 30);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(41, 12);
            this.label43.TabIndex = 52;
            this.label43.Text = "层号：";
            // 
            // combSto
            // 
            this.combSto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combSto.FormattingEnabled = true;
            this.combSto.Items.AddRange(new object[] {
            "A层",
            "B层"});
            this.combSto.Location = new System.Drawing.Point(362, 25);
            this.combSto.Name = "combSto";
            this.combSto.Size = new System.Drawing.Size(77, 20);
            this.combSto.TabIndex = 51;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(158, 30);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 12);
            this.label42.TabIndex = 50;
            this.label42.Text = "机台：";
            // 
            // combMac
            // 
            this.combMac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combMac.FormattingEnabled = true;
            this.combMac.Items.AddRange(new object[] {
            "1#真空炉",
            "2#真空炉",
            "3#真空炉",
            "4#真空炉",
            "5#真空炉",
            "6#真空炉"});
            this.combMac.Location = new System.Drawing.Point(215, 25);
            this.combMac.Name = "combMac";
            this.combMac.Size = new System.Drawing.Size(84, 20);
            this.combMac.TabIndex = 49;
            // 
            // buttOut
            // 
            this.buttOut.Location = new System.Drawing.Point(987, 25);
            this.buttOut.Name = "buttOut";
            this.buttOut.Size = new System.Drawing.Size(75, 23);
            this.buttOut.TabIndex = 48;
            this.buttOut.Text = "导出";
            this.buttOut.UseVisualStyleBackColor = true;
            this.buttOut.Click += new System.EventHandler(this.buttOut_Click);
            // 
            // buttQuery
            // 
            this.buttQuery.Location = new System.Drawing.Point(906, 25);
            this.buttQuery.Name = "buttQuery";
            this.buttQuery.Size = new System.Drawing.Size(75, 23);
            this.buttQuery.TabIndex = 47;
            this.buttQuery.Text = "查询";
            this.buttQuery.UseVisualStyleBackColor = true;
            this.buttQuery.Click += new System.EventHandler(this.buttQuery_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(676, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "结束时间:";
            // 
            // dateTEnd
            // 
            this.dateTEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTEnd.Location = new System.Drawing.Point(749, 27);
            this.dateTEnd.Name = "dateTEnd";
            this.dateTEnd.Size = new System.Drawing.Size(151, 21);
            this.dateTEnd.TabIndex = 45;
            // 
            // dateTBegin
            // 
            this.dateTBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTBegin.Location = new System.Drawing.Point(516, 27);
            this.dateTBegin.Name = "dateTBegin";
            this.dateTBegin.Size = new System.Drawing.Size(151, 21);
            this.dateTBegin.TabIndex = 44;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(516, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 21);
            this.textBox1.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "开始时间：";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "BBakingName";
            this.Column1.HeaderText = "名称";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BRecordCon";
            this.Column2.HeaderText = "内容";
            this.Column2.Name = "Column2";
            this.Column2.Width = 550;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BRecordTime";
            this.Column3.HeaderText = "时间";
            this.Column3.Name = "Column3";
            this.Column3.Width = 250;
            // 
            // ErrorQueryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Util.Controls.Properties.Resources.mainPage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label43);
            this.Controls.Add(this.combSto);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.combMac);
            this.Controls.Add(this.buttOut);
            this.Controls.Add(this.buttQuery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTEnd);
            this.Controls.Add(this.dateTBegin);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Name = "ErrorQueryPage";
            this.Size = new System.Drawing.Size(1130, 620);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox combSto;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox combMac;
        private System.Windows.Forms.Button buttOut;
        private System.Windows.Forms.Button buttQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTEnd;
        private System.Windows.Forms.DateTimePicker dateTBegin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
