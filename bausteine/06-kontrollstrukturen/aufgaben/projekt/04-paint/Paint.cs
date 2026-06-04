using System.Drawing;
using BoDraw;

// Basic things
BoDrawApp app = new BoDrawApp();
Image image = new Image(-1.1, -1.1, 1.1, 1.1, 100);
app.Add(image);

// Image size
int nrows = image.PixelSize.Height;
int ncols = image.PixelSize.Width;

// Manipulate pixel
Image.Pixel p = image.PixelAt(50, 50);
p.Color = Colors.Green;

// Print
Console.WriteLine($"Image is of size {nrows} x {ncols}");
Console.WriteLine($"Pixel at x = {p.X:0.####} y = {p.Y:0.####}");

// Show
app.Show();