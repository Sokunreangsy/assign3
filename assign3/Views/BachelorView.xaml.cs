using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assign3.Views
{
    /// <summary>
    /// Interaction logic for BachelorView.xaml
    /// </summary>
    public partial class BachelorView : UserControl
    {
        private bool isSearchOptionClosed = true;
        public BachelorView()
        {
            InitializeComponent();
        }
        private void ChangeTextBoxValue()
        {
            if (searchOptions.SelectedItem != null)
            {
                KeyValuePair<int, string> search = (KeyValuePair<int, string>)searchOptions.SelectedItem;
                if (search.Value != null)
                {

                    switch (search.Value)
                    {
                        case "Student Groups":
                            searchSuggest.Text = "Please enter students' id";
                            break;

                        case "Classes":
                            searchSuggest.Text = "Please enter class id";
                            break;
                        case "Student Classes":
                            searchSuggest.Text = "Please enter students' id";
                            break;
                        case "Groups":
                            searchSuggest.Text = "Please enter group id";
                            break;
                    }
                }
            }
        }
        private void SearchOptionsSelectChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox search = sender as ComboBox;
            isSearchOptionClosed = !search.IsDropDownOpen;
            ChangeTextBoxValue();
        }
        private void SearchOptionsDropDownClosed(object sender, EventArgs e)
        {
            if (isSearchOptionClosed)
            {
                ChangeTextBoxValue();
                isSearchOptionClosed = true;
            }
        }

    }
}
