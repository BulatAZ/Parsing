namespace ConsoleApp1.Core.Habra
{
    class HabraSettings : IParserSettings
    {
        public string BaseUrl { get; set; } = "http://habrahabr.ru";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
