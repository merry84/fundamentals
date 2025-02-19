﻿namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that keeps track of the guests that are going to a house party.
            //On the first line, of input you are
            //going to receive the number of commands that will follow.
            //On the next lines,
            //you are going to receive some of the following: "{name} is going!"
            // • You have to add the person, if they are not on the guestlist already.
            // • If the person is on the list print the following to the console:
            // "{name} is already in the list!"
            //"{name} is not going!"
            // • You have to remove the person, if they are on the list. 
            //• If not, print out: "{name} is not in the list!"
            // Finally, print all of the guests, each on a new line.
            int guestCount = int.Parse(Console.ReadLine());
            string input;
            List<string> guestList = new List<string>();
            for (int i = 0; i < guestCount; i++)
            {
                string[] argument = Console.ReadLine().Split();
                string name = argument[0];
                if (argument[2] == "going!")
                {
                    if (guestList.Exists(x => x == name))
                    {
                        Console.WriteLine($"{name} is already in the list!");

                    }
                    else
                    {
                        guestList.Add(name);
                    }
                }
                else if (argument[2] == "not")
                {
                    if (guestList.Contains(name))
                    {
                        guestList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                

            }

            foreach (string guest in guestList)
            {
                Console.WriteLine(guest);

            }
	
        }
    }
}