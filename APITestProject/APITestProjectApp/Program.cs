using NameDaysAPIFramework.Services;
using RestSharp;

namespace APITestProjectApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Today");
            var today = new NamedayForTodayService();
            var param = new Dictionary<string, string>
            {
                { "country", "es" },
                { "timezone", "Europe/London" }
            };

            await today.MakeRequest(param, Method.Post);
            foreach (var y in today.JsonResponse)
                Console.WriteLine(y);

            Console.WriteLine("\nYesterday");
            var yesterday = new NamedayForYesterdayService();
            await yesterday.MakeRequest(param, Method.Post);
            foreach (var y in yesterday.JsonResponse)
                Console.WriteLine(y);

            Console.WriteLine("\nTomorrow");
            var tomorrow = new NamedayForTomorrowService();
            await tomorrow.MakeRequest(Method.Post);
            foreach (var y in tomorrow.JsonResponse)
                Console.WriteLine(y);

            Console.WriteLine("\nName: Daniel");
            var nameParams = new Dictionary<string, string>
            {
                { "name", "Daniel" },
                { "country", "us" },
            };

            var name = new NamedayForNameService();
            await name.MakeRequest(nameParams, Method.Post);
            foreach (var y in name.JsonResponse)
                Console.WriteLine(y);

            Console.WriteLine("\nDate: 1st Jan");
            var dateParams = new Dictionary<string, string>
            {
                { "day", "1" },
                { "month", "1" },
            };

            var date = new NamedayForDateService();
            await date.MakeRequest(dateParams, Method.Post);
            foreach (var y in date.JsonResponse)
                Console.WriteLine(y);
        }
    }
}