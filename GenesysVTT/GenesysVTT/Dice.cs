namespace GenesysVTT
{
    public class Dice
    {
        public string Name { get; set; }
        public List<Face> Faces { get; set; }
        private readonly Random rnd;

        public Dice()
        {
            Name = "";
            Faces = new List<Face> { new Face() };
            rnd = new Random();
        }
        public Face Roll()
        {
            return Faces.ElementAt(rnd.Next(1, Faces.Count));
        }

    }
    public class Face
    {
        public int Success = 0;
        public int Failure = 0;
        public int Advantage = 0;
        public int Threat = 0;
        public int Triumph = 0;
        public int Despair = 0;
    }
    public class Result
    {
        public Result(List<Dice> dicePool)
        {
            foreach (var dice in dicePool)
            {
                var face = dice.Roll();
                Success += face.Success;
                Failures += face.Failure;
                Advantage += face.Advantage;
                Threat += face.Threat;
                Triumph += face.Triumph;
                Despair += face.Despair;
            }
            Success += Triumph;
            Failures += Despair;

            NetSuccessFail = Success - Failures;
            NetAdvantageThreat = Advantage - Threat;
        }
        public override string ToString()
        {
            string result = "Final Result: ";
            if (NetSuccessFail > 0) { result += $"{NetSuccessFail} Success"; }
            if (NetSuccessFail == 0) { result += "Wash     "; }
            if (NetSuccessFail < 0) { result += $"{NetSuccessFail * -1} Failure"; }
            result += " || ";
            if (NetAdvantageThreat > 0) { result += $"{NetAdvantageThreat} Advantages"; }
            if (NetAdvantageThreat == 0) { result += "Wash     "; }
            if (NetAdvantageThreat < 0) { result += $"{NetAdvantageThreat * -1} Threats"; }
            if (Triumph > 0) { result += $" || {Triumph} Triumph"; }
            if (Despair > 0) { result += $" || {Despair} Despair"; }
            return result;
        }
        public int NetSuccessFail { get; set; }
        public int NetAdvantageThreat { get; set; }
        public int Success { get; set; }
        public int Failures { get; set; }
        public int Advantage { get; set; }
        public int Threat { get; set; }
        public int Triumph { get; set; }
        public int Despair { get; set; }
    }
    public class Boost : Dice
    {
        public Boost()
        {
            Name = "Boost";
            Faces = new List<Face>
            {
                new Face() {},
                new Face() {},
                new Face() {Success=1},
                new Face() {Success=1, Advantage=1},
                new Face() {Advantage=2},
                new Face() {Advantage=1}
            };
        }
    }
    public class Setback : Dice
    {
        public Setback()
        {
            Name = "Setback";
            Faces = new List<Face>
            {
                new Face() {},
                new Face() {},
                new Face() {Failure=1},
                new Face() {Failure=1},
                new Face() {Threat=1},
                new Face() {Threat=1}
            };
        }
    }
    public class Ability : Dice
    {
        public Ability()
        {
            Name = "Ability";
            Faces = new List<Face>
            {
                new Face() {},
                new Face() {Success=1},
                new Face() {Success=1},
                new Face() {Success=2},
                new Face() {Advantage=1},
                new Face() {Advantage=1},
                new Face() {Success=1, Advantage=1},
                new Face() {Advantage=2}
            };
        }
    }
    public class Difficulty : Dice
    {
        public Difficulty()
        {
            Name = "Difficulty";
            Faces = new List<Face>
            {
                new Face() {},
                new Face() {Failure=1},
                new Face() {Failure=2},
                new Face() {Threat=1},
                new Face() {Threat=1},
                new Face() {Threat=1},
                new Face() {Threat=2},
                new Face() {Failure=1, Threat=1}
            };
        }
    }
    public class Proficiency : Dice
    {
        public Proficiency()
        {
            Name = "Difficulty";
            Faces = new List<Face>
            {
                new Face() {},
                new Face() {Success=1},
                new Face() {Success=1},
                new Face() {Success=2},
                new Face() {Success=2},
                new Face() {Advantage=1},
                new Face() {Success=1, Advantage=1},
                new Face() {Success=1, Advantage=1},
                new Face() {Success=1, Advantage=1},
                new Face() {Advantage = 2 },
                new Face() {Advantage = 2 },
                new Face() {Triumph=1}
            };
        }
    }
    public class Challenge : Dice
    {
        public Challenge()
        {
            Name = "Difficulty";
            Faces = new List<Face>
            {
                new Face() {},
                new Face() {Failure=1},
                new Face() {Failure=1},
                new Face() {Failure=2},
                new Face() {Failure=2},
                new Face() {Threat=1},
                new Face() {Threat=1},
                new Face() {Failure=1, Threat=1},
                new Face() {Failure=1, Threat=1},
                new Face() {Threat = 2 },
                new Face() {Threat = 2 },
                new Face() {Despair=1}
            };
        }
    }
    
}
