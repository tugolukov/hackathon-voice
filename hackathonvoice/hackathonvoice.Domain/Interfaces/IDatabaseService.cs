using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using hackathonvoice.Database.Models;
using hackathonvoice.Domain.ViewModels;

namespace hackathonvoice.Domain.Interfaces
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Добавление нового пациента
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task<Guid> CreatePatient(PatientModel patient);
        
        /// <summary>
        /// Обновление информации о пациенте
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Task UpdatePatient(PatientModel patient);

        /// <summary>
        /// Получение всех пациентов
        /// </summary>
        /// <returns></returns>
        Task<List<Patient>> GetAllPatients();

        /// <summary>
        /// Получение пациента по уникальному идентификатору
        /// </summary>
        /// <param name="guidPatient"></param>
        /// <returns></returns>
        Task<Patient> GetPatient(Guid guidPatient);

        /// <summary>
        /// Создание нового визита
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        Task<Guid> CreateVisit(VisitModel visit);
        
        /// <summary>
        /// Обновление информации о визите
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>
        Task UpdateVisit(VisitModel visit);
        
        /// <summary>
        /// Получение визита по уникальному идентификатору
        /// </summary>
        /// <param name="guidVisit"></param>
        /// <returns></returns>
        Task<Visit> GetVisit(Guid guidVisit);

        /// <summary>
        /// Получение списка визитов для пациента
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<List<Visit>> GetAllVisits(Guid guid);
    }
}