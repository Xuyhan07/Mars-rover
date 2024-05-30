using System;

enum InputCommand {
	Forward = 'F',
	Backward = 'B',
	TurnRight = 'R',
	TurnLeft = 'L'	
}

enum Direction {
	North = 'N',
	East = 'E',
	South = 'S',
	West = 'W'
}


class MainClass {
	
	public static int positionX = 0;
	public static int positionY = 0;
	public static Direction direction = Direction.North;

	
	public static void Main (string[] args) {
		printCurrentPosition(positionX, positionY, direction);
		
		while(true) {
			Console.Write("Please input your command or enter to stop.: ");
			string input = Console.ReadLine();
			if(input == "") {
				Console.WriteLine("App has stopped.");
				break;
			}
			
			// to pass current for patarn 2 app & 3
			int x = positionX;
			int y = positionY;
			Direction d = direction;

			// check each function pattarn
			Console.WriteLine("makeMotion1: ");
			makeMotion1(input);
			Console.WriteLine("makeMotion2: ");
			makeMotion2(input, x, y, d);
			Console.WriteLine("makeMotion3: ");
			makeMotion3(input, x, y, d);		

			continue;
		}
	}

	
	static void printCurrentPosition(int positionX, int positionY, Direction direction) {
		Console.WriteLine("Current position ( X position, Y position, Direction): ( {0}, {1}, {2} )", positionX, positionY, direction);
	}
	
	static void makeMotion1(string input) {
		foreach(char c in input) {			
			switch((InputCommand)c){
				case InputCommand.Forward:
					moveForward();
					break;
				case InputCommand.Backward:
					moveBackward();
					break;
				case InputCommand.TurnRight:
					turnRight();
					break;
				case InputCommand.TurnLeft:
					turnLeft();
					break;
				default:
					Console.WriteLine("not correct input!");
					break;
			}
		}		
		printCurrentPosition(positionX, positionY, direction);
	}
	
	static void moveForward() {		
		switch(direction) {
			case Direction.North:	
				positionY++;
				break;
			case Direction.South:
				positionY--;
				break;
			case Direction.East:
				positionX++;
				break;
			case Direction.West:
				positionX--;
				break;
			default:
				break;
		}
	}

	static void moveBackward() {		
		switch(direction) {
			case Direction.North:
				positionY--;
				break;
			case Direction.South:
				positionY++;
				break;
			case Direction.East:
				positionX--;
				break;
			case Direction.West:
				positionX++;
				break;
			default:
				break;
		}
	}

	static void turnRight() {
		switch(direction) {
			case Direction.North:	
				direction = Direction.East;
				break;
			case Direction.South:	
				direction = Direction.West;
				break;
			case Direction.East:	
				direction = Direction.South;
				break;
			case Direction.West:	
				direction = Direction.North;
				break;
			default:
				break;
		}
	}

	static void turnLeft() {
		switch(direction) {
			case Direction.North:	
				direction = Direction.West;
				break;
			case Direction.South:	
				direction = Direction.East;
				break;
			case Direction.East:	
				direction = Direction.North;
				break;
			case Direction.West:	
				direction = Direction.South;
				break;
			default:
				break;
		}
	}

	/// <summary>
	/// Move or change direction depends on current direction, and print out result.
	/// This function is closed inside and using "switch" two times as conditional logic.
	/// <param name="input">Input command</param name>
	/// <param name="positionX">Current position of X</param name>
	/// <param name="positionY">Current position of Y</param name>
	/// <param name="direction">Current direction</param name>
	/// </summary>
	static void makeMotion2(string input, int positionX, int positionY, Direction direction) {
		foreach(char c in input) {
			switch(direction) {
				case Direction.North:					
					switch((InputCommand)c){
						case InputCommand.Forward:
							positionY++;
							break;
						case InputCommand.Backward:
							positionY--;
							break;
						case InputCommand.TurnRight:
							direction = Direction.East;
							break;
						case InputCommand.TurnLeft:
							direction = Direction.West;
							break;
						default:
							Console.WriteLine("not correct input!");
							break;
					}
					break;
					
				case Direction.South:
					switch((InputCommand)c){
						case InputCommand.Forward:
							positionY--;
							break;
						case InputCommand.Backward:
							positionY++;
							break;
						case InputCommand.TurnRight:
							direction = Direction.West;
							break;
						case InputCommand.TurnLeft:
							direction = Direction.East;
							break;
						default:
							Console.WriteLine("not correct input!");
							break;
					}
					break;
					
				case Direction.East:
					switch((InputCommand)c){
						case InputCommand.Forward:
							positionX++;
							break;
						case InputCommand.Backward:
							positionX--;
							break;
						case InputCommand.TurnRight:
							direction = Direction.South;
							break;
						case InputCommand.TurnLeft:
							direction = Direction.North;
							break;
						default:
							Console.WriteLine("not correct input!");
							break;
					}
					break;
					
				case Direction.West:
					switch((InputCommand)c){
						case InputCommand.Forward:
							positionX--;
							break;
						case InputCommand.Backward:
							positionX++;
							break;
						case InputCommand.TurnRight:
							direction = Direction.North;
							break;
						case InputCommand.TurnLeft:
							direction = Direction.South;
							break;
						default:
							Console.WriteLine("not correct input!");
							break;
					}
					break;
			}
		}		
		printCurrentPosition(positionX, positionY, direction);		
	}

	
	static void makeMotion3(string input, int positionX, int positionY, Direction direction) {
		foreach(char c in input) {
			InputCommand request = (InputCommand)c; 
			switch(direction) {
				case Direction.North:
					if(request == InputCommand.Forward) positionY++;
					else if(request == InputCommand.Backward) positionY--;
					else if(request == InputCommand.TurnRight) direction = Direction.East;
					else if(request == InputCommand.TurnLeft) direction = Direction.West;
					else Console.WriteLine("not correct input!");					
					break;
					
				case Direction.South:
					if(request == InputCommand.Forward) positionY--;
					else if(request == InputCommand.Backward) positionY++;
					else if(request == InputCommand.TurnRight) direction = Direction.West;
					else if(request == InputCommand.TurnLeft) direction = Direction.East;
					else Console.WriteLine("not correct input!");						
					break;
					
				case Direction.East:
					if(request == InputCommand.Forward) positionX++;
					else if(request == InputCommand.Backward) positionX--;
					else if(request == InputCommand.TurnRight) direction = Direction.South;
					else if(request == InputCommand.TurnLeft) direction = Direction.North;
					else Console.WriteLine("not correct input!");						
					break;
					
				case Direction.West:
					if(request == InputCommand.Forward) positionX--;
					else if(request == InputCommand.Backward) positionX++;
					else if(request == InputCommand.TurnRight) direction = Direction.North;
					else if(request == InputCommand.TurnLeft) direction = Direction.South;
					else Console.WriteLine("not correct input!");						
					break;
			}
		}		
		printCurrentPosition(positionX, positionY, direction);
	}	
}
