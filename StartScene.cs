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
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        Texture2D startScreen;
        string[] menuItems = {"Start Game",
                                "How To Play",
                                "High Score",
                                "Helps",
                                "About",
                                "Quit"};
        public StartScene(Game game): base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g.spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("Fonts\\regularFont");
            SpriteFont highlightFont = game.Content.Load<SpriteFont>("Fonts\\hilightFont");
            startScreen = g.Content.Load<Texture2D>("Images\\StartScreen");


            Menu = new MenuComponent(game, spriteBatch, regularFont, highlightFont, menuItems);
            this.Components.Add(Menu);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(startScreen, new Rectangle(0, 0, 1200, 1000), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
