
namespace Aetly.MOD

{
    public static class Tkvaluetxt
    {
        public static string[]? tkvt = null;
        public static void all()
        {
            tkvt = File.ReadAllLines(Directory.GetCurrentDirectory() + "/MOD/tkvaluetext.txt");
        }
    }

    public class Stks
    {
        public string? Name { get; set; }
        public string Tk
        {
            get
            {
                if (Tkvaluetxt.tkvt == null || Tkvaluetxt.tkvt.Length == 0)
                    return "No data available";
                    
                Random r = new Random();
                int it = Math.Abs(r.Next(Tkvaluetxt.tkvt.Length));
                return Tkvaluetxt.tkvt[it];
            }

            set { }
        }
    }

   

}
