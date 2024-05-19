namespace Domain.Abstractions
{
    public interface IScriptLoader
    {
        public Task<string?> GetCachedScriptAsync(string scriptFolderPath, string scriptName);
    }
}
