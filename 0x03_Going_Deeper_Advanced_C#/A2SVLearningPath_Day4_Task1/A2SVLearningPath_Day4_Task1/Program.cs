using System.Threading.Tasks;
using A2SVLearningPath_Day4_Task1.Class;

namespace A2SVLearningPath_Day4_Task1
{
    internal abstract class Program
    {
        public static async Task Main(string[] args)
        {
            await Operations.AddTask();
            // Operations.GetAllTask();
            // Operations.Filter();
        }
    }
}