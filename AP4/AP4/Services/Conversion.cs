using AP4.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AP4.Services
{
    static class Conversion // code prof 
    {
        public static ImageSource ConvertFromBase64(string param)
        {

            byte[] Base64Stream = Convert.FromBase64String(param);
            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));


        }
        public static string ConvertToBase64(this Stream stream)
        {
            if (stream is MemoryStream memoryStream)
            {
                return Convert.ToBase64String(memoryStream.ToArray());
            }

            var bytes = new Byte[(int)stream.Length];

            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);

            return DependencyService.Get<MyImageCompressor>().ImageCompressor(bytes);
        }
    }
}
