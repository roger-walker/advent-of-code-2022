using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public enum EntryTypes
    {
        Unknown = 0,
        ChangeDirCmd,
        ListCmd,
        Dir,
        File
    }



    public class Day7
    {
        public (string,int) FindFileInfo(string file)
        {
            int fileSize = 0;
            string filename = "";
            var fileInfo = file.Split(' ');
            fileSize = Convert.ToInt32(fileInfo[0]);
            filename = fileInfo[1];

            return (filename, fileSize);
        }

        public EntryTypes FindEntryType(string entry)
        {
            EntryTypes entryType = EntryTypes.Unknown;


            if (entry.StartsWith("$ cd"))
            {
                entryType = EntryTypes.ChangeDirCmd;
            }
            else if (entry.StartsWith("$ ls"))
            {
                entryType = EntryTypes.ListCmd;
            }
            else if (entry.StartsWith("dir"))
            {
                entryType = EntryTypes.Dir;
            }
            else{

                string filePattern = @"^\d+";
                if (Regex.Match(entry, filePattern).Success)
                {
                    entryType = EntryTypes.File;
                }
            }
            return entryType;
        }

        public string FindNextDir(string cdEntry, string curr)
        {
            string next = "";
            string dirPattern = @"\$ cd (/|[a-z]+|\.\.)";
            Match m = Regex.Match(cdEntry, dirPattern);
            if (m.Success)
            {
                string dir = m.Groups[1].Value;

                if (dir == "/")
                {
                    next = dir;
                }
                else if(dir == "..")
                {
                    int lastSlash = curr.LastIndexOf('/');
                    next = lastSlash <= 0 ? "/" : curr.Substring(0, lastSlash);
                }
                else
                {
                    next = curr == "/" ? $"/{dir}" : $"{curr}/{dir}";
                }

            }
            return next;
        }

        public string FindDirName(string dir)
        {
            
            string dirname = "";
            var dirInfo = dir.Split(' ');
            
            dirname = dirInfo[1];

            return dirname;
        }

        public Dictionary<string, int> ProcessIntoFileMap(List<string> entries)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();


            string currDir = "/";

            foreach (string entry in entries)
            {
                EntryTypes type = FindEntryType(entry);
                switch (type)
                {
                    case EntryTypes.ChangeDirCmd:
                        currDir = FindNextDir(entry, currDir);
                        break;
                    case EntryTypes.ListCmd:
                        break;
                    case EntryTypes.Dir:
                        string dirName = FindDirName(entry);
                        string dirPath = currDir == "/" ? $"/{dirName}" : $"{currDir}/{dirName}";
                        map.Add(dirPath, 0);
                        break;
                    case EntryTypes.File:
                        var (fileName, fileSize) = FindFileInfo(entry);
                        string filePath = currDir == "/" ? $"/{fileName}" : $"{currDir}/{fileName}";
                        map.Add(filePath, fileSize);
                        break;
                    default:
                        break;
                }
            }

            return map;

        }

        public Dictionary<string, int> FindDirSizes(Dictionary<string, int> map)
        {
            Dictionary<string , int> sizes = new Dictionary<string , int>();

            sizes.Add("/", map.Values.Sum(x => x));
            var dirs = map.Keys.Where(x => map[x] == 0);

            dirs.ToList().ForEach(dir => sizes.Add(dir, map.Keys.Where(file => file.StartsWith(dir))
                                                                .Sum(x => map[x]))
                                  );

            return sizes;
        }

        public int FindSmallDirSum(Dictionary<string, int> dirSizes, int limit)
        {
            return dirSizes.Values.Where(x => x <= limit).Sum();
        }

        public int SmallSum(List<string> list, int limit = 100000)
        {
            var map = ProcessIntoFileMap(list);
            var sizes = FindDirSizes(map);
            return FindSmallDirSum(sizes, limit);
        }

        public int FindSmallestDirToDeleteSize(List<string> list, int totalSpace, int minFree)
        {
            var map = ProcessIntoFileMap(list);
            var sizes = FindDirSizes(map);

            int currFree = totalSpace - sizes["/"];
            int lowest = minFree - currFree;

            var smallEnough = sizes.Values.Where(x => x >= lowest);
            return smallEnough.Min(x => x);
        }
    }
}
