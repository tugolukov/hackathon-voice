using System.Threading.Tasks;
using hackathonvoice.Domain.Models;

namespace hackathonvoice.Domain.Interfaces
{
    public interface IParserService
    {
        Task<CardModel> TextToCard(string text);
    }
}