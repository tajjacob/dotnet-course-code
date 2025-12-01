// 49. Model Mapping with AutoMapper 
/// Commands to run in terminal:
/// cd /Users/tajjacob/Documents/GitHub/dotnet-course-code/HelloWorld
/// dotnet --info
/// dotnet clean
/// dotnet build -v:m
/// dotnet run

using System;
using System.Data;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using AutoMapper;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            DataContextDapper dapper = new DataContextDapper(config);

            // Console.WriteLine(rightNow.ToString());

            // Computer myComputer = new Computer()
            // {
            //     Motherboard = "Z690",
            //     HasWifi = true,
            //     HasLTE = false,
            //     ReleaseDate = DateTime.Now,
            //     Price = 943.87m,
            //     VideoCard = "RTX 2060"
            // };

            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard,
            //     HasWifi,
            //     HasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('" + myComputer.Motherboard
            //         + "','" + myComputer.HasWifi
            //         + "','" + myComputer.HasLTE
            //         + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //         + "','" + myComputer.Price.ToString("0.00", CultureInfo.InvariantCulture)
            //         + "','" + myComputer.VideoCard
            // + "')";

            // File.WriteAllText("log.txt", "\n" + sql + "\n");

            // using StreamWriter openFile = new("log.txt", append: true);

            // openFile.WriteLine("\n" + sql + "\n");

            // openFile.Close();

            // string computersJson = File.ReadAllText("Computers.json");
            string computersJson = File.ReadAllText("ComputersSnake.json");

             Mapper mapper = new Mapper(new MapperConfiguration((cfg) => {
                cfg.CreateMap<ComputerSnake, Computer>()
                    .ForMember(destination => destination.ComputerId, options => 
                        options.MapFrom(source => source.computer_id))
                    .ForMember(destination => destination.CPUCore, options => 
                        options.MapFrom(source => source.cpu_cores))
                    .ForMember(destination => destination.HasLTE, options => 
                        options.MapFrom(source => source.has_lte))
                    .ForMember(destination => destination.HasWifi, options => 
                        options.MapFrom(source => source.has_wifi))
                    .ForMember(destination => destination.Motherboard, options => 
                        options.MapFrom(source => source.motherboard))
                    .ForMember(destination => destination.VideoCard, options => 
                        options.MapFrom(source => source.video_card))
                    .ForMember(destination => destination.ReleaseDate, options => 
                        options.MapFrom(source => source.release_date))
                    .ForMember(destination => destination.Price, options => 
                        options.MapFrom(source => source.price));
            }));

                        IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson); // explanation: using System.Text.Json package with Automapper for mapping snake_case to PascalCase

                          if (computersSystem != null)
            {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);
                Console.WriteLine("Automapper Count: " +  computerResult.Count());
                // foreach (Computer computer in computerResult)
                // {
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            IEnumerable<Computer>? computersJsonPropertyMapping = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);
            if (computersJsonPropertyMapping != null)
            {
                Console.WriteLine("JSON Property Count: " + computersJsonPropertyMapping.Count());
                // foreach (Computer computer in computersJsonPropertyMapping)
                // {
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            // Console.WriteLine(computersJson);

            // JsonSerializerOptions options = new JsonSerializerOptions // explanation: options to match camelCase naming in the JSON file
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase // explanation: matches the camelCase naming in the JSON file
            // };

            // IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson); // explanation: using Newtonsoft.Json package is easier for this case

            // IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);  // explanation: System.Text.Json requires more setup for this case


            // if (computersNewtonSoft != null)
            // {
            //     foreach (Computer computer in computersNewtonSoft)
            //     {
            //         string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //             Motherboard,
            //             CPUCore,
            //             HasWifi,
            //             HasLTE,
            //             ReleaseDate,
            //             Price,
            //             VideoCard
            //         ) VALUES (@Motherboard,
            //             @CPUCore,
            //             @HasWifi,
            //             @HasLTE,
            //             @ReleaseDate,
            //             @Price,
            //             @VideoCard)";

            //         dapper.ExecuteSqlWithRowCount(sql, computer);
            //     }
            // }

            // JsonSerializerSettings settings = new JsonSerializerSettings // explanation: settings to match camelCase naming in the JSON file
            // {
            //     ContractResolver = new CamelCasePropertyNamesContractResolver()
            // };


            // string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            // File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);

            // string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

            // File.WriteAllText("computersCopySystem.txt", computersCopySystem);


        }
        
        // static string escapeSingleQuote(string input)
        // {
        //     string output = input.Replace("'", "''");
        //     return output;
        // }

    }
}