using System;
using System.Collections.Generic;

namespace MarsRoverApp
{
    class MarsRover
    {
        private const int GridSize = 100;
        private (int Row, int Column) Position = (1, 1);
        private string Direction = "south";  // Initial direction

        public void TurnLeft()
        {
            Dictionary<string, string> leftTurns = new Dictionary<string, string>
            {
                { "north", "west" },
                { "west", "south" },
                { "south", "east" },
                { "east", "north" }
            };
            Direction = leftTurns[Direction];
        }

        public void TurnRight()
        {
            Dictionary<string, string> rightTurns = new Dictionary<string, string>
            {
                { "north", "east" },
                { "east", "south" },
                { "south", "west" },
                { "west", "north" }
            };
            Direction = rightTurns[Direction];
        }

        public void MoveForward(int meters)
        {
            int newRow = Position.Row;
            int newColumn = Position.Column;

            switch (Direction)
            {
                case "north":
                    newRow -= meters;
                    break;
                case "south":
                    newRow += meters;
                    break;
                case "west":
                    newColumn -= meters;
                    break;
                case "east":
                    newColumn += meters;
                    break;
            }

            // Check if new position is within boundaries
            if (newRow >= 1 && newRow <= GridSize && newColumn >= 1 && newColumn <= GridSize)
            {
                Position = (newRow, newColumn);
            }
            else
            {
                Console.WriteLine("Movement halted: boundary exceeded");
            }
        }

        public void ExecuteCommands(List<string> commands)
        {
            foreach (var command in commands)
            {
                if (command.EndsWith("m"))
                {
                    int meters = int.Parse(command.TrimEnd('m'));
                    MoveForward(meters);
                }
                else if (command.Equals("left", StringComparison.OrdinalIgnoreCase))
                {
                    TurnLeft();
                }
                else if (command.Equals("right", StringComparison.OrdinalIgnoreCase))
                {
                    TurnRight();
                }
            }
            ReportPosition();
        }

        public void ReportPosition()
        {
            int squareNumber = (Position.Row - 1) * GridSize + Position.Column;
            Console.WriteLine($"Position: {squareNumber}, Direction: {Direction}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example set of commands
            List<string> commands = new List<string> { "50m", "left", "23m", "left", "4m" };

            MarsRover rover = new MarsRover();
            rover.ExecuteCommands(commands);

            // Further commands can be executed from the new position
            List<string> nextCommands = new List<string> { "10m", "right", "30m" };
            rover.ExecuteCommands(nextCommands);
        }
    }
}
