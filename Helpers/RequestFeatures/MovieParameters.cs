namespace Shared.RequestFeatures;

public class MovieParameters : RequestParameters
{
	public MovieParameters() => OrderBy = "title";
	public string? SearchTerm { get; set; }
}
