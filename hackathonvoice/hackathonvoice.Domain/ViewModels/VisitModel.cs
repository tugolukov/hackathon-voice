using System;

namespace hackathonvoice.Domain.ViewModels
{
    public class VisitModel
    {
        /// <summary>
        /// Жалобы пациента
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Диагноз
        /// </summary>
        public string Diagnoses { get; set; }        

        /// <summary>
        /// Назначенные лекарства
        /// </summary>
        public string Recipe { get; set; }
    }
}