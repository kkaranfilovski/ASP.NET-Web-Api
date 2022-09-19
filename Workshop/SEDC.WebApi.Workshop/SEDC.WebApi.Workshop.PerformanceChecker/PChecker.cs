namespace SEDC.WebApi.Workshop.PerformanceChecker
{
    public class PChecker : ICheckPerformance, IPChecker
    {
        private string _url = string.Empty;

        public ICheckPerformance SetUrl(string url)
        {
            _url = url;
            return this;
        } 

        public void CheckPerformance()
        {
            using var client = new HttpClient();
            var limit = 100;

            using HttpResponseMessage response = client.GetAsync(_url).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            if (int.Parse(responseBody) > limit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //msg = $"Performance: {responseBody} [Limit: {limit}]";
            Console.WriteLine($"Performance: {responseBody} [Limit: {limit}]");
            //return msg;
        }
    }

    public interface IPChecker
    {
        ICheckPerformance SetUrl(string url);
    }

    public interface ICheckPerformance
    {
        void CheckPerformance(); 
    }

    public class Test
    {
        private readonly IPChecker _perforamnceChecker;

        public Test(IPChecker perforamnceChecker)
        {
            _perforamnceChecker = perforamnceChecker;
        }

        public void Teest()
        {
            _perforamnceChecker.SetUrl("").CheckPerformance();
        }
    }
}
