using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Tutorials
{
    class Google
    {
        private static VineInfo[] ReadFile(string path)
        {
            int vineCount = 0;
            VineInfo[] vineArray;
            int counter = 0;
            using (StreamReader r = new StreamReader(path))
            {
                vineCount = Int32.Parse(r.ReadLine());
                vineArray = new VineInfo[vineCount];
                VineInfo v = new VineInfo();

                bool initial = true;
                while (r.Peek() != -1)
                {
                    string line = r.ReadLine();
                    if (initial)
                    {
                        v = new VineInfo();
                        v.vines = new List<Vine>();
                        v.vineCount = Int32.Parse(line);
                        initial = false;
                    }
                    else
                    {
                        if (line.Contains(" "))
                        {
                            int d = Int32.Parse(line.Split(' ')[0]);
                            int l = Int32.Parse(line.Split(' ')[1]);
                            v.vines.Add(new Vine() { distanceFromLedge = d, lengthOfVine = l });
                        }
                        else
                        {
                            v.totalLength = Int32.Parse(line);
                            initial = true;
                            vineArray[counter] = v;
                            counter++;
                        }

                    }
                }
            }

            return vineArray;
        }

        private static void GoogleSwingWild()
        {
            VineInfo[] vineInfos = ReadFile(@"C:\users\shaw\desktop\input.txt");
            SwingWild(vineInfos[1]);
        }

        private static bool SwingWild(VineInfo v)
        {
            Console.WriteLine(v.vineCount + " " + v.vines.Count + " " + v.totalLength);
            Vine myVine = v.vines[0];
            for (int i = 1; i < v.vineCount; i++)
            {
                if (canIReachIt(myVine, v.vines[i]))
                {
                    myVine = v.vines[i];
                }

            }
            if (canIReachTheEnd(myVine, v.totalLength))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool canIReachIt(Vine a, Vine b)
        {
            int distanceBetween = b.distanceFromLedge - a.distanceFromLedge;
            if ((distanceBetween / 2.0) < a.lengthOfVine)
            {
                return true;
            }
            return false;

        }

        private static bool canIReachTheEnd(Vine a, int totalLength)
        {
            if (a.lengthOfVine / 2 > (totalLength - a.distanceFromLedge))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class VineInfo
    {
        public int vineCount;
        public int totalLength;
        public List<Vine> vines;
    }

    class Vine
    {
        public int distanceFromLedge;
        public int lengthOfVine;
    }


}
