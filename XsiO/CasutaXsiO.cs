using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XsiO
{
    public class CasutaXsiO : Button, IObserverBtn
    {
        public void update()
        {
            this.BackColor = Color.Aquamarine;
        }

        public void update(Color c)
        {
            this.BackColor = c;
        }
    }
}
