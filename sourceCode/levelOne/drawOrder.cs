using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bushido
{
    public static class drawOrder
    {
       static int orderDraw;
        public static int order
        {
            get { return orderDraw; }
            set { orderDraw = value; }
        }
    }
}
