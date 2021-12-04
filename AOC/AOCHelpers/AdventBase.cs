using AOCHelpers.Extensions;

namespace AOCHelpers
{
    public abstract class AdventBase
    {
        private readonly TimeHelper timeHelper;
        protected string RawInput { get; set; } = "";
        protected List<string> InputLines { get; set; }

        public AdventBase(string inputFile)
        {
            this.timeHelper = new TimeHelper();
            this.RawInput = File.ReadAllText($"Input/{inputFile}");
            this.InputLines = RawInput.ToStringList(Environment.NewLine);
        }

        /// <summary>
        /// Execute the logic and print the result to the console.
        /// </summary>
        public async void ConsoleStart()
        {
            this.timeHelper.Start();
            var result = await this.ExecutePart1();
            Console.WriteLine("Result part 1:");
            Console.WriteLine(result);
            Console.WriteLine();

            try
            {
                var result2 = await this.ExecutePart2();
                Console.WriteLine("Result part 2:");
                Console.WriteLine(result2);
                Console.WriteLine();
            } catch (Exception e)
            {
                Console.WriteLine($"Part 2 not available: {e.Message}");
            }

            this.timeHelper.Stop();
        }

        /// <summary>
        /// Execute any logic for part 1 and return the result as a string.
        /// </summary>
        /// <returns>A string with the result.</returns>
        protected abstract Task<string> ExecutePart1();

        /// <summary>
        /// Execute any logic for part 1 and return the result as a string.
        /// </summary>
        /// <returns>A string with the result.</returns>
        protected abstract Task<string> ExecutePart2();
    }
}

