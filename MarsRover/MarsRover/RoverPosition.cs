using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// Enums for Directions
    /// </summary>
    public enum Directions
    {
        North = 1,
        South = 2,
        East = 3,
        West = 4
    }

    /// <summary>
    /// Rover movement 
    /// </summary>
    public class RoverPosition : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public RoverPosition()
        {
            X = Y = 1;
            Direction = Directions.North;
        }

        /// <summary>
        /// Change direction to left based on the commands.
        /// </summary>
        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.West;
                    break;
                case Directions.South:
                    this.Direction = Directions.East;
                    break;
                case Directions.East:
                    this.Direction = Directions.North;
                    break;
                case Directions.West:
                    this.Direction = Directions.South;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Change direction to rigt based on the commands.
        /// </summary>
        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Direction = Directions.East;
                    break;
                case Directions.South:
                    this.Direction = Directions.West;
                    break;
                case Directions.East:
                    this.Direction = Directions.South;
                    break;
                case Directions.West:
                    this.Direction = Directions.North;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Moving the direction based on changes in the axis direction.
        /// </summary>
        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.North:
                    this.Y += 1;
                    break;
                case Directions.South:
                    this.Y -= 1;
                    break;
                case Directions.East:
                    this.X += 1;
                    break;
                case Directions.West:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Moving rover to next step within the size of plateau,rover can move else throw and error.
        /// </summary>
        /// <param name="maxPoints">size of a plateau</param>
        /// <param name="moves">set of intructions for movement.</param>
        /// <exception cref="Exception"></exception>
        public void StartMoving(List<int> maxPoints, string moves)
        {
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'F':
                        this.MoveInSameDirection();
                        break;
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Instructions {move}");
                        break;
                }

                if (this.X < 0 || this.X > maxPoints[0] || this.Y < 0 || this.Y > maxPoints[1])
                {
                    throw new Exception($"Wrong move position can not be beyond plateau (0 , 0) and ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
       }
    }
}
