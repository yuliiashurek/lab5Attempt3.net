using System.Xml;
using System.Xml.Schema;

namespace lab5.Subjects.Currency.XmlCurrency;

public class WorkWithXml
{
    private String _xmlData;
    public List<ICurrencyInfo> CurrencyInfos { get; private set; }
    private readonly XmlTags _xmlTags;
    private readonly XmlDocument _xmlDocument;

    public WorkWithXml()
    {
        _xmlDocument = new XmlDocument();
        _xmlTags = XmlTags.GetXmlTags();
        _xmlData = RetrieveXmlData();
        CurrencyInfos = UpdateOurList(_xmlData);
    }

    public (bool, List<ICurrencyInfo>?) Reload()
    {
        string newData = RetrieveXmlData();
        if (newData != _xmlData)
        {
            _xmlData = newData;
            UpdateOurList(_xmlData);
            return (true, UpdateOurList(_xmlData));
        }

        //Console.WriteLine("compared");
        return (false, null);
    }

    private string RetrieveXmlData()
    {
        string url = _xmlTags.Url;

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string xml = response.Content.ReadAsStringAsync().Result;
            return xml;
        }
    }

    private void ValidateXmlString(string xmlContent)
    {
        string xsdFilePath = _xmlTags.FilepathXsd;

        _xmlDocument.LoadXml(xmlContent);

        XmlSchemaSet schemas = new XmlSchemaSet();
        schemas.Add("", xsdFilePath);

        _xmlDocument.Schemas.Add(schemas);

        ValidationEventHandler validationHandler = (o, e) => throw new Exception($"xml not validated");
        _xmlDocument.Validate(validationHandler);
    }

    private List<ICurrencyInfo> UpdateOurList(string xmlString)
    {
        List<ICurrencyInfo> currencyInfoList = new List<ICurrencyInfo>();
        ValidateXmlString(xmlString);

        XmlNodeList? currencyNodes = _xmlDocument.SelectNodes(_xmlTags.XPathNodeIterate);

        CurrencyInfos = currencyInfoList;
        if (currencyNodes == null) return currencyInfoList;
        foreach (XmlNode currencyNode in currencyNodes)
        {
            string code = currencyNode.SelectSingleNode(_xmlTags.CodeXmlTag)?.InnerText ?? "no code";
            string name = currencyNode.SelectSingleNode(_xmlTags.CurrencyNameXmlTag)?.InnerText ?? "no name";
            string shortName = currencyNode.SelectSingleNode(_xmlTags.ShortCurrencyNameXmlTag)?.InnerText ??
                               "no short name";
            decimal exchangeRate =
                decimal.Parse(currencyNode.SelectSingleNode(_xmlTags.ExchangeRateXmlTag)?.InnerText ?? "0");
            DateTime dateTime =
                DateTime.ParseExact(
                    currencyNode.SelectSingleNode(_xmlTags.LastUpdatedXmlTag)?.InnerText ??
                    DateTime.Now.ToString(_xmlTags.DateFormatInXml), _xmlTags.DateFormatInXml, null);

            CurrencyInfo currencyInfo = new CurrencyInfo(code, name, shortName, exchangeRate, dateTime);
            currencyInfoList.Add(currencyInfo);
        }

        return currencyInfoList;
    }
}