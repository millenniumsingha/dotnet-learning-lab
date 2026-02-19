using DotNetLearningLab.Chess;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace EightQueens.Tests
{
    public class ChessBoardTests
    {
        [Fact]
        public void Test010EmptyBoardIsSafe()
        {
            var board = new ChessBoard("00000000");

            Assert.True(board.IsSafe());
        }

        [Fact]
        public void Test011BoardIsSafe()
        {
            var board = new ChessBoard("10000000");

            Assert.True(board.IsSafe());
        }

        [Fact]
        public void Test012BoardIsSafe()
        {
            var board = new ChessBoard("15863720");

            Assert.True(board.IsSafe());
        }

        [Fact]
        public void Test019EachKnownSolutionIsSafe()
        {
            var boards = from solution in ChessBoard.Solutions
                         select new ChessBoard(solution);

            // checks the validity of each known solution
            Assert.True(boards.All(board => board.IsSafe()));
        }

        [Fact]
        public void Test020PlaceQueens()
        {
            // starting from an empty board, can we find one solution
            Assert.True(ChessBoard.PlaceQueens());
        }

        [Fact]
        public void Test030PlaceQueens()
        {
            // starting from an empty board, can we find all solutions
            var solutions = new List<ChessBoard>(92);
            ChessBoard.PlaceQueens(solutions);
            Assert.Equal(92, solutions.Count);

            // confirm all found solutions are known
            Assert.True(solutions.All(board => ChessBoard.Solutions.Contains(board.ToString())));
        }
        [Fact]
        public void Test031InvalidBoardValuesThrowsException()
        {
            // Board with values outside 0-8 range should throw
            var invalidBoard = new int[] { 9, -1, 0, 0, 0, 0, 0, 0 };
            
            // This relies on the private constructor validation which is called by the public string constructor
            // However, the int[] constructor is private. Let's use reflection or modify the test slightly if needed.
            // Wait, the public string constructor calls: public ChessBoard(string board) : this(board.Select(c => c - '0').ToArray()) { }
            // So if we pass "9" in a string, '9' - '0' = 9. So passing "9..." string should trigger it.
            
            // '9' is valid char '9', '9'-'0'=9. ':' is char 58, 58-48=10. '/' is 47, 47-48=-1.
            Assert.Throws<System.ArgumentOutOfRangeException>(() => new ChessBoard("90000000"));
            Assert.Throws<System.ArgumentOutOfRangeException>(() => new ChessBoard("/0000000")); // '/' is char before '0', so -1 value
        }
    }
}
