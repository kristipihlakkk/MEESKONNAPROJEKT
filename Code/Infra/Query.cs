using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Infra;

public sealed class Query(Dictionary<string, string>? d = null)
{
    public static int[] PageSizes => [7, 15, 25, 50, 100];
    public int Page => toInt(get(nameof(Page)), 1);
    public int PageSize => toInt(get(nameof(PageSize)), PageSizes[0]);
    public string SortBy => get(nameof(SortBy)) ?? "";
    public string SortDir => get(nameof(SortDir)) ?? "";
    public string SearchBy => get(nameof(SearchBy)) ?? "";
    public string SearchStr => get(nameof(SearchStr)) ?? "";

    private string? get(string s) => (d ?? []).TryGetValue(s, out var x) ? x : null;
    private static int toInt(string? s, int def) => int.TryParse(s, out var i) ? i : def;
}
