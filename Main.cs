using System; 
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
class Schumacher{
    public string date      {get;set;}
    public string gp        {get;set;}
    public int    pos       {get;set;}
    public int    laps      {get;set;}
    public int    points    {get;set;}
    public string team      {get;set;}
    public string status    {get;set;}

    public Schumacher(string sor){
        var s = sor.Trim().Split(";");
        date   = s[0];
        gp     = s[1];
        pos    = int.Parse(s[2]);
        laps   = int.Parse(s[3]);
        points = int.Parse(s[4]);
        team   = s[5];
        status = s[6];

        
        
    }
}

public class Program {

  public static void Main(string[] args) {
      var lista = new List<Schumacher>();
      var sr = new StreamReader("schumacher.csv");
      var elso_sor = sr.ReadLine();

      while(!sr.EndOfStream){
          lista.Add(new Schumacher(sr.ReadLine()));
      }
      sr.Close();

      Console.WriteLine($"3.feladat: {lista.Count()}");

      var schwin = (
          from sor in lista 
          where sor.gp == "Hungarian Grand Prix" & sor.pos > 0
          select sor 
      );
      Console.WriteLine($"4.feladat: Magyar nagydíj helyezései");
      foreach(var sor in schwin){
          Console.WriteLine($"   {sor.date}  -  {sor.pos}. hely");
      }

      var stat = (
          from sor in lista
          where sor.status != "Finished" & sor.status != "Disqualified" & sor.status != "+1 Lap" & sor.pos == 0
          group sor by sor.status     
      );
     
      Console.WriteLine("Statisztika");

      foreach(var sor in stat){
          if(sor.Count() > 2){
              Console.WriteLine($"\t\t{sor.Key}: {sor.Count()}");
          }
          
              
      }
      
      
    
  }
}