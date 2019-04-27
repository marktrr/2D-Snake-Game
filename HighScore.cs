/* FINAL GAME PROJECT
 * 
 * File: HighScore.cs 
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HMFinal
{
    class HighScore : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D highscore;
        SpriteFont font;

        public HighScore(Game game, SpriteFont font, SpriteBatch spriteBatch, Texture2D highscore) : base(game)
        {
            this.font = font;
            this.spriteBatch = spriteBatch;
            this.highscore = highscore;     
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(highscore, new Rectangle(1010, 200, 62, 62), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
