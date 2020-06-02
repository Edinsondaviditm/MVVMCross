using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalculator.Core.Interfaces
{
    public interface IDialogService
    {
        void Alert(string message, string title, string okbtnText);
    }
}
