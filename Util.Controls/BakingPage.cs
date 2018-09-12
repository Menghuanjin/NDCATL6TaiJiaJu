using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util.Controls
{
    public partial class BakingPage : UserControl
    {
        public delegate void MyDelegate(object sender, EventArgs e);//建立委托
        public static  MyDelegate myEven_click;

   
        /// <summary>
        /// 
        /// </summary>
        public string  _labName
        {
            get { return labName.Text; }
            set { labName.Text = value; }
        }


        ///// <summary>
        ///// 机器运行状态
        ///// </summary>
        //public Image _picBox
        //{
        //    get { return PicBox.Image; }
        //    set { PicBox.Image = value; }
        //}
      
        /// <summary>
        /// A层内容显示
        /// </summary>
        public string _textA
        {
            get { return textA.Text; }
            set { textA.Text = value; }
        }

       
        /// <summary>
        /// B层内容显示
        /// </summary>
        public string  _textB
        {
            get { return textB.Text; }
            set { textB.Text = value; }
        }

        /// <summary>
        /// A层运行状态显示
        /// </summary>
        public  string _labA
        {
            get { return labA.Text; }
            set { labA.Text = value; }
        }
        /// <summary>
        /// B层运行状态显示
        /// </summary>
        public  string _labB
        {
            get { return labB.Text; }
            set { labB.Text = value; }
        }

     

        public string _buttA
        {
            get { return buttA.Name; }
            set { buttA.Name = value; }
        }

        public string _buttB
        {
            get { return buttB.Name; }
            set { buttB.Name = value; }
        }


        private static string context;
        /// <summary>
        /// 获取快捷菜单从那个点击
        /// </summary>
        public static string _context
        {
            get { return context; }
            set { context = value; }
        }

        public BakingPage()
        {
            InitializeComponent();
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        private void Connect_Click(object sender, EventArgs e)
        {
            if (myEven_click != null)
            {
                myEven_click(sender, e);
            }
        }
        // 圆角    
        private int _Radius = 50;  // 圆角弧度
        public void Round(System.Drawing.Region region)
        {
            System.Drawing.Drawing2D.GraphicsPath oPath = new System.Drawing.Drawing2D.GraphicsPath();
            int x = 0;
            int y = 0;
            int thisWidth = this.Width;
            int thisHeight = this.Height;
            int angle = _Radius;
            if (angle > 0)
            {
                System.Drawing.Graphics g = CreateGraphics();
                oPath.AddArc(x, y, angle, angle, 180, 90);                                 // 左上角
                oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90);                 // 右上角
                oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90);  // 右下角
                oPath.AddArc(x, thisHeight - angle, angle, angle, 90, 90);                 // 左下角
                oPath.CloseAllFigures();
                Region = new System.Drawing.Region(oPath);
            }
            else
            {
                oPath.AddLine(x + angle, y, thisWidth - angle, y);                         // 顶端
                oPath.AddLine(thisWidth, y + angle, thisWidth, thisHeight - angle);        // 右边
                oPath.AddLine(thisWidth - angle, thisHeight, x + angle, thisHeight);       // 底边
                oPath.AddLine(x, y + angle, x, thisHeight - angle);                        // 左边
                oPath.CloseAllFigures();
                Region = new System.Drawing.Region(oPath);
            }
        }
        public BakingPage(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            this.run.Click += new EventHandler(Connect_Click);
            this.bide.Click+=new EventHandler(Connect_Click);
         //   this.service.Click+=new EventHandler(Connect_Click);
      

            //  ConnectPLC.Click += new EventHandler(ConnectPLC_Click); //绑定委托事件

        }

  

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Round(this.Region);  // 圆角
        }
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            base.Refresh();
        }

        private void cmp_Opening(object sender, CancelEventArgs e)
        {
            context = (sender as ContextMenuStrip).SourceControl.Name;
        }
    }
}
