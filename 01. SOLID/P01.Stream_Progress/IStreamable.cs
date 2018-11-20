using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public interface IStreamable
    {
        int Length { get; set; }

        int BytesSent { get; set; }
    }
}
