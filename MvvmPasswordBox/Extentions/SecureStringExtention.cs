using System;
using System.Runtime.InteropServices;
using System.Security;

namespace MvvmPasswordBox.Extentions
{
    public static class SecureStringExtention
    {
        public static string ConvertToString(this SecureString secureString)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                if (secureString is null)
                    return string.Empty;
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static SecureString ConvertToSecureString(this string unsecureString)
        {
            var secureStr = new SecureString();
            if (unsecureString.Length > 0)
            {
                foreach (var c in unsecureString) secureStr.AppendChar(c);
            }
            return secureStr;
        }
    }
}
