using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanupIO.Utility;

namespace CleanupIO
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <example>
        /// CleanupIO.exe -Folder="D:\MyApp\Devxpress\Source" -Pattern="licenses.licx" -EmptyContents -SubDir -Days=-1 //Empty the contents of all licenses.licx files
        /// CleanupIO.exe -Folder="C:\MyApp\Logs" -Pattern="*.log" -Days="10" // Cleans up all log files older than 10 days
        /// </example>
        static void Main(string[] args)
        {


            int daysOld = -1;
            string folder = "";
            string pattern = "*.*";
            System.IO.SearchOption searchOption = System.IO.SearchOption.TopDirectoryOnly;
            Arguments CommandLine = new Arguments(args);

            if (CommandLine["Help"] != null)
            {
                Console.Out.WriteLine("-Help, -Folder, -Pattern, -Days", "-EmptyContents");
            }
            else
            {
                if (CommandLine["Subdir"] != null)
                {
                    // includeSubDirectories = true;
                    searchOption = System.IO.SearchOption.AllDirectories;
                }

                if (CommandLine["Folder"] != null)
                {
                    folder = CommandLine["Folder"];
                }
                else
                {
                    throw new MissingMemberException("Missing the Folder argument");
                }

                if (CommandLine["Pattern"] != null)
                {
                    pattern = CommandLine["Pattern"];
                }

                if (CommandLine["Days"] != null)
                {
                    daysOld = int.Parse(CommandLine["Days"]);
                }

                bool emptyContents = CommandLine["EmptyContents"] != null;

                var CurrentTime = System.DateTime.UtcNow;
                var pre_matched_files = new System.IO.DirectoryInfo(folder).GetFiles(pattern, searchOption);
                var matched_files = pre_matched_files.Where(el => daysOld == -1 ||  el.LastWriteTimeUtc.AddDays(daysOld) < CurrentTime).ToList();

                Console.Out.WriteLine(string.Format("Matched {0} files in folder {1}", matched_files.Count(),folder));
                foreach (var file in matched_files)
                {

                    if(emptyContents)
                    {
                        Console.Out.WriteLine(string.Format("Emptying contents {0} ...", file.Name));
                        System.IO.File.WriteAllText(file.FullName, "");
                    }
                    else
                    {
                        Console.Out.WriteLine(string.Format("Deleting {0} ...", file.Name));
                        file.Delete();
                    }
                   
                }

                Console.Out.WriteLine(string.Format("Modified {0} files ", matched_files.Count()));
            }

        }
    }
}
