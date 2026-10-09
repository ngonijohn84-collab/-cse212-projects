
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1 - Find symmetric pairs using a HashSet.
    /// Expected time complexity: O(n).
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            string reverse = new string(new[] { word[1], word[0] });

            if (seen.Contains(reverse))
            {
                pairs.Add($"{word} & {reverse}");
            }

            seen.Add(word);
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Problem 2 - Read a census file and count how many
    /// people have each education qualification.
    /// The degree is found in the fourth column.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length < 4)
                continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Problem 3 - Determine whether two strings
    /// are anagrams using a dictionary.
    /// Ignore spaces and capitalization.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var counts = new Dictionary<char, int>();
        int letters1 = 0;
        int letters2 = 0;

        foreach (char character in word1)
        {
            if (character == ' ')
                continue;

            char letter = char.ToLowerInvariant(character);
            letters1++;

            if (!counts.TryAdd(letter, 1))
            {
                counts[letter]++;
            }
        }

        foreach (char character in word2)
        {
            if (character == ' ')
                continue;

            char letter = char.ToLowerInvariant(character);
            letters2++;

            if (!counts.TryGetValue(letter, out int count) || count == 0)
            {
                return false;
            }

            counts[letter] = count - 1;
        }

        return letters1 == letters2;
    }

    /// <summary>
    /// Problem 5 - Retrieve today's earthquakes
    /// from the USGS API and return formatted
    /// location and magnitude descriptions.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();

        using var response = client.GetAsync(uri)
            .GetAwaiter()
            .GetResult();

        response.EnsureSuccessStatusCode();

        var json = response.Content
            .ReadAsStringAsync()
            .GetAwaiter()
            .GetResult();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection == null)
        {
            return [];
        }

        var summary = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            string place = feature.Properties.Place ?? "Unknown location";
            double? magnitude = feature.Properties.Mag;

            summary.Add($"{place} - Mag {magnitude}");
        }

        return summary.ToArray();
    }
}
