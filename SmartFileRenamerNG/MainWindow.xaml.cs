using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.IO;

namespace SmartFileRenamerNG
{
    public enum DisplayMode
    {
        FullPath,
        NameOnly,
        DiscrepancyOnly,
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DisplayMode DisplayMode { get; set; } = DisplayMode.FullPath;
        public List<string> SubtitleFiles { get; set; } = new List<string>();
        public List<string> VideoFiles { get; set; } = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void subtitlesFilter_Click(object sender, RoutedEventArgs e)
        {
            SubtitleFiles = SubtitleFiles.Where(x => x.Contains(subtitlesFilterValue.Text)).ToList();
        }

        private void subtitlesFilterAuto_Click(object sender, RoutedEventArgs e)
        {
            SubtitleFiles = SubtitleFiles.Where(x => x.Contains(".ass") || x.Contains(".ssa") || x.Contains(".srt") || x.Contains(".idx") || x.Contains(".sub")).ToList();
        }

        private void subtitlesSort_Click(object sender, RoutedEventArgs e)
        {
            SubtitleFiles.Sort();
        }

        private void subtitlesAddFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == true)
            {
                SubtitleFiles.AddRange(dialog.FileNames.Where(f => !SubtitleFiles.Contains(f)));
            }
        }

        private void subtitlesAddFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SubtitleFiles.AddRange(Directory.EnumerateFiles(dialog.SelectedPath).Where(f => !SubtitleFiles.Contains(f)));
            }
        }
    }
}
