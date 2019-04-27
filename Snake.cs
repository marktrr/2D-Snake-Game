/* FINAL GAME PROJECT
 * 
 * File: Snake.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 11/25/2018 
 * Finished: 9:00 AM December 10, 2018.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HMFinal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HMFinal
{
    class Snake : DrawableGameComponent
    {
        #region variables
        SpriteFont font;
        SpriteBatch spriteBatch;
        Texture2D snake, tail;
        Color color;
        List<Vector2> snakePos;
        private ScoreManager scoreManager;

        const int DEFAULT_X = 4;
        const int DEFAULT_Y = 7;
        const int ITEM_SIZE = 62;
        const int SPEED = 110;
        const int SCORE_X = 350;
        const int SCORE_Y = 400;

        Boolean isOver;
        int direction = 3;
        int lastTime;
        int checkReverse;
        int score = 0;
        #endregion

        List<int> HighScoreList;
        public const string highScoreFilename = "highscore.txt";

        public List<Vector2> SnakePos { get { return snakePos; } }

        public Boolean isRun { get; set; } = false;

        public Boolean GameOver { get { return isOver; } set { isOver = value; } } 

        public int Score {  get { return score; } set { score = value; } }

        public Snake(Game game, SpriteFont font, SpriteBatch spriteBatch, Texture2D snake, Texture2D tail, Color color) : base(game)
        {
            this.font = font;
            this.spriteBatch = spriteBatch;
            this.snake = snake;
            this.tail = tail;
            this.color = color;

            snakePos = new List<Vector2>();
            HighScoreList = new List<int>();
            reset();
        }

        public override void Update(GameTime gameTime)
        { 
            KeyboardState keyState = Keyboard.GetState();

            //check the direction of the snake.
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W) && checkReverse != 1 && !isOver)
            {
                direction = 0;
            }
            else if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S) && checkReverse != 0 && !isOver)
            {
                direction = 1;
            }
            else if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A) && checkReverse != 3 && !isOver)
            {
                direction = 2;
            }
            else if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D) && checkReverse != 2 && !isOver)
            {
                direction = 3;
            }
            else if (keyState.IsKeyDown(Keys.Space) && !isOver)
            {
                isRun = true;
            }
            else if (keyState.IsKeyDown(Keys.R) && isOver)
            {
                reset();
                isRun = false;               
                isOver = false;
                
                direction = 3;
            }
            if (gameTime.TotalGameTime.TotalMilliseconds > lastTime + SPEED && isRun)
            {
                checkReverse = direction;

                for (int i = snakePos.Count - 1; i > 0; i--)
                {
                    snakePos[i] = snakePos[i - 1];
                }

                if (direction == 0)
                {
                    snakePos[0] += new Vector2(0, -1);
                }
                if (direction == 1)
                {
                    snakePos[0] += new Vector2(0, 1);
                }
                if (direction == 2)
                {
                    snakePos[0] += new Vector2(-1, 0);
                }
                if (direction == 3)
                {
                    snakePos[0] += new Vector2(1, 0);
                }

                lastTime = (int)gameTime.TotalGameTime.TotalMilliseconds;
            }            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, score.ToString(), new Vector2(1100, 65), Color.Red);
            if (!isOver) // if game is not over
            {
                for (int i = 0; i < snakePos.Count; i++)
                {
                    if (i == 0)
                    {
                        spriteBatch.Draw(snake, new Rectangle((int)snakePos[i].X * ITEM_SIZE, (int)snakePos[i].Y * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(tail, new Rectangle((int)snakePos[i].X * ITEM_SIZE, (int)snakePos[i].Y * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE), Color.White);
                    }
                }
            }
            else // when game over
            {
                scoreManager = ScoreManager.Load();
                spriteBatch.DrawString(font, "Your Score: " + score.ToString(), new Vector2(SCORE_X, SCORE_Y), Color.Black); // score earn
                spriteBatch.DrawString(font,
                                            "High Score: " + scoreManager.Highscores.Select(c => c.Value).First().ToString() // high score read from xml file.
                                            , new Vector2(SCORE_X, SCORE_Y + 50), Color.Black);
            }
           
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// This method will reset everything such as score, the default length of snake, and run is false. 
        /// </summary>
        public void reset()
        {
            score = 0;
            snakePos = new List<Vector2>();
            for (int i = 0; i < 2; i++)
            {
                snakePos.Add(new Vector2(DEFAULT_X - i, DEFAULT_Y));
            }
            isRun = false;
        }
    }
}
