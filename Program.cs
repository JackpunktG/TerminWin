using System;
using System.IO;
using System.Linq;

class Program
{
		static void Main(string[] args)
		{
			Console.WriteLine("\n*** Welcome to the game... test your k-knowledge about Linux Console Commandes ***");
			Console.WriteLine("You will be asked how to give a command line in Linux, respond entring the command");
			Console.WriteLine("3 Chances - then the answer will be given\n");

			string fileName = args[0];
			String[] lines = File.ReadAllLines(fileName);
			int length = lines.Length;
			Random rnd = new Random();

			int[] questionNumbers = Enumerable.Range(0,length)
							  .OrderBy(x => rnd.Next())
							  .ToArray();
					
			Console.WriteLine("Ready?? [y/n] ");
			
			string option = Console.ReadLine().ToLower();
			
			bool finished = false;
			
			if (option == "n") finished = true; 
				
				
			while(!finished)
			{	
				Console.WriteLine();
				bool correct = false;
				int n = questionNumbers.Length;
				
				while(n > 0)
				{
					string[] qNa = lines[questionNumbers[n-1]].Split(',');
					correct = false;
						
					int count = 3;

					Console.WriteLine(qNa[0]);
					while(!correct)					
					{	if (count < 1) 
						{
							Console.WriteLine($"Correct answer was: {qNa[1]}");
							break;
						}
						else
						{

							string answer = Console.ReadLine();
						
							if (answer == qNa[1])
							{
								correct = true;
								Console.WriteLine("Correct!!");
							}
							else 
							{
								Console.WriteLine("Incorrect\n ");
								count--;
							}
						}
					}
					Console.WriteLine("\n\nNext Question:");
				
					n--;		
				}
				Console.WriteLine("You've passed all the questions :)\nCongratz you are going to be a Linux Profi in no time");
				Console.WriteLine("\nAgain? [y/n]");
				string input = Console.ReadLine().ToLower();
				if (input != "y") finished = true;  	
				}
			
			Console.WriteLine("B-byeee :)");
		}
}	

