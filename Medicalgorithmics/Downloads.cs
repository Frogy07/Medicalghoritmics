using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medicalgorithmics
{
    class Downloads
    {
        private readonly String directoryPath;
        public Downloads(String path)
        {
            this.directoryPath = path;
        }
        public void FindZip(String name)
        {
            bool isFound = false;
            int timeout = 0;

            String[] files;
            while (!isFound && timeout < 10)
            {
                files = Directory.GetFiles(directoryPath);
                foreach (var x in files)
                {
                    if (x.EndsWith(name))
                    {
                        isFound = true;
                        break;
                    }
                }
                Thread.Sleep(1000);
                timeout++;
            }
            Assert.IsTrue(isFound, "ZIP file has not been found");
        }

        public void ExtractAndFindFile(String zipName, String fileName)
        {
            String expectedPath = directoryPath + zipName;
            String extract_directory = directoryPath + "MyLogos";
            Directory.CreateDirectory(extract_directory);
            
            ZipFile.ExtractToDirectory(expectedPath, extract_directory);
            String[] files = Directory.GetFiles(extract_directory);
            bool isFound = false;
            foreach (var x in files)
            {
                if (x.EndsWith(fileName))
                {
                    isFound = true;
                    break;
                }
            }
            Assert.IsTrue(isFound, "PDF file has not been found");
            Directory.Delete(extract_directory, true);
            File.Delete(directoryPath + zipName);
        }
    }
}
