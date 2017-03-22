#r "System.Drawing"
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace HackNight.ImageProcessor
{
    public class ImageProcessor
    {

        public static void Run(string myQueueItem, TraceWriter log, out string outputBlob)
        {
            {
                log.Info($"C# Queue trigger function processed: {myQueueItem}");
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(myQueueItem);

                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        outputBlob = Convert.ToBase64String(mem.ToArray());

                        using (var image = System.Drawing.Image.FromStream(mem))
                        {
                            log.Info(image.Height.ToString());
                        }
                    }

                }
            }
}