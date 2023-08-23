using System.Collections.Generic;

namespace Crypter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                
                Console.Write("Введите фразу для шифрования: ");
                string? wordToCode = Console.ReadLine();
                
                Console.Write("Введите ключ для шифрования: ");
                int key = int.Parse(s: Console.ReadLine());
                Crypto crypto = new Crypto { Original = wordToCode, Key = key };
                Console.WriteLine($"Результат шифровки: {crypto.codeWord()}");
                db.Cryptos.Add(crypto);
                db.SaveChanges();
                List<Crypto> cryptos = db.Cryptos.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Crypto c in cryptos)
                {
                    Console.WriteLine($"id: {c.Id}, original: {c.Original}, coded: {c.Coded}");
                }
                Console.Write("Введите id фразы для расшифрования: ");
                int id = int.Parse(s: Console.ReadLine());
                if (id < 0 || id > crypto.Id) {
                    Console.WriteLine("Такого id нет в базе!");
                }
                else
                {
                    Crypto word = db.Cryptos.First(x => x.Id == id);
                    Console.WriteLine($"Результат шифровки: {crypto.decodeWord(word.Coded)}"); //можно просто вывести word.Original так как у меня хрнаится оба варианта
                }
                
            }
            

        }
    }
}