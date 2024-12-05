namespace Days.Five;

/// <summary>
/// This class contains the logic for day five.
/// </summary>
public static class DayFiveService
{
    public static int SumMiddlePages(IEnumerable<string> pageOrderingRules, IEnumerable<string> pageUpdates)
    {
        var rules = ParseRules(pageOrderingRules);
        var updates = ParseUpdates(pageUpdates);

        return updates
            .Where(update => IsValidUpdate(update, rules))
            .Sum(GetMiddlePage);
    }

    public static int SumSortedMiddlePages(IEnumerable<string> pageOrderingRules, IEnumerable<string> pageUpdates)
    {
        var rules = ParseRules(pageOrderingRules);
        var updates = ParseUpdates(pageUpdates);

        return updates
            .Where(update => !IsValidUpdate(update, rules))
            .Select(update => FixUpdate(update, rules))
            .Select(GetMiddlePage)
            .Sum();
    }

    private static List<(int Before, int After)> ParseRules(IEnumerable<string> rulesInput)
    {
        return rulesInput
            .Select(rule =>
            {
                var parts = rule.Split('|').Select(int.Parse).ToArray();
                return (Before: parts[0], After: parts[1]);
            })
            .ToList();
    }

    private static List<List<int>> ParseUpdates(IEnumerable<string> updatesInput)
    {
        return updatesInput
            .Select(update => update.Split(',').Select(int.Parse).ToList())
            .ToList();
    }

    private static bool IsValidUpdate(List<int> update, List<(int Before, int After)> rules)
    {
        var positions = update
            .Select((value, index) => (Value: value, Index: index))
            .ToDictionary(pair => pair.Value, pair => pair.Index);

        foreach (var (before, after) in rules)
        {
            if (!positions.ContainsKey(before) || !positions.TryGetValue(after, out var position))
                continue;

            if (positions[before] >= position)
            {
                return false;
            }
        }

        return true;
    }

    private static List<int> FixUpdate(List<int> update, List<(int Before, int After)> rules)
    {
        var graph = new Dictionary<int, List<int>>();
        foreach (var page in update)
        {
            graph[page] = [];
        }

        foreach (var (before, after) in rules)
        {
            if (graph.TryGetValue(before, out var value) && graph.ContainsKey(after))
            {
                value.Add(after);
            }
        }

        var visited = new HashSet<int>();
        var stack = new Stack<int>();

        foreach (var page in update.Where(page => !visited.Contains(page)))
        {
            PerformTopologicalSort(page, graph, visited, stack);
        }

        var result = new List<int>();
        while (stack.Count > 0)
        {
            result.Add(stack.Pop());
        }

        return result;
    }

    private static void PerformTopologicalSort(int page, Dictionary<int, List<int>> graph, HashSet<int> visited,
        Stack<int> stack)
    {
        if (!visited.Add(page))
            return;

        foreach (var neighbor in graph[page])
        {
            PerformTopologicalSort(neighbor, graph, visited, stack);
        }

        stack.Push(page);
    }

    private static int GetMiddlePage(List<int> update)
    {
        return update[update.Count / 2];
    }
}