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
    }
}
