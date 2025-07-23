using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string fileName=SourceFile;
            FileInfo fileInfo = new FileInfo(fileName);
            string extention=fileInfo.Extension;

            return GenerateGUID()+extention;
        }
        public static bool CreateFolderIfDoesNotExists(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (IOException iox)
                {
                    MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        public static bool CopyImageToProjectImagesFolder( ref string SourceFile)
        {
            string destinationFolder = @"D:\C# Projects\DVLD\DVLD-People-Image\";
            if (!CreateFolderIfDoesNotExists(destinationFolder))
            {
                return false;
            }
            string destinationFile=destinationFolder+ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, destinationFile,true);
            }
            catch (IOException iox)
            {

                MessageBox.Show(iox.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            SourceFile = destinationFile;

            return true;
        }
    }
}
