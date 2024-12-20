namespace Static.PreRenderer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Components;

public static class PrerenderRouteHelper
{
    public static List<string> GetRoutes(Assembly assembly)
    {
        // Get all the components whose base class is ComponentBase
        var components = assembly.ExportedTypes.Where(t => t.IsSubclassOf(typeof(ComponentBase)));

        var routes = components
            .Select(GetRouteFromComponents)
            .SelectMany(route => route)
            .Where(config => config is not null)
            .ToList();

        return routes;
    }

    private static string[] GetRouteFromComponents(Type component)
    {
        var attributes = component.GetCustomAttributes(inherit: true);

        return attributes
            .OfType<RouteAttribute>()
            .Select(route => GetRouteFromComponent(route, component))
            .ToArray();
    }

    private static string GetRouteFromComponent(RouteAttribute routeAttribute, Type component)
    {
        if (routeAttribute is null)
        {
            // Only map routable components
            return null;
        }

        var route = routeAttribute.Template;

        if (string.IsNullOrEmpty(route))
        {
            throw new Exception(
                $"RouteAttribute in component '{component}' has empty route template"
            );
        }

        // Doesn't support tokens yet
        if (route.Contains('{'))
        {
            throw new Exception(
                $"RouteAttribute for component '{component}' contains route values. Route values are invalid for prerendering"
            );
        }

        return route;
    }
}
