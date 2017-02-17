using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Enterprise.Component.Infrastructure
{
    /// <summary>
    /// MD5����
    /// </summary>
    public class Md5Helper
    {
        const string KEY_64 = "VavicApp";//ע���ˣ���8���ַ���64λ  

        const string IV_64 = "VavicApp";

        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="data">�������ַ���</param>
        /// <returns></returns>
        public static string MD5Encrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey,byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();  
        }

        /// <summary>
        /// DES�����ַ���
        /// </summary>
        /// <returns>���ܺ���ַ���</returns>
        public static string Encrypt(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey,byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);  
        }

    }


    /// <summary>
    /// MD5������
    /// </summary>
    public class MD5Tool
    {
        /// <summary>
        /// ȡ�������ַ�����MD5��ϣֵ
        /// </summary>
        /// <param name="argInput">�����ַ���</param>
        /// <returns>MD5��ϣֵ</returns>
        public static string GetMD5Hash(string argInput)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(argInput));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// ��֤MD5��ϣֵ
        /// </summary>
        /// <param name="argInput">�����ַ���</param>
        /// <param name="argHash">��ϣֵ</param>
        /// <returns>��ͬ����TRUE,��ͬ����FALSE</returns>
        public static bool verifyMd5Hash(string argInput, string argHash)
        {
            // Hash the input.
            string hashOfInput = GetMD5Hash(argInput);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, argHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
   

   
