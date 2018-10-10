using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;


namespace DataPAL.Pro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _dataFolders = new List<string>();

        public List<string> SearchSource = new List<string>(); //List used to populate UC1 SearchBar(combobox)
        public Dictionary<string, string> PathDict = new Dictionary<string, string>(); //Dictionary used to store layer paths with layer name as key

        public MainWindow()
        {
            InitializeComponent();
            ContentControl.Content = new UserControl1();

            ShadowAssist.SetShadowDepth(this, ShadowDepth.Depth0); //Needed to use Material Design dependencies for some reason
            var hue = new Hue("Dummy", Colors.AliceBlue, Colors.AntiqueWhite); //Needed to use Material Design dependencies for some reason

            _dataFolders.Add(@"\\Epcnas\gis\DataPal\Layers\Boundaries");
            _dataFolders.Add(@"\\Epcnas\gis\DataPal\Layers\Imagery");
            _dataFolders.Add(@"\\Epcnas\gis\DataPal\Layers\Water");
            _dataFolders.Add(@"\\Epcnas\gis\DataPal\Layers\Transportation");
            _dataFolders.Add(@"\\Epcnas\gis\DataPal\Layers\HabitatEnvironment");
            _dataFolders.Add(@"\\Epcnas\gis\DataPal\Layers\EPC_Authoritative");

            //Populate search source list and layer path dictionary
            foreach (var pth in _dataFolders)
            {
                DirectoryInfo dinfo = new DirectoryInfo(pth);
                FileInfo[] files = dinfo.GetFiles("*.lyr");
                foreach (FileInfo file in files)
                {

                    string fileName = Path.GetFileNameWithoutExtension(file.FullName);
                    SearchSource.Add(fileName);
                    PathDict.Add(fileName, Path.GetFullPath(file.FullName));

                }
            }

        }
    }
}
