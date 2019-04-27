/* FINAL GAME PROJECT
 * 
 * File: Game1.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 11/25/2018 
 * Finished: 9:00 AM December 10, 2018.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace HMFinal
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont HighScoreFont;
        public SpriteFont ScoreFont;

        //declare all the scenes here
        private StartScene startScene;
        private ActionScene actionScene;
        private HelpScene helpScene;
        private HowToPlayScreen HowToPlayScreen;
        private AboutScreen aboutScreen;
        private HighScoreScreen highScoreScreen;
        Song theme, play;

        const int GAME_WIDTH = 1000;
        const int GAME_HEIGHT = 1200;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = GAME_WIDTH;
            graphics.PreferredBackBufferWidth = GAME_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            //initialize other Shared class members
            base.Initialize();
        }

        private void hideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent  item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            HighScoreFont = Content.Load<SpriteFont>("Fonts\\HighScoreFont");
            ScoreFont = Content.Load<SpriteFont>("Fonts\\ScoreFont");

            // TODO: use this.Content to load your game content here
            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            HowToPlayScreen = new HowToPlayScreen(this);
            this.Components.Add(HowToPlayScreen);

            highScoreScreen = new HighScoreScreen(this);
            this.Components.Add(highScoreScreen);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            aboutScreen = new AboutScreen(this);
            this.Components.Add(aboutScreen);

            theme = Content.Load<Song>("Sound\\start");
            play = Content.Load<Song>("Sound\\play");
            MediaPlayer.Play(theme);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;

            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
              
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    MediaPlayer.Play(play);
                    MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged; // run the music again.
                    actionScene.show();                  
                }
                else if(selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    HowToPlayScreen.show();
                }
                else if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    highScoreScreen.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                }
                else if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScreen.show();
                }
                else if (selectedIndex == 5 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (actionScene.Enabled || helpScene.Enabled || HowToPlayScreen.Enabled || highScoreScreen.Enabled || aboutScreen.Enabled)
            {              
                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();                  
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        /// <summary>
        /// This method win run the media player again after it done.
        /// </summary>
        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            if(MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.Play(play);
            }           
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
