namespace TinyLink.Core.Configuration;

public class AzureCloudConfiguration
{
    public const string SectionName = "Azure";

    public string? StorageAccountName { get; set; }
    public string? ServiceBusName { get; set; }
   
}