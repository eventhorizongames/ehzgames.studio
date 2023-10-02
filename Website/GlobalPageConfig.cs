namespace Website;

using System.Collections.Generic;

public static class GlobalPageConfig
{
    public static readonly IDictionary<string, float> PageOrders = new Dictionary<string, float>()
    {
        ["games"] = -1000,
        ["game-development-platform"] = 1000,
    };

    public static readonly string GameDevelopmentPlatformLink =
        "https://cloud-sandbox.sandbox.ehzgames.studio/";
}
