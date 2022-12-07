using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day7
    {
        public int FindFileSize(string file)
        {
            int fileSize = 0;
            var fileInfo = file.Split(' ');
            fileSize = Convert.ToInt32(fileInfo[0]);

            return fileSize;
        }
    }
}
