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
            var game = new LudoEngine(2, "xxx");

            game.PlayersList[0].Pieces[0].InNest = false;
            game.PlayersList[0].Pieces[0].Movement = 14;

            var question = game.MovePiece(0);
            var answer = new string[] { "Blue", "Piece has moved" };

            Assert.Equal(question, answer);
        }


        [Fact]
        public void TestPieceInFinalStretch()
        {
            var game = new LudoEngine(2, "yyy");

            game.PlayersList[0].Pieces[0].InNest = false;
            game.PlayersList[0].Pieces[0].Movement = 42;

            var question = game.MovePiece(0);
            var answer = new string[] { "Blue", "Piece has moved" };

            Assert.Equal(question, answer);
        }


        // Only works when dice is set to throw 3:s.

        //[Fact]
        //public void NextTurn()
        //{
        //    var game = new LudoEngine(2, "xxx");



        //    var question = game.NextTurn();
        //    var answer = new string[] { "Blue", "3" };

        //    Assert.Equal(question, answer);
        //}

        [Fact]
        public void StartGameWihTwoPlayer()
        {
            var game = new LudoEngine(2, "zzz");


            Assert.Equal(2, game.PlayersList.Count);

            Assert.Equal(40, game.TileList.Count);

            Assert.Equal(5, game.FinalStretch.Count);

            Assert.Equal(4, game.PlayersList[0].Pieces.Count);
        }
        [Fact]
        public void StartGameWihFourPlayer()
        {
            var game = new LudoEngine(4, "ppp");


            Assert.Equal(4, game.PlayersList.Count);

           
        }
    }
}
