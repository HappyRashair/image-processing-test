// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using SkiaSharp;

Console.WriteLine("Hello, SkiaSharp!");

var st = Stopwatch.StartNew();
for (int i = 0; i < 1000; ++i)
{
    var fileContents = File.ReadAllBytes("image.png");

    using MemoryStream ms = new MemoryStream(fileContents);
    using SKBitmap sourceBitmap = SKBitmap.Decode(ms);

    int height = Math.Min(100, sourceBitmap.Height);
    int width = Math.Min(100, sourceBitmap.Width);

    using SKBitmap scaledBitmap = sourceBitmap.Resize(new SKImageInfo(width, height), SKFilterQuality.High);
    using SKImage scaledImage = SKImage.FromBitmap(scaledBitmap);
    using SKData data = scaledImage.Encode();

    File.WriteAllBytes($"image-resized-${i}.png", data.ToArray());
}
Console.WriteLine($"Processing took {st.Elapsed.TotalSeconds}");