using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

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
            Random r = new Random();
            int[][] Process = new int[st][];

            for(int i=0;i<st;i++)
            {
                Process[i] = new int[r.Next(4, 8)];
            }

            for(int i=0;i<st;i++)
            {
                for(int j=0;j<Process[i].Length;j++)
                {
                    Process[i][j] = j;
                }
            }
            int tempLength = 0;
            foreach(int[] a in Process)
            {
                displayProcess(tempLength,a.Length);
                tempLength++; 
            }
            
            int quantum = 2;
            string completed = "";
            //display(pc, ir, flag, completed);
            int[] count = new int[Process.GetLength(0)];
            for (int i = 0; i < count.Length;i++ )
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
                    completedprocess.Add(i);
                    ignore = true;
                }
                
                for(int check =0;check<completed.Length;check++)
                {
                    if(i == completed[check])
                    {
                        ignore = true;
                        break;
                    }
                }
                if (!ignore)
                {
                    Console.WriteLine();
                    Console.Write("Process ID: " + i + " \n");
                    Console.WriteLine("IR: " + count[i]);
                    Console.WriteLine("PC: " + (count[i] + 1));
                    Console.WriteLine("Program " + i + " is running \n");
                    Console.ReadLine();
                    int temp = 0;
                    do
                    {
                        if (count[i] == Process[i].Length)
                        {
                            break;
                        }
                        
                        count[i]++;
                        temp++;

                    } while (temp < quantum);

                    if (count[i] == Process[i].Length)
                    {
                        Console.WriteLine("Process " + i + " is Completed");
                    }
                }

                if (completedprocess.Count == Process.GetLength(0))
                {
                    completeflag = true;
                    break;
                }
            }

        }
        public static void display(int pc,int ir,string flag,string completed)
        {
            Console.WriteLine("\n" + "Program Counter : " + pc + "\n" + "Instruction Counter : " + ir + "\n" + "flag : " + flag + "\n" + "Completed : " + completed);
        }
        public static void displayProcess(int num,int length)
        {
            Console.WriteLine("Process "+num+"\n"+"Instructions "+length);
        }
    }
}
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pcb
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("No. of Processes limit upto 5");
            Console.WriteLine();
            Console.Write("Enter No. of Processes: ");
            String str = Console.ReadLine();
            int inp = Convert.ToInt16(str);
            Console.WriteLine();



            if (inp == 1)
            {

                Random ran = new Random();


                int rand = ran.Next(10) + 1;
                int[] Arr = new int[rand];

                for (int i = 0; i < rand; i++)
                {
                    Arr[i] = ran.Next(10);
                    Console.Write(Arr[i] + ",");

                }
                Console.WriteLine("\n");




                Console.Write("Enter Quantum Number: ");

                String quan = Console.ReadLine();
                int quan_num = Convert.ToInt16(quan);
                
                int count = 0;
                for (int len = 0; len < Arr.Length; len++)
                {
                    // process id here
                    if (count == Arr.Length)
                        break;
                    Console.WriteLine();
                    Console.Write("Process ID: A1 \n");
                    Console.Write("\n");
                    Console.WriteLine("IR: "+count );
                    Console.Write("PC: " +(count+1) );
                    Console.WriteLine("\nFlag: A1 is running ");
                    Console.WriteLine();
                    Console.WriteLine("Do You Want To Continue? (Y/N)");
                    string check = Console.ReadLine();
                    if (check != "y" && check !="Y")
                    { break; }
                    Console.WriteLine();
                    Console.Write("PSW: ");
                    int ir = 0;
                    
                    do
                    {
                        if (count == Arr.Length)
                            break;
                        
                        Console.Write(Arr[count] + ",");
                        count++;
                        ir++;
                        
                    } while (ir < quan_num);
                    Console.WriteLine();
                }
                dispatcher();
            }
            else if (inp == 2)
            {
                Random ran = new Random();


                int rand1 = ran.Next(10) + 1;
                int[] Arr1 = new int[rand1];

                for (int i = 0; i < rand1; i++)
                {
                    Arr1[i] = ran.Next(10);
                    Console.Write(Arr1[i] + ",");

                }
                Console.WriteLine("\n");




                int rand2 = ran.Next(10) + 1;
                int[] Arr2 = new int[rand2];

                for (int i = 0; i < rand2; i++)
                {
                    Arr2[i] = ran.Next(10);
                    Console.Write(Arr2[i] + ",");

                }
                Console.WriteLine("\n");

                Console.Write("Enter Quantum Number: ");

                String quan = Console.ReadLine();
                int quan_num = Convert.ToInt16(quan);
                Console.WriteLine();

                int count = 0;
                int count1 = 0;
                

                do
                {
                    if (count == Arr1.Length)
                    { Console.WriteLine("A1 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A1 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count);
                        Console.Write("PC: Process A2 (" + (count1)+")");
                        Console.WriteLine("\nFlag: A1 is running,A2 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count == Arr1.Length)
                                break;

                            Console.Write(Arr1[count] + ",");
                            count++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }
                    Console.WriteLine();
                    
                    // process id here
                    if (count1 == Arr2.Length)
                    { Console.WriteLine("A2 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A2 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count1);
                        Console.Write("PC: Process A1 (" + (count)+")");
                        Console.WriteLine("\nFlag: A1 is Completed, A2 is Runnnig ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir1 = 0;

                        do
                        {
                            if (count1 == Arr2.Length)
                                break;

                            Console.Write(Arr2[count1] + ",");
                            count1++;
                            ir1++;

                        } while (ir1 < quan_num);
                        dispatcher();
                    }
                    
                    Console.WriteLine("\n");
                }while(Arr1.Length != count || Arr2.Length != count1);
            }
            else if (inp == 3)
            {
                Random ran = new Random();


                int rand1 = ran.Next(10) + 1;
                int[] Arr1 = new int[rand1];
                for (int i = 0; i < rand1; i++)
                {
                    Arr1[i] = ran.Next(10);
                    Console.Write(Arr1[i] + ",");

                }
                Console.WriteLine("\n");


                int rand2 = ran.Next(10) + 1;
                int[] Arr2 = new int[rand2];
                for (int i = 0; i < rand2; i++)
                {
                    Arr2[i] = ran.Next(10);
                    Console.Write(Arr2[i] + ",");

                }
                Console.WriteLine("\n");


                int rand3 = ran.Next(10) + 1;
                int[] Arr3 = new int[rand3];
                for (int i = 0; i < rand3; i++)
                {
                    Arr3[i] = ran.Next(10);
                    Console.Write(Arr3[i] + ",");

                }
                Console.WriteLine("\n");


                Console.Write("Enter Quantum Number: ");

                String quan = Console.ReadLine();
                int quan_num = Convert.ToInt16(quan);
                Console.WriteLine();
                int count = 0;
                int count1 = 0;
                int count2 = 0;
                do
                {
                // process id here
                    if (count == Arr1.Length)
                    { Console.WriteLine("A1 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A1 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count);
                        Console.Write("PC: Process A2 (" + (count1)+")");
                        Console.WriteLine("\nFlag: A1 is running,A2 and A3 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count == Arr1.Length)
                                break;

                            Console.Write(Arr1[count] + ",");
                            count++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }

                Console.WriteLine("\n");

                // process id here
                if (count1 == Arr2.Length)
                { Console.WriteLine("A2 is completed"); }
                else
                {
                    // process id here
                    Console.WriteLine();
                    Console.Write("Process ID: A2 \n");
                    Console.Write("\n");
                    Console.WriteLine("IR: " + count1);
                    Console.Write("PC: Process A3 (" + (count2)+")");
                    Console.WriteLine("\nFlag: A1 is Completed, A2 is Runnnig and A3 is waiting ");
                    Console.WriteLine();
                    Console.WriteLine("Do You Want To Continue? (Y/N)");
                    string check = Console.ReadLine();
                    if (check != "y" && check != "Y")
                    { break; }
                    Console.WriteLine();
                    Console.Write("PSW: ");
                    int ir1 = 0;

                    do
                    {
                        if (count1 == Arr2.Length)
                            break;

                        Console.Write(Arr2[count1] + ",");
                        count1++;
                        ir1++;

                    } while (ir1 < quan_num);
                    dispatcher();
                }

                Console.WriteLine("\n");

                // process id here
                if (count2 == Arr3.Length)
                { Console.WriteLine("A3 is completed"); }
                else
                {
                    // process id here
                    Console.WriteLine();
                    Console.Write("Process ID: A3 \n");
                    Console.Write("\n");
                    Console.WriteLine("IR: " + count2);
                    Console.Write("PC: Process A1 (" + (count)+")");
                    Console.WriteLine("\nFlag: A1 and A2 is Completed, A3 is Runnnig ");
                    Console.WriteLine();
                    Console.WriteLine("Do You Want To Continue? (Y/N)");
                    string check = Console.ReadLine();
                    if (check != "y" && check != "Y")
                    { break; }
                    Console.WriteLine();
                    Console.Write("PSW: ");
                    int ir2 = 0;

                    do
                    {
                        if (count2 == Arr3.Length)
                            break;

                        Console.Write(Arr3[count2] + ",");
                        count2++;
                        ir2++;

                    } while (ir2 < quan_num);
                    dispatcher();
                }
                Console.WriteLine("\n");
                } while (Arr1.Length != count || Arr2.Length != count1 || Arr3.Length != count2 );
            }
            

            else if (inp == 4)
            {
                Random ran = new Random();


                int rand1 = ran.Next(10) + 1;
                int[] Arr1 = new int[rand1];
                for (int i = 0; i < rand1; i++)
                {
                    Arr1[i] = ran.Next(10);
                    Console.Write(Arr1[i] + ",");

                }
                Console.WriteLine("\n");


                int rand2 = ran.Next(10) + 1;
                int[] Arr2 = new int[rand2];
                for (int i = 0; i < rand2; i++)
                {
                    Arr2[i] = ran.Next(10);
                    Console.Write(Arr2[i] + ",");

                }
                Console.WriteLine("\n");


                int rand3 = ran.Next(10) + 1;
                int[] Arr3 = new int[rand3];
                for (int i = 0; i < rand3; i++)
                {
                    Arr3[i] = ran.Next(10);
                    Console.Write(Arr3[i] + ",");

                }
                Console.WriteLine("\n");

                int rand4 = ran.Next(10) + 1;
                int[] Arr4 = new int[rand4];
                for (int i = 0; i < rand4; i++)
                {
                    Arr4[i] = ran.Next(10);
                    Console.Write(Arr4[i] + ",");

                }
                Console.WriteLine("\n");


                Console.Write("Enter Quantum Number: ");

                String quan = Console.ReadLine();
                int quan_num = Convert.ToInt16(quan);
                Console.WriteLine();
                int count = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                do
                {
                    // process id here
                    if (count == Arr1.Length)
                    { Console.WriteLine("A1 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A1 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count);
                        Console.Write("PC: Process A2 (" + (count1)+")");
                        Console.WriteLine("\nFlag: A1 is running,A2, A3 and A4 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count == Arr1.Length)
                                break;

                            Console.Write(Arr1[count] + ",");
                            count++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");

                    // process id here
                    if (count1 == Arr2.Length)
                    { Console.WriteLine("A2 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A2 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count1);
                        Console.Write("PC: Process A3 (" + (count2)+")");
                        Console.WriteLine("\nFlag: A1 is Completed, A2 is Runnnig, A3 and A4 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir1 = 0;

                        do
                        {
                            if (count1 == Arr2.Length)
                                break;

                            Console.Write(Arr2[count1] + ",");
                            count1++;
                            ir1++;

                        } while (ir1 < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");

                    // process id here
                    if (count2 == Arr3.Length)
                    { Console.WriteLine("A3 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A3 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count2);
                        Console.Write("PC: Process A4 (" + (count3)+")");
                        Console.WriteLine("\nFlag: A1 and A2 is Completed, A3 is Runnnig and A4 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir2 = 0;

                        do
                        {
                            if (count2 == Arr3.Length)
                                break;

                            Console.Write(Arr3[count2] + ",");
                            count2++;
                            ir2++;

                        } while (ir2 < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");
                    // process id here
                    if (count3 == Arr4.Length)
                    { Console.WriteLine("A4 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A4 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count3);
                        Console.Write("PC: Process A1 (" + (count)+")");
                        Console.WriteLine("\nFlag: A1,A2 and A3 is completed, A4 is running ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count3 == Arr4.Length)
                                break;

                            Console.Write(Arr4[count3] + ",");
                            count3++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }



                    Console.WriteLine("\n");
                } while (Arr1.Length != count || Arr2.Length != count1 || Arr3.Length != count2 || Arr4.Length != count3);
            }

            //hello

            else if (inp == 5)
            {
                Random ran = new Random();


                int rand1 = ran.Next(10) + 1;
                int[] Arr1 = new int[rand1];
                for (int i = 0; i < rand1; i++)
                {
                    Arr1[i] = ran.Next(10);
                    Console.Write(Arr1[i] + ",");

                }
                Console.WriteLine("\n");


                int rand2 = ran.Next(10) + 1;
                int[] Arr2 = new int[rand2];
                for (int i = 0; i < rand2; i++)
                {
                    Arr2[i] = ran.Next(10);
                    Console.Write(Arr2[i] + ",");

                }
                Console.WriteLine("\n");


                int rand3 = ran.Next(10) + 1;
                int[] Arr3 = new int[rand3];
                for (int i = 0; i < rand3; i++)
                {
                    Arr3[i] = ran.Next(10);
                    Console.Write(Arr3[i] + ",");

                }
                Console.WriteLine("\n");

                int rand4 = ran.Next(10) + 1;
                int[] Arr4 = new int[rand4];
                for (int i = 0; i < rand4; i++)
                {
                    Arr4[i] = ran.Next(10);
                    Console.Write(Arr4[i] + ",");

                }
                Console.WriteLine("\n");

                int rand5 = ran.Next(10) + 1;
                int[] Arr5 = new int[rand4];
                for (int i = 0; i < rand4; i++)
                {
                    Arr5[i] = ran.Next(10);
                    Console.Write(Arr5[i] + ",");

                }
                Console.WriteLine("\n");

                Console.Write("Enter Quantum Number: ");

                String quan = Console.ReadLine();
                int quan_num = Convert.ToInt16(quan);
                Console.WriteLine();
                int count = 0;
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                do
                {
                    // process id here
                    if (count == Arr1.Length)
                    { Console.WriteLine("A1 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A1 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count);
                        Console.Write("PC: Process A2 (" + (count1)+")");
                        Console.WriteLine("\nFlag: A1 is running,A2, A3 , A4 and A5 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count == Arr1.Length)
                                break;

                            Console.Write(Arr1[count] + ",");
                            count++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");

                    // process id here
                    if (count1 == Arr2.Length)
                    { Console.WriteLine("A2 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A2 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count1);
                        Console.Write("PC: Process A3 (" + (count2)+")");
                        Console.WriteLine("\nFlag: A1 is Completed, A2 is Runnnig, A3 ,A4 and A5 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir1 = 0;

                        do
                        {
                            if (count1 == Arr2.Length)
                                break;

                            Console.Write(Arr2[count1] + ",");
                            count1++;
                            ir1++;

                        } while (ir1 < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");

                    // process id here
                    if (count2 == Arr3.Length)
                    { Console.WriteLine("A3 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A3 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count2);
                        Console.Write("PC: Process A4 (" + (count3)+")");
                        Console.WriteLine("\nFlag: A1 and A2 is Completed, A3 is Runnnig ,A5 and A4 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir2 = 0;

                        do
                        {
                            if (count2 == Arr3.Length)
                                break;

                            Console.Write(Arr3[count2] + ",");
                            count2++;
                            ir2++;

                        } while (ir2 < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");
                    // process id here
                    if (count3 == Arr4.Length)
                    { Console.WriteLine("A4 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A4 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count3);
                        Console.Write("PC: Process A5 (" + (count4)+")");
                        Console.WriteLine("\nFlag: A1,A2 and A3 is completed, A4 is running and A5 is waiting ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count3 == Arr4.Length)
                                break;

                            Console.Write(Arr4[count3] + ",");
                            count3++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }

                    // process id here
                    if (count4 == Arr5.Length)
                    { Console.WriteLine("A5 is completed"); }
                    else
                    {
                        // process id here
                        Console.WriteLine();
                        Console.Write("Process ID: A5 \n");
                        Console.Write("\n");
                        Console.WriteLine("IR: " + count4);
                        Console.Write("PC: Process A1 (" + (count)+")");
                        Console.WriteLine("\nFlag: A1 ,A2, A3 and A4 is completed, A5 is running ");
                        Console.WriteLine();
                        Console.WriteLine("Do You Want To Continue? (Y/N)");
                        string check = Console.ReadLine();
                        if (check != "y" && check != "Y")
                        { break; }
                        Console.WriteLine();
                        Console.Write("PSW: ");
                        int ir = 0;

                        do
                        {
                            if (count4 == Arr5.Length)
                                break;

                            Console.Write(Arr5[count4] + ",");
                            count4++;
                            ir++;

                        } while (ir < quan_num);
                        dispatcher();
                    }

                    Console.WriteLine("\n");
                } while (Arr1.Length != count || Arr2.Length != count1 || Arr3.Length != count2 || Arr4.Length != count3 || Arr5.Length != count4);
            }

            Console.ReadLine();

                   
        }
       public static void dispatcher()
       {
           Random ran = new Random();


           int rand = ran.Next(10) + 1;
           int[] dispatch = new int[rand];
           Console.WriteLine();
           Console.Write("Dispatcher: ");
           for (int i = 0; i < rand; i++)
           {
               dispatch[i] = ran.Next(10);
               Console.Write(dispatch[i] + ",");

           }
       }
    }
}

*/
