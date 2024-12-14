namespace Website.Metadata.Model;

using System.Collections.Generic;
using Website.Metadata.Api;

public class PageNavigationModel : PageNavigation
{
    public string Id { get; set; } = string.Empty;
    public float Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public bool IsFolder { get; set; }
    public IEnumerable<PageNavigation> Children => ChildrenAsList;
    public List<PageNavigationModel> ChildrenAsList { get; set; } = new List<PageNavigationModel>();
}
