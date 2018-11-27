using AutoMapper;
using hackathonvoice.Database.Models;
using hackathonvoice.Domain.ViewModels;

namespace hackathonvoice.Domain.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientModel>();
            CreateMap<PatientModel, Patient>();

            CreateMap<Visit, VisitModel>();
            CreateMap<VisitModel, Visit>();
        }
    }
}