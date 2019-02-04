using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;


namespace DataPAL.Pro
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        //Populate autocomplete in combobox
        private void SearchBar_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            SearchBar.ItemsSource = win.SearchSource;

        }

        //Add selected combobox item to TOC
        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            MainWindow win = new MainWindow();

            if (e.Key == Key.Return)
            {

                string url = win.PathDict[SearchBar.Text];
                Uri uri = new Uri(url);
                QueuedTask.Run(() => LayerFactory.Instance.CreateLayer(uri, MapView.Active.Map));

            }
        }

        //Populate listbox in UC2 with layers corresponding to card catagory
        private void PlacesCard_MouseDown(object sender, MouseButtonEventArgs e)
        {

            UserControl2 ucControl2 = new UserControl2();
            ucControl2.LayerList.Items.Clear();
            ucControl2.PopulatecheckedListBox1(ucControl2.LayerList, @"\\nas\gis\DataPal\Layers\Boundaries", "*.lyr");
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = ucControl2;
        }

        public void ImageryCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControl2 ucControl2 = new UserControl2();
            ucControl2.LayerList.Items.Clear();
            ucControl2.PopulatecheckedListBox1(ucControl2.LayerList, @"\\nas\gis\DataPal\Layers\Imagery", "*.lyr");
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = ucControl2;
        }

        private void HydroCard_MouseDown(object sender, MouseButtonEventArgs e)
        {

            UserControl2 ucControl2 = new UserControl2();
            ucControl2.LayerList.Items.Clear();
            ucControl2.PopulatecheckedListBox1(ucControl2.LayerList, @"\\nas\gis\DataPal\Layers\Water", "*.lyr");
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = ucControl2;

        }

        private void UtilCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControl2 ucControl2 = new UserControl2();
            ucControl2.LayerList.Items.Clear();
            ucControl2.PopulatecheckedListBox1(ucControl2.LayerList, @"\\nas\gis\DataPal\Layers\Transportation", "*.lyr");
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = ucControl2;
        }

        private void EnvCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControl2 ucControl2 = new UserControl2();
            ucControl2.LayerList.Items.Clear();
            ucControl2.PopulatecheckedListBox1(ucControl2.LayerList, @"\\nas\gis\DataPal\Layers\HabitatEnvironment", "*.lyr");
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = ucControl2;
        }

        private void AuthCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserControl2 ucControl2 = new UserControl2();
            ucControl2.LayerList.Items.Clear();
            ucControl2.PopulatecheckedListBox1(ucControl2.LayerList, @"\\nas\gis\DataPal\Layers\EPC_Authoritative", "*.lyr");
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = ucControl2;
        }
    }
}
