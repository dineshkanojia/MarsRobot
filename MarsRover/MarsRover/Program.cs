using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(args);

            Console.ReadLine();

        }
    }
}
