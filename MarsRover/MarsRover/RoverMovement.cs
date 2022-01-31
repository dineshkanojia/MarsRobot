using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class RoverMovement : IRoverMovement
    {
        /// <summary>
        /// Based on input command rover movement takes place
        /// </summary>
        /// <param name="args">Set of command includung plateau size and instruction for movement.</param>
        public void RoverCommand(string[] args)
        {
            IValidation validate = new Validation();

            //Validate input.
            if (validate.IsInputValidate(args))
            {
                List<int> plateau = args[0].Trim().Split('x').Select(int.Parse).ToList();

                //Validate plateau size
                if (validate.IsInputPlateauValidate(plateau))
                {
                    //Setting default values;
                    RoverPosition position = new RoverPosition();
                    position.X = 1;
                    position.Y = 1;
                    position.Direction = Directions.North;

                    try
                    {
                        //Command rover based on set of commands.
                        position.StartMoving(plateau, args[1]);
                        Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine($"{position.X} {position.Y} {position.Direction.ToString()}");
                    }

                }
            }
        }
    }
}
