using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace PriceFlux.Helpers
{
    //Md5 is no longer considered as a secure way to store passwords since 2004
    public static class MD5Hash
    {
        public static string GetMd5Hash(MD5 md5Hash,string input)
        {
            //converting the input string to a byte array and comute the hash
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            //create a new string builder to collect the bytes
            //and create a string
            StringBuilder strBuilder = new StringBuilder();

            //loop through each byte of the hashed data
            //and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                strBuilder.Append(data[i].ToString("x2"));
            }

            //return the hexadecimal string
            return strBuilder.ToString();
        }

        public static bool VerifyMd5Hash(MD5 md5Hash,string input,string hash)
        {
            //hash the input
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(hashOfInput, hash)==0)
            {
                return true;
            }
            return false;
        }
    }
}