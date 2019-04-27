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
    class BackGround : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D background, iconScore;

        const int BACKGROUND_LOCATION = 1000;
        const int ITEM_SIZE = 62;      

        public BackGround(Game game, SpriteBatch spriteBatch, Texture2D background, Texture2D iconScore) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.background = background;
            this.iconScore = iconScore;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, BACKGROUND_LOCATION, BACKGROUND_LOCATION), Color.White);
            spriteBatch.Draw(iconScore, new Rectangle(BACKGROUND_LOCATION + 10, 50, ITEM_SIZE, ITEM_SIZE), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
