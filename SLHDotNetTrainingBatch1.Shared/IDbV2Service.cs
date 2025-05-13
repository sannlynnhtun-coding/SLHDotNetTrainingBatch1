
namespace SLHDotNetTrainingBatch1.Shared
{
    public interface IDbV2Service
    {
        int Execute(string query, object? parameters = null);
        List<Collin> Query<Collin>(string query, object? parameters = null);
    }
}