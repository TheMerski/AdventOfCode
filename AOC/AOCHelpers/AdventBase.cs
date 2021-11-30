using AOCHelpers.Extensions;

namespace AOCHelpers
{
    public abstract class AdventBase
    {
        private readonly TimeHelper timeHelper;
        protected string RawInput { get; set; } = "";

        public AdventBase(string inputFile)
        {
            this.timeHelper = new TimeHelper();
            this.RawInput = File.ReadAllText($"Input/{inputFile}");
        }

        /// <summary>
        /// Execute the logic and print the result to the console.
        /// </summary>
        public async void ConsoleStart(bool executePart2 = false)
        {
            this.timeHelper.Start();
            var result = await this.ExecutePart1();
            Console.WriteLine("Result part 1:");
            Console.WriteLine(result);
            Console.WriteLine();

            if (executePart2)
            {
                var result2 = await this.ExecutePart2();
                Console.WriteLine("Result part 2:");
                Console.WriteLine(result2);
                Console.WriteLine();
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

