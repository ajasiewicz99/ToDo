using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToDoList.Core
{
    public class BaseView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, EventArgs) => { };

        protected void OnProperyChanged(string name)
        {
            PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(name)));
        }
    }
}
