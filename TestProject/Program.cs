using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.IsolatedStorage;
using FileManagement.FileType;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;


namespace TestProject
{
    public class Team
    {
        public string Name { get; set; }

        public Team() { }

        public Team(string name)
        {
            Name = name;
        }
    }

    public class Match
    {
        public string Id { get; set; }

        public string HomeTeamFinalScore { get; set; }

        public string AwayTeamFinalScore { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public Match()
        {

        }

        public Match(Team homeTeam,Team awayTeam,string homeTeamFinalScore,string awayTeamFinalScore)
        {
            Id = Guid.NewGuid().ToString();

            HomeTeam = homeTeam;

            AwayTeam = awayTeam;

            HomeTeamFinalScore = homeTeamFinalScore;

            AwayTeamFinalScore = awayTeamFinalScore;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var t2020 = new List<Team>() { new Team("Lakers"), new Team("Detroit") };

            //var jsonFile = new CustomFile("myJson");
            //jsonFile.SetData(CustomFile.SerializeAsJsonFormat(t2020));
            //var bbb = jsonFile.SaveAs(CustomFile.CurrentProjectBinPath);

            var jsonFile2 = new CustomFile(CustomFile.CombinePaths(CustomFile.CurrentProjectBinPath,"myJson.json"));
            var objTT = CustomFile.DeserializeAsJsonFormat<List<Team>>(jsonFile2.DataAsString);

            objTT.FirstOrDefault().Name = "Chicago";

            var xbx = jsonFile2.SaveAs(CustomFile.CurrentProjectBinPath,"myJson2",".json",CustomFile.SerializeAsJsonFormat(objTT));


            var f2020 = new CustomFile();



            var obj2020 = JsonFile.SerializeAsJsonFormat(t2020);

            var obj2023 = JsonFile.DeserializeAsJsonFormat<List<Team>>(obj2020);

            var b = f2020.SaveAs(CustomFile.CurrentProjectBinPath, "myFirst", ".json", obj2020);


            var customFile2 = new CustomFile("efg",".png");

            customFile2.SetData(CustomFile.ReadAllBytes(CustomFile.CombinePaths(CustomFile.CurrentUserDesktopPath, "colorSample.png"), null));

            var cffas2 = customFile2.DataAsString;

            //customFile2.WriteAllBytes(CustomFile.CombinePaths(CustomFile.CurrentProjectBinPath,"a12v.png"));

            customFile2.SaveAs(CustomFile.CurrentProjectBinPath,"a12v",".png");

            //var jsonToCreate = new TextFile(CustomFile.CombinePaths(true,CustomFile.CurrentProjectBinPath,"abc.json"));

            var match = new Match(new Team("HomeTeam"),new Team("AwayTeam"),"51","29");

            //jsonToCreate.SetSerializer();

            //jsonToCreate.Serializer.Serialize();

            //var f = Serializer.ConvertToFile("abc","json",match);

            //f.Serialize();

            //var jsonString = f.Serializer.JsonString;

           // var mm = f.Serializer.Deserialize<List<Match>>();


            //Dsv csv = new Dsv(FileManagement.CustomFile.CombinePaths(FileManagement.CustomFile.CurrentUserDesktopPath, "kişiler.csv"), ',');
            //var results = csv.Split(13, false);


            //var isolatedFile = new TextFile("kişiler", ".csv");

            ////isolatedFile.WriteLineByStreamWriter(results, isolatedFile.GetIsolatedStorageFileStream());

            //var lines = isolatedFile.ReadLineByStreamReader(csv.GetIsolatedStorageFileStream());

            //var product = new
            //{
            //    Name = "Product1",
            //    Date = DateTime.Now
            //};

            //var file = Serializer.ConvertToFile("abc", ".txt", product);

            //file.Serializer.SetSerializationType(SerializationType.JSON)
            //    .Serialize();

            //var jsonStr = file.Serializer.JsonString;

            ////var obj = JsonConvert.DeserializeObject(json);


            //var jsonFile = new TextFile(FileManagement.CustomFile.CombinePaths(FileManagement.CustomFile.CurrentUserDesktopPath, "myJson.json"));
            //jsonFile.SetSerializer();

            //var objList = jsonFile.Serializer.Deserialize<List<Match>>();
            //test
        }
    }
}


//Create a new file which doesnt exist

//         var tFile = new TextFile(CustomFile.CombinePaths(CustomFile.CurrentUserDesktopPath, "AnimationProject2.txt"));

//tFile.CreateNewIfNotExists();


