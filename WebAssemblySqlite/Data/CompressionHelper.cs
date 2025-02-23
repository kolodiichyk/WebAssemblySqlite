using System.IO.Compression;

namespace WebAssemblySqlite.Data;

public static class CompressionHelper
{
    // Compress using GZip
    public static byte[] CompressGZip(byte[] originalBytes)
    {
        using var compressedStream = new MemoryStream();
        using (var gzipStream = new GZipStream(compressedStream, CompressionLevel.Optimal))
        {
            gzipStream.Write(originalBytes, 0, originalBytes.Length);
        }
        return compressedStream.ToArray();
    }

    // Decompress using GZip
    public static byte[] DecompressGZip(byte[] compressedBytes)
    {
        using var compressedStream = new MemoryStream(compressedBytes);
        using var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
        using var decompressedStream = new MemoryStream();
        gzipStream.CopyTo(decompressedStream);
        return decompressedStream.ToArray();
    }
}
