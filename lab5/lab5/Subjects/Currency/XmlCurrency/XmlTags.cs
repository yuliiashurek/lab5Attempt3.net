namespace lab5.Subjects.Currency.XmlCurrency;

public class XmlTags
{
    private static XmlTags? _xmlTags;
    public string FilepathXsd { get; }
    public string Url { get; }
    public string XPathNodeIterate { get; }
    public string CodeXmlTag { get; }
    public string CurrencyNameXmlTag { get; }
    public string ShortCurrencyNameXmlTag { get; }
    public string ExchangeRateXmlTag { get; }
    public string LastUpdatedXmlTag { get; }
    public string DateFormatInXml { get; }

    private XmlTags( string filepathXsd,string url, string xPathNodeIterate, string codeXmlTag, string currencyNameXmlTag,
        string shortCurrencyNameXmlTag, string exchangeRateXmlTag, string lastUpdatedXmlTag, string dateFormatInXml)
    {
        Url = url;
        XPathNodeIterate = xPathNodeIterate;
        CodeXmlTag = codeXmlTag;
        CurrencyNameXmlTag = currencyNameXmlTag;
        ShortCurrencyNameXmlTag = shortCurrencyNameXmlTag;
        ExchangeRateXmlTag = exchangeRateXmlTag;
        LastUpdatedXmlTag = lastUpdatedXmlTag;
        DateFormatInXml = dateFormatInXml;
        FilepathXsd = filepathXsd;
    }

    public static XmlTags GetXmlTags()
    {
        if (_xmlTags != null) return _xmlTags;

        _xmlTags = new XmlTags("currencyRates.xsd",
            "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange",
            "/exchange/currency",
            "r030", "txt", "cc", "rate", "exchangedate",
            "dd.MM.yyyy");

        return _xmlTags;
    }
}