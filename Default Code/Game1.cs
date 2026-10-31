using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Halloween2027
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private StateManager StateManager;
        private WrapperStruct wrapper;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Going to set our resolution so we don't get goofy results
            _graphics.PreferredBackBufferWidth = 1920;                                                      // Set our preferred width
            _graphics.PreferredBackBufferHeight = 1080;                                                     // Set our preferred height
            _graphics.HardwareModeSwitch = true;                                                              // Signals the monitor to switch resolution since we've (theoretically) adjusted the resolution
            _graphics.ApplyChanges();                                                                                   // Make sure the changes take
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            wrapper = new WrapperStruct();                                                                          // Create a new instance of our WrapperStruct
            wrapper.Content = Content;                                                                                 // Set our WrapperStruct's Content
            wrapper.Graphics = _graphics;                                                                              // Set our WrapperStruct's GraphicsDeviceManager
            wrapper.SpriteBatch = _spriteBatch;                                                                     // Set our WrapperStruct's spriteBatch

            List<iGameState> states = new List<iGameState> { new OpeningState(wrapper) };                                                      // Set up a list of states so we can instanciate the StateManager, using our wrapper
            StateManager = new StateManager(states[0], states);                                                                                                    // Set that bad boy up, using the first state as the Opening State
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            StateManager.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);     // Update our StateManager so the current state is active

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            StateManager.Render();                                                                                          // Render our current state

            base.Draw(gameTime);
        }
    }
}
