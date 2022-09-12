using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace cteds_avaliacao.Models
{
    internal class Read_Write
    {
        private const string path = "Logs/UsersLog.txt";
        private readonly FileStream fileStream;
        public static void CreateFolderFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            else if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
        public Read_Write(FileStream filestream)
        {
            this.fileStream = filestream;
        }
        public static string TextLine(User user)
        {
            return $"O usuário {user.Name} ({user.Id}) acessou o sistema em {DateTimeOffset.Now}";
        }
        public void RegisterAccess(User user)
        {
            string line = TextLine(user);
            byte[] info = new UTF8Encoding(true).GetBytes(line);

            fileStream.Write(info);
        }
    }
}
