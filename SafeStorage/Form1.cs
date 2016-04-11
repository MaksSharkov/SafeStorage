using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SafeStorage
{
    public partial class SafeStorage : Form
    {
        string storagePath;
        string addFile;
        List<long> positionsFiles = new List<long> { };
        List<long> lengthFiles = new List<long> { };
        byte[] password16 = new byte[16];
        byte[] test = new byte[5] { 1, 2, 3, 4, 5 };
        static byte[] IV = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        static byte[] checkSumm = { 0x64, 0xFF, 0xA6, 0x25, 0x92, 0xB1, 0x0F, 0xAA, 0x26, 0x3F, 0x7B, 0xBB, 0x26, 0x79, 0x11, 0xC5 };

        public SafeStorage()
        {
            InitializeComponent();
        }

        private void startAddFileInStorage(string file, string storage)
        {
            BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open));
            BinaryWriter writer = new BinaryWriter(File.Open(storage, FileMode.Append));

            try
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileName = fileInfo.Name;
                long fileSize = fileInfo.Length;
                //MessageBox.Show("Имя файла: " + fileName);
                //MessageBox.Show("Размер файла(байт): " + fileSize);
                long currentFile = writer.Seek(0, SeekOrigin.Current);
                //MessageBox.Show("Текущий файл находится на " + currentFile + " байте");
                writer.Write(fileName);
                long nextFile = writer.Seek(0, SeekOrigin.Current) + sizeof(long) * 2 + fileSize;
                //MessageBox.Show("Следующий файл будет на " + nextFile + " байте");
                writer.Write(nextFile);
                writer.Write(fileSize);
                progressAdd.Maximum = (int)fileSize;
                for (long i = 0; i < fileSize; i++)
                {
                    writer.Write(reader.ReadByte());
                    progressAdd.Value++;
                }
                progressAdd.Value = 0;
                reader.Close();
                writer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                reader.Close();
                writer.Close();
            }

        }

        private void createFilesList(string storage)
        {

            BinaryReader reader = new BinaryReader(File.Open(storage, FileMode.Open));

            try
            {
                contentStorage.Items.Clear();
                string fileName;
                long fileSize;
                long currentFile = 0;
                long previousFileLength = 0;
                long nextFile;
                byte[] trash = new byte[1];
                byte stringLength;
                while (reader.PeekChar() > -1)
                {
                    stringLength = (byte)reader.PeekChar();
                    fileName = reader.ReadString();
                    nextFile = reader.ReadInt64();
                    fileSize = reader.ReadInt64();
                    currentFile = stringLength + sizeof(long) * 2 + previousFileLength + 1;
                    previousFileLength = fileSize + currentFile;
                    contentStorage.Items.Add(fileName + getReadableFileSize(fileSize));
                    positionsFiles.Add(currentFile);
                    lengthFiles.Add(fileSize);
                    for (long i = 0; i < fileSize; i++)
                    {
                        reader.Read(trash, 0, 1);
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Файл поврежден и не может быть открыт!");
                reader.Close();
            }

        }

        private void extractFile(string storage, string name)
        {

            BinaryWriter writer = new BinaryWriter(File.Open(name, FileMode.Create));
            BinaryReader reader = new BinaryReader(File.Open(storage, FileMode.Open));

            try
            {
                int indexFile = contentStorage.SelectedIndex;
                byte[] trash = new byte[1];
                progressAdd.Maximum = (int)lengthFiles[indexFile];
                for (long i = 0; i < positionsFiles[indexFile]; i++)
                {
                    reader.Read(trash, 0, 1);
                }
                for (long i = 0; i < lengthFiles[indexFile]; i++)
                {
                    writer.Write(reader.ReadByte());
                    progressAdd.Value++;
                }
                progressAdd.Value = 0;
                reader.Close();
                writer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                reader.Close();
                writer.Close();
            }
        }

        private void создатьХранилищеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (createStorageFile.ShowDialog() == DialogResult.OK)
            {
                storagePath = createStorageFile.FileName;
                if (!File.Exists(storagePath))
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(storagePath, FileMode.Create));
                    writer.Close();
                    labelStoragePath.Text = storagePath;
                    contentStorage.Items.Clear();
                }
                else MessageBox.Show("Такое хранилище уже существует!");
            }
        }

        private void openStorage_Click(object sender, EventArgs e)
        {
            if (openStorageFile.ShowDialog() == DialogResult.OK)
            {
                storagePath = openStorageFile.FileName;
                labelStoragePath.Text = storagePath;
                createFilesList(storagePath);
            }
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (storagePath == null)
            {
                MessageBox.Show("Сначала выберите хранилище!");
            }
            else
            {
                if (addFileInStorage.ShowDialog() == DialogResult.OK)
                {
                    addFile = addFileInStorage.FileName;
                    startAddFileInStorage(addFile, storagePath);
                    createFilesList(storagePath);
                }
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (storagePath == null)
            {
                MessageBox.Show("Сначала выберите хранилище!");
            }
            else if (contentStorage.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите файл для извлечения!");
            }
            else
            {
                extractFileDialog.FileName = (string)contentStorage.SelectedItem;
                if (extractFileDialog.ShowDialog() == DialogResult.OK)
                {
                    extractFile(storagePath, extractFileDialog.FileName);
                }
            }
        }

        private void getPassword()
        {
            using (MD5 md5hash = MD5.Create())
            {
                string fullPassword = GetMd5Hash(md5hash, passwordBox.Text);
                for (int i = 0; i < 16; i++)
                {
                    password16[i] = (byte)fullPassword[i + 1];
                }
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static byte[] Encrypt(byte[] ENC, byte[] AES_KEY, byte[] AES_IV)
        {
            using (Rijndael AES = Rijndael.Create())
            {
                //AES.KeySize = 128;
                //AES.BlockSize = 128;
                AES.IV = AES_IV;
                AES.Key = AES_KEY;
                AES.Padding = PaddingMode.None;

                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, AES.CreateEncryptor(), CryptoStreamMode.Write);
                CS.Write(ENC, 0, ENC.Length);
                CS.Clear();
                CS.Close();

                return MS.ToArray();
            }
        }
        private static byte[] Decrypt(byte[] DEC, byte[] AES_KEY, byte[] AES_IV)
        {
            using (Rijndael AES = Rijndael.Create())
            {
                //AES.KeySize = 128;
                //AES.BlockSize = 128;
                AES.IV = AES_IV;
                AES.Key = AES_KEY;
                AES.Padding = PaddingMode.None;

                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, AES.CreateDecryptor(), CryptoStreamMode.Write);

                CS.Write(DEC, 0, DEC.Length);
                CS.Clear();
                CS.Close();

                return MS.ToArray();
            }
        }

        private void buttonCrypt_Click(object sender, EventArgs e)
        {
            if (storagePath == null)
            {
                MessageBox.Show("Сначала выберите хранилище!");
            }
            else
            {

                FileInfo fileInfo = new FileInfo(storagePath);
                string path = fileInfo.DirectoryName;
                string name = fileInfo.Name;
                name = name.Replace(fileInfo.Extension, "");
                FileStream reader = File.Open(storagePath, FileMode.Open);
                FileStream writer = File.Open(path + "\\" + name + ".stcr", FileMode.Create);

                try
                {
                    getPassword();
                    byte[] temp = new byte[16];
                    int whole = (int)(reader.Length) / 16;
                    int residue = (int)(reader.Length) % 16;
                    progressAdd.Maximum = whole;
                    for (int i = 0; i < whole; i++)
                    {
                        reader.Read(temp, 0, 16);
                        temp = Encrypt(temp, password16, IV);
                        writer.Write(temp, 0, 16);
                        progressAdd.Value++;
                    }
                    if (residue != 0)
                    {
                        reader.Read(temp, 0, residue);
                        temp = Encrypt(temp, password16, IV);
                        writer.Write(temp, 0, residue);
                    }
                    progressAdd.Value = 0;
                    reader.Close();
                    writer.Close();
                    File.Delete(storagePath);
                    MessageBox.Show("Шифрование завершено!");
                    storagePath = null;
                    contentStorage.Items.Clear();
                    labelStoragePath.Text = "N/A";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    reader.Close();
                    writer.Close();
                }
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (decryptDialog.ShowDialog() == DialogResult.OK)
            {

                string cryptFilename = decryptDialog.FileName;
                FileInfo fileInfo = new FileInfo(cryptFilename);
                string path = fileInfo.DirectoryName;
                string name = fileInfo.Name;
                name = name.Replace(fileInfo.Extension, "");
                string storageName = path + "\\" + name + ".stor";
                FileStream reader = File.Open(cryptFilename, FileMode.Open);
                FileStream writer = File.Open(storageName, FileMode.Create);

                try
                {
                    getPassword();
                    byte[] temp = new byte[16];
                    int whole = (int)(reader.Length) / 16;
                    int residue = (int)(reader.Length) % 16;
                    progressAdd.Maximum = whole;
                    for (int i = 0; i < whole; i++)
                    {
                        reader.Read(temp, 0, 16);
                        temp = Decrypt(temp, password16, IV);
                        writer.Write(temp, 0, 16);
                        progressAdd.Value++;
                    }
                    if (residue != 0)
                    {
                        reader.Read(temp, 0, residue);
                        temp = Decrypt(temp, password16, IV);
                        writer.Write(temp, 0, residue);
                    }
                    progressAdd.Value = 0;
                    reader.Close();
                    writer.Close();
                    MessageBox.Show("Расшифровка завершена!");
                    storagePath = storageName;
                    labelStoragePath.Text = storagePath;
                    createFilesList(storagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    reader.Close();
                    writer.Close();
                }
            }
        }

        private string getReadableFileSize(long size)
        {
            return "";
        }
    }
}
