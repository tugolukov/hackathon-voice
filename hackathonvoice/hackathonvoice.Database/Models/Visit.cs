using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hackathonvoice.Database.Models
{
    /// <summary>
    /// Описание посещения
    /// </summary>
    public class Visit
    {
        /// <summary>
        /// Идентификатор посещения
        /// </summary>
        [Key]
        public Guid VisitGuid { get; set; }
        
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

        /// <summary>
        /// Идентификатор пациента
        /// </summary>
        [ForeignKey(nameof(Patient))]
        public Guid PatientGuid { get; set; }
    }
}