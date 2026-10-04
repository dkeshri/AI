using ModelContextProtocol.Server;
using System.ComponentModel;

/// <summary>
/// Sample MCP tools for demonstration purposes.
/// These tools can be invoked by MCP clients to perform various operations.
/// </summary>
internal class RandomNumberTools
{
    [McpServerTool]
    [Description("Calculates the age based on the provided date of birth.")]
    public int AgeCalculation(
        [Description("The date of birth in YYYY-MM-DD format")] string dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(dateOfBirth))
            throw new ArgumentException("The date of birth must be provided in YYYY-MM-DD format.", nameof(dateOfBirth));

        dateOfBirth = dateOfBirth.Trim();

        if (!DateOnly.TryParseExact(
                dateOfBirth,
                "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out var dob))
        {
            // Fallback to a more flexible parse to accept other common formats
            if (!DateOnly.TryParse(
                    dateOfBirth,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out dob))
            {
                throw new ArgumentException("Invalid date format. Expected YYYY-MM-DD.", nameof(dateOfBirth));
            }
        }

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (dob > today)
            throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));

        int age = today.Year - dob.Year;
        if (today < dob.AddYears(age))
            age--;

        return age;
    }
}
