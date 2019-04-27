/* FINAL GAME PROJECT
 * 
 * File: HowToStart.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 12/1/2018 
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
    class HowToStart : DrawableGameComponent
    {
        SpriteFont font;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Texture2D lose;

        Boolean isClick = false;
        Boolean restart = false;

        public Boolean ReStart { set { restart = value; } get { return restart; } }

        public HowToStart(Game game, SpriteBatch spriteBatch, SpriteFont font, Texture2D texture, Texture2D lose) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.texture = texture;
            this.lose = lose;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                isClick = true;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if(isClick == false && restart == false)
            {
                spriteBatch.Draw(texture, new Rectangle(350, 50, 300, 100), Color.White);
                spriteBatch.DrawString(font, "Click Space To Start The Game", new Vector2(200, 150), Color.White);
            }
            if(restart == true)
            {
                spriteBatch.Draw(lose, new Rectangle(220, 50, 600, 100), Color.White);
                spriteBatch.DrawString(font, "Click R To Start New Game", new Vector2(250, 180), Color.White);
                restart = false;
                isClick = false;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
