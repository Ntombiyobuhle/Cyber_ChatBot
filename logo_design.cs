using System.IO;
using System;
using System.Drawing;

namespace Cyber_ChatBot
{
    public class logo_design
    {
        public logo_design()
        {
            // GET  LOCATION OF THE PROJECT
            string location = AppDomain.CurrentDomain.BaseDirectory;

            // replace the bin_debug
            string new_Location = location.Replace("bin\\Debug\\", "");

            // teh combine the path 
            string full_path = Path.Combine(new_Location, "logo.jpeg");
            // then time to use ascii 

            // creating the BitMap  class 
            Bitmap image = new Bitmap(full_path);

            // then set the size 
            image = new Bitmap(image, new Size(90, 50));

            // outer and inner loop
            for (int i = 0; i < image.Height; i++)
            {
                // inner loop
                for (int j = 0; j < image.Width; j++)
                {
                    Color pixelColor = image.GetPixel(j, i);
                    int gray = (int)(pixelColor.R + pixelColor.G  + pixelColor.B ) / 3;
                    char ascciiChar = gray > 200 ? ' ' : gray > 150 ? '@' : gray > 50 ? ' ' : gray > 25 ? '!' : '#';
                    Console.Write(ascciiChar);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }

        }// END OF CONSTUCTOR
    }//END OF CLASS 
}// END OF NAMESPACE
        