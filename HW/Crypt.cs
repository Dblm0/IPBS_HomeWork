using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
namespace HW
{
    class Crypt
    {
        public static string RsaEncrypt(string text)
        {
            string output = string.Empty;
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            X509Certificate2 cert = new X509Certificate2(path+"\\Sample.pfx", "123456");
            using (RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key)
            {
                byte[] bytesData = Encoding.UTF8.GetBytes(text);
                byte[] bytesEncrypted = csp.Encrypt(bytesData, false);
                output = Convert.ToBase64String(bytesEncrypted);
            }
            return output;
        }
        public static string RsaDecrypt(string encrypted)
        {

            string text = string.Empty;
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            X509Certificate2 cert = new X509Certificate2(path + "\\Sample.pfx", "123456");
            using (RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PrivateKey)
            {
                byte[] bytesEncrypted = Convert.FromBase64String(encrypted);
                byte[] bytesDecrypted = csp.Decrypt(bytesEncrypted, false);
                text = Encoding.UTF8.GetString(bytesDecrypted);
            }
            return text;
        }

        static public string AesEncrypt(string Text, string Key)
        {

            byte[] encrypted;
            byte[] keyBytes = SHA256.Create().ComputeHash(Convert.FromBase64String(Key));
            using (AesCryptoServiceProvider rijAlg = new AesCryptoServiceProvider())
            {
                rijAlg.Key = keyBytes;
                rijAlg.Mode = CipherMode.ECB;

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {


                            swEncrypt.Write(Text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);

        }

        static public string AesDecrypt(string Text, string Key)
        {

            byte[] cipherText = Convert.FromBase64String(Text);
            string plaintext = null;
            byte[] keyBytes = SHA256.Create().ComputeHash(Convert.FromBase64String(Key));
            using (AesCryptoServiceProvider rijAlg = new AesCryptoServiceProvider())
            {
                rijAlg.Key = keyBytes;
                rijAlg.Mode = CipherMode.ECB;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);


                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
        public static String GenerateSalt()
        {
            RNGCryptoServiceProvider Provider = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[32];

            Provider.GetBytes(buffer);
            string salt = Convert.ToBase64String(buffer);
            return salt;
        }
        public static string GetHash(string str)
        {
            SHA256 Hasher = SHA256Managed.Create();
            byte[] hash;
            byte[] bytes;
            bytes = Encoding.Unicode.GetBytes(str);
            hash = Hasher.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
