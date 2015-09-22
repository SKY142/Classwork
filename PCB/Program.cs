using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Timers;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quantum is Set to 2");
            ArrayList Arr = new ArrayList();
            Console.Write("Enter No. of Processes: ");
            String str = Console.ReadLine();
            int st = Convert.ToInt16(str);
            int ir=0,pc=0;
            Random r = new Random();
            int[][] Process = new int[st][];

            for (int i = 0; i < st; i++)
            {
                Process[i] = new int[r.Next(4, 8)];
            }

            for (int i = 0; i < st; i++)
            {
                for (int j = 0; j < Process[i].Length; j++)
                {
                    Process[i][j] = j;
                }
            }
            int tempLength = 0;
            foreach (int[] a in Process)
            {
                displayProcess(tempLength, a.Length);
                tempLength++;
            }

            int quantum = 2;
            int[] count = new int[Process.GetLength(0)];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
            }
            ArrayList completedprocess = new ArrayList();
            bool completeflag = false;
            bool ignore = false;
            for (int i = 0; !completeflag; i++)
            {
                if (i >= Process.GetLength(0))
                    i = 0;

                if (count[i] == Process[i].Length)
                {
                    ignore = true;
                }
               //Interrupt Handle
                if(Console.KeyAvailable)
                {
                    interrupt(ir, pc,Process.GetLength(0));
                }
                if (!ignore)
                {
                    Console.WriteLine();
                    Console.Write("Process ID: " + i + " \n");
                    Console.WriteLine("Program " + i + " is running \n");
                    
                    int temp = 0;
                    do
                    {
                        ir = count[i];
                        pc = getPc(i,Process.GetLength(0));
                        Console.Write(Process[i][count[i]] + " , " + " IR : "+ir+" PC : "+pc);
                        Console.WriteLine();
                        count[i]++;
                        if (count[i] == Process[i].Length)
                        {
                            completedprocess.Add(i);
                            break;
                        }
                        temp++;

                    } while (temp < quantum);
                }
                if (count[i] == Process[i].Length)
                {
                    Console.WriteLine("Process " + i + " is Completed");
                }
                //Console.ReadLine();
                Task t = Task.Delay(1000);
                t.Wait();
                //await Task.Delay(1000); 
                if (completedprocess.Count == Process.GetLength(0))
                {
                    completeflag = true;
                }
                ignore = false;
            }

        }
        public static void interrupt(int ir,int pc,int length)
        {
            Console.WriteLine("============================");
            Console.WriteLine("Interrupt Occured ");
            if (pc - 1 < 0)
                pc = length;
            Console.WriteLine("at IR : " + ir + " PC : " + (pc-1));
            Console.ReadLine();
        }
        public static int getPc(int process,int length)
        {
            if (process + 1 >= length)
            {
                return 0;
            }
            return process+1;

        }
        public static void displayProcess(int num, int length)
        {
            Console.WriteLine("Process " + num + "\n" + "Instructions " + length);
        }
    }
}
