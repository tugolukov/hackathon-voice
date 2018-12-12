using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace hackathonvoice.API.Controllers
{
    public class SpeechController : Controller
    {
        private readonly IParserService _parserService;
        private readonly ISpeechService _speechService;

        public SpeechController(ISpeechService speechService, IParserService parserService)
        {
            _speechService = speechService;
            _parserService = parserService;
        }

        [HttpPost("api/speech")]
        public async Task<ReportModel> SendAudioToAPI()
        {
            var request = Request;
            var file = request.Form.Files.FirstOrDefault();
            var text = await _speechService.SpeechToText(file?.OpenReadStream());
            var result = await _parserService.TextToCard(text);
            return result;
        }   
        
        [HttpPost("api/speech/sendlocalfile")]
        public async Task<string> SendFileToAPI(string path)
        {
            FileStream file = System.IO.File.Open(path, FileMode.Open);
            
            var text = await _speechService.SpeechToText(file);
            return text;
        }   
    }
}