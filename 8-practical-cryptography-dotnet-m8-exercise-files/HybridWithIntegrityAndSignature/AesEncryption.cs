using System.IO;
using System.Security.Cryptography;

namespace CryptographyInDotNet
{
public class AesEncryption 
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
        using (var aes = new AesCryptoServiceProvider())
        {                
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.Key = key;
            aes.IV = iv;

            using (var memoryStream = new MemoryStream())
            {
                var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                cryptoStream.FlushFinalBlock();

                return memoryStream.ToArray();
            }
        }
    }

    public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
    {                                
        using (var aes = new AesCryptoServiceProvider())
        {
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.Key = key;
            aes.IV = iv;

            using (var memoryStream = new MemoryStream())
            {                       
                var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

                cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                cryptoStream.FlushFinalBlock();

                var decryptBytes = memoryStream.ToArray();

                return decryptBytes;
            }
        }                            
    }
}
}