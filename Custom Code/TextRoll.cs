using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Halloween2027
{
    internal class TextRoll
    {
        Texture2D Asset;                                                                                                                                            // Something to hold our asset
        Rectangle Position;                                                                                                                                        // Something to hold our Position
        WrapperStruct WrapperStruct;                                                                                                                      // Something to hold a class-level WrapperStruct reference

        public TextRoll(string asset, WrapperStruct wrapperStruct, int offset)                                                          // Basic constructor for our TextRoll
        {
            WrapperStruct = wrapperStruct;                                                                                                               // Setup our copy of the WrapperStruct
            Asset = WrapperStruct.Content.Load<Texture2D>(asset);                                                                       // Use the WrapperStruct to load in our asset for rendering

            // Going to need to center the text on the display based on the display width, and the width of the text asset

            int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;                                   // Get our current display width
            int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;                                 // Get our current display height

            int horizontalPosition = (screenWidth / 2) - (Asset.Width / 2);                                                                 // Calculate the center of the display for our text using it's width for the proper placement
            screenHeight += (screenHeight / 2) * offset;                                                                                            // This will allow us to spread out the different text displays horizontally based on the provided offset

            Position = new Rectangle(horizontalPosition, screenHeight, Asset.Width, Asset.Height);                        // Define the location where we're going to draw our text on the display
        }

        public void Update()                                                                                                                                      // Basic constructor for our Update method
        {
            Position.Y = (int)(Position.Y - 2.5f);                                                                                                            // We're going to be scrolling the text up, off the top of the display, so reduce the vertical position
            Position = new Rectangle(Position.X, Position.Y, Asset.Width, Asset.Height);                                           // Update our position rectangle so we actually scroll the text
        }

        public void Render()                                                                                                                                      // Basic constructor for our Render method
        {
            WrapperStruct.SpriteBatch.Begin();                                                                                                           // Start our Rendering run
            WrapperStruct.SpriteBatch.Draw(Asset, Position, Color.White);                                                                // Render the current asset using the calculated position
            WrapperStruct.SpriteBatch.End();                                                                                                              // End our Rendering run
        }
    }
}
