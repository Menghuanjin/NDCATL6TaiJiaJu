namespace Util.Controls
{
    partial class BakingPage
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
            this.components = new System.ComponentModel.Container();
            this.labName = new System.Windows.Forms.Label();
            this.buttB = new System.Windows.Forms.Button();
            this.cmp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.run = new System.Windows.Forms.ToolStripMenuItem();
            this.bide = new System.Windows.Forms.ToolStripMenuItem();
            this.textB = new System.Windows.Forms.TextBox();
            this.textA = new System.Windows.Forms.TextBox();
            this.buttA = new System.Windows.Forms.Button();
            this.labB = new System.Windows.Forms.Label();
            this.labA = new System.Windows.Forms.Label();
            this.cmp.SuspendLayout();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.Location = new System.Drawing.Point(35, 11);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(95, 21);
            this.labName.TabIndex = 3;
            this.labName.Text = "1#真空炉";
            // 
            // buttB
            // 
            this.buttB.BackColor = System.Drawing.Color.Lime;
            this.buttB.Location = new System.Drawing.Point(128, 64);
            this.buttB.Name = "buttB";
            this.buttB.Size = new System.Drawing.Size(41, 23);
            this.buttB.TabIndex = 4;
            this.buttB.Text = "B层";
            this.buttB.UseVisualStyleBackColor = false;
            // 
            // cmp
            // 
            this.cmp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.run,
            this.bide});
            this.cmp.Name = "cmp";
            this.cmp.Size = new System.Drawing.Size(113, 48);
            this.cmp.Text = "122";
            this.cmp.Opening += new System.ComponentModel.CancelEventHandler(this.cmp_Opening);
            // 
            // run
            // 
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(112, 22);
            this.run.Text = "运行中";
            // 
            // bide
            // 
            this.bide.Name = "bide";
            this.bide.Size = new System.Drawing.Size(112, 22);
            this.bide.Text = "待机中";
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(22, 64);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(100, 21);
            this.textB.TabIndex = 5;
            this.textB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textA
            // 
            this.textA.Location = new System.Drawing.Point(22, 113);
            this.textA.Name = "textA";
            this.textA.Size = new System.Drawing.Size(100, 21);
            this.textA.TabIndex = 7;
            this.textA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttA
            // 
            this.buttA.BackColor = System.Drawing.Color.Lime;
            this.buttA.Location = new System.Drawing.Point(128, 113);
            this.buttA.Name = "buttA";
            this.buttA.Size = new System.Drawing.Size(41, 23);
            this.buttA.TabIndex = 6;
            this.buttA.Text = "A层";
            this.buttA.UseVisualStyleBackColor = false;
            // 
            // labB
            // 
            this.labB.AutoSize = true;
            this.labB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labB.ForeColor = System.Drawing.Color.Crimson;
            this.labB.Location = new System.Drawing.Point(53, 47);
            this.labB.Name = "labB";
            this.labB.Size = new System.Drawing.Size(35, 14);
            this.labB.TabIndex = 9;
            this.labB.Text = "失败";
            // 
            // labA
            // 
            this.labA.AutoSize = true;
            this.labA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labA.ForeColor = System.Drawing.Color.Crimson;
            this.labA.Location = new System.Drawing.Point(53, 96);
            this.labA.Name = "labA";
            this.labA.Size = new System.Drawing.Size(35, 14);
            this.labA.TabIndex = 10;
            this.labA.Text = "失败";
            // 
            // BakingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.labA);
            this.Controls.Add(this.labB);
            this.Controls.Add(this.textA);
            this.Controls.Add(this.buttA);
            this.Controls.Add(this.textB);
            this.Controls.Add(this.buttB);
            this.Controls.Add(this.labName);
            this.Name = "BakingPage";
            this.Size = new System.Drawing.Size(175, 169);
            this.cmp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Button buttB;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.TextBox textA;
        private System.Windows.Forms.Button buttA;
        private System.Windows.Forms.ContextMenuStrip cmp;
        private System.Windows.Forms.ToolStripMenuItem run;
        private System.Windows.Forms.ToolStripMenuItem bide;
        private System.Windows.Forms.Label labB;
        private System.Windows.Forms.Label labA;
    }
}
