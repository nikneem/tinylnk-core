using Azure.Core;
using Azure.Identity;

namespace TinyLink.Core.Helpers;

public static  class CloudIdentity
{
    public static TokenCredential GetChainedTokenCredential()
    {
        return new ChainedTokenCredential(new ManagedIdentityCredential(),
            new EnvironmentCredential(),
            new VisualStudioCredential(),
            new AzureCliCredential(),
            new DefaultAzureCredential());
    }
}