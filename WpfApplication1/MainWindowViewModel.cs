using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;

namespace WpfApplication1 {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel() {
            OpenFileCommand = new RelayCommand(OpenFile);
            ReadFileCommand = new RelayCommand(ReadFile);
            EncodingList.Add(Encoding.ASCII);
            EncodingList.Add(Encoding.GetEncoding("Shift_JIS"));
            EncodingList.Add(Encoding.UTF8);
            EncodingList.Add(Encoding.Unicode);
            EncodingList.Add(Encoding.BigEndianUnicode);
            FileEncoding = EncodingList.First();
        }

        private string _filePath;
        public string FilePath {
            get { return _filePath; }
            set {
                if (_filePath == value)
                    return;
                _filePath = value;
                RaisePropertyChanged("FilePath");
            }
        }

        private ObservableCollection<string> _text = new ObservableCollection<string>();
        public ObservableCollection<string> Text {
            get { return _text; }
            set {
                if (_text == value)
                    return;
                _text = value;
                RaisePropertyChanged("Text");
            }
        }

        private ObservableCollection<string> _hexText = new ObservableCollection<string>();
        public ObservableCollection<string> HexText {
            get { return _hexText; }
            set {
                if (_hexText == value)
                    return;
                _hexText = value;
                RaisePropertyChanged("HexText");
            }
        }

        private Encoding _fileEncoding;
        public Encoding FileEncoding {
            get { return _fileEncoding; }
            set {
                if (_fileEncoding == value)
                    return;
                _fileEncoding = value;
                RaisePropertyChanged("FileEncoding");
            }
        }

        private ObservableCollection<Encoding> _encodingList = new ObservableCollection<Encoding>();
        public ObservableCollection<Encoding> EncodingList {
            get { return _encodingList; }
            set {
                if (_encodingList == value)
                    return;
                _encodingList = value;
                RaisePropertyChanged("EncodingList");
            }
        }

        public ICommand ReadFileCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }

        private void ReadFile(object parameter) {
            string fileName = parameter.ToString();
            if (!File.Exists(fileName))
                return;
            Task.Factory.StartNew(() => {
                Text = GetPlainText(fileName);
            });

            Task.Factory.StartNew(() => {
                HexText = GetHexText(fileName);
            });
        }

        private ObservableCollection<string> GetPlainText(string fileName) {
            var oc = new ObservableCollection<string>();
            using (var sr = new StreamReader(fileName, FileEncoding, false)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    oc.Add(line);
                }
            }
            return oc;
        }

        private ObservableCollection<string> GetHexText(string fileName) {
            var oc = new ObservableCollection<string>();
            var sb = new StringBuilder();
            using (var fs = new FileStream(fileName, FileMode.Open)) {
                int i = 0;
                int sc = 0;
                var b = FileEncoding.GetBytes(Environment.NewLine);
                while ((i = fs.ReadByte()) > -1) {
                    if (i == (int)b[sc])
                        sc++;
                    sb.Append(i.ToString("X2") + " ");
                    if (sc >= b.Length) {
                        oc.Add(sb.ToString());
                        sb.Clear();
                        sc = 0;
                    }
                }
                if (sb.Length > 0)
                    oc.Add(sb.ToString());
            }
            return oc;
        }

        private void OpenFile(object parameter) {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
                FilePath = ofd.FileName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
