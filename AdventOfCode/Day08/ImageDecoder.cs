using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day08
{
    public class ImageDecoder
    {
        public SpaceImage CreateNewSpaceImage(string encryptedData, int width, int height)
        {
            var spaceImage = new SpaceImage { Width = width, Height = height };
            while (!string.IsNullOrEmpty(encryptedData))
            {
                var rows = new SpaceImageLayer();
                for (int i = 0; i < height; i++)
                {
                    rows.Rows.Add(encryptedData.Substring(0, width));
                    encryptedData = encryptedData.Remove(0, width);
                }
                spaceImage.Layers.Add(rows);
            }

            return spaceImage;
        }

        public int GetChecksum(SpaceImage spaceImage)
        {
            var layer = GetLayerWithFewestZeros(spaceImage.Layers);
            var ones = CountNumber(layer, 1);
            var twos = CountNumber(layer, 2);
            return ones * twos;
        }

        public string DecodeImageToString(SpaceImage spaceImage) =>
            ConvertLayerToString(DecodeImage(spaceImage), spaceImage.Width, spaceImage.Height);

        public string[,] DecodeImage(SpaceImage spaceImage)
        {
            var decodedImage = new string[spaceImage.Height, spaceImage.Width];
            foreach (var layer in spaceImage.Layers)
            {
                for (int i = 0; i < spaceImage.Height; i++)
                {
                    for (int j = 0; j < spaceImage.Width; j++)
                    {
                        decodedImage[i, j] = string.IsNullOrEmpty(decodedImage[i, j]) || decodedImage[i, j] == "2"
                            ? layer.Rows[i][j].ToString()
                            : decodedImage[i, j];
                    }
                }
            }
            return decodedImage;
        }

        private string ConvertLayerToString(string[,] layer, int width, int height)
        {
            var fullBlock = '\u2588';
            var lightShade = '\u2591';
            var result = string.Empty;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result += layer[i, j];
                }
                result += "\n";
            }
            return result.Replace('1', fullBlock).Replace('0', lightShade);
        }

        private SpaceImageLayer GetLayerWithFewestZeros(List<SpaceImageLayer> layers)
        {
            var zerosPerLayer = new List<int>();
            foreach (var layer in layers)
            {
                zerosPerLayer.Add(CountNumber(layer, 0));
            }

            var layerIndex = zerosPerLayer.IndexOf(zerosPerLayer.OrderBy(z => z).FirstOrDefault());
            return layers[layerIndex];
        }

        private int CountNumber(SpaceImageLayer layer, int searchedNumber)
        {
            var numberCount = 0;
            foreach (var row in layer.Rows)
            {
                numberCount += row.Count(d => d == $"{searchedNumber}"[0]);
            }
            return numberCount;
        }
    }
}
