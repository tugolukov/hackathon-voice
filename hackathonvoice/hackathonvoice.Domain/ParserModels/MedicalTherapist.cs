using System.Collections.Generic;

namespace hackathonvoice.Domain.ParserModels
{
    public class MedicalTherapist
    {
        //жалоб
        private List<string> _descriptions = new List<string>()
        {
            "жалоб",
            "жалует",
            "беспоко"
        };

        //диагнозы
        private List<string> _diagnoses = new List<string>()
        {
            "диагноз",
            "вердикт",
            "заключ"
        };

        //рецепты
        private List<string> _recipe = new List<string>()
        {
            "назнач",
            "лекарст",
            "принима",
            "лечени"
        };

        //имя пациента
        private List<string> _name = new List<string>()
        {
            "имя",
            "зовут",
            "пациент"
        };

        //полис
        private List<string> _policy = new List<string>()
        {
            "номер",
            "полис"
        };

         
        public List<string> GetDescription()
        {
            return _descriptions;
        }
        public List<string> GetDiagnoses()
        {
            return _diagnoses;
        }
        public List<string> GetRecipe()
        {
            return _recipe;
        }
        public List<string> GetName()
        {
            return _name;
        }
        public List<string> GetPolicy()
        {
            return _policy;
        }
    }
}