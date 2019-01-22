using System;
using Xunit;
using GameEngine;


namespace Testning
{
    public class UnitTest1
    {
        [Fact]
        public void TestPieceMoveOnGameBoard()
        {
            var game = new LudoEngine(2);

            game.PlayersList[0].Pieces[0].InNest = false;
            game.PlayersList[0].Pieces[0].Movement = 14;

            var question = game.MovePiece(0);
            var answer = new string[] { "Blue", "Piece has moved" };

            Assert.Equal(question, answer);
        }


        [Fact]
        public void TestPieceInFinalStretch()
        {
            var game = new LudoEngine(2);

            game.PlayersList[0].Pieces[0].InNest = false;
            game.PlayersList[0].Pieces[0].Movement = 42;

            var question = game.MovePiece(0);
            var answer = new string[] { "Blue", "Piece has moved" };

            Assert.Equal(question, answer);
        }
    }
}
