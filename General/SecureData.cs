using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UsersManagementApp.General
{
    public class SecureData
    {
                                            //Admin
        public  static EncryptData(string simpleString) 
        { 
            MD5 md5 = MD5CryptoServiceProvider();
                           
                   // xxksdkskj32423j4lkjfaskljfsdlksdf
            byte[] passwordHash = Encoding.UTF8.GetBytes(simpleString);

            return Encoding.UTF8.GetString(md5.ComputeHash(passwordHash));


        }
    }
}
