using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Collections.ObjectModel;
using System.Windows.Input;

using assign3.Models;
using assign3.Database;
using assign3.Command;
using System.Runtime.CompilerServices;

namespace assign3.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
        }

    }
      
}
/*public class SelectStudentsCommand : ICommand
{
    
    public event EventHandler CanExecuteChanged;

    private List<Student>
    public SelectStudentsCommand()
    public bool CanExecute(object parameter)
    {
        return true;
    }
    protected void OnCanExecutedChanged()
    {
        CanExecuteChanged.Invoke(this, new EventArgs());
    }

    public void Execute(object parameter)
    {
        
    }
}*/
//https://www.youtube.com/watch?v=2FPFgW0xVB0
//https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/commanding-overview?view=netframeworkdesktop-4.8
// https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern