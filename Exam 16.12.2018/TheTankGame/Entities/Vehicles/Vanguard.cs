namespace TheTankGame.Entities.Vehicles
{
    using TheTankGame.Entities.Miscellaneous.Contracts;

    public class Vanguard : BaseVehicle
    {
        public Vanguard(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}
