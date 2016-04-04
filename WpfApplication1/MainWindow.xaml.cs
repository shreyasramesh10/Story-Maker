using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;


namespace WpfApplication1
{

    public class StoryBlock
    {
        public int StoryBlockID { get; set; }
        public int StoryBlockSeq { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string ImgName { get; set; }
        public virtual int CollageID { get; set; }
    }
    public class Collage
    {
        public int CollageID { get; set; }
        public int CollageSeq { get; set; }
        public string CollageName { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public DateTime Uploaded { get; set; }
        public virtual ICollection<StoryBlock> storyblock { get; set; }
    }
    public partial class MainWindow : Window
    {

        List<string> foundfiles = new List<string>();
        IAsyncResult cbResult;
        public MainWindow()
        {
            InitializeComponent();
        }

        void showPath(string path)
        {
            textBlock1.Text = "";
        }
        /*-- invoke on UI thread --------------------------------*/

        void addFile(string file)
        {
            bool options_check = Regex.IsMatch(file, @"(.*?)\.(jpg|jpeg|png|gif)$");
            if (options_check)
            {        
                listBox1.Items.Add(file);
            }
        }
        void search(string path, string pattern)
        {
            /* called on asynch delegate's thread */
            if (Dispatcher.CheckAccess())
                showPath(path);
            else
                Dispatcher.Invoke(
                  new Action<string>(showPath),
                  System.Windows.Threading.DispatcherPriority.Background,
                  new string[] { path }
                );
            string[] files = System.IO.Directory.GetFiles(path, pattern);
            foreach (string file in files)
            {
                if (Dispatcher.CheckAccess())
                    addFile(file);
                else
                    Dispatcher.Invoke(
                      new Action<string>(addFile),
                      System.Windows.Threading.DispatcherPriority.Background,
                      new string[] { file }
                    );
            }
            string[] dirs = System.IO.Directory.GetDirectories(path);
            foreach (string dir in dirs)
                search(dir, pattern);
        }
        /*-- Start search on asynchronous delegate's thread -----*/

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            dlg.SelectedPath = path;
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                listBox1.Items.Clear();
                path = dlg.SelectedPath;
                string pattern = "*.*";
                Action<string, string> proc = this.search;
                cbResult = proc.BeginInvoke(path, pattern, null, null);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            string curItem = listBox1.SelectedItem.ToString();
            textBlock1.Text = curItem;
        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            string sequenceNum = TextSeq1.Text;
            string ImageName = TextName.Text;
            string ImageCaption = TextCaption.Text;
            string ImageDesc = TextDesc.Text;
            string ImagePath = textBlock1.Text;
            string ImagePathDup = ImagePath;
            int seqNum = Int32.Parse(sequenceNum);
            string fileName = System.IO.Path.GetFileName(ImagePath);
            string currDir =  System.IO.Directory.GetCurrentDirectory();
            System.IO.Directory.SetCurrentDirectory("../../..");
            currDir = System.IO.Directory.GetCurrentDirectory();
            string appPath = currDir + @"\IPFinalPrj\UploadedFiles\" + fileName;
            if (!System.IO.File.Exists(appPath)) { System.IO.File.Copy(ImagePathDup, appPath); }
        }
    }
}
