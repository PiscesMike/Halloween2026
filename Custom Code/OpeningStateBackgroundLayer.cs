using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Halloween2027
{
     internal class OpeningStateBackgroundLayer : iGameState                                                // Class constructor, making sure to define it as our iGameState interface
    {
        WrapperStruct WrapperStruct;                                                                                         // Need a local copy of our WrapperStruct
        Texture2D Asset;                                                                                                               // Something to hold our asset

        /*
         * To create a larger 'world' we're going to need to 'tile' our background layer assets. For this particular project, we ended up needing enough to last 61 seconds
         * so we're going to need 5 copies, and therefore 5 rectangles so we know where to render them on screen.
         */

        Rectangle Position = new Rectangle(0, 0, 4096, 1080);                                                    // Our display space for the first tile
        Rectangle Position2 = new Rectangle(4094, 0, 4096, 1080);                                            // Our display space for the second tile
        Rectangle Position3 = new Rectangle(8192, 0, 4096, 1080);                                            // Our display space for the third tile
        Rectangle Position4 = new Rectangle(12288, 0, 4096, 1080);                                          // Our display space for the fourth tile
        Rectangle Position5 = new Rectangle(16384, 0, 4096, 1080);                                          // Our display space for the fifth tile

        Matrix transform = Matrix.CreateTranslation(0, 0, 0);                                                       // We need to keep track of our transform so we can use scrolling and parallax
        
        public OpeningStateBackgroundLayer(string asset, WrapperStruct wrapperStruct)        // Our basic constructor.. we're going to need our asset name, and a WrapperStruct
        {
            WrapperStruct = wrapperStruct;                                                                                  // Our class-level instance of the WrapperStruct
            Asset = WrapperStruct.Content.Load<Texture2D>(asset);                                          // Use our WrapperStruct to set up our Asset for rendering
        }

        public void Render()                                                                                                        // A basic constructor for our Render method
        {            
            WrapperStruct.SpriteBatch.Begin(transformMatrix: transform);                                  // Start our Rendering run
                WrapperStruct.SpriteBatch.Draw(Asset, Position, Color.White);                              // Render this background's First tile
                WrapperStruct.SpriteBatch.Draw(Asset, Position2, Color.White);                            // Render this background's First tile
                WrapperStruct.SpriteBatch.Draw(Asset, Position3, Color.White);                            // Render this background's First tile
                WrapperStruct.SpriteBatch.Draw(Asset, Position4, Color.White);                            // Render this background's First tile
                WrapperStruct.SpriteBatch.Draw(Asset, Position5, Color.White);                            // Render this background's First tile
            WrapperStruct.SpriteBatch.End();                                                                                // End our Rendering run
        }

        public void Update(float speed)                                                                                      // A basic constructor for our Update method. In this instance, we are using what would normally
        {                                                                                                                                       // be the gameTime for the speed of our scrolling    
            transform = transform * Matrix.CreateTranslation((int)speed, 0, 0);                           // Update the transform Matrix based on the provided speed
        }
    }
}
