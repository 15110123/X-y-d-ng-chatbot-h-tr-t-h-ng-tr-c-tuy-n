using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CutieShop.API.Models.JSONEntities.Settings;
using CutieShop.API.Models.JSONEntities.Vision;
using Newtonsoft.Json;

namespace CutieShop.API.Models.Utils
{
    /// <summary>
    /// Class for vision-related methods
    /// </summary>
    public sealed class VisionUtil
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly AzureSettings _azureSettings;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="azureSettings">Contains Azure's settings</param>
        public VisionUtil(AzureSettings azureSettings)
        {
            _azureSettings = azureSettings;

            // Request headers.
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _azureSettings.Vision.Key1);
        }

        /// <summary>
        /// Get vision result of the image from the URL. 
        /// </summary>
        /// <param name="imageUrl">The URL to the image. </param>
        /// <returns></returns>
        public async Task<VisionResult> GetResult(string imageUrl)
        {

            // Request parameters. A third optional parameter is "details". WARNING: No 'vi' (Vietnamese) for this API. 
            var requestParameters = "visualFeatures=Categories,Description,Color&language=en";

            // Assemble the URI for the REST API Call.
            var uri = _azureSettings.Vision.Endpoint + "?" + requestParameters;

            // Request body. Posts a locally stored JPEG image.
            var byteData = (await HttpUtil.GetBytesFromUrl(imageUrl)).ToArray();

            using (var content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                var response = await _httpClient.PostAsync(uri, content);

                // Get the JSON response.
                var contentString = await response.Content.ReadAsStringAsync();

                // Convert response to appropriate VisionResult. 
                return JsonConvert.DeserializeObject<VisionResult>(contentString);
            }
        }

        public async Task<VisionResult> GetResult(Stream imgStream)
        {
            var requestParameters = "visualFeatures=Categories,Description,Color&language=en";

            var uri = _azureSettings.Vision.Endpoint + "?" + requestParameters;

            var byteData = imgStream.AsByteArray();

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                var response = await _httpClient.PostAsync(uri, content);

                var contentString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<VisionResult>(contentString);
            }
        }
    }
}
