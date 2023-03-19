namespace SimpleThings
{
    class PasswordEncryption
    {
        private static string plainText = "", cipherText = "", password = "";
        [STAThread]
        static void Main(string[] args)
        {
            string command = ReadUserInput("Select a mode:\n1. Encrypt message\n2. Decrypt message\n3. Close program");
            ExecuteCommand(Convert.ToInt32(command));
        }

        public static void ExecuteCommand(int commandID)
        {
            switch (commandID)
            {
                case 1:
                    EncryptMessage();
                    break;
                case 2:
                    DecryptMessage();
                    break;
                case 3:
                    System.Console.WriteLine("Close program");
                    break;
                default:
                    System.Console.WriteLine("Invalid mode. Close program ...");
                    break;
            }
        }

        public static void EncryptMessage()
        {
            plainText = ReadUserInput("Write the message you want to encrypto: ");
            password = ReadUserInput("Write the password you want to use for encryption: ");

            int passwordSum = GetPasswordSize(password);

            cipherText = "";
            foreach (byte x in plainText)
            {
                cipherText += (x + passwordSum) + " ";
            }

            System.Console.WriteLine("Your cipher text:");
            System.Console.WriteLine(cipherText);
        }

        public static void DecryptMessage()
        {
            cipherText = ReadUserInput("Write the message you want to decrypt: ");
            password = ReadUserInput("Write the password you want to use for decryption: ");

            string[] cipherTextArr = cipherText.Trim().Split(" ");

            int passwordSum = GetPasswordSize(password);

            plainText = "";
            foreach (string x in cipherTextArr)
            {
                byte cipherPart = Convert.ToByte(x);
                plainText += (char)(cipherPart - passwordSum);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Your plain text:");
            System.Console.WriteLine(plainText);
        }

        private static string ReadUserInput(string message)
        {
            System.Console.WriteLine(message);
            string input = Console.ReadLine() ?? "";

            if (input == "")
            {
                System.Console.WriteLine("You have to enter some input! Try again ...");
                ReadUserInput(message);
            }
            return input;
        }

        private static int GetPasswordSize(string password)
        {
            byte passwordSum = 0;
            foreach (byte letter in password)
            {
                passwordSum += letter;
            }
            return passwordSum;
        }
    }
}
