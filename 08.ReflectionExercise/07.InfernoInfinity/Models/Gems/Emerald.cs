namespace _07.InfernoInfinity.Models.Gems
{
    public class Emerald
    {
        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Vitality { get; private set; }

        public Emerald()
        {
            this.Strength = 1;
            this.Agility = 4;
            this.Vitality = 9;
        }
    }
}