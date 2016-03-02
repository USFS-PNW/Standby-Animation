using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace StandByAnimation
{
    public class StandByAnimation
    {
        private mainform _oAnimationWindow=null;
        private double dblLeft = -1;
        private double dblHeight = -1;
        private double dblWidth = -1;
        private double dblTop = -1;
        private System.Windows.Forms.FormWindowState oWindowState;
        public delegate void ExecuteControlMethodCallback(Control oControl, string strMethodName);
        public StandByAnimation()
        {
        }
        
        
        public StandByAnimation(System.Windows.Forms.FormWindowState p_oWindowState,
                                  double p_dblLeft, 
                                  double p_dblHeight,
                                  double p_dblWidth,
                                  double p_dblTop)
        {
            dblLeft = p_dblLeft;
            dblHeight = p_dblHeight;
            dblWidth = p_dblWidth;
            dblTop = p_dblTop;
            oWindowState = p_oWindowState;

        }
      
        public mainform StandByAnimationWindow
        {
            get { return _oAnimationWindow; }
            set { _oAnimationWindow = value; }
        }
        
        public void StartSplashing()
        {

            if (dblHeight != -1)
            {
                //center the animation inside the client window
                _oAnimationWindow = new mainform(oWindowState,dblLeft, dblHeight, dblWidth,dblTop);
            }
            else
              _oAnimationWindow = new mainform();

           

            _oAnimationWindow.ShowDialog();
        }
        public void StopSplashing()
        {
            while (_oAnimationWindow == null)
                System.Threading.Thread.Sleep(100);

            // Now stop this window dead in its tracks!
            ExecuteControlMethod(_oAnimationWindow, "Close");
           
        }
        public void ExecuteControlMethod(Control p_oControl, string p_strMethodName)
        {

            if (p_oControl.InvokeRequired)
            {
                ExecuteControlMethodCallback d = new ExecuteControlMethodCallback(ExecuteControlMethod);
                try
                {
                    p_oControl.Invoke(d, new object[] { p_oControl, p_strMethodName });
                }
                catch
                {
                }
            }
            else
            {
                Type t = p_oControl.GetType();
                System.Reflection.MethodInfo[] methods = t.GetMethods();
                foreach (System.Reflection.MethodInfo m in methods)
                {
                    if (m.Name.Trim().ToUpper() == p_strMethodName.Trim().ToUpper())
                    {
                        m.Invoke(p_oControl, null);
                        break;
                    }
                }
            }


        }
    }
    
}
