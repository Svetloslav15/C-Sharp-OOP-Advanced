namespace Solid.Logger.Layouts.Factory
{
    using Solid.Logger.Layouts.Contracts;
    using System;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
