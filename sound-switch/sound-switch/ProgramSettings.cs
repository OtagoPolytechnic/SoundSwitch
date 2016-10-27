using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sound_switch
{
    public static class ProgramSettings
    {
        //Name for the currently unbound or unmatched file, default: 'unprocessed_.wav'
        public const string UnprocessedFileName = "unprocessed_.wav";

        //Name of the exe that controls the matching of sound files. default: 'overlap-analysis.exe'
        public const string MatcherExecutable = "overlap-analysis.exe";

        //Name of the txt file that holds the intermediary results of the sound matcher exe. default: 'match-result.txt'
        public const string MatcherResult = "match-result.txt";

        //Value that holds the sampling length and recording length.
        public const int sampleLength = 1;
    }
}
