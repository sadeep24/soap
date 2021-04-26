using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sampath.SMSB.Utility
{
    public class FileManager
    {

        public void WriteLog(string message, string fileName)
        {


            var directoryPath = AppContext.BaseDirectory+ "logs";
            String logfilePath = directoryPath + "\\" + fileName;


            try
            {
                // Determine whether the directory exists.
                 if (Directory.Exists(directoryPath))
                {
                    
                    if (!File.Exists(logfilePath))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            sw.WriteLine(message);

                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(logfilePath))
                        {
                            sw.WriteLine(message);

                        }
                    }
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                    if(!File.Exists(logfilePath))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(logfilePath))
                        {
                            sw.WriteLine(message);

                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(logfilePath))
                        {
                            sw.WriteLine(message);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                    Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
