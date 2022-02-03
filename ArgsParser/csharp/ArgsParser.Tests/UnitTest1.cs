using System;
using Xunit;

namespace ArgsParser.Tests;

public class UnitTest1
{
    /**
     *  Provide schema and the specified args
     *
     *  A schema is a set of flags and symbolic values (specifies rules)
     *
     *  -l -p 8080 -d /usr/logs -g this,is,a,list -d 1,2,-3,5
     *      l: boolean
     *      p: integer
     *      d: string
     *      g: list strings
     *      d: list of ints
     *      ...
     *  How do we specify the expected types?
     */
    [Fact]
    public void Test1()
    {
        throw new NotImplementedException();
    }
}