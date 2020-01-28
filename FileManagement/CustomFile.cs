using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement
{
    public class CustomFile
    {
        #region Properties

        public Guid EntityId { get; set; }

        Guid? id { get; set; }
        public Guid Id
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid();

                return id.Value;
            }
            set
            {
                id = value;
            }
        }

        public string Name { get; private set; }

        public string NameWithExtension
        {
            get
            {
                return string.Format("{0}{1}", Name, Extension);
            }
        }

        public byte[] Data { get; private set; }

        public string DataAsString
        {
            get
            {
                return ByteArrayToString(Data);
            }
        }

        public string Extension { get; private set; }

        public string PathToRead { get; private set; }

        public string PathToWrite { get; private set; }

        public FileInfo FileInfo { get; set; }

        Compressor Compressor { get; set; }

        public IsolatedStorage IsolatedStorage { get; private set; }

        public Serializer Serializer { get; set; }

        public Action<Exception> LogAction { get; set; }

        public string Base64String
        {
            get
            {
                return Convert.ToBase64String(Data);
            }
        }

        public double LengthAsGb
        {
            get
            {
                return Convert.ToDouble(string.Format("{0:0.0000}", (double)LengthAsMb / (double)1024));
            }
        }

        public double LengthAsMb
        {
            get
            {
                return Convert.ToDouble(String.Format("{0:0.0000}", (double)LengthAsKb / (double)1024));
            }
        }

        public double LengthAsKb
        {
            get
            {
                return Convert.ToDouble(String.Format("{0:0.0000}", (double)LengthAsByte / (double)1024));
            }
        }

        public double LengthAsByte
        {
            get
            {
                return Convert.ToDouble(String.Format("{0:0.0000}", (double)FileInfo.Length));
            }
        }

        public static string CurrentUserDesktopPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }

        public static string CurrentProjectBinPath
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }

        #endregion

        #region Constructor

        public CustomFile() 
        {
            Initialize();
        }

        public CustomFile(string path)
        {
            SetData(path);

            Initialize();
        }

        public CustomFile(string fileName, string extension, byte[] data = null)
        {
            SetName(fileName);

            SetExtension(extension);

            SetData(data);

            Initialize();
        }

        public virtual void Initialize()
        {
            //SetIsolatedStorage();
        }

        #endregion

        #region Functions

        //public BinaryReader CreateBinaryReader()
        //{
        //    return new BinaryReader(System.IO.File.Open(PathToRead, FileMode.Open));
        //}

        //public BinaryWriter CreateBinaryWriter()
        //{
        //    return new BinaryWriter(System.IO.File.Open(PathToWrite, FileMode.Create));
        //}

        public Stream GetIsolatedStorageFileStream()
        {
            SetIsolatedStorage();

            return IsolatedStorage.StorageFileStream;
        }

        public MemoryStream CreateMemoryStream()
        {
            return new MemoryStream(Data);
        }

        public byte[] ReadAllBytes()
        {
            return ReadAllBytes(PathToRead, LogAction);
        }

        public CustomFile SetData(string path)
        {
            try
            {
                if (!Exists(path))
                    throw new Exception(string.Format("The file : '{0}' doesnt exists", path));

                SetPathToRead(path);
                SetPathToWrite(path);

                Data = ReadAllBytes();

                SetExtension(System.IO.Path.GetExtension(path));

                SetName(System.IO.Path.GetFileNameWithoutExtension(path));

                FileInfo = new FileInfo(path);
            }
            catch (Exception ex)
            {
                if (LogAction != null)
                    LogAction(ex);
            }

            return this;
        }

        private CustomFile SetData(byte[] data)
        {
            Data = data;

            return this;
        }

        public CustomFile SetCompressor()
        {
            Compressor = new Compressor(this);

            return this;
        }

        public CustomFile SetExtension(string extension)
        {
            Extension = extension;

            return this;
        }

        private CustomFile SetIsolatedStorage()
        {
            if (IsolatedStorage != null)
                IsolatedStorage.Dispose();

            IsolatedStorage = new IsolatedStorage(this);

            return this;
        }

        public CustomFile SetLogAction(Action<Exception> logAction)
        {
            LogAction = logAction;

            return this;
        }

        public CustomFile SetName(string name)
        {
            Name = name;

            return this;
        }

        public CustomFile SetPathToRead(string path)
        {
            PathToRead = path;

            return this;
        }

        public CustomFile SetPathToWrite(string path)
        {
            PathToWrite = path;

            return this;
        }

        public Serializer SetSerializer()
        {
            Serializer = new Serializer(this);

            return Serializer;
        }

        public void WriteAllBytes(byte[] data = null)
        {
            //string.Format("{0}-Compressed.gz", DateTime.Now.ToString("[yyyy-MM-dd HH-mm-ss-fff]")

            data = data ?? Data;

            WriteAllBytes(PathToWrite, data, LogAction);
        }
        #endregion

        #region Static Functions

        public static string ByteArrayToString(byte[] data, Encoding encoding = null)
        {
            encoding = encoding ?? System.Text.Encoding.UTF8;

            return encoding.GetString(data);
        }

        public static byte[] StringToByteArray(string value, Encoding encoding = null)
        {
            encoding = encoding ?? System.Text.Encoding.UTF8;

            return encoding.GetBytes(value);
        }

        public static string CombinePaths(params string[] paths)
        {
            return System.IO.Path.Combine(paths);
        }

        public static List<string> DirectoryGetFiles(string path)
        {
            var list = new List<string>();

            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                list.Add(file);
            }

            return list;
        }

        public static bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public static string GetFilePathFromCurrentProjectBin(string fileName)
        {
            return CombinePaths(CurrentProjectBinPath, fileName);
        }

        public static string GetFilePathFromCurrentUserDesktop(string fileName)
        {
            return CombinePaths(CurrentUserDesktopPath, fileName);
        }

        public static bool HasInvalidPathChar(string path)
        {
            return System.IO.Path.GetInvalidPathChars().ToList().Any(c => path.Contains(c));
        }

        public static byte[] ReadAllBytes(string path, Action<Exception> logAction)
        {
            byte[] array = null;

            try
            {
                array = System.IO.File.ReadAllBytes(path);
            }
            catch (Exception ex)
            {
                if (logAction != null)
                    logAction(ex);
            }

            return array;
        }

        public static void WriteAllBytes(string path, byte[] data, Action<Exception> logAction)
        {
            try
            {
                System.IO.File.WriteAllBytes(path, data);
            }
            catch (Exception ex)
            {
                if (logAction != null)
                    logAction(ex);
            }
        }

        #endregion
    }
}
