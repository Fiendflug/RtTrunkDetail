using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication9
{
    static class RtReport
    {
        static int durationOutcomingCalls = 0;
        static int countOutcomingCalls = 0;

        static int durationIncomingCalls = 0;
        static int countIncomingCalls = 0;
        //

        static public void Create(string pathToCdrFile)
        {
            
            List<long> altesRes = new List<long>();
            for (long i = 4558000; i <= 4559999; i++)
            {
                altesRes.Add(i);
            }
            for (long i = 4590000; i <= 4592999; i++)
            {
                altesRes.Add(i);
            }
            
            List<long> rtRes = new List<long>();
            for (long i = 4964520000; i <= 4964557999; i++)
            {
                rtRes.Add(i);
            }
            for (long i = 4964560000; i <= 4964579999; i++)
            {
                rtRes.Add(i);
            }

            foreach (string line in File.ReadAllLines(pathToCdrFile))
            {
                string[] splitedLine = line.Split(' ');
                
                long numA;
                long numB;

                if (long.TryParse(splitedLine[1], out numA) & long.TryParse(splitedLine[3], out numB))
                {
                    //long numA = long.Parse(splitedLine[1]);
                    //long numB = (long.Parse(splitedLine[3]) > 4500000) ? long.Parse(splitedLine[3]) : long.Parse(splitedLine[3]) + 4500000;
                    if (numB < 4500000) numB += 4500000;
                    //if (splitedLine[0].Contains("C015") & int.Parse(splitedLine[6]) > 0 & splitedLine[1].Length <= 7)
                    if (rtRes.Contains(numA)) //Входящие из РТ
                    {
                        File.AppendAllText(Directory.GetCurrentDirectory() + "/Reports/incomingCallsFromRostelekom.csv", line.Replace(" ", ";") + Environment.NewLine);
                        durationIncomingCalls += int.Parse(splitedLine[6]);
                        countIncomingCalls++;
                    }
                    //if (splitedLine[2].Contains("C015") & !splitedLine[2].Contains("C0156") & int.Parse(splitedLine[6]) > 0)
                    //Исходящие из Альтеса
                    if (rtRes.Contains(numB + 4960000000))
                    {
                        File.AppendAllText(Directory.GetCurrentDirectory() + "/Reports/outcomingCallsToRostelekom.csv", line.Replace(" ", ";") + Environment.NewLine);
                        durationOutcomingCalls += int.Parse(splitedLine[6]);
                        countOutcomingCalls++;
                    }
                }                
            }                
        }

        static public void CreatePS()
        {
            File.AppendAllText(Directory.GetCurrentDirectory() + "/Reports/incomingCallsFromRostelekom.csv", "Duration (min) - " + (durationIncomingCalls / 60).ToString() + Environment.NewLine + "Calls - " + countIncomingCalls.ToString() + Environment.NewLine);
            File.AppendAllText(Directory.GetCurrentDirectory() + "/Reports/outcomingCallsToRostelekom.csv", "Duration (min) - " + (durationOutcomingCalls / 60).ToString() + Environment.NewLine + "Calls - " + countOutcomingCalls.ToString() + Environment.NewLine);            
        }
    }
}
