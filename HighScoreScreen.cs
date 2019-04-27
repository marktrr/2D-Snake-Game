/* FINAL GAME PROJECT
 * 
 * File: HighScoreScreen.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 11/30/2018 
 * Finished: 9:00 AM December 10, 2018.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HMFinal
{
    public class HighScoreScreen : GameScene
    {
        private SpriteBatch spriteBatch;
        SpriteFont HighScoreFont;
        SpriteFont ScoreFont;
        private Texture2D backgroundHighScoreScreen;

        const int GAME_WIDTH = 1000;
        const int GAME_HEIGHT = 1200;
        public const string highScoreFilename = "highscore.txt";
        private ScoreManager _scoreManager;
        int one, two, three, four, five;

        public HighScoreScreen(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            this.HighScoreFont = g.HighScoreFont;
            this.ScoreFont = g.ScoreFont;

            backgroundHighScoreScreen = g.Content.Load<Texture2D>("Images\\ShareBackGround");
            _scoreManager = ScoreManager.Load();

            //take variable from xml file
            one = _scoreManager.Highscores.Select(c => c.Value).First();
            two = _scoreManager.Highscores.Select(c => c.Value).Skip(1).First();
            three = _scoreManager.Highscores.Select(c => c.Value).Skip(2).First();
            four = _scoreManager.Highscores.Select(c => c.Value).Skip(3).First();
            five = _scoreManager.Highscores.Select(c => c.Value).Skip(4).First();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Take top 5 of xml file.
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundHighScoreScreen, new Rectangle(0, 0, GAME_HEIGHT, GAME_WIDTH), Color.White);

            spriteBatch.DrawString(HighScoreFont, "HIGH SCORE LISTS", new Vector2(350,150), Color.Red);

            spriteBatch.DrawString(ScoreFont, "TOP 1", new Vector2(200, 300), Color.Red);
            spriteBatch.DrawString(ScoreFont, one.ToString(), new Vector2(600, 300), Color.Red);

            spriteBatch.DrawString(ScoreFont, "TOP 2", new Vector2(200, 400), Color.Red);
            spriteBatch.DrawString(ScoreFont, two.ToString(), new Vector2(600, 400), Color.Red);

            spriteBatch.DrawString(ScoreFont, "TOP 3", new Vector2(200, 500), Color.Red);
            spriteBatch.DrawString(ScoreFont, three.ToString(), new Vector2(600, 500), Color.Red);

            spriteBatch.DrawString(ScoreFont, "TOP 4", new Vector2(200, 600), Color.Red);
            spriteBatch.DrawString(ScoreFont, four.ToString(), new Vector2(600, 600), Color.Red);

            spriteBatch.DrawString(ScoreFont, "TOP 5", new Vector2(200, 700), Color.Red);
            spriteBatch.DrawString(ScoreFont, five.ToString(), new Vector2(600, 700), Color.Red);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
