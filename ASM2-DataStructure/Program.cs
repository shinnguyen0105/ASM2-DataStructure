using System;
using System.Diagnostics;
namespace ASM2_DataStructure
{
    class Queue
    {
        public int max;
        public char[] Q;
        public int r;
        public int f;
        public Queue(int max, char[] Q)
        {
            r = 0;
            f = 0;
            this.max = max;
            this.Q = Q;
        }
        public int Enum()
        {
            if (r == f)
            {
                return 0;
            }
            else
                return (((max - f) + r) % max);
        }
        public bool Isempty()
        {
            if (f == r)
            {
                Console.WriteLine("Queue is empty");
                return true;
            }
            else
                return false;
        }
        public void Enqueue(char x)
        {
            Q[r] = x;
            r = (r + 1) % max;
        }
        public char Dequeue()
        {
            char De =' ';
            De = Q[f];
                f = (f + 1) % max;
                return De;
        }
    }
    class Stack
    {
        public int MAX ;
        public int top;
        public char[] stack;
        public Stack()
        {
            top = -1;
            MAX = 250;
            stack = new char[MAX];
        }
        public void Push(char data)
        {
            if (top >= MAX)
            {
                Console.WriteLine("Stack Overflow");
            }
            else
            {
                top = top + 1;
                stack[top] = data;
            }
        }

        public char Pop()
        {
            char value = ' ';
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return value;
            }
            else
            {
                value = stack[top--];
                return value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new char[250];
            var s2 = new char[250];
            Stack mystack = new Stack();
            Queue myqueue = new Queue(250, s1);
            Stopwatch st = new Stopwatch();
            Console.WriteLine("====================================");
            Console.WriteLine("Program transmits message via buffer");
            Console.WriteLine("====================================");
            Console.WriteLine("Enter your characters (max 250) : ");
            st.Start();
            string input = Console.ReadLine();
            if (input.Length > 250)
            {
                Console.WriteLine("Error! Overload array...");
            }
            else if (input.Length < 1)
            {
                Console.WriteLine("Error! Array null...");
            }
            else 
            {
                try
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        mystack.Push(input[i]);
                    }
                    for (int i = 0; i < input.Length; i++)
                    {
                        myqueue.Enqueue(mystack.Pop());
                    } 
                    for (int i = input.Length; i > 0; i--)
                    {
                        s2[i] = myqueue.Dequeue();
                    }
                    Console.WriteLine("Your input after transfer: ");
                    Console.Write(s2);
                    st.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("                               ");
                Console.WriteLine("\n{0} giay", st.Elapsed.ToString());
            }
            Console.ReadKey();
        }
    }
}
