/* FINAL GAME PROJECT
 * 
 * File: AboutScreen.cs 
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
    public class AboutScreen : GameScene
    {
        #region variables
        private SpriteBatch spriteBatch;
        private Texture2D backgroundAboutScreen;
        private Texture2D content;

        const int GAME_WIDTH = 1000;
        const int GAME_HEIGHT = 1200;
        const int CONTENT_X = 250;
        const int CONTENT_Y = 100;
        const int CONTENT_W = 700;
        #endregion

        public AboutScreen(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            backgroundAboutScreen = g.Content.Load<Texture2D>("Images\\ShareBackGround");
            content = g.Content.Load<Texture2D>("Images\\About");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundAboutScreen, new Rectangle(0, 0, GAME_HEIGHT, GAME_WIDTH), Color.White);
            spriteBatch.Draw(content, new Rectangle(CONTENT_X, CONTENT_Y, CONTENT_W, CONTENT_W - CONTENT_X), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

