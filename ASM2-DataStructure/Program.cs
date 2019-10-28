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
            if (Enum() == 50)
            {
                Console.WriteLine("Queue is full");
            }
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
            MAX = 50;
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
    class Send
    {
        string s2;
        public void SendMess(string input)
        {
            var queue = new char[50];
            string subInput = "";
            Stack mystack = new Stack(); 
            Queue myqueue = new Queue(50, queue); 
            Console.WriteLine("\nNumber elements of string: {0}", input.Length);
            int n = 0;
            try
            {
                while (n < input.Length && n <= 250)
                {
                    while (mystack.top < 50)
                    {
                        mystack.Push(input[n]);
                        n++;
                    }
                    while (mystack.top != 0)
                    {
                        myqueue.Enqueue(mystack.Pop());
                    }
                    while (myqueue.Enum() != 0)
                    {
                        s2 = myqueue.Dequeue() + s2;
                        
                    }
                    s2 = subInput + s2;
                    subInput = "";
                }
            }
            catch (Exception)
            {
                subInput = "";
                while (mystack.top != 0)
                {
                    myqueue.Enqueue(mystack.Pop());
                }
                while (myqueue.Enum() != 0)
                {
                    subInput = myqueue.Dequeue() + subInput;
                }
                s2 = s2 + subInput;
            }
            Console.WriteLine("Your input after transfer: ");
            Console.Write(s2);
            }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Send mysend = new Send();
            Stopwatch st = new Stopwatch();
            Console.WriteLine("====================================");
            Console.WriteLine("Program transmits message via buffer");
            Console.WriteLine("====================================");
            Console.WriteLine("Enter your characters (max 250) : ");
            st.Start();
            string input = Console.ReadLine();
            if (input.Length >= 250)
            {
                mysend.SendMess(input);
                Console.WriteLine("\nWe just send message with 250 characters.");
            }
            else if (input.Length < 1)
            {
                Console.WriteLine("Error! Array null...");
            }
            else
            {
                mysend.SendMess(input);
            }
            st.Stop();
            Console.WriteLine("                               ");
            Console.WriteLine("\n{0} giay", st.ElapsedMilliseconds.ToString());
            Console.ReadKey();
        }
    }
}
