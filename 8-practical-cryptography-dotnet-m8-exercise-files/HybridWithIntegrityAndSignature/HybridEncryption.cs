using System.Security.Cryptography;

namespace CryptographyInDotNet
{
    public class HybridEncryption
    {
        private readonly AesEncryption _aes = new AesEncryption();

        public EncryptedPacket EncryptData(byte[] original, RSAWithRSAParameterKey rsaParams, 
                                           DigitalSignature digitalSignature)
        {            
            var sessionKey = _aes.GenerateRandomNumber(32);
            
            var encryptedPacket = new EncryptedPacket { Iv = _aes.GenerateRandomNumber(16) };
                        
            encryptedPacket.EncryptedData = _aes.Encrypt(original, sessionKey, encryptedPacket.Iv);
            
            encryptedPacket.EncryptedSessionKey = rsaParams.EncryptData(sessionKey);          
            
            using (var hmac = new HMACSHA256(sessionKey))
            {
                encryptedPacket.Hmac = hmac.ComputeHash(encryptedPacket.EncryptedData);
            }
            
            encryptedPacket.Signature = digitalSignature.SignData(encryptedPacket.Hmac);

            return encryptedPacket;
        }

        public byte[] DecryptData(EncryptedPacket encryptedPacket, RSAWithRSAParameterKey rsaParams, 
                                  DigitalSignature digitalSignature)
        {            
            var decryptedSessionKey = rsaParams.DecryptData(encryptedPacket.EncryptedSessionKey);
            
            using (var hmac = new HMACSHA256(decryptedSessionKey))
            {                
                var hmacToCheck = hmac.ComputeHash(encryptedPacket.EncryptedData);
                
                if (!Compare(encryptedPacket.Hmac, hmacToCheck)){
                    throw new CryptographicException(
                        "HMAC for decryption does not match encrypted packet.");
                }
                
                if (!digitalSignature.VerifySignature(encryptedPacket.Hmac, 
                                                      encryptedPacket.Signature)){
                    throw new CryptographicException(
                        "Digital Signature can not be verified.");
                }
            }

            var decryptedData = _aes.Decrypt(encryptedPacket.EncryptedData, decryptedSessionKey, 
                                             encryptedPacket.Iv);

            return decryptedData;
        }

        private static bool Compare(byte[] array1, byte[] array2)
        {
            var result = array1.Length == array2.Length;

            for (var i = 0; i < array1.Length && i < array2.Length; ++i)
            {
                result &= array1[i] == array2[i];
            }

            return result;
        }

        private static bool CompareUnSecure(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; ++i)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
