using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Brush
    {
        public static int W;
        public static int H;

        public Color BrushColor { get; set; }
        public int Size { get; set; }
        public Brush(Color brushColor, int size)
        {
            BrushColor = brushColor;
            Size = size;
        }
        public abstract void Draw(Bitmap image, int x, int y);
    }

    class QuadBrush : Brush
    {
        public QuadBrush(Color brushColor, int size)
            : base(brushColor, size) { }

        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    image.SetPixel(x0, y0, BrushColor);
                }
            }
        }
    }

    class SolidBrush : Brush
    {
        public SolidBrush(Color brushColor, int size)
            : base(brushColor, size) { }

        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {

                    if (((x - x0) * (x - x0)) + ((y - y0) * (y - y0)) < (Size * Size))
                    {
                        if (x0 > 0 & y0 > 0 & x0 < W & y0 < H)
                        {
                            image.SetPixel(x0, y0, BrushColor);
                        }
                    }
                }
            }

        }
    }

    class CirclestBrush : Brush
    {
        public CirclestBrush(Color brushColor, int size)
            : base(brushColor, size) { }

        public override void Draw(Bitmap image, int x, int y)
        {
            Random rand = new Random();

            for (int y0 = y - Size; y0 < y + Size; ++y0)
            {
                for (int x0 = x - Size; x0 < x + Size; ++x0)
                {
                    int randomNumber = rand.Next(1, 100);

                    if (randomNumber % 5 == 0)
                    {
                        if (x0 > 0 & y0 > 0 & x0 < W & y0 < H)
                        {
                            image.SetPixel(x0, y0, BrushColor);
                        }
                    }
                }
            }
        }
    }

    class Clear : Brush
    {
        public Clear(Color brushColor, int size)
            : base(brushColor, size) { }

        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0 = y - Size; y0 < y + Size; y0++)
            {
                for (int x0 = x - Size; x0 < x + Size; x0++)
                {
                    if (x0 > 0 & y0 > 0 & x0 < W & y0 < H)
                    {
                        image.SetPixel(x0, y0, Color.White);
                    }
                }
            }
        }
    }
}


