using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XylophoneRobot
{
    public class PaperPanel : Panel
    {
        public PaperPanel() : base()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles();
        }
    }
}
