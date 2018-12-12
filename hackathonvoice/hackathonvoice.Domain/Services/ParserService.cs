using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.ParserModels;
using hackathonvoice.Domain.ViewModels;

namespace hackathonvoice.Domain.Services
{
    public class Litera
    {
        public bool IsKey { get; set; }
        public string Text { get; set; }
    }

    public class ParserService : IParserService
    {
        public async Task<ReportModel> TextToCard(string text)
        {
            // делим текст на слова
            string[] words = text.Split(' ');
            
            MedicalTherapist parseModel = new MedicalTherapist();
            
            //жалоб
            var descriptions = parseModel.GetDescription();
            
            //диагнозы
            var diagnoses = parseModel.GetDiagnoses();
            
            //рецепты
            var recipe = parseModel.GetRecipe();
            
            //имя пациента
            var name = parseModel.GetName();
            
            //полис
            var policy = parseModel.GetPolicy();

            // устанавливаем ключевые слова
            List<string> keys = new List<string>();

            List<string> allkeys = new List<string>();
            allkeys.AddRange(name);
            allkeys.AddRange(policy);
            allkeys.AddRange(descriptions);
            allkeys.AddRange(diagnoses);
            allkeys.AddRange(recipe);


            foreach (var allkey in allkeys)
            {
                if (text.Contains(allkey))
                {
                    keys.Add(allkey);
                }
            }

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
                        if ((i + 1) == phrases.Count)
                        {
                            result.Add(buffer);
                            buffer = new Litera();
                        }
                    }
                    else
                    {
                        result.Add(buffer);
                        buffer = new Litera();
                        buffer.Text = phrases[i].Text;
                        buffer.IsKey = phrases[i].IsKey;
                        if ((i + 1) == phrases.Count)
                        {
                            result.Add(buffer);
                            buffer = new Litera();
                        }
                    }
                }


            }

            // Делаем красивую коллекцию
            Dictionary<string, string> model = new Dictionary<string, string>();
            for (int i = 0; i < result.Count; i += 2)
            {
                model.Add(result[i].Text, result[i + 1].Text);
            }

            ReportModel report = new ReportModel();

            PatientModel patient = new PatientModel();
            VisitModel visit = new VisitModel();

            foreach (var item in name)
            {
                if (model.Keys.Any(a => a.Contains(item)))
                {
                    var data = model.First(a => a.Key.Contains(item)).Value;
                    patient.FullName = data;
                    break;
                }
            }

            foreach (var item in policy)
            {
                if (model.Keys.Any(a => a.Contains(item)))
                {
                    var data = model.First(a => a.Key.Contains(item)).Value;
                    patient.Policy = data;
                    break;
                }
            }

            foreach (var item in descriptions)
            {
                if (model.Keys.Any(a => a.Contains(item)))
                {
                    var data = model.First(a => a.Key.Contains(item)).Value;
                    visit.Description = data;
                    break;
                }
            }

            foreach (var item in diagnoses)
            {
                if (model.Keys.Any(a => a.Contains(item)))
                {
                    var data = model.First(a => a.Key.Contains(item)).Value;
                    visit.Diagnoses = data;
                    break;
                }
            }

            foreach (var item in recipe)
            {
                if (model.Keys.Any(a => a.Contains(item)))
                {
                    var data = model.First(a => a.Key.Contains(item)).Value;
                    visit.Recipe = data;
                    break;
                }
            }

            report.PatientModel = patient;
            report.VisitModel = visit;

            return report;
        }
    }
}