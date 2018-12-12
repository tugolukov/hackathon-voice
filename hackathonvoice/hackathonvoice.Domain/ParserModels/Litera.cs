namespace hackathonvoice.Domain.ParserModels
{
    public class Litera
    {
        public bool IsKey { get; set; }
        public string Text { get; set; }

        public Litera()
        {}
        
        public Litera(bool isKey, string text)
        {
            IsKey = isKey;
            Text = text;
        }
    }
}