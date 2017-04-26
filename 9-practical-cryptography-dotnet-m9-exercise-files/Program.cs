using System;
using System.Runtime.InteropServices;
using System.Security;

namespace SecureStringExample
{
    class Program
    {
        static void Main()
        {
            var str = ToSecureString(new[] { '5', '1', '2', '5' });

            char [] charArray = CharacterData(str);

            string unsecure = ConvertToUnsecureString(str);
        }


        private static SecureString ToSecureString(char[] str)
        {
            var secureString = new SecureString();

            // Append each character onto the SecureString
            Array.ForEach(str, secureString.AppendChar);

            return secureString;
        }


        private static char[] CharacterData(SecureString secureString)
        {
            char[] bytes;
            var ptr = IntPtr.Zero;

            try
            {
                // Allocate a BSTR and copy contents of SecureString into it
                ptr = Marshal.SecureStringToBSTR(secureString);
                bytes = new char[secureString.Length];

                // Copy data from unmanaged memory into a managed char array
                Marshal.Copy(ptr, bytes, 0, secureString.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    // Free unmanaged memory
                    Marshal.ZeroFreeBSTR(ptr);
                }
            }

            return bytes;            
        }

        private static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                throw new ArgumentNullException("securePassword");
            }

            var unmanagedString = IntPtr.Zero;

            try
            {
                // Copy the contents of the SecureString to unmanaged memory
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);

                // Allocate a managed string and copy the contents of the unmanaged 
                //string data into it
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // Free the unmanaged string pointer
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
