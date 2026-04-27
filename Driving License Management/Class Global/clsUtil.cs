using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management
{
    internal class clsUtil
    {
        public static bool CreateFolderIfDoesNotExist(string Path)
        {
            if (File.Exists(Path))
            {
                File.Create(Path);
            }
                return true;
        }

        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }
        public static string ReplaceFileNameWithGUID(string SourseImage )
        {
            string FileName = SourseImage;
            FileInfo fi=new FileInfo(FileName);

            string extn=fi.Extension;
            return GenerateGUID()+extn ;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourseImage)
        {
            string DestinationFolder = @"D:\course 19\DVLD Image\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string DestinationFile= DestinationFolder+ ReplaceFileNameWithGUID(SourseImage);

            try
            {
                File.Copy(SourseImage, DestinationFile,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erorr Image", MessageBoxButtons.OK);
                return false;
            }
            SourseImage = DestinationFile;
            return true;

        }
    }
}
