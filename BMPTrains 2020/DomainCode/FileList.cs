using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Allows for a list of current files.
namespace BMPTrains_2020.DomainCode
{
    class FileList : XmlPropertyObject
    {
        public const string RecentFiles = "RecentFiles.xml";
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string File3 { get; set; }
        public string File4 { get; set; }
        public string File5 { get; set; }
        public string File6 { get; set; }
       
        public List<string> files;

        // Constructor - build a File List for Open
        public FileList()
        {
            files = new List<String>();
            OpenFileList();
        }

        // Build the FileList adding a new File
        public FileList(string fn)
        {
            files = new List<String>();
            OpenFileList();
            createListFromFilenames();
            AddFile(fn);
            SetValues();
        }

        public void SetValues()
        {
            int n = files.Count;
            if (n == 0) return;
            File1 = files[0]; if (n == 1) return;
            File2 = files[1]; if (n == 2) return;
            File3 = files[2]; if (n == 3) return;
            File4 = files[3]; if (n == 4) return;
            File5 = files[4]; if (n == 5) return;
            File6 = files[5];
        }

        public void AddFile(string filename)
        {
            // Adds the file to the list
            if (filename == null) return;
            
            if (files.Contains<String>(filename))
            {
                files.RemoveAll(x => x == filename);
                files.Insert(0, filename);
            }
            else
            {
                files.Insert(0, filename);
            }
        }

        public bool SaveFileList()
        {
            SetValues();
            string filename = Common.WorkingDirectory() + "\\" + RecentFiles;
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                    sw.WriteLine(this.AsXML());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string OpenFileList()
        {
            string filename = Common.WorkingDirectory() + "\\" + RecentFiles;
            //{
            if (File.Exists(filename))
            {
                string s = File.ReadAllText(filename);
                s = s.Replace('&', '_');
                this.fromXML(s);
            }
            
            return "";
        }

        public void createListFromFilenames()
        {
            // Reverse order as the Add always adds to the first element
            if (File6 != "") AddFile(File6);
            if (File5 != "") AddFile(File5);
            if (File4 != "") AddFile(File4);
            if (File3 != "") AddFile(File3);
            if (File2 != "") AddFile(File2);
            if (File1 != "") AddFile(File1);

        }

        // Helper type used to display basename while retaining full path
        private class RecentFileItem
        {
            public string FullPath { get; }
            public string DisplayName { get; }

            public RecentFileItem(string fullPath)
            {
                FullPath = fullPath ?? "";
                try
                {
                    DisplayName = string.IsNullOrEmpty(FullPath) ? "" : Path.GetFileName(FullPath);
                    if (string.IsNullOrEmpty(DisplayName)) DisplayName = FullPath; // fallback
                }
                catch
                {
                    DisplayName = FullPath;
                }
            }

            // ListBox calls ToString() for display when Items are objects
            public override string ToString() => DisplayName;
        }

        /// <summary>
        /// Populate the ListBox with SHORT names (file name only) while the ListBox.Items keep the object
        /// that contains the full path.  Double-click handlers should read the selected RecentFileItem.FullPath.
        /// </summary>
        public void FillListBox(ListBox lb)
        {
            if (lb == null) return;
            lb.Items.Clear();

            // Prefer the in-memory 'files' list if available, otherwise fall back to File1..File6
            var source = new List<string>();
            if (files != null && files.Count > 0)
            {
                source.AddRange(files.Where(f => !string.IsNullOrWhiteSpace(f)));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(File1)) source.Add(File1);
                if (!string.IsNullOrWhiteSpace(File2)) source.Add(File2);
                if (!string.IsNullOrWhiteSpace(File3)) source.Add(File3);
                if (!string.IsNullOrWhiteSpace(File4)) source.Add(File4);
                if (!string.IsNullOrWhiteSpace(File5)) source.Add(File5);
                if (!string.IsNullOrWhiteSpace(File6)) source.Add(File6);
            }

            // Add RecentFileItem objects so ListBox shows the filename but SelectedItem contains full path
            foreach (var path in source)
            {
                if (string.IsNullOrWhiteSpace(path)) continue;
                lb.Items.Add(new RecentFileItem(path));
            }
        }

        /// <summary>
        /// Return the full path for the currently selected item in the ListBox.  Works with legacy string items too.
        /// </summary>
        public static string GetFullPathFromListBox(ListBox lb)
        {
            if (lb == null || lb.SelectedItem == null) return string.Empty;

            if (lb.SelectedItem is RecentFileItem rfi)
            {
                return rfi.FullPath;
            }

            // Backwards compatibility: item might be plain string (full path)
            if (lb.SelectedItem is string s)
            {
                return s;
            }

            return lb.SelectedItem.ToString();
        }

        public override Dictionary<string, string> PropertyLabels()
        {
            return new Dictionary<string, string>
            {
            };
        }

        public override Dictionary<string, int> PropertyDecimalPlaces()
        {
            return new Dictionary<string, int>
            {
            };
        }
    }
}
