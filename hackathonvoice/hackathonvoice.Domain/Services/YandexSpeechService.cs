using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using hackathonvoice.Domain.Interfaces;
using ITCC.YandexSpeechKitClient;
using ITCC.YandexSpeechKitClient.Enums;

namespace hackathonvoice.Domain.Services
{
    public class YandexSpeechService : ISpeechService
    {
        private readonly HttpClient _client;
        private readonly IParserService _parserService;

        public YandexSpeechService(IParserService parserService)
        {
            _parserService = parserService;
            _client = new HttpClient();
            _client.BaseAddress =
                new Uri(
                    "https://asr.yandex.net/asr_xml?uuid=f1cdf2643dcc4990951d6d1546c0b828&key=7102e72c3cc94f928b3881dd97c93075&topic=queries&lang=ru-RU");
        }

        public async Task<string> SpeechToText(Stream content)
        {
            var apiSetttings = new SpeechKitClientOptions("7102e72c-3cc9-4f92-8b38-81dd97c93075", "HackathonVoice", Guid.NewGuid(), "device");

            using (var client = new SpeechKitClient(apiSetttings))
            {
                var speechRecognitionOptions = new SpeechRecognitionOptions(SpeechModel.Queries, RecognitionAudioFormat.WebM, RecognitionLanguage.Russian);
                try
                {
                    var result = await client.SpeechToTextAsync(speechRecognitionOptions, content, CancellationToken.None).ConfigureAwait(false);

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        return result.Result.Variants.First().Text;
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
            
            throw new System.NotImplementedException();
        }
    }
}