namespace AdventOfCode2022
{
    public class Day8
    {
        public Day8(List<string> trees)
        {
            trees.ForEach(treeRow =>
            {
                List<int> row = new List<int>();

                foreach (var t in treeRow)
                {
                    row.Add(Convert.ToInt32(t.ToString()));
                }

                TreeMap.Add(row);
            });
        }

        public List<List<int>> TreeMap { get; } = new List<List<int>>();
        public int MapHeight { get => TreeMap.Count; }
        public int MapWidth { get => TreeMap.Count > 0 ? TreeMap[0].Count : 0; }

        public bool IsEdgeTree(int row, int col)
        {
            return (row == 0 || row == MapHeight - 1) || (col == 0 || col == MapWidth - 1);
        }

        public bool IsTreeVisibleTop(int row, int col)
        {
            bool visible = true;
            if (!IsEdgeTree(row, col))
            {
                int treeHeight = TreeMap[row][col];
                int curr = row - 1;
                while (curr >= 0)
                {
                    if (treeHeight <= TreeMap[curr][col])
                    {
                        visible = false;
                    }
                    curr--;
                }

            }
            return visible;
        }

        public bool IsTreeVisibleBottom(int row, int col)
        {
            bool visible = true;
            if (!IsEdgeTree(row, col))
            {
                int treeHeight = TreeMap[row][col];
                int curr = row + 1;
                while (curr <= MapHeight - 1)
                {
                    if (treeHeight <= TreeMap[curr][col])
                    {
                        visible = false;
                    }
                    curr++;
                }

            }
            return visible;
        }

        public bool IsTreeVisibleLeft(int row, int col)
        {
            bool visible = true;
            if (!IsEdgeTree(row, col))
            {
                int treeHeight = TreeMap[row][col];
                int curr = col - 1;
                while (curr >= 0)
                {
                    if (treeHeight <= TreeMap[row][curr])
                    {
                        visible = false;
                    }
                    curr--;
                }

            }
            return visible;
        }

        public bool IsTreeVisibleRight(int row, int col)
        {
            bool visible = true;
            if (!IsEdgeTree(row, col))
            {
                int treeHeight = TreeMap[row][col];
                int curr = col + 1;
                while (curr <= MapWidth - 1)
                {
                    if (treeHeight <= TreeMap[row][curr])
                    {
                        visible = false;
                    }
                    curr++;
                }

            }
            return visible;
        }

        public int GetVisibleTreeCount()
        {
            int count = 0;
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    bool isVisible = IsEdgeTree(j, i)
                                || IsTreeVisibleTop(j, i)
                                || IsTreeVisibleRight(j, i)
                                || IsTreeVisibleBottom(j, i)
                                || IsTreeVisibleLeft(j, i);

                    count = isVisible ? count + 1 : count;
                }
            }

            return count;
        }

        public int GetScenicScoreTop(int row, int col)
        {
            if (row <= 0) return 0;

            int treeHeight = TreeMap[row][col];
            int count = 0;
            int curr = row - 1;

            while (curr >= 0)
            {
                count++;
                if (treeHeight <= TreeMap[curr][col])
                {
                    break;
                }
                curr--;
            }
            return count;

        }

        public int GetScenicScoreBottom(int row, int col)
        {
            if (row >= MapHeight - 1) return 0;

            int treeHeight = TreeMap[row][col];
            int count = 0;
            int curr = row + 1;

            while (curr <= MapHeight - 1)
            {
                count++;
                if (treeHeight <= TreeMap[curr][col])
                {
                    break;
                }
                curr++;
            }
            return count;

        }

        public int GetScenicScoreRight(int row, int col)
        {
            if (col >= MapWidth - 1) return 0;

            int treeHeight = TreeMap[row][col];
            int count = 0;
            int curr = col + 1;

            while (curr <= MapWidth - 1)
            {
                count++;
                if (treeHeight <= TreeMap[row][curr])
                {
                    break;
                }
                curr++;
            }
            return count;
        }

        public int GetScenicScoreLeft(int row, int col)
        {
            if (col <= 0) return 0;

            int treeHeight = TreeMap[row][col];
            int count = 0;
            int curr = col - 1;

            while (curr >= 0)
            {
                count++;
                if (treeHeight <= TreeMap[row][curr])
                {
                    break;
                }
                curr--;
            }
            return count;
        }

        public List<List<int>> FindScenicScores()
        {
            List<List<int>> scores = new List<List<int>>();

            for (int j = 0; j < MapHeight; j++)
            {
                List<int> row = new List<int>();
                for (int i = 0; i < MapWidth; i++)
                {
                    int left = GetScenicScoreLeft(j, i);
                    int right = GetScenicScoreRight(j, i);
                    int top = GetScenicScoreTop(j, i);
                    int bottom = GetScenicScoreBottom(j, i);

                    int score = left * right * top * bottom;
                    row.Add(score);
                }
                scores.Add(row);
            }
            return scores;
        }

        public int FindMaxScenicScore()
        {
            List<List<int>> scores = FindScenicScores();

            int max = 0;
            foreach (List<int> row in scores)
            {
                foreach (int score in row)
                {
                    max = Math.Max(max, score);
                }
            }
            return max;
        }
    }
}
