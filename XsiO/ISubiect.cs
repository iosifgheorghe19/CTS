using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XsiO
{
    public interface ISubiect
    {
        void attach(IObserverBtn o);
        void detach(IObserverBtn o);
        void notificaObservatorii();

    }
}
