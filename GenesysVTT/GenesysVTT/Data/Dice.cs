using System.Text.Json;
using System.Text.Json.Serialization;

namespace GenesysVTT
{
    public enum DiceType
    {
        Boost,
        Setback,
        Ability,
        Difficulty,
        Proficiency,
        Challenge
    }
    public abstract class Dice
    {
        public abstract string ToSymbolString();
        public DiceType Type { get; set; }
        public List<Face> Faces { get; set; }
        private readonly Random rnd;

        public Dice()
        {
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
        public Result(List<Dice> dicePool, string character = "")
        {
            Character = character;
            Pool = dicePool;
            PoolString = "";
            foreach (var dice in dicePool)
            {
                PoolString += dice.Type.ToString() + "|";
                var resultFace = dice.Roll();
                Success += resultFace.Success;
                Failures += resultFace.Failure;
                Advantage += resultFace.Advantage;
                Threat += resultFace.Threat;
                Triumph += resultFace.Triumph;
                Despair += resultFace.Despair;
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
        public string ToDiceResultString()
        {
            string result = "";
            if (NetSuccessFail > 0)
            {
                for (int i = 0; i < NetSuccessFail; i++)
                {
                    result += "s";
                }
            }
            if (NetSuccessFail < 0)
            {
                for (int i = 0; i < NetSuccessFail; i++)
                {
                    result += "f";
                }
            }

            if (NetAdvantageThreat > 0)
            {
                for (int i = 0; i < NetAdvantageThreat; i++)
                {
                    result += "a";
                }
            }
            if (NetAdvantageThreat < 0)
            {

                for (int i = 0; i < NetAdvantageThreat; i++)
                {
                    result += "h";
                }
            }
            for (int i = 0; i < Triumph; i++)
            {
                result += "t";
            }

            for (int i = 0; i < Despair; i++)
            {
                result += "d";
            }
            return result;
        }
        public IEnumerable<Dice> Pool { get; set; }
        public string Character { get; set; }
        public string PoolString { get; set; }
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
            Type = DiceType.Boost;
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
        public override string ToSymbolString()
        {
            return "<span class=\"genesys dice boost\">j</span>";
        }
    }
    public class Setback : Dice
    {
        public Setback()
        {
            Type = DiceType.Setback;
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

        public override string ToSymbolString()
        {
            return "<span class=\"genesys dice setback\">j</span>";
        }
    }
    public class Ability : Dice
    {
        public Ability()
        {
            Type = DiceType.Ability;
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

        public override string ToSymbolString()
        {
            return "<span class=\"genesys dice ability\">k</span>";
        }
    }
    public class Difficulty : Dice
    {
        public Difficulty()
        {
            Type = DiceType.Difficulty;
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

        public override string ToSymbolString()
        {
            return "<span class=\"genesys dice difficulty\">k</span>";
        }
    }
    public class Proficiency : Dice
    {
        public Proficiency()
        {
            Type = DiceType.Proficiency;
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

        public override string ToSymbolString()
        {
            return "<span class=\"genesys dice proficiency\">l</span>";
        }
    }
    public class Challenge : Dice
    {
        public Challenge()
        {
            Type = DiceType.Challenge;
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

        public override string ToSymbolString()
        {
            return "<span class=\"genesys dice challenge\">l</span>";
        }
    }

}
