using cteds_avaliacao.Models;
using cteds_avaliacao.Repositories;
using System.ComponentModel.DataAnnotations;

namespace cteds_avaliacao
{
    internal class Program
    {
        private const string path = "Logs/UsersLog.txt";
        static void Main(string[] args)
        {
            Read_Write.CreateFolderFile(path);
            FileStream file = File.OpenWrite(path);
            Read_Write log = new(file);
            UsersRepository usersRepository = new();
            string option;

            do
            {
                Console.WriteLine("1) Acessar");
                Console.WriteLine("2) Cancelar");
                option = Console.ReadLine();

                if (option == "1")
                {
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Senha: ");
                    string senha = Console.ReadLine();

                    var allUsers = usersRepository.GetUsers();
                    bool success = false;
                    foreach (var user in allUsers)
                    {
                        if ((user.Email == email) & (user.Senha == senha))
                        {
                            log.RegisterAccess(user);
                            file.Close();
                            success = true;
                            break;
                        }
                    }

                    if (success)
                    {
                        Console.WriteLine("Logado com sucesso");
                        Console.WriteLine("1) Deslogar");
                        Console.WriteLine("2) Encerrar sistema");
                        string userOption = Console.ReadLine();

                        if (userOption == "2")
                        {
                            option = "2";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usuario ou senha incorretos");
                    }
                }
            } while (option != "2");
        }
    }
}