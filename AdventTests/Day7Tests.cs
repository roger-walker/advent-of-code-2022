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




    internal class Day7Tests
    {
        [Test]
        [TestCase("0 a", 0)]
        [TestCase("1 a", 1)]
        [TestCase("14848514 b.txt", 14848514)]
        [TestCase("8504156 c.dat", 8504156)]
        [TestCase("29116 f", 29116)]
        [TestCase("2557 g", 2557)]
        public void GivenFileInput_DetermineFileSize(string file, int expected)
        {
            Day7 day = new Day7();

            var actual = day.FindFileSize(file);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
