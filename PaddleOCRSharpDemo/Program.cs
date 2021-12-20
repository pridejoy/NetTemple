using PaddleOCRSharp;
using System;
using System.Drawing;
using System.IO;

namespace PaddleOCRSharpDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var imagebyte = File.ReadAllBytes(@"2.jpg");
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));
            OCRResult ocrResult = PaddleOCRSharp.PaddleOCRHelper.DetectText(bitmap);
            if (ocrResult != null)
            {
                Console.WriteLine($"识别结果,{ocrResult.Text}");
            }
        }
    }
}