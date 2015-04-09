using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInformationDemo.Common
{
    public class Command : GalaSoft.MvvmLight.Command.RelayCommand
    {
        public Command(Action execute) : base(execute) { }
        public Command(Action execute, Func<bool> canExecute) : base(execute, canExecute) { }
    }

    public class Command<T> : GalaSoft.MvvmLight.Command.RelayCommand<T>
    {
        public Command(Action<T> execute) : base(execute) { }
        public Command(Action<T> execute, Func<T, bool> canExecute) : base(execute, canExecute) { }
    }
}
