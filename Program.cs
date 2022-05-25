public class Program
{
    public static void Main()
    {
        //Shunting - yard algorithm
        string input = Console.ReadLine();
        Queue<char> queue = new Queue<char>();
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                queue.Enqueue(input[i]);
            }
            else if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '^')
            {
                stack.Push(input[i]);
            }
            else if (input[i] == '/')
            {
                queue.Enqueue(stack.Pop());
                stack.Push(input[i]);
            }
            else if (input[i] == '(')
            {
                stack.Push(input[i]);
            }
            else if (input[i] == ')')
            {
                while (stack.Peek() != '(')
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Pop();
            }
        }
        while (stack.Count > 0)
        {
            queue.Enqueue(stack.Pop());
        }

        //Reverse Polish notation
        List<char> sequence = queue.ToList();

        Stack<decimal> reversePolishNotationStack = new Stack<decimal>();
        int n = 2;
        for (int i = 0; i < sequence.Count; i++)
        {
            if (char.IsDigit(sequence[i]))
            {
                reversePolishNotationStack.Push(sequence[i]);
            }
            else
            {
                if (reversePolishNotationStack.Count < n)
                {
                    Console.WriteLine("Error!");
                    break;
                }
                else
                {
                    decimal firstNumber = reversePolishNotationStack.Pop();
                    decimal secondNumber = reversePolishNotationStack.Pop();
                    decimal result = 0.0m;
                    switch (sequence[i])
                    {
                        case '+':
                            result = firstNumber + secondNumber;
                            break;
                        case '-':
                            result = firstNumber - secondNumber;
                            break;
                        case '*':
                            result = firstNumber * secondNumber;
                            break;
                        default:
                            result = firstNumber / secondNumber;
                            break;
                    }
                    reversePolishNotationStack.Push(result);
                }
            }
        }
        if (reversePolishNotationStack.Count == 1)
        {
            Console.WriteLine(reversePolishNotationStack);
        }
        else
        {
            Console.WriteLine("Error!");
        }
    }
}