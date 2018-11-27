using System.Threading.Tasks;
using hackathonvoice.Domain.ViewModels;

namespace hackathonvoice.Domain.Interfaces
{
    public interface IParserService
    {
        Task<ReportModel> TextToCard(string text);
    }
}