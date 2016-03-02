using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Threading;


namespace StandByAnimation
{
    public partial class mainform : Form
    {
        CircularIndeterminateProgress m_oStandByAnimation = null;
        public mainform()
        {
            InitializeComponent();
            this.Text = "MainForm";
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            m_oStandByAnimation = new CircularIndeterminateProgress();
            m_oStandByAnimation.BackColor = Color.Black;
            m_oStandByAnimation.ForeColor = Color.Red;
            this.Controls.Add(m_oStandByAnimation);
            m_oStandByAnimation.Left = (int)(this.Width / 2) - (int)(m_oStandByAnimation.Width / 2);
            m_oStandByAnimation.Top = (int)(this.Height / 2) - (int)(m_oStandByAnimation.Height / 2);
            
        }
        public mainform(System.Windows.Forms.FormWindowState p_oWindowState,
                                  double p_dblLeft, 
                                  double p_dblHeight,
                                  double p_dblWidth,
                                  double p_dblTop)
         {
             
             InitializeComponent();
             this.Text = "MainForm";
             this.BackColor = Color.Black;
             this.TransparencyKey = Color.Black;
             m_oStandByAnimation = new CircularIndeterminateProgress();
             m_oStandByAnimation.BackColor = Color.Black;
             m_oStandByAnimation.ForeColor = Color.Red;
             this.Controls.Add(m_oStandByAnimation);
             m_oStandByAnimation.Left = (int)(this.Width / 2) - (int)(m_oStandByAnimation.Width / 2);
             m_oStandByAnimation.Top = (int)(this.Height / 2) - (int)(m_oStandByAnimation.Height / 2);
             _dblLeft = p_dblLeft;
             _dblHeight = p_dblHeight;
             _dblTop = p_dblTop;
             _dblWidth = p_dblWidth;
             _oWindowState = p_oWindowState;
             

             if (_oWindowState == System.Windows.Forms.FormWindowState.Maximized)
             {
                 this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
             }
             else
             {
                 this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
             }
             
             this.BringToFront();
             

         }
        public CircularIndeterminateProgress StandByAnimation
        {
            get { return m_oStandByAnimation; }
            set { m_oStandByAnimation = value; }
        }
        private static double _dblLeft=-1;
        public static double ClientPositionLeft
        {
            get {return _dblLeft;}
            set { _dblLeft = value; }
        }
        private static double _dblHeight = -1;
        public static double ClientHeight
        {
            get { return _dblHeight; }
            set { _dblHeight = value; }
        }
        private static double _dblWidth = -1;
        public static double ClientWidth
        {
            get { return _dblWidth; }
            set { _dblWidth = value; }
        }
        private static double _dblTop = -1;
        public static double ClientPositionTop
        {
            get { return _dblTop; }
            set { _dblTop = value; }
        }
        private static System.Windows.Forms.FormWindowState _oWindowState;
        public static System.Windows.Forms.FormWindowState ClientWindowState
        {
            get { return _oWindowState; }
            set { _oWindowState = value; }
        }
        private void mainform_Resize(object sender, EventArgs e)
        {
            m_oStandByAnimation.Left = (int)(this.Width / 2) - (int)(m_oStandByAnimation.Width / 2);
            m_oStandByAnimation.Top = (int)(this.Height / 2) - (int)(m_oStandByAnimation.Height / 2);
        }
        private void CenterAnimation()
        {
            m_oStandByAnimation.Left = (int)(this.Width / 2) - (int)(m_oStandByAnimation.Width / 2);
            m_oStandByAnimation.Top = (int)(this.Height / 2) - (int)(m_oStandByAnimation.Height / 2);
        }
        public void ShowAnimation()
        {
            this.BringToFront();
            m_oStandByAnimation.Show();
        }
        public void CenterMainForm(System.Windows.Forms.FormWindowState p_oWindowState, double p_dblLeft, double p_dblHeight, double p_dblWidth, double p_dblTop)
        {
            this.Left = (int)((int)p_dblWidth / 2) - (int)(this.Width / 2);
            this.Top = (int)((int)p_dblHeight / 2) - (int)(this.Height / 2);
            CenterAnimation();
        }
        public void StartSplashing()
        {
            this.BringToFront();
            m_oStandByAnimation.Show();
        }

        public void StopSplashing()
        {
            // If the time between creating this splash window and requesting it to stop is tooooo short,
            // you need to wait until the Window exists or you'll throw a NullReferenceException.
            while (m_oStandByAnimation == null)
                Thread.Sleep(100);

            this.Close();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            if (ClientWindowState != System.Windows.Forms.FormWindowState.Maximized)
            {
                this.Left = (int)((ClientWidth * .5) + (int)ClientPositionLeft) - (int)(this.Width / 2);
                this.Top = (int)((ClientHeight * .5) + (int)ClientPositionTop) - (int)(this.Height * .5);
            }
        }
       
    }
   

}
