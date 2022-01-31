using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Validation : IValidation
    {
        /// <summary>
        /// Validate for X and Y position to create a plateau.
        /// </summary>
        /// <param name="plateau">X and Y values for plateau</param>
        /// <returns></returns>
        public bool IsInputPlateauValidate(List<int> plateau)
        {
            if (plateau.Count <= 1)
            {
                Console.WriteLine("Invalid input because no x or y position to create a plateau.");
                //Console.ReadLine();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate user input.
        /// </summary>
        /// <param name="strInput">Collection of user inputs.</param>
        /// <returns></returns>
        public bool IsInputValidate(string[] strInput)
        {
            if (strInput.Length == 0)
            {
                Console.WriteLine("Invalid input");
                return false;

            }

            if (strInput.Length == 1)
            {
                Console.WriteLine("Invalid commands to move.");
                //Console.ReadLine();
                return false;
            }

            return true;
        }
    }
}
