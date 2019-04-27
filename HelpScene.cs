/* FINAL GAME PROJECT
 * 
 * File: HelpScreen.cs 
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
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D backgroundHelp;
        private Texture2D content;
        public HelpScene(Game game): base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            backgroundHelp = g.Content.Load<Texture2D>("Images\\ShareBackGround");
            content = g.Content.Load<Texture2D>("Images\\Help");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundHelp, new Rectangle(0, 0, 1200, 1000), Color.White);
            spriteBatch.Draw(content, new Rectangle(200, 100, 800, 600), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
