using System;
using System.Security.Cryptography;
using System.Text;
using EncryptionH4Lib;

namespace RsaEncryptSender
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAServiceProLib rsa = new RSAServiceProLib(false);
            string msg = "bla bla";
            string oldMsgD = "xNdyNDX25jK9bT+4eHaATS+sRL5QBR+W/g2okiIC5QcSarvYCoPXQQAqqcS7T8gtD2whDnjFTaIg9O+iwhV9Vw==";
            
            byte[] msgInByte = Encoding.UTF8.GetBytes(msg);
            var t = rsa.RSA.ExportParameters(false);
            
            //Console.WriteLine($" CSPContainerName : {rsa.cspParameters.KeyContainerName}\n praivetKey D: {Convert.ToBase64String(t.Modulus)} \npublicKey D: {Convert.ToBase64String(rsa.RSA.ExportParameters(true).Q)}\n");
            //Console.WriteLine(oldMsgD);
            //Console.ReadLine();
            
            Console.WriteLine("1:to show alle RSA keys\n2:To input msg to encrypt.\n3:to decrypt Msg.\n4:To decrypt from \"Outside World\" ");
            ConsoleKey input = Console.ReadKey().Key;
            string userinput = "";
            while (true)
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine($"PublicKey \n  Moduels: {Convert.ToBase64String(t.Modulus)}\n  Exponet: {Convert.ToBase64String(t.Exponent)}");
                        Console.WriteLine($" PraivteKeyInfo:\nD:{Convert.ToBase64String( rsa.RSA.ExportParameters(true).D)}\nP: {Convert.ToBase64String(rsa.RSA.ExportParameters(true).P)}\nExponet: {Convert.ToBase64String(rsa.RSA.ExportParameters(true).Exponent)}");
                        Console.WriteLine("Pressed 1");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Write the msg you wanna encrypt");
                        userinput = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Coby this over in the decryption program\n\n");
                        Console.WriteLine(Convert.ToBase64String(rsa.RSA.Encrypt(Encoding.UTF8.GetBytes(userinput), false)));
                        Console.WriteLine("\n\nPress enten when you want to return to main \"page\"..");
                        Console.WriteLine("Pressed 2");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Input the msg here");
                        string userin = Console.ReadLine();
                        byte[] dmsgB = Convert.FromBase64String(userin);
                        Console.WriteLine(Encoding.UTF8.GetString(rsa.RSA.Decrypt(dmsgB,false)));                       
                        Console.WriteLine("Pressed 3");
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("Input the publickey E: ");
                        string pE = Console.ReadLine();
                        Console.WriteLine("Input the publickey M: ");
                        string pM = Console.ReadLine();
                        Console.WriteLine("Input the msg you want to send");
                        string usermsg = Console.ReadLine();                       
                        RSAParameters newKey = new RSAParameters();
                        newKey.Modulus = Convert.FromBase64String(pM);
                        newKey.Exponent = Convert.FromBase64String(pE);

                        Console.WriteLine(BitConverter.ToString(rsa.Encryption(Encoding.UTF8.GetBytes(usermsg),newKey)));
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
                input = Console.ReadKey().Key;
                Console.Clear();
            }

        }
    }
}
