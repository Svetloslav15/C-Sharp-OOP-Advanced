namespace Solid.Logger.Layouts
{
    using Solid.Logger.Layouts.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
