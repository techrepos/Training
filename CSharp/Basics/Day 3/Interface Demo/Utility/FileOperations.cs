using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Basics.Utility
{
    class FileOperations 
    {
        protected string FileName;
        public string CreateFile()
        {
            
            FileStream file = null;
            try
            {
                FileInfo fileInfo = new FileInfo($"./{FileName}.txt");

                file = fileInfo.OpenWrite();
                file.WriteByte(0xF);
                return Path.Combine(fileInfo.FullName, fileInfo.Name);
            }
            finally
            {
                file?.Close();
            }
        }

        
    }



}