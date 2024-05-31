// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace WindowsFormsApp29
{
    class combined: sha1
    {
        public combined(string text,string pa):base (text, pa) 
        {

        }
        string text;
        public string doEncrypt() 
        {
             text =base.Encrypt();
            int a = 0;
            while (a < 2)
            {
                string ishText = text; string pass = Pa;
                string sol = "806e23f3107c8b087191a8109eb7d42b";
                string cryptographicAlgorithm = "MD5";
                int passIter = 2;
                string initVec = "a8doSuDitOz1hZe#";
                int keySize = 256;
                if (string.IsNullOrEmpty(ishText))
                    return "";

                byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
                byte[] solB = Encoding.ASCII.GetBytes(sol);
                byte[] ishTextB = Encoding.UTF8.GetBytes(ishText);

                PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter);
                byte[] keyBytes = derivPass.GetBytes(keySize / 8);
                RijndaelManaged symmK = new RijndaelManaged();
                symmK.Mode = CipherMode.CBC;

                byte[] cipherTextBytes = null;

                using (ICryptoTransform encryptor = symmK.CreateEncryptor(keyBytes, initVecB))
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(ishTextB, 0, ishTextB.Length);
                            cryptoStream.FlushFinalBlock();
                            cipherTextBytes = memStream.ToArray();
                            memStream.Close();
                            cryptoStream.Close();
                        }
                    }
                }

                symmK.Clear();
                text = Convert.ToBase64String(cipherTextBytes);
                a++;
            }
            return text;
        }
        public string doDecrypt() 
        {
            string ciphText =text; string pass = Pa;
            string sol = "806e23f3107c8b087191a8109eb7d42b";
            string cryptographicAlgorithm = "MD5";
            int passIter = 2;
            string initVec = "a8doSuDitOz1hZe#";
            int keySize = 256;
            int a = 0;
            while (a < 2)
            {
                if (string.IsNullOrEmpty(ciphText))
                    return "";

                byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
                byte[] solB = Encoding.ASCII.GetBytes(sol);
                byte[] cipherTextBytes = Convert.FromBase64String(ciphText);

                PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter);
                byte[] keyBytes = derivPass.GetBytes(keySize / 8);

                RijndaelManaged symmK = new RijndaelManaged();
                symmK.Mode = CipherMode.CBC;

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int byteCount = 0;

                using (ICryptoTransform decryptor = symmK.CreateDecryptor(keyBytes, initVecB))
                {
                    using (MemoryStream mSt = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(mSt, decryptor, CryptoStreamMode.Read))
                        {
                            byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            mSt.Close();
                            cryptoStream.Close();
                        }
                    }
                }

                symmK.Clear();
                ciphText= Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
                a++;
            }
            // if (string.IsNullOrEmpty(ciphText))
            // return "";

            //byte[] initVecB1 = Encoding.ASCII.GetBytes(initVec);
            //byte[] solB1 = Encoding.ASCII.GetBytes(sol);
            // byte[] cipherTextBytes1 = Convert.FromBase64String(ciphText);

            //PasswordDeriveBytes derivPass1 = new PasswordDeriveBytes(pass, solB1, cryptographicAlgorithm, passIter);
            //byte[] keyBytes1 = derivPass1.GetBytes(keySize / 8);

            // RijndaelManaged symmK1 = new RijndaelManaged();
            // symmK1.Mode = CipherMode.CBC;

            //byte[] plainTextBytes1 = new byte[cipherTextBytes1.Length];
            // int byteCount1 = 0;

            // using (ICryptoTransform decryptor = symmK1.CreateDecryptor(keyBytes1, initVecB1))
            // {
            //using (MemoryStream mSt = new MemoryStream(cipherTextBytes1))
            //{
            //using (CryptoStream cryptoStream = new CryptoStream(mSt, decryptor, CryptoStreamMode.Read))
            // {
            // byteCount1 = cryptoStream.Read(plainTextBytes1, 0, plainTextBytes1.Length);
            // mSt.Close();
            // cryptoStream.Close();
            //}
            // }
            // }

            //symmK1.Clear();
            text = ciphText;
            return ciphText;
        }
        public string doDecrypt2() 
        {
            string ciphText = text; string pass = Pa;
            string sol = "806e23f3107c8b087191a8109eb7d42b";
            string cryptographicAlgorithm = "SHA1";
            int passIter = 2;
            string initVec = "a8doSuDitOz1hZe#";
            int keySize = 256;
            if (string.IsNullOrEmpty(ciphText))
                return "";

            byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
            byte[] solB = Encoding.ASCII.GetBytes(sol);
            byte[] cipherTextBytes = Convert.FromBase64String(ciphText);

            PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter);
            byte[] keyBytes = derivPass.GetBytes(keySize / 8);

            RijndaelManaged symmK = new RijndaelManaged();
            symmK.Mode = CipherMode.CBC;

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int byteCount = 0;

            using (ICryptoTransform decryptor = symmK.CreateDecryptor(keyBytes, initVecB))
            {
                using (MemoryStream mSt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mSt, decryptor, CryptoStreamMode.Read))
                    {
                        byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        mSt.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmK.Clear();
            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        }
    }
}
