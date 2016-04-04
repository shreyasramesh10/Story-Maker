using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IPFinalPrj.Controllers
{
    [Authorize]
    public class UploadController : ApiController
    {
        [HttpPost]
        public KeyValuePair<bool, string> UploadFile()
        {
            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedFile != null)
                    {
                        // Get the complete file path
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);
                        FileInfo fi = new FileInfo(httpPostedFile.FileName);

                        return new KeyValuePair<bool, string>(true, "File uploaded as " + fi.FullName + "Size:" + fi.Length + "B");
                    }
                    return new KeyValuePair<bool, string>(true, "Could not get the uploaded file.");
                }
                return new KeyValuePair<bool, string>(true, "No file found to upload.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(true, "File uploaded  ");
            }
        }
    }
}
