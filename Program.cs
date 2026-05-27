using System.Runtime.InteropServices;

namespace LogGen;

class Program
{
    public static string [] female = 
    [
        "katze", "maus", "kuh", "ziege", "robbe", "giraffe", "antilope",
        "eule", "amsel", "meise", "gans", "ente", "taube", "moewe", "schwalbe", "wachtel",
        "eidechse", "schildkroete", "forelle", "garnele", "scholle", "biene", "ameise", "hummel", "libelle", "raupe"
    ];
    public static string [] male = 
    ["hund", "baer", "fuchs", "hase", "igel", "loewe", "tiger", "wolf", "affe", "biber", "otter", "wal", "elefant",
    "pinguin", "adler", "falke", "schwan", "specht", "rabe", "storch", "kolibri", "schneeleopard",
    "fisch", "lachs", "hai", "karpfen", "delphin", "kaefer", "schmetterling", "marienkaefer", "krebs"
    ];
    public static string [] neutral =
    [
    "pferd", "kamel", "alpaka", "lama", "reh", "zebra", "ermaennchen", "fohlen", "lamm", "kitz",
    "seepferdchen", "walross", "krokodil", "einhorn", "glueckskaeferchen", "phantom"
    ];
    public static string[] colors = ["rot", "gelb", "gruen", "blau", "violett", "weiss", "schwarz"];
    public static string[] stand = ["gehend", "fliegend", "rennend", "schwimmend"];
    public class Login
    {
        public string Animal { get; set; }  = String.Empty;
        public string Article { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Nickname {get;set;} = String.Empty;
        public string Password {get;set;} = String.Empty;
        public void CreateLogin()
        {
            Nickname = State + "_" + Color + "_" + Animal;
        }
        public void CreatePassword()
        {
            Random random = new();
            for (int i = 0; i < 13; i++)
            {
                Password += Convert.ToChar(random.Next(33,127));                
            }
        }
    }

    static void Main(string[] args)
    {
        Random random = new();
        Login login = new();
        switch (random.Next(1, 4))
        {
            case 1:
                login.Article = "die";
                break;
            case 2:
                login.Article = "der";
                break;
            default:
                login.Article = "das";
                break;
        }
        switch (login.Article)
        {
            case "die":
                login.Animal = female[random.Next(female.Length)];
                login.Stand = stand[random.Next(stand.Length)] + "e";
                login.Color = colors[random.Next(colors.Length)] +"e";
                break;
            case "der":
                login.Animal = male[random.Next(male.Length)];
                login.Stand = stand[random.Next(stand.Length)] + "er";
                login.Color = colors[random.Next(colors.Length)] + "er";
                break;
            default:
                login.Animal = neutral[random.Next(neutral.Length)];
                login.Stand = stand[random.Next(stand.Length)] + "es";
                login.Color = colors[random.Next(colors.Length)] + "es";
                break;
        }
        login.CreateLogin();
        login.CreatePassword();
        Console.WriteLine($"Login: {login.Nickname} | Password: {login.Password}");
    }
}