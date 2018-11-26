using System.IO;
using System.Threading.Tasks;
using ITCC.YandexSpeechKitClient.Enums;
using Microsoft.AspNetCore.Http;

namespace hackathonvoice.Domain.Interfaces
{
    public interface ISpeechToTextService
    {
        /// <summary>
        /// Чтение текста из аудиофайла
        /// </summary>
        /// <param name="audiofile">Аудиозапись</param>
        /// <param name="format">Формат аудиозаписи</param>
        /// <returns></returns>
        Task<string> FileToText(IFormFile audiofile, RecognitionAudioFormat format);

        /// <summary>
        /// Чтение текста из потока
        /// </summary>
        /// <param name="audiostream">Поток с аудиозаписью</param>
        /// <param name="format">Формат аудиозаписи</param>
        /// <returns></returns>
        Task<string> StreamToText(Stream audiostream, RecognitionAudioFormat format);
    }
}