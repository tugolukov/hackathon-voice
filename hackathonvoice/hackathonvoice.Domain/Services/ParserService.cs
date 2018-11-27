using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.Models;

namespace hackathonvoice.Domain.Services
{
    public class Litera
    {
        public bool IsKey { get; set; }
        public string Text { get; set; }
    }

    public class ParserService : IParserService
    {
        public Task<CardModel> TextToCard(string text)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            Dictionary<int, string> nextdictionary = new Dictionary<int, string>();

            // делим текст на слова
            string[] words = text.Split(' ');

            Dictionary<int, List<int>> keywords = new Dictionary<int, List<int>>();

            // устанавливаем ключевые слова
            List<string> keys = new List<string>()
            {
                "имя",
                "пациент",
                "номер",
                "полис",
                "жалоб",
                "диагноз",
                "назнач",
                "лекарств"
            };

            // Присваиваем словам ключи
            List<Litera> phrases = new List<Litera>();
            foreach (var word in words)
            {
                bool check = true;

                if (keys.Count == 0)
                {
                    phrases.Add(new Litera()
                    {
                        IsKey = false,
                        Text = word
                    });
                }
                
                foreach (var key in keys)
                {
                    if (word.Contains(key))
                    {
                        if (check)
                        {
                            phrases.Add(new Litera()
                            {
                                IsKey = true,
                                Text = word
                            });
                            keys.Remove(key);
                            break;
                        }

                        check = false;
                    }
                    else
                    {
                        if (check)
                        {
                            phrases.Add(new Litera()
                            {
                                IsKey = false,
                                Text = word
                            });
                            break;
                        }

                        check = false;

                    }

                }

                check = true;
            }
            
            // Получаем коллекцию с ключами
            List<Litera> result = new List<Litera>();
            Litera buffer = new Litera();
            for (int i = 0; i < phrases.Count; i++)
            {
                if (i == 0)
                {
                    buffer.Text = phrases[i].Text;
                    buffer.IsKey = phrases[i].IsKey;
                }
                else
                {
                    if (phrases[i].IsKey == buffer.IsKey)
                    {
                        buffer.Text += " " + phrases[i].Text;
                        if ((i+1) == phrases.Count)
                        {
                            result.Add(buffer);
                        }
                    }
                    else
                    {
                        result.Add(buffer);
                        buffer = new Litera();
                        buffer.Text = phrases[i].Text;
                        buffer.IsKey = phrases[i].IsKey;
                    }
                }                
            }

            // Делаем красивую коллекцию
            Dictionary<string, string> model = new Dictionary<string, string>();
            for (int i = 0; i < result.Count; i+=2)
            {
                model.Add(result[i].Text, result[i+1].Text);
            }

        }
    }
}