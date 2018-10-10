using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace DataPAL.Pro
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        // Gets layer list to populate listbox in UC2 (called from UC1)
        public void PopulatecheckedListBox1(ListBox lsb, string folder, string fileType)
        {

            DirectoryInfo dinfo = new DirectoryInfo(folder);
            FileInfo[] files = dinfo.GetFiles(fileType);
            foreach (FileInfo file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FullName);
                lsb.Items.Add(fileName);
            }

        }

        //Returns to UC1
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.ContentControl.Content = new UserControl1();
        }

        //Adds listbox item to 'chosen' listbox
        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            ChosenList.Items.Remove(LayerList.SelectedItem);
            ChosenList.Items.Add(LayerList.SelectedItem);
        }

        //Removes item from 'chosen' listbox
        private void layerUp_Click(object sender, RoutedEventArgs e)
        {
            ChosenList.Items.Remove(ChosenList.SelectedItem);
        }

        //Adds items from 'chosen' listbox to TOC
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var pth in ChosenList.Items)
            {
                MainWindow win = new MainWindow();
                string url = win.PathDict[pth.ToString()];
                Uri uri = new Uri(url);
                QueuedTask.Run(() => LayerFactory.Instance.CreateLayer(uri, MapView.Active.Map));
            }

        }
    }
}
