using System;
using System.Threading.Tasks;
using AutoMapper;
using hackathonvoice.Database;
using hackathonvoice.Database.Models;
using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace hackathonvoice.Domain.Services
{
    public class DatabaseService:IDatabaseService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        
        public DatabaseService(IMapper mapper,DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task CreatePatient(PatientModel patientModel)
        {
            var patient = _mapper.Map<Patient>(patientModel);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatient(PatientModel patientModel)
        {
            var patient = _mapper.Map<Patient>(patientModel);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<Patient> GetPatient(Guid guidPatient)
        {
            return await _context.Patients.SingleAsync(c=>c.PatientGuid == guidPatient);
        }

        public async Task CreateVisit(VisitModel visitModel)
        {
            var visit = _mapper.Map<Visit>(visitModel);
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVisit(VisitModel visitModel)
        {
            var visit = _mapper.Map<Visit>(visitModel);
            _context.Visits.Update(visit);
            await  _context.SaveChangesAsync();
        }

        public async Task<Visit> GetVisit(Guid guidVisit)
        {
            return await _context.Visits.SingleAsync(c=>c.VisitGuid == guidVisit);
        }
    }
}