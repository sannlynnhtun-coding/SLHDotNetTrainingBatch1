// See https://aka.ms/new-console-template for more information
using SLHDotNetTrainingBatch1.SampleProject.BusinessLogicLayer;

Console.WriteLine("Hello, World!");

SaleService service = new SaleService();
service.Execute();
