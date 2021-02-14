using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    //for methods returning void
    public interface IResult
    {
        //readonly (constant)
        bool Success { get; }
        string Message { get; }
    }
}
