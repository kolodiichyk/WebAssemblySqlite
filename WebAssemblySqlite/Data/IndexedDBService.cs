namespace WebAssemblySqlite.Data;
using Microsoft.JSInterop;
using System.Threading.Tasks;

public class IndexedDbService : IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private const string _dbName = "AppStorage";
    private const string _storeName = "BinaryStore";
    private const string _versionStoreName = "VersionStore";

    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public IndexedDbService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "../js/indexedDb.js").AsTask());
    }

    public async Task InitializeAsync()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("initIndexedDB", _dbName, _storeName, _versionStoreName);
    }

    public async Task StoreBytes(string key, byte[] data, string version)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("storeData", _dbName, _storeName, _versionStoreName, key, data, version);
    }

    public async Task<byte[]?> GetBytes(string key)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<byte[]>("getDataOnly", _dbName, _storeName, key);
    }

    public async Task<string?> GetVersion(string key)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("getVersion", _dbName, _versionStoreName, key);
    }

    public async Task DeleteFile(string key)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("deleteData", _dbName, _storeName, _versionStoreName, key);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
