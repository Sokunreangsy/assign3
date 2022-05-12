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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private bool isSearchOptionClosed = true;
        public HomeView()
        {
            InitializeComponent();
           
        }

        private void ChangeTextBoxValue()
        {
            if(searchOptions.SelectedItem != null)
            {
                KeyValuePair<int, string> search = new KeyValuePair<int, string>();
                search = (KeyValuePair<int, string>)searchOptions.SelectedItem;
                if (search.Value != null)
                {

                    switch (search.Value)
                    {
                        case "Students":
                            searchSuggest.Text = "Please enter students' name";
                            break;

                        case "Classes":
                            searchSuggest.Text = "Please enter class id";
                            break;
                        case "Meetings":
                            searchSuggest.Text = "Please enter meeting id";
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

        private void GridResultUpdated(object sender, DataTransferEventArgs e)
        {
            DataGrid itemList = sender as DataGrid;
            if (itemList.Columns.Count != 0)
            {
                if ((string)itemList.Columns[0].Header == "StudentId")
                {
                    itemList.Columns.RemoveAt(0);
                }
                if (itemList.Columns.Count == 7)
                {
                    if ((string)itemList.Columns[6].Header == "StudentGroups")
                    {
                        itemList.Columns.RemoveAt(6);
                    }
                }
               

            }
            
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender)
        {

        }
    }
}
