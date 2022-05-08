using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using assign3.ViewModels;
namespace assign3.NavState
{
    // class for navigation's state between page
    public class NavigationState
    {

        //add event when the current view model value is changed
        //else it wont update the view
        public event Action CurrentViewModelChanged;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel {

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
