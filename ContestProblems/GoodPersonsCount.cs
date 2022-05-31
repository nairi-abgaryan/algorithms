using System;
using System.Linq;

namespace ContestProblems
{
    //Input: statements = [[2,1,2],[1,2,2],[2,0,2]]
    /*
     *  taking 2 person as a key
     * 2 = good
     * 1 = bad
     * if 1 is bad they can tell lie or truth
     *   if saying truth it means
     *      person 0 also good person but saying that 1 is good it means assumptions is invalid
     *
     *   if 1 person lying
     *       it means person person one is bad person
     *
     * Assuming that person 2 is is a bad person and told the truth
     *
     *
     * assuming that person two is a bad person
     * 1 - is bad person and lying it means
     *    0 - is a bad person
     *    1 - is a bad person
     *    2 -is a good one
     *
     *
     * assuming that person two is a bad person and telling the truth
     * 0 - bad
     * 1 - bad
     * 2 - bad
     *
     * assuming that person two is a bad person and lying
     * 1 - is a good person and 0 is a good one
     *
     * so after this assumptions the result of the maximum good persons will be 2
     *
     */
    public class Person
    {
        public int MaximumGood(int[][] statements)
        {
            // assuming that key person is 0
            // we need to take statements about one and two
            // if 0 is good person
            //    1 is a good one
            //        2 is a bad one
            // if 0 is a bad one and telling the truths
            //     1 - good
            //     2 - bad
            // if 0 is bad one and lying
            //     1 - bad
            //     2 - bad

            const int keyPerson = 0; // good one
            for (var i = 0; i < statements[i].Length; i++)
            {
                int counter = 0;
                for (var j = 0; j < statements.Length; j++)
                {
                    if (statements[i][j] == 1 && i == keyPerson)
                    {
                        counter++;
                    }

                    if (statements[i][j] == 1 && statements[keyPerson][i] == 1)
                    {
                        counter++;
                    }
                }
            }

            return 0;
        }

    }
}
