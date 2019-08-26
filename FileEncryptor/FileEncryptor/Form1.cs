using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace FileEncryptor
{
    public partial class Form1 : Form
    {
        private string filePath = null;

        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        public Form1()
        {
            InitializeComponent();
            Cryptor.Enabled = false;
            Password.UseSystemPasswordChar = true;
            State.BackColor = Color.Gray;
        }

        private void Cryptor_Click(object sender, EventArgs e)
        {
            if (Password.Text != null)
            {
                string password = Password.Text;
                if (State.BackColor == Color.Green)
                {
                    if (CheckPassword(password))
                    {
                        GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
                        FileEncrypt(filePath, password);
                        File.Delete(filePath);
                        ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                        gch.Free();
                        CheckFile();
                        MessageBox.Show("Successfully encryped the file!");
                    }
                }
                else if (State.BackColor == Color.Red)
                {
                    GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
                    try
                    {
                        FileDecrypt(filePath, TrimAES(filePath), password);
                        File.Delete(filePath);
                        CheckFile();
                        MessageBox.Show("Successfully decrypted the file!");
                    }
                    catch (Exception error)
                    {
                        CheckFile();
                        MessageBox.Show(error.Message);
                    }
                    finally
                    {
                        ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                        gch.Free();
                    }
                }
            }
            else
                MessageBox.Show("Enter password...");
        }

        private void FileChooser_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                CheckFile();
                Path_Box.Text = filePath;
                Cryptor.Enabled = true;
            }
        }

        /// <summary>Trims the ".aes" at the end of the string</summary>
        /// <param name="str">A string with ".aes" at the end</param>
        private string TrimAES(string str)
        {
            return str.Remove(str.Length - 4, 4);
        }

        private void CheckFile()
        {
            if (File.Exists(filePath))
            {
                if (filePath.EndsWith(".aes"))
                    State.BackColor = Color.Red;
                else
                    State.BackColor = Color.Green;
            }
            else
            {
                if (File.Exists(filePath + ".aes"))
                {
                    filePath += ".aes";
                    State.BackColor = Color.Red;
                }
                else if (File.Exists(TrimAES(filePath)))
                {
                    filePath = TrimAES(filePath);
                    State.BackColor = Color.Green;
                }
                else
                {
                    filePath = null;
                    State.BackColor = Color.Gray;
                    State.Enabled = false;
                    MessageBox.Show("File does not exist!\nChoose an existing file.");
                }
            }
        }

        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }
            return data;
        }

        private void FileEncrypt(string inputFile, string password)
        {
            byte[] salt = GenerateRandomSalt();

            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            byte[] buffer = new byte[1048576];
            int read;

            while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
            {
                Application.DoEvents();
                cs.Write(buffer, 0, read);
            }

            fsIn.Close();

            cs.Close();
            fsCrypt.Close();
        }

        private void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }

                fsOut.Close();
                fsCrypt.Close();
            }
            catch
            {
                fsOut.Close();
                fsCrypt.Close();
                File.Delete(outputFile);
                throw new Exception("Wrong password!");
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                Password.UseSystemPasswordChar = false;
            else
                Password.UseSystemPasswordChar = true;
        }

        private bool CheckPassword(string password)
        {
            bool UpperLegal = false, LengthLegal = false, NumberLegal = false;
            if (password.Length > 6)
            {
                LengthLegal = true;
            }
            foreach (char x in Password.Text)
            {
                if (x.ToString() == x.ToString().ToUpper())
                    UpperLegal = true;
                if (int.TryParse(x.ToString(), out int y))
                    NumberLegal = true;
            }
            if (UpperLegal && LengthLegal && NumberLegal)
                return true;
            if (MessageBox.Show("Password is weak! Are you sure you want this password?", "Weak password", MessageBoxButtons.YesNo) == DialogResult.Yes)
                return true;
            return false;
        }
    }
}