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
        private readonly HttpClient _client;
        private readonly IParserService _parserService;

        public HomeController(IParserService parserService)
        {
            _parserService = parserService;
            _client = new HttpClient();
            _client.BaseAddress =
                new Uri(
                    "https://asr.yandex.net/asr_xml?uuid=f1cdf2643dcc4990951d6d1546c0b828&key=7102e72c3cc94f928b3881dd97c93075&topic=queries&lang=ru-RU");
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
            
            var apiSetttings = new SpeechKitClientOptions("7102e72c-3cc9-4f92-8b38-81dd97c93075", "HackathonVoice", Guid.NewGuid(), "device");

            using (var client = new SpeechKitClient(apiSetttings))
            {
                var speechRecognitionOptions = new SpeechRecognitionOptions(SpeechModel.Queries, RecognitionAudioFormat.Mpeg3, RecognitionLanguage.Russian);
                try
                {
                    var content = file.OpenReadStream();
                    var result = await client.SpeechToTextAsync(speechRecognitionOptions, content, CancellationToken.None).ConfigureAwait(false);

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var count = result.Result.Variants.Count - 1;
                        Random rnd = new Random(); 
                        int value = rnd.Next(0, count);

                        var model = await _parserService.TextToCard(result.Result.Variants[value].Text);
                        return model;
                    }
                    
                    if (result.TransportStatus != TransportStatus.Ok || result.StatusCode != HttpStatusCode.OK)
                    {
                        return null;
                        //Handle network and request parameters error
                    }

                    if (!result.Result.Success)
                    {
                        //Unable to recognize speech
                    }

                    return null;
                    //Use recognition results

                }
                catch (OperationCanceledException)
                {
                    //Handle operation cancellation
                }
            }

            return null;
        }   
    }
}