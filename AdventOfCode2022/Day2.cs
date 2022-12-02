using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day2
    {
        public const int Rock = 1;
        public const int Paper = 2;
        public const int Scissors = 3;
        
        private Dictionary<string, int> ScoringMap = new Dictionary<string, int>()
        {
            ["A"] = Rock, //opp rock
            ["B"] = Paper, //opp paper
            ["C"] = Scissors, //opp scissors
            ["X"] = Rock, //you rock
            ["Y"] = Paper, //you paper
            ["Z"] = Scissors, //you scissors

        };

        private Dictionary<string, Decision> DecisionMap = new Dictionary<string, Decision>()
        {
            ["X"] = Decision.Loss, //you lose
            ["Y"] = Decision.Tie, //you draw
            ["Z"] = Decision.Win, //you win
        };

        private Dictionary<int, int> LossMap = new Dictionary<int, int>()
        {
            // given the oppenent ... these lose
            [Rock] = Scissors,
            [Paper] = Rock,
            [Scissors] = Paper
        };

        private Dictionary<int, int> WinMap = new Dictionary<int, int>()
        {
            // given the oppenent ... these win
            [Rock] = Paper,
            [Paper] = Scissors,
            [Scissors] = Rock
        };

        public enum Decision
        {
            Loss = 0,
            Tie = 3,
            Win = 6
        };

        public IList<string> Results { get; set; }
        public bool UseDecisionMap { get; }

        public Day2(IList<string> results, bool useDecisionMap = false)
        {
            Results = results;
            UseDecisionMap = useDecisionMap;
        }

        public int TallyScore()
        {
            int result = 0;

            if (UseDecisionMap)
            {
                result = Results.Select(r => DecisionMapScore(r))
                               .Sum();
            }
            else
            {
                result = Results.Select(r => FindScores(r))
                                .Aggregate(0, (acc, s) => acc + RoundScore(s));
            }
            return result;
        }

        public int DecisionMapScore(string round)
        {
            (int opp, int desc) = FindScores(round);
            int result = desc;

            int play = FindPlay(opp, (Decision)desc);
            result += play;

            return result;
        }

        public (int,int) FindScores(string result)
        {
            int left = 0;
            int right = 0;

            string[] scores = result.Split(' ');

            if (scores.Length == 2)
            {
                left = ScoringMap[scores[0]];
                right = UseDecisionMap ? (int) DecisionMap[scores[1]] : ScoringMap[scores[1]];
            }
            
            return (left, right);
        }

        

        public int RoundScore((int opp, int you) round)
        {
            int score = round.you + (int)CheckRound(round.opp, round.you);
            
            return score;
        }

        public Decision CheckRound(int left, int right)
        {
            Decision decision = Decision.Loss;
            if (left == right)
            {
                decision = Decision.Tie;
            }
            else if ((right == Rock && left == Scissors) ||
                 (right == Paper && left == Rock) ||
                 (right == Scissors && left == Paper))
            {
                decision = Decision.Win;
            }
            return decision;
        }

        public int FindPlay(int opp, Decision desc)
        {
            int correctPlay = 0;

            if (desc == Decision.Tie)
            {
                correctPlay = opp;
            }
            else if (desc == Decision.Win)
            {
                correctPlay = WinMap[opp];    
            }
            else if (desc == Decision.Loss)
            {
                correctPlay = LossMap[opp];
            }
                
            return correctPlay;
        }
    }
}
