using System;
using System.ComponentModel.DataAnnotations;

namespace hackathonvoice.Database.Models
{
    /// <summary>
    /// Описание диагноза
    /// </summary>
    public class Diagnosis
    {
        /// <summary>
        /// Идентификатор диагноза
        /// </summary>
        [Key]
        public Guid DiagnosisGuid { get; set; }
        
        /// <summary>
        /// Содержимое
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Назначенные лекарства
        /// </summary>
        public string Recipe { get; set; }

        
        public Guid PatientGuid { get; set; }
    }
}