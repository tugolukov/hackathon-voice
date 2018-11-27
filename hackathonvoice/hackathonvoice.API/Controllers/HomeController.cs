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
using ITCC.YandexSpeechKitClient;
using ITCC.YandexSpeechKitClient.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace hackathonvoice.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController()
        {
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
        public async Task<string> SendFlacToAPI()
        {
            var request = Request;

            var file = request.Form.Files.FirstOrDefault();
            var fileName = file.FileName;
            
            
            var apiSetttings = new SpeechKitClientOptions("7102e72c-3cc9-4f92-8b38-81dd97c93075", "HackathonVoice", Guid.NewGuid(), "device");

            using (var client = new SpeechKitClient(apiSetttings))
            {
                var speechRecognitionOptions = new SpeechRecognitionOptions(SpeechModel.Queries, RecognitionAudioFormat.Wav, RecognitionLanguage.Russian);
                try
                {
                    var content = file.OpenReadStream();
                    var result = await client.SpeechToTextAsync(speechRecognitionOptions, content, CancellationToken.None).ConfigureAwait(false);
                    if (result.TransportStatus != TransportStatus.Ok || result.StatusCode != HttpStatusCode.OK)
                    {
                        return result.Result.Variants.First().Text;
                        //Handle network and request parameters error
                    }

                    if (!result.Result.Success)
                    {
                        //Unable to recognize speech
                    }

                    var utterances = result.Result.Variants;
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