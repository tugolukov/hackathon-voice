using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hackathonvoice.Database.Models
{
    /// <summary>
    /// Пациент
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Идентификатор пациента
        /// </summary>
        [Key]
        public Guid PatientGuid { get; set; }
        
        /// <summary>
        /// Полное имя
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Диагнозы
        /// </summary>
        public virtual IList<Guid> Diagnoses { get; set; }
    }
}