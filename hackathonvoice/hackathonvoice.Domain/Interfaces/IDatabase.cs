using System.Dynamic;
using System.Threading.Tasks;

namespace hackathonvoice.Domain.Interfaces
{
    public interface IDatabase
    {
        Task CreatePatient(string fullName, string policy);
        Task UpdatePatient(string fullName, string policy);
        Task GetPatient();

        Task CreateVisit(string description, string diagnoses, string recipe);
        Task UpdateVisit(string description, string diagnoses, string recipe);
        Task GetVisit();
    }
}