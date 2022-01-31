using MarsRover;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsRoverTest
{
    public class Tests
    {
        [Test]
        public void TestValidateInput()
        {
            string[] input = {"5x5", "LFLFLFLFF" };

            IValidation validation = new Validation();
            Assert.IsTrue(validation.IsInputValidate(input));
        }

        [Test]
        public void TestValidateInputFail()
        {
            string[] input = { };

            IValidation validation = new Validation();
            Assert.IsFalse(validation.IsInputValidate(input));
        }

        [Test]
        public void TestValidPlateauSize()
        {
            string[] input = { "5x5", "LFLFLFLFF" };
            List<int> plateau = input[0].Trim().Split('x').Select(int.Parse).ToList();
            IValidation validation = new Validation();
            Assert.IsTrue(validation.IsInputPlateauValidate(plateau));
        }

        [Test]
        public void TestValidPlateauSizeFail()
        {
            string[] input = { "5", "LFLFLFLFF" };
            List<int> plateau = input[0].Trim().Split('x').Select(int.Parse).ToList();
            IValidation validation = new Validation();
            Assert.IsFalse(validation.IsInputPlateauValidate(plateau));
        }

        [Test]
        public void TestRoverMovement_InvalidCommands_WithoutPlateau()
        {
            string[] input = { "FFRFFRFRRF" };


            //Arranging console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            string expectedOutput = "Invalid commands to move.";
            var stringReader = new StringReader(expectedOutput);
            Console.SetIn(stringReader);


            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(input);

            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(expectedOutput, output[0]);
        }

        [Test]
        public void TestRoverMovement_InvalidCommands_WithoutInstruction()
        {
            string[] input = { "5x5" };


            //Arranging console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            string expectedOutput = "Invalid commands to move.";
            var stringReader = new StringReader(expectedOutput);
            Console.SetIn(stringReader);


            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(input);

            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(expectedOutput, output[0]);
        }

        [Test]
        public void TestRoverMovementPass1()
        {
            string[] input = { "5x5", "LFLFLFLFF" };

            
            //Arranging console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            string expectedOutput = "1 2 North";
            var stringReader = new StringReader(expectedOutput);
            Console.SetIn(stringReader);


            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(input);

            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(expectedOutput, output[0]);

        }

        [Test]
        public void TestRoverMovementPass2()
        {
            string[] input = { "5x5", "FFRFFRFRRF" };


            //Arranging console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            string expectedOutput = "3 3 North";
            var stringReader = new StringReader(expectedOutput);
            Console.SetIn(stringReader);


            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(input);

            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(expectedOutput, output[0]);

        }


        [Test]
        public void TestRoverMovement_InvalidInstruction()
        {
            string[] input = { "5x5", "WASDRRRLLLSDD" };


            //Arranging console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            string expectedOutput = "Invalid Instructions W";
            var stringReader = new StringReader(expectedOutput);
            Console.SetIn(stringReader);


            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(input);

            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(expectedOutput, output[0]);
        }


        [Test]
        public void TestRoverMovement_MoveBeyond_Plateau()
        {
            string[] input = { "5x5", "LFFFRFFFFLFFRFRF" };


            //Arranging console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            StringBuilder sb = new StringBuilder();
            sb.Append("Wrong move position can not be beyond plateau (0 , 0) and (5 , 5)");
            sb.Append("-1 1 West");

            var stringReader = new StringReader(sb.ToString());
            Console.SetIn(stringReader);


            IRoverMovement roverMovement = new RoverMovement();
            roverMovement.RoverCommand(input);

            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var expectedOutput = Console.ReadLine();

            Assert.AreEqual(expectedOutput, output[0]+output[1]);
        }



    }
}