using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace hackathonvoice.Domain.ViewModels
{
    public class ReportModel
    {
        public PatientModel PatientModel { get; set; }
        public VisitModel VisitModel { get; set; }
    }
}