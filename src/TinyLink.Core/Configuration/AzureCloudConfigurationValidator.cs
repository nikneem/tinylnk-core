using Microsoft.Extensions.Options;

namespace TinyLink.Core.Configuration;

public class AzureCloudConfigurationValidator : IValidateOptions<AzureCloudConfiguration>
{
        public ValidateOptionsResult Validate(string? name, AzureCloudConfiguration options)
        {
            var errorList = new List<string>();
            if (string.IsNullOrWhiteSpace(options.StorageAccountName))
            {
                errorList.Add($"The app setting {AzureCloudConfiguration.SectionName}.StorageAccountName cannot be null or empty");
            }
            return errorList.Count > 0 ? ValidateOptionsResult.Fail(errorList) : ValidateOptionsResult.Success;
        }
}