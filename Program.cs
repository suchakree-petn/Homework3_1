class Program
{
    private static CircularLinkedList<char> pool = new CircularLinkedList<char>();
    private static CircularLinkedList<char> wheel = new CircularLinkedList<char>();

    static void Main(string[] args)
    {
        pool.Add('J');
        pool.Add('G');
        pool.Add('O');
        pool.Add('R');
        char currentInput = char.Parse(Console.ReadLine());
        while (checkInput(currentInput))
        {
            wheel.Add(currentInput);
            if (currentInput == 'G')
            {
                checkConditionG(wheel.GetLength() - 1);
            }
            checkConditionR();
            currentInput = char.Parse(Console.ReadLine());
        }
        printEveryNode();
    }
    static bool checkInput(char currentInput)
    {
        for (int i = 0; i < 4; i++)
        {
            if (currentInput == pool.Get(i))
            {
                return true;
            }
        }
        return false;
    }
    static void checkConditionG(int index)
    {
        if (wheel.GetLength() > 3)
        {
            int I = index - 1;
            List<int> tmpList = new List<int>();
            for (int j = 0; j < wheel.GetLength(); j++)
            {
                tmpList.Add(j);
            }
            int count = 1;
            for (int i = I; i >= 0; i--)
            {
                if (wheel.Get(i) == 'G')
                {
                    tmpList.Remove(i);
                    count++;
                    if (count > 3)
                    {
                        Console.WriteLine("Invalid pattern.");
                        Program.wheel.Remove(index);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (wheel.Get(i) == 'G')
                {
                    try
                    {
                        tmpList.Remove(i);
                    }
                    catch
                    {
                        return;
                    }
                    count++;
                    if (count > 3)
                    {
                        Console.WriteLine("Invalid pattern.");
                        Program.wheel.Remove(index);
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
    static void checkConditionR()
    {
        for (int i = 0; i < wheel.GetLength(); i++)
        {
            if (wheel.Get(i) == 'R')
            {
                if (wheel.GetLength() >= 3)
                {
                    if (wheel.Get(i + 1) == wheel.Get(i - 1))
                    {
                        if (i == wheel.GetLength() - 1)
                        {
                            Console.WriteLine("Invalid pattern.");
                            wheel.Remove(i);
                        }
                        else
                        {
                            Console.WriteLine("Invalid pattern.");
                            wheel.Remove(i + 1);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid pattern.");
                    wheel.Remove(i);
                }
            }
        }
    }
    static void printEveryNode()
    {
        for (int i = 0; i < wheel.GetLength(); i++)
        {
            Console.Write(wheel.Get(i));
        }
    }
}