using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zotin_1
{
    static class Morphology
    {
        public static List<List<bool>> createMaskList(int width, int height)
        {
            List<List<bool>> maskList = new List<List<bool>>();
            maskList.Clear();

            for(int i = 0; i < height; i++)
            {
                List<bool> row = new List<bool>();
                for(int j = 0; j < width; j++)
                {
                    row.Add(false);
                }
                maskList.Add(row);
            }

            return maskList;
        }

        public static Bitmap applyDillation(string colorModelTag, int colorChannelIndex, Bitmap image, Point imageSize, List<List<bool>> mask, Point maskSize)
        {
            Bitmap rezult = new Bitmap(image);
            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, maskSize);

            for (int x = 0; x < apertures.Count; x++)
            {
                int rMax = 0, gMax = 0, bMax = 0;

                List<List<Point>> matrix = apertures[x].matrix;
                int i = 0, j = 0;
                foreach (var matrixLine in matrix)
                {
                    j = 0;
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;
                        Color color = image.GetPixel(pixelPosX, pixelPosY);
                        if(mask[i][j] == true)
                        {
                            if (color.R > rMax) rMax = color.R;
                            if (color.G > gMax) gMax = color.G;
                            if (color.B > bMax) bMax = color.B;
                        }
                        j++;                      
                    }
                    i++;
                }

                int aperturePosX = matrix.Count / 2;
                int aperturePosY = matrix[aperturePosX].Count / 2;


                Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                if (colorChannelIndex == 0)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rMax, gMax, bMax));
                }
                else if (colorChannelIndex == 1)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rMax, oldColor.G, oldColor.B));
                }
                else if (colorChannelIndex == 2)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, gMax, oldColor.B));
                }
                else if (colorChannelIndex == 3)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, bMax));
                }
            }


            service = null;
            for (int i = 0; i < apertures.Count; i++)
            {
                apertures[i].Dispose();
            }
            apertures.Clear();

            return rezult;
        }

        public static Bitmap applyErosion(string colorModelTag, int colorChannelIndex, Bitmap image, Point imageSize, List<List<bool>> mask, Point maskSize)
        {
            Bitmap rezult = new Bitmap(image);
            ApertureService service = new ApertureService();

            List<Aperture> apertures = service.getApertureMatrixGenerator(imageSize, maskSize);

            for (int x = 0; x < apertures.Count; x++)
            {
                int rMin = 255, gMin = 255, bMin = 255;

                List<List<Point>> matrix = apertures[x].matrix;
                int i = 0, j = 0;
                foreach (var matrixLine in matrix)
                {
                    j = 0;
                    foreach (var Point in matrixLine)
                    {
                        int pixelPosX = Point.X;
                        int pixelPosY = Point.Y;
                        Color color = image.GetPixel(pixelPosX, pixelPosY);
                        if (mask[i][j] == true)
                        {
                            if (color.R < rMin) rMin = color.R;
                            if (color.G < gMin) gMin = color.G;
                            if (color.B < bMin) bMin = color.B;
                        }
                        j++;
                    }
                    i++;
                }

                int aperturePosX = matrix.Count / 2;
                int aperturePosY = matrix[aperturePosX].Count / 2;


                Color oldColor = image.GetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y);

                if (colorChannelIndex == 0)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rMin, gMin, bMin));
                }
                else if (colorChannelIndex == 1)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(rMin, oldColor.G, oldColor.B));
                }
                else if (colorChannelIndex == 2)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, gMin, oldColor.B));
                }
                else if (colorChannelIndex == 3)
                {
                    rezult.SetPixel(matrix[aperturePosX][aperturePosY].X, matrix[aperturePosX][aperturePosY].Y, Color.FromArgb(oldColor.R, oldColor.G, bMin));
                }
            }


            service = null;
            for (int i = 0; i < apertures.Count; i++)
            {
                apertures[i].Dispose();
            }
            apertures.Clear();

            return rezult;
        }
    }
}
