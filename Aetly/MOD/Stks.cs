
namespace Aetly.MOD

{
    public static class Tkvaluetxt
    {
        public static string[] tkvt = null;
        public static void all()
        {
            tkvt = File.ReadAllLines(Directory.GetCurrentDirectory() + "/MOD/tkvaluetext.txt");
        }
    }

    public class Stks
    {
        public string Name { get; set; }
        public string Tk
        {
            get
            {
                
                   Random r = new Random();
                int it=Math.Abs( r.Next(98));
                return Tkvaluetxt.tkvt[it];
            }

            set { }
        }
    }

   

}
