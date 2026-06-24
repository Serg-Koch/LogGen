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
    public static string[] state = ["gehend", "fliegend", "rennend", "schwimmend"];
    public static string[] excludedSigns = ["'", ".", "\\", "^", "`", "/", ",","[", "]", ":",";","\""];
    public static string[] signs = ["!","@","#","$","%","&","*","<",">","?"];

    public class Generator
    {
        public string Animal { get; set; }  = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Login()
        {
            return $"{State}_{Color}_{Animal}";        
        }
        public string Password()
        {
            string password = String.Empty;
            Random random = new();
            password += Convert.ToChar(random.Next('A','Z'+1)).ToString();
            password += Convert.ToChar(random.Next('a','z'+1)).ToString();
            password += random.Next(0,10).ToString();
            password += signs[random.Next(signs.Length)];
            for (int i = 0; i < 14; i++)
            {
                string sign = Convert.ToChar(random.Next(33,122)).ToString();
                if(!excludedSigns.Contains(sign))
                {
                    password += sign;
                }                
            }
            return password;
        }
    }
    static void Main(string[] args)
    {
        int numberOfSignIn;
        Random random = new();
        Generator user = new();
        Console.Write("Gib eine Anzahl der Zugriffsdaten ein: ");
        numberOfSignIn = Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < numberOfSignIn; i++)
        {
            user.State = state[random.Next(state.Length)];
            user.Color = colors[random.Next(colors.Length)];
            switch (random.Next(4))
            {
                case 1:
                    user.Animal = female[random.Next(female.Length)];
                    user.State += "e";
                    user.Color += "e";
                    break;
                case 2:
                    user.Animal = male[random.Next(male.Length)];
                    user.State += "er";
                    user.Color += "er";
                    break;
                default:
                    user.Animal = neutral[random.Next(neutral.Length)];
                    user.State += "es";
                    user.Color += "es";
                    break;
            }
            Console.WriteLine($"Login: {user.Login()} | Password: {user.Password()}");
        }
    }
}