using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            AesManaged algorithm = new AesManaged();

            ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
            EncryptSymetric(encryptor);
            Console.WriteLine("Encrypted");
            Console.ReadLine();


            ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV); var dec = DescryptSymetric(decryptor);
            Console.WriteLine(dec);
            Console.ReadLine();

        }

        private static string DescryptSymetric(ICryptoTransform decryptor)
        {
            string filePath = "c:\\test\\enc.dat";
            byte[] encData = File.ReadAllBytes(filePath);

            using (var ms =new MemoryStream(encData))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var reader = new StreamReader(cs))
                    {
                        string s = reader.ReadToEnd();
                        return s;
                    }
                }
            }
        }


        private static void EncryptSymetric(ICryptoTransform encryptor)
        {
            var s = Console.ReadLine();


            //string password = "hhello";
            //var bytes = Encoding.UTF8.GetBytes(password);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(s);
                    }
                }

                //StreamReader reader = new StreamReader(ms);
                //var encrypted = reader.ReadToEnd();

                byte[] bytes = ms.ToArray();

                Directory.CreateDirectory("c:\\test");
                File.WriteAllBytes("c:\\test\\enc.dat", bytes);

                Console.ReadLine();
            }
        }
    }
}
