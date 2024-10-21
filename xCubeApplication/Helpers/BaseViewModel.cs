using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xCubeApplication.Helpers
{
    public class BaseViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Notifies objects registered to receive this event that a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that was changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
