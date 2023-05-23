using System.Transactions;

namespace TranslatorApp.DTOs
{
    internal class TranslationRequest
    {
        public string Format { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Input { get; set; }
        public TranslationOptions Options { get; set; }
    }
}