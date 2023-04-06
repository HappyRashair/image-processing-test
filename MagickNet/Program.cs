// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ImageMagick;

Console.WriteLine("Hello, Magic.Net!");

var st = Stopwatch.StartNew();
for (int i = 0; i < 1000; ++i)
{
    using (var image = new MagickImage("image.png"))
    {
        var size = new MagickGeometry(100, 100);
        // This will resize the image to a fixed size without maintaining the aspect ratio.
        // Normally an image will be resized to fit inside the specified size.
        size.IgnoreAspectRatio = true;

        image.Resize(size);

        // Save the result
        image.Write($"image-resized{i}.png");
    }
}
Console.WriteLine($"Processing took {st.Elapsed.TotalSeconds}");