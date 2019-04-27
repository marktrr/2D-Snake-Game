/* FINAL GAME PROJECT
 * 
 * File: BackGround.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 11/25/2018 
 * Finished: 9:00 AM December 10, 2018.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HMFinal
{
    class Food : DrawableGameComponent
    {
        #region variables
        SpriteBatch spriteBatch;
        Texture2D apple;
        Vector2 foodPos = new Vector2(DEFAULT_X, DEFAULT_Y);
        Random random = new Random();

        const int DEFAULT_X = 10;
        const int DEFAULT_Y = 7;
        const int ITEM_SIZE = 62;
        const int MIMIMUM_LOCATION = 1;
        const int MAXIMUM_LOCATION = 14;

        Boolean isOver = false;
        #endregion
        public Vector2 Apple { set { foodPos = value; } get { return foodPos; } }

        public Boolean GameOver { set { isOver = value; } get { return isOver; } }

        public Food(Game game, SpriteBatch spriteBatch, Texture2D apple) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.apple = apple;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (!isOver)
            {
                spriteBatch.Draw(apple, new Rectangle((int)foodPos.X * ITEM_SIZE, (int)foodPos.Y * ITEM_SIZE, ITEM_SIZE, ITEM_SIZE), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
