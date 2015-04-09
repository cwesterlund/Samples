using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDemo.Services
{
    public class ToastService
    {
        private ToastHelper Helper;
        public ToastService()
        {
            this.Helper = new ToastHelper();
        }
    }
}
