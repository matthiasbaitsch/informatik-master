using BoDraw;

BoDrawApp app = new BoDrawApp();
Image image = new Image(-1.1, -1.1, 1.1, 1.1, 1500);

for (int row = 0; row < image.PixelSize.Height; row++)
{
    for (int col = 0; col < image.PixelSize.Width; col++)
    {
        Image.Pixel p = image.PixelAt(row, col);

        if (p.X * p.X + p.Y * p.Y <= 1)
        {
            if (p.X >= 0 && p.Y >= 0)
            {
                p.Color = Colors.Orange;
            }
            else
            {
                p.Color = Colors.LightBlue;
            }
        }
        else
        {
            if (p.X >= 0 && p.Y >= 0)
            {
                p.Color = Colors.Bisque;
            }
            else
            {
                p.Color = Colors.Coral;
            }
        }
    }
}


app.Add(image);
app.Show();