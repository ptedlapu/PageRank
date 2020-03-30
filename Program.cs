using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            string order,dampf,decision="no",dinput;
            int ord, i, j,outlink=0;
            float ordf,df; 
            Console.WriteLine("PageRank Algorithm");
            Console.WriteLine("Enter the number of pages");
            order = Console.ReadLine();
            ord = int.Parse(order);
            ordf = float.Parse(order);
            int[,] adj = new int[ord, ord];
            while (decision == "no")
            {
                Console.Write("Enter the entries of the adjacency matrix");
                Console.Write("\n");
                for (i = 0; i < ord; i++)
                {
                    for (j = 0; j < ord; j++)
                    {
                        adj[i, j] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("\n");
                }
                Console.Write("Please review the adjacency matrix");
                Console.Write("\n");
                for (i = 0; i < ord; i++)
                {
                    for (j = 0; j < ord; j++)
                    {
                        Console.Write(adj[i, j]);
                        Console.Write(" ");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
                Console.Write("Is the adjancey matrix correct? yes or no ?");
                dinput = Console.ReadLine();
                if (dinput == "yes")
                    decision = "yes";
                if (dinput == "no")
                    decision = "no";
            }
            Console.Write("\n");
            Console.Write("Enter the damping factor");
            Console.Write("\n");
            Console.Write("Note:Must be in the range 0 to 1,suggested value:0.85");
            Console.Write("\n");
            dampf = Console.ReadLine();
            df = float.Parse(dampf);
            Console.Write("\n");
            float[] tempr = new float[ord];
            float[] irank = new float[ord];
            Console.Write("The initial rank of each page is");
            Console.Write("\n");
            for (i = 0; i < ord; i++)
            {
                irank[i] = 1 / ordf;
                //tempr[i] = irank[i];
                //irank[i] = 1;
                Console.Write("Page {0} = ", i+1);
                Console.Write(irank[i]);
                Console.Write("\n");
            }
            int[] outlinka = new int[ord];
            for(i = 0;i < ord; i++)
            {
            for(j = 0;j < ord; j++)
                {
                    if (adj[i, j] == 1 )
                        outlink = outlink + 1;
                }
                outlinka[i] = outlink;
                outlink = 0;
            }
            Console.Write("Count of outgoing links");
            for (i =0;i < ord; i++)
            {
                Console.Write("\n");
                Console.Write("Page {0} = {1}", i + 1, outlinka[i]);
            }
            Console.ReadLine();
            float[] rank = new float[ord];
            float firstpt, secondpt;
            float intermediate;
            int iteration = 1;
            while (iteration<=16)
            {
                Console.Write("\n");
                Console.WriteLine("PageRank of each page at iteration {0}", iteration);
                for (j = 0; j < ord; j++)
                {
                    for (i = 0; i < ord; i++)
                    {
                        if (adj[i, j] == 1)
                        {
                            intermediate = irank[i] / outlinka[i];
                            rank[j] = rank[j] + intermediate;
                        }

                    }
                    firstpt = 1 - df;
                    secondpt = df * (rank[j]);
                    rank[j] = firstpt + secondpt;
                    irank[j] = rank[j];
                    Console.WriteLine();
                    Console.WriteLine("PageRank of Page {0} = {1}", j + 1, irank[j]);
                }
                iteration = iteration + 1;
                Array.Clear(rank, 0, rank.Length);
            }
            Console.ReadKey();
        }
    }
}
