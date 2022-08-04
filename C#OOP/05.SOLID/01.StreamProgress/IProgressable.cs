using System;
using System.Collections.Generic;
using System.Text;

namespace StreamProgress
{
    public interface IProgressable
    {
        int Length { get; }

        int BytesSent { get; }
    }
}
