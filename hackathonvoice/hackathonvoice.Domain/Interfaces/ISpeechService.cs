using System.IO;
using System.Threading.Tasks;

namespace hackathonvoice.Domain.Interfaces
{
    public interface ISpeechService
    {
        Task<string> SpeechToText(Stream file);
    }
}