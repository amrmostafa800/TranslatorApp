using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Transactions;
using TranslatorApp.DTOs;

namespace TranslatorApp
{
    internal class Translator
    {

        private string _Text;
        private string[] _Sentences;
        private List<string> _TranslatedSentences = new List<string>();

        private static readonly HttpClient httpClient = new HttpClient();

        public Translator(string Text)
        {
            _Text = Text;
            SplitTextToSentences();
        }

        private void SplitTextToSentences()
        {
            //_Sentences = Regex.Split(_Text, @"(?<=[.?!])\s*(?=\S)");
            int maxLength = 2000;
            List<string> stringList = new List<string>();

            // Split the input string into substrings of maximum length 2000
            while (_Text.Length > maxLength)
            {
                // Find the nearest '.' character to the maximum length position
                int splitPos = _Text.LastIndexOf('.', maxLength - 1);
                if (splitPos == -1)
                {
                    // No '.' character found, split at the maximum length position
                    splitPos = maxLength;
                }
                // Add the substring to the list
                stringList.Add(_Text.Substring(0, splitPos + 1));
                // Remove the substring from the input string
                _Text = _Text.Substring(splitPos + 1);
            }
            // Add the remaining substring to the list
            stringList.Add(_Text);

            // Convert the list to an array
            _Sentences = stringList.ToArray();
        }

        private async Task<string> SendToTranslateApi(string Text)
        {
            //var url = "https://amrmostafa800-english-arabic-translate.hf.space/run/predict";

            //var requestData = new
            //{
            //    data = new string[] { Text }
            //};

            //using var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

            //var response = await httpClient.PostAsync(url, content);
            //var responseContent = await response.Content.ReadAsStringAsync();

            TranslationRequest requestBody = new TranslationRequest
            {
                Format = "text",
                From = "eng",
                To = "ara",
                Input = Text,
                Options = new TranslationOptions
                {
                    SentenceSplitter = true,
                    Origin = "translation.web",
                    ContextResults = true,
                    LanguageDetection = true
                }
            };

            string jsonString = JsonSerializer.Serialize(requestBody);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.reverso.net/translate/v1/translation"),
                Headers =
            {
                { "authority", "api.reverso.net" },
                { "accept", "application/json, text/plain, */*" },
                { "accept-language", "ar,en;q=0.9" },
                { "dnt", "1" },
                { "origin", "https://www.reverso.net" },
                { "referer", "https://www.reverso.net/" },
                { "sec-ch-ua", "\"Chromium\";v=\"112\", \"Google Chrome\";v=\"112\", \"Not:A-Brand\";v=\"99\"" },
                { "sec-ch-ua-mobile", "?0" },
                { "sec-ch-ua-platform", "\"Windows\"" },
                { "sec-fetch-dest", "empty" },
                { "sec-fetch-mode", "cors" },
                { "sec-fetch-site", "same-site" },
                { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36" },
                { "x-reverso-origin", "translation.web" },
            },
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    JObject jObject = JObject.Parse(responseBody);
            //    JArray dataField = (JArray)jObject["data"]!;

            //    return (string)dataField[0]!;
            //}

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject jsonObject = JObject.Parse(responseBody);

                JToken translationToken = jsonObject.SelectToken("$.translation");
                return string.Join('\n', translationToken);
            }
            return null;
        }

        private void ReplaceText(ref string text)
        {
            text = text.Replace("الله", "");
        }

        public async Task<string[]> Translate()
        {
            for (int i = 0; i < _Sentences.Length; i++)
            {
                string Result = null;
                while (Result == null)
                {
                    Result = await SendToTranslateApi(_Sentences[i]);
                }
                ReplaceText(ref Result);
                _TranslatedSentences.Add(Result);
            }
            return _TranslatedSentences.ToArray();
        }
    }
}
