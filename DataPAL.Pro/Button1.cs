using ArcGIS.Desktop.Framework.Contracts;


namespace DataPAL.Pro
{
    internal class Button1 : Button
    {
        protected override void OnClick()
        {
            var mw = new MainWindow();
            mw.Show();
        }
    }
}
