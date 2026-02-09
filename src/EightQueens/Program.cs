// See https://aka.ms/new-console-template for more information
using DotNetLearningLab.Chess;

Console.WriteLine("Eight Queens Puzzle - .NET 10 Migration");
Console.WriteLine("Finding solutions...");

var solutions = new List<ChessBoard>();
ChessBoard.PlaceQueens(solutions);
if (solutions.Count > 0)
{
    Console.WriteLine($"Found {solutions.Count} solutions.");
    if (solutions.Count > 0)
    {
        Console.WriteLine("First solution:");
        Console.WriteLine(solutions[0].ToString());
    }
}
else
{
    Console.WriteLine("No solutions found.");
}
