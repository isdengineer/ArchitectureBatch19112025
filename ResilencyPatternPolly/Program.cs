using Polly;

namespace ResilencyPatternPolly
{
    internal class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            int count = 0;
            var policy = Policy
                        .Handle<Exception>()
                        .CircuitBreaker(3, TimeSpan.FromSeconds(10));
            while (true)
            {

                count++;
                Console.WriteLine("Attempting " + count);
                try
                {
                    policy.Execute(() => { SimulateOperation(); });

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
                Thread.Sleep(1000);
            }


        }
        static void SimulateOperation()
        {
            counter++;
            Console.WriteLine("Retried");
            // Simulate an operation that may throw an exception
            if (counter == 4)
            {
                counter = 0;
                Console.WriteLine("No error");

            }
            else
            {
                throw new Exception("Simulated failure.");
            }
        }

    }
}
