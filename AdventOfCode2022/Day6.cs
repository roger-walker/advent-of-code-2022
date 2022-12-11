namespace AdventOfCode2022
{
    public class Day6
    {
        public const int StartOfPacketLength = 4;

        public const int StartOfMessageLength = 14;

        public Day6(bool isMessageCheck = false)
        {
            IsMessageCheck = isMessageCheck;
        }

        public bool IsMessageCheck { get; private set; }

        public int FindStartIndex(string message)
        {
            int length = GetLength();

            string poss = "";
            int i = 1;
            foreach (var ch in message)
            {
                poss += ch;
                if (poss.Length > length)
                {
                    poss = poss.Substring(1, length);
                }
                if (IsStart(poss)) return i;

                i++;
            }
            return -1;
        }

        public bool IsStart(string message)
        {
            int length = GetLength();

            if (message.Length < length) return false;

            return message.Aggregate("", (acc, c) => acc.IndexOf(c) != -1 ? acc : acc + c).Length == length;

        }

        private int GetLength()
        {
            return IsMessageCheck ? StartOfMessageLength : StartOfPacketLength;
        }
    }
}
