using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using hackathonvoice.Domain.Interfaces;
using hackathonvoice.Domain.ViewModels;
using ITCC.YandexSpeechKitClient;
using ITCC.YandexSpeechKitClient.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace hackathonvoice.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParserService _parserService;
        private readonly ISpeechService _speechService;

        public HomeController(IParserService parserService, ISpeechService speechService)
        {
            _parserService = parserService;
            _speechService = speechService;
        }

        /// <summary/>
        [HttpGet]
        [Route("{*catchall}")]
        public IActionResult Index()
        {
            return View("../Administration/Administration");
        }
        
        [HttpPost("api/send")]
        public async Task<ReportModel> SendFlacToAPI()
        {
            var request = Request;
            var file = request.Form.Files.FirstOrDefault();
            var text = await _speechService.SpeechToText(file?.OpenReadStream());
            var result = await _parserService.TextToCard(text);
            return result;
        }   
        
        
    }
}