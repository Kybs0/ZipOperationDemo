using System;
using System.Collections.Generic;
using System.IO;
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
using ICSharpCode.SharpZipLib.Zip;
using Path = System.IO.Path;

namespace ZipDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var destZipPath = @"C:\Users\10167\Desktop\新建文件夹\test.zip";
            var fileToZip = @"C:\Users\10167\Desktop\20200319010103402_easyicon_net_128.ico";
            using (var zip = ZipFile.Create(destZipPath))
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                zip.BeginUpdate();
                Directory.SetCurrentDirectory(Path.GetDirectoryName(fileToZip));
                zip.Add(Path.GetFileName(fileToZip));
                zip.CommitUpdate();
                Directory.SetCurrentDirectory(currentDirectory);
            }
        }
    }
}
