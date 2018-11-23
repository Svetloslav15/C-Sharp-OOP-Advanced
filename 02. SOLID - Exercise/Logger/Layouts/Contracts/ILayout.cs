using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Layouts.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
