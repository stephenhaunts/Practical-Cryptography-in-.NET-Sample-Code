using System.IO;
using System.Security.Cryptography;

namespace CryptographyInDotNet
{
    public class TripleDesEncryption 
    {
        public byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {            
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;
               
                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), 
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;

                using (var memoryStream = new MemoryStream())
                {                       
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), 
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    var decryptBytes = memoryStream.ToArray();

                    return decryptBytes;
                }
            }                            
        }
    }
}