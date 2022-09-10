using SEDC.WebApi.Workshop.PerformanceChecker;

var url = @"http://localhost:5277/api/v1/performance/notes";

Console.WriteLine("Performance check started");
Console.WriteLine("=========================");
//var service = new PerformanceService();
//service.SetUrl(url);
//service.CheckPerformance();

//PerformanceService.SetUrl(url).CheckPerformance();

new PChecker().SetUrl(url).CheckPerformance();

Console.ReadLine();

