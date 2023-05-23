namespace TranslatorApp.DTOs
{
    public class TranslationOptions
    {
        public bool SentenceSplitter { get; set; }
        public string Origin { get; set; }
        public bool ContextResults { get; set; }
        public bool LanguageDetection { get; set; }
    }
}