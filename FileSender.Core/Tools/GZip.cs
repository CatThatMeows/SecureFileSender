using System.IO.Compression;

namespace FileSender.Core.Tools
{
    public class GZip
    {
        public static async Task<byte[]> CompressData(byte[] input, CancellationToken CT)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress))
                {
                    await gzip.WriteAsync(input, 0, input.Length, CT);
                }
                return output.ToArray();
            }
        }

        public static async Task<byte[]> DecompressData(ArraySegment<byte> input, CancellationToken CT)
        {
            if (input.Array == null)
                return Array.Empty<byte>();

            using (MemoryStream ms = new MemoryStream(input.Array))
            using (GZipStream gzip = new GZipStream(ms, CompressionMode.Decompress))
            using (MemoryStream msout = new MemoryStream())
            {
                await gzip.CopyToAsync(msout, CT);
                return msout.ToArray();
            }
        }
    }
}
