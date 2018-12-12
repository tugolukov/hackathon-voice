using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hackathonvoice.Database;
using hackathonvoice.Database.Models;
using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace hackathonvoice.Domain.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public DatabaseService(IMapper mapper, DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> CreatePatient(PatientModel patientModel)
        {
            var policy = patientModel.Policy;
            var search = await _context.Patients.FirstOrDefaultAsync(a => a.Poliсy.Equals(policy));
            if (search != null)
            {
                return search.PatientGuid;
            }
                        
            Patient patient = new Patient()
            {
                PatientGuid = Guid.NewGuid(),
                FullName = patientModel.FullName,
                Poliсy = patientModel.Policy
            };
            
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient.PatientGuid;
        }

        public async Task UpdatePatient(PatientModel patientModel)
        {
            var patient = _mapper.Map<Patient>(patientModel);
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }

        public async Task<Patient> GetPatient(Guid guidPatient)
        {
            return await _context.Patients.SingleAsync(c => c.PatientGuid == guidPatient);
        }

        public async Task<Guid> CreateVisit(VisitModel visitModel)
        {
            var visit = _mapper.Map<Visit>(visitModel);
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();
            return visit.VisitGuid;
        }

        public async Task UpdateVisit(VisitModel visitModel)
        {
            var visit = _mapper.Map<Visit>(visitModel);
            _context.Visits.Update(visit);
            await _context.SaveChangesAsync();
        }

        public async Task<Visit> GetVisit(Guid guidVisit)
        {
            return await _context.Visits.SingleAsync(c => c.VisitGuid == guidVisit);
        }

        public async Task<List<Visit>> GetAllVisits(Guid guid)
        {
            var visits = await _context.Visits.Where(a => a.PatientGuid == guid).ToListAsync();
            return visits;
        }
    }
}