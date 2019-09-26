using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PeppyWeb.Helpers
{
    public class Filehelpers
    {
        public static bool UploadPhoto(MemoryStream memorystream, string FolderName, string FileName)
        {
            try
            {
                memorystream.Position = 0;
                //gets the complete path of the file i.e [c:/FolderName/FileName.....]
                var path = Path.Combine(HttpContext.Current.Server.MapPath(FolderName), FileName); 
                File.WriteAllBytes(path, memorystream.ToArray());

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            return true;
        }
    }
}