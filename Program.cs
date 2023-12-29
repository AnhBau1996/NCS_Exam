using System;
using System.Security.Cryptography;
using System.Text;

namespace AsymmetricEncryptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a public/private key pair using RSA
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                // Export the public key
                var publicKey = rsa.ToXmlString(false);

                // Export the private key
                var privateKey = rsa.ToXmlString(true);

                // Display the keys
                Console.WriteLine("Public key:");
                Console.WriteLine(publicKey);
                Console.WriteLine();
                Console.WriteLine("Private key:");
                Console.WriteLine(privateKey);
                Console.WriteLine();

                // Create a sample data to encrypt 
                var data = "Hello!";

                // Convert the data to bytes
                var dataBytes = Encoding.UTF8.GetBytes(data);

                // Encrypt the data using the public key
                var encryptedData = rsa.Encrypt(dataBytes, false);

                // Convert the encrypted data to base64 string
                var encryptedDataString = Convert.ToBase64String(encryptedData);

                // Display the encrypted data
                Console.WriteLine("Encrypted data:");
                Console.WriteLine(encryptedDataString);
                Console.WriteLine();

                // Decrypt the data using the private key
                var decryptedData = rsa.Decrypt(encryptedData, false);

                // Convert the decrypted data to string
                var decryptedDataString = Encoding.UTF8.GetString(decryptedData);

                // Display the decrypted data
                Console.WriteLine("Decrypted data:");
                Console.WriteLine(decryptedDataString);
                Console.WriteLine();
            }
        }
    }
}