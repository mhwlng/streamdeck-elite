using System;
using System.Drawing;
using System.IO;
using BarRaider.SdTools;

namespace Elite
{
    // copied from streamdeck-tools/barraider-sdtools/Tools.cs

    /// <summary>
    /// Set of common utilities used by various plugins
    /// Currently the class mostly focuses on image-related functions that will be passed to the StreamDeck key
    /// </summary>
    public static class Tools
    {
        private const string HEADER_GIF_PREFIX = "data:image/gif;base64,";


        /// <summary>
        /// Convert an image file to Base64 format. Set the addHeaderPrefix to true, if this is sent to the SendImageAsync function
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="addHeaderPrefix"></param>
        /// <returns></returns>
        public static string FileToBase64(string fileName, bool addHeaderPrefix)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            if (fileName.ToLower().EndsWith(".gif"))
            {
                byte[] imageBytes = File.ReadAllBytes(fileName);

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return addHeaderPrefix ? HEADER_GIF_PREFIX + base64String : base64String;

            }
            else
            {
                try
                {
                    using (Image image = Image.FromFile(fileName))
                    {
                        return BarRaider.SdTools.Tools.ImageToBase64(image, addHeaderPrefix);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.LogMessage(TracingLevel.FATAL, "FileToBase64 " + ex);

                    return null;
                }

            }
        }

    }
}
