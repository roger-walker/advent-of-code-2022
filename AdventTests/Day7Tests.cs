using AdventOfCode2022;




namespace AdventTests
{

    /*
    $ cd /
    $ ls
    dir a
    14848514 b.txt
    8504156 c.dat
    dir d
    $ cd a
    $ ls
    dir e
    29116 f
    2557 g
    62596 h.lst
    $ cd e
    $ ls
    584 i
    $ cd ..
    $ cd ..
    $ cd d
    $ ls
    4060174 j
    8033020 d.log
    5626152 d.ext
    7214296 k
     */

    /*
                List<string> list = new List<string>()
                {
                    "$ cd /",
                    "$ ls",
                    "dir a",
                    "14848514 b.txt",
                    "8504156 c.dat",
                    "dir d",
                    "$ cd a",
                    "$ ls",
                    "dir e",
                    "29116 f",
                    "2557 g",
                    "62596 h.lst",
                    "$ cd e",
                    "$ ls",
                    "584 i",
                    "$ cd ..",
                    "$ cd ..",
                    "$ cd d",
                    "$ ls",
                    "4060174 j",
                    "8033020 d.log",
                    "5626152 d.ext",
                    "7214296 k"
                }; 
    */


    internal class Day7Tests
    {
        [Test]
        [TestCase("0 a", 0, "a")]
        [TestCase("1 a", 1, "a")]
        [TestCase("14848514 b.txt", 14848514, "b.txt")]
        [TestCase("8504156 c.dat", 8504156, "c.dat")]
        [TestCase("29116 f", 29116, "f")]
        [TestCase("2557 g", 2557, "g")]
        public void GivenFileInput_DetermineFileInfo(string file, int expSize, string expName)
        {
            Day7 day = new Day7();

            var (actName, actSize) = day.FindFileInfo(file);

            Assert.That(actSize, Is.EqualTo(expSize));
        }

        [Test]
        [TestCase("0 a", EntryTypes.File)]
        [TestCase("dir a", EntryTypes.Dir)]
        [TestCase("$ cd /", EntryTypes.ChangeDirCmd)]
        [TestCase("$ ls", EntryTypes.ListCmd)]
        public void GivenEntry_IdentifyDirectory(string entry, EntryTypes expected)
        {
            Day7 day = new Day7();

            var actual = day.FindEntryType(entry);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("$ cd /", "", "/")]
        [TestCase("$ cd a", "/", "/a")]
        [TestCase("$ cd e", "/a", "/a/e")]
        [TestCase("$ cd ..", "/a/e", "/a")]
        [TestCase("$ cd ..", "/abc/eeee", "/abc")]
        [TestCase("$ cd ..", "/abc", "/")]
        [TestCase("$ cd dfg", "/", "/dfg")]
        public void GivenCDEntryAndDir_FindNextDir(string cdEntry, string curr, string expected)
        {

            Day7 day = new Day7();
            var actual = day.FindNextDir(cdEntry, curr);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenEntries_ProcessIntoFileMap()
        {
            List<string> list = new List<string>()
            {
                "$ cd /",
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d",
                "$ cd a",
                "$ ls",
                "dir e",
                "29116 f",
                "2557 g",
                "62596 h.lst",
                "$ cd e",
                "$ ls",
                "584 i",
                "$ cd ..",
                "$ cd ..",
                "$ cd d",
                "$ ls",
                "4060174 j",
                "8033020 d.log",
                "5626152 d.ext",
                "7214296 k"
            };

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "/a", 0 },
                { "/b.txt", 14848514 },
                { "/c.dat", 8504156 },
                { "/d", 0 },
                { "/a/e", 0 },
                { "/a/f", 29116 },
                { "/a/g", 2557 },
                { "/a/h.lst", 62596 },
                { "/a/e/i", 584 },
                { "/d/j", 4060174 },
                { "/d/d.log", 8033020 },
                { "/d/d.ext", 5626152 },
                { "/d/k", 7214296 },

            };

            Day7 day = new Day7();
            var actual = day.ProcessIntoFileMap(list);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        [TestCase("dir a", "a")]
        [TestCase("dir abcd", "abcd")]
        public void GivenDirEntry_FindDirName(string dir, string expected)
        {
            Day7 day = new Day7();
            string actual = day.FindDirName(dir);

            Assert.That(expected, Is.EqualTo(actual));

        }

        [Test]
        public void GivenFileMap_ReturnDirSizeMap()
        {
            Dictionary<string, int> map = new Dictionary<string, int>()
            {
                { "/a", 0 },
                { "/b.txt", 14848514 },
                { "/c.dat", 8504156 },
                { "/d", 0 },
                { "/a/e", 0 },
                { "/a/f", 29116 },
                { "/a/g", 2557 },
                { "/a/h.lst", 62596 },
                { "/a/e/i", 584 },
                { "/d/j", 4060174 },
                { "/d/d.log", 8033020 },
                { "/d/d.ext", 5626152 },
                { "/d/k", 7214296 },

            };

            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                { "/", 48381165 },
                { "/a", 94853  },
                { "/a/e", 584  },
                { "/d", 24933642 },
            };

            Day7 day = new Day7();
            var actual = day.FindDirSizes(map);

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void GivenDirSizeMap_FindSumOfSmallDirs()
        {
            Dictionary<string, int> dirSizes = new Dictionary<string, int>()
            {
                { "/", 48381165 },
                { "/a", 94853  },
                { "/a/e", 584  },
                { "/d", 24933642 },
            };

            int expected = 95437;

            Day7 day = new Day7();
            var actual = day.FindSmallDirSum(dirSizes, limit: 100000);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void GivenList_FindSmall()
        {
            List<string> list = new List<string>()
            {
                "$ cd /",
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d",
                "$ cd a",
                "$ ls",
                "dir e",
                "29116 f",
                "2557 g",
                "62596 h.lst",
                "$ cd e",
                "$ ls",
                "584 i",
                "$ cd ..",
                "$ cd ..",
                "$ cd d",
                "$ ls",
                "4060174 j",
                "8033020 d.log",
                "5626152 d.ext",
                "7214296 k"
            };

            int expected = 95437;

            Day7 day = new Day7();
            var actual = day.SmallSum(list);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenList_FindSmallestDirToDelete()
        {
            List<string> list = new List<string>()
            {
                "$ cd /",
                "$ ls",
                "dir a",
                "14848514 b.txt",
                "8504156 c.dat",
                "dir d",
                "$ cd a",
                "$ ls",
                "dir e",
                "29116 f",
                "2557 g",
                "62596 h.lst",
                "$ cd e",
                "$ ls",
                "584 i",
                "$ cd ..",
                "$ cd ..",
                "$ cd d",
                "$ ls",
                "4060174 j",
                "8033020 d.log",
                "5626152 d.ext",
                "7214296 k"
            };
            int expected = 24933642;

            Day7 day = new Day7();
            var actual = day.FindSmallestDirToDeleteSize(list, 70000000, 30000000);

            Assert.That(actual, Is.EqualTo(expected));

        }



    }
}
