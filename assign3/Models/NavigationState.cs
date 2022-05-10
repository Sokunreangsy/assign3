using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
    public class NavigationState
    {


        public event Action CurrentViewModelChanged;
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {

            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }

        }

        protected void OnCurrentViewModelChanged()
        {
            //similar to on propertychange in viewmodels
            CurrentViewModelChanged?.Invoke();
        }


    }
}
