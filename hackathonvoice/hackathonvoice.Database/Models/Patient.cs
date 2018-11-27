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
        /// Полис
        /// </summary>
        public string Poliсy { get; set; }
 
        /// <summary>
        /// Визиты
        /// </summary>
        public virtual IList<Visit> Visits { get; set; }
    }
}