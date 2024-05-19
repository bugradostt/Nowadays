using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nowadays.DataAccess.Extensions
{
    public static class StringExtensions
    {
        public static string Encrypt(string plainText)
        {

            // 32-byte key
            string key = "0123456789abcdef0123458769abcdef";
            // 16-byte IV
            string iv = "fedcba9876345210";

            using (Aes aesAlg = Aes.Create())
            {
                if (aesAlg != null)
                {
                    aesAlg.KeySize = 256; // Key boyutunu belirtin (256 bit)
                    aesAlg.Mode = CipherMode.CFB; // Şifreleme modunu belirtin (örneğin, Cipher Block Chaining)
                    aesAlg.Padding = PaddingMode.PKCS7; // Dolgu modunu belirtin (örneğin, PKCS7)

                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
                else
                {
                    throw new Exception("AES nesnesi oluşturulamadı.");
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            string key = "0123456789abcdef0123458769abcdef";
            string iv = "fedcba9876345210";

            using (Aes aesAlg = Aes.Create())
            {
                if (aesAlg != null)
                {
                    aesAlg.KeySize = 256;
                    aesAlg.Mode = CipherMode.CFB;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("AES nesnesi oluşturulamadı.");
                }
            }
        }

        public static string MaskTCNumber(string originalTCNumber)
        {
            if (originalTCNumber.Length != 11)
            {
                throw new ArgumentException("TC 11 basamaklı olmalıdır.");
            }

            // İlk 8 rakamı '*' ile gizle  //  --> 11111111111
            string maskedPart = new string('*', 8);
            // Son 3 rakamı orijinal haliyle bırak
            string visiblePart = originalTCNumber.Substring(3, 3);
            // Maskeleme ve orijinal kısmı birleştir //  --> *********111
            string maskedTCNumber = maskedPart + visiblePart;

            return maskedTCNumber;
        }


    }
}
