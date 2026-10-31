using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Halloween2027
{
    public struct WrapperStruct                                             // A basic Struct constructor
    {
        public GraphicsDeviceManager Graphics;                   // We're going to need our GraphicsDeviceManager
        public ContentManager Content;                                // We're also going to need the ContentManager for managing assets
        public SpriteBatch SpriteBatch;                                    // And lastly, we need the SpriteBatch so we can draw things to the display
    }
}
