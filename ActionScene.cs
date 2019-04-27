/* FINAL GAME PROJECT
 * 
 * File: ActionScene.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 11/30/2018 
 * Finished: 9:00 AM December 10, 2018.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMFinal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HMFinal
{
    public class ActionScene : GameScene
    {
        #region variables
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D texture, apple, tail, snake, background, lose, score, iconHighScore, howToStart;
        SoundEffect eat, hit;
        SoundEffectInstance mySoundInstance;

        Snake mySnake;
        Food myApple;
        HowToStart myStart;
        Random random;

        const int GAME_WIDTH = 1000;
        const int GAME_HEIGHT = 1200;
        const int ITEM_SIZE = 62;
        const int MIMIMUM_LOCATION = 1;
        const int MAXIMUM_LOCATION = 14;
        const int DEFAULT_X = 10;
        const int DEFAULT_Y = 7;
        const int HIGHSCORE_X = 1100;
        const int HIGHSCORE_Y = 210;

        private ScoreManager scoreManager;

        #endregion
        public ActionScene (Game game): base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = g.Content.Load<SpriteFont>("Fonts\\font");
            texture = g.Content.Load<Texture2D>("Images\\blank");
            snake = g.Content.Load<Texture2D>("Images\\Snake");
            apple = g.Content.Load<Texture2D>("Images\\apple");
            tail = g.Content.Load<Texture2D>("Images\\tail");
            background = g.Content.Load<Texture2D>("Images\\background");
            lose = g.Content.Load<Texture2D>("Images\\LoseScreen");
            score = g.Content.Load<Texture2D>("Images\\score");
            iconHighScore = g.Content.Load<Texture2D>("Images\\highscore");
            howToStart = g.Content.Load<Texture2D>("Images\\space");
           
            eat = g.Content.Load<SoundEffect>("Sound\\eat");
            hit = g.Content.Load<SoundEffect>("Sound\\hit");

            mySoundInstance = hit.CreateInstance();

            random = new Random();

            BackGround myBackGround = new BackGround(g, spriteBatch, background, score);
            this.Components.Add(myBackGround);

            mySnake = new Snake(g, font, spriteBatch, snake, tail, Color.White);
            this.Components.Add(mySnake);            

            myApple = new Food(g, spriteBatch, apple);
            this.Components.Add(myApple);

            HighScore myHighScore = new HighScore(g, font, spriteBatch, iconHighScore);
            this.Components.Add(myHighScore);

            myStart = new HowToStart(g, spriteBatch, font, howToStart, lose);
            this.Components.Add(myStart);

            scoreManager = ScoreManager.Load(); // load the highscore list.
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            GameOver();
            CheckDuplicate();
            if (mySnake.GameOver)
            {
                mySoundInstance.Play();

                if(scoreManager.Highscores.Select(c => c.Value).First() < mySnake.Score)
                {
                    // add new score.
                    scoreManager.Add(new Score()
                    {
                        Value = mySnake.Score,
                    }
                    );
                    ScoreManager.Save(scoreManager); // save new score.
                }              
            }
            if(myApple.GameOver == true) // when game over is true, reset the location of the apple.
            {
                resetApple();
            }
            myApple.GameOver = mySnake.GameOver;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(231, 434, 904)); // color for background.

            spriteBatch.Begin();
            spriteBatch.DrawString(font,
                                    scoreManager.Highscores.Select(c => c.Value).First().ToString()
                                    , new Vector2(HIGHSCORE_X, HIGHSCORE_Y), Color.Red);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        /// <summary>
        /// This method will check whether snake eat an apple.
        /// When the snake eat an apple, create a new apple with a new location.
        /// </summary>
        public void CheckDuplicate()
        {
            if (mySnake.SnakePos[0].X == myApple.Apple.X && mySnake.SnakePos[0].Y == myApple.Apple.Y)
            {
                mySnake.Score++;
                eat.Play(); // play the sound effect when snake eat an apple.
                mySnake.SnakePos.Add(mySnake.SnakePos[mySnake.SnakePos.Count - 1]);
                myApple.Apple = new Vector2(random.Next(MIMIMUM_LOCATION, MAXIMUM_LOCATION), random.Next(MIMIMUM_LOCATION, MAXIMUM_LOCATION)); // create next random position 
                for (int i = 1; i < mySnake.SnakePos.Count; i++)
                {
                    // if the location is duplicate which the snake tail, create in another location.
                    if (myApple.Apple.X == mySnake.SnakePos[i].X && myApple.Apple.Y == mySnake.SnakePos[i].Y)
                    {
                        myApple.Apple = new Vector2(random.Next(MIMIMUM_LOCATION, MAXIMUM_LOCATION), random.Next(MIMIMUM_LOCATION, MAXIMUM_LOCATION));
                    }
                }
            }
        }
        /// <summary>
        /// This method will check the game over.
        /// </summary>
        public void GameOver()
        {
            for (int i = 1; i < mySnake.SnakePos.Count; i++)
            {
                //if snake hit itself
                if (mySnake.SnakePos[0].X == mySnake.SnakePos[i].X && mySnake.SnakePos[0].Y == mySnake.SnakePos[i].Y)
                {
                    mySnake.GameOver = true;
                    mySnake.isRun = false;
                    myApple.GameOver = true;
                    myStart.ReStart = true;
                }
            }

            //if snake hit the wall
            if (mySnake.SnakePos[0].X == 0 || mySnake.SnakePos[0].Y == 0 || mySnake.SnakePos[0].Y > 14 || mySnake.SnakePos[0].X > 14)
            {
                mySnake.GameOver = true;
                mySnake.isRun = false;
                myApple.GameOver = true;
                myStart.ReStart = true;
            }
        }
        /// <summary>
        /// Restart the apple.
        /// </summary>
        public void resetApple()
        {
            myApple.Apple = new Vector2(DEFAULT_X, DEFAULT_Y);
        }
    }
}
