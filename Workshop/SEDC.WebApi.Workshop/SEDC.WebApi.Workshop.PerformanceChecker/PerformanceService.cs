namespace SEDC.WebApi.Workshop.PerformanceChecker
{
    public static class PerformanceService
    {
        private static string _url = string.Empty;
        
        public static string SetUrl(this string url) => _url = url;

        public static void CheckPerformance(this string a)
        {
            using var client = new HttpClient();
            var limit = 100;

            using HttpResponseMessage response = client.GetAsync(_url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            if(int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //msg = $"Performance: {responseBody} [Limit: {limit}]";
            Console.WriteLine($"Performance: {responseBody} [Limit: {limit}]");
            //return msg;
        }
    }
}
