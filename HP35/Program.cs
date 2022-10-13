using System;
using System.Collections;
using System.Diagnostics;
using HP35.Current;
using HP35.Current.Hash;
using Microsoft.VisualBasic.CompilerServices;

namespace HP35
{
    class Program
    {
        static void Main()
        {
            Zip zip = new Zip("NewFile1.txt");
            zip.read();
        }
    }
}
