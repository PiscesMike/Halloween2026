using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Halloween2027
{
    internal class Ghost
    {
        WrapperStruct WrapperStruct;                                                                                // Need a local copy of our WrapperStruct
        Texture2D Asset;                                                                                                      // Something to hold our asset
        Rectangle Position;                                                                                                  // A rectangle for our display space (where the asset will appear on screen in display space)

        Random Random = new Random();                                                                       // Initialize our random class so we can generate some Randomish numbers

        float alphaSpeed;                                                                                                    // Used to track how FAST the ghosts fade in and out
        float myAlpha = 0.5f;                                                                                              // Used to track our actual transparency level, defaults to semi-transparent
        float timer = 0.0f;                                                                                                    // Used to track the gameTime for regulating the transparancy speed(s)

        Vector2 Velocity;                                                                                                     // Used to track the direction and speed our ghost is travelling

        public Ghost(string asset, WrapperStruct wrapperStruct)                                      // A basic constructor for our Ghost object
        {
            WrapperStruct= wrapperStruct;                                                                         // A class-level instance of our Wrapper Struct, used for assets and rendering
            Asset = WrapperStruct.Content.Load<Texture2D>(asset);                                // Set up our Texture2D so it's ready for rendering in our spriteBatch.Draw below

            Position = new Rectangle(Random.Next(1800), Random.Next(900), Asset.Width / 8, Asset.Height / 8);       // Generate a random location for this ghost, within our display resolution
            Velocity = new Vector2(Random.Next(3), Random.Next(3));                                                                          // Generate a random direction and speed for this Ghost

            if (Velocity.X <= 2) Velocity.X = 2.8f;                                                                 // A bit of a safety net intended to keep this Ghost from moving in a straight line
            if (Velocity.Y <= 2) Velocity.Y = -2.8f;                                                                // A bit of a safety net intended to keep this Ghost from moving in s straight line

            alphaSpeed = (float)(Random.Next(5) + 1) / 100;                                             // Generate a random speed for the transparancy fading effect
        }

        public void Update(float gameTime)                                                                     // Our Update method's definition
        {
            if (myAlpha <= 0.0f || myAlpha >= 1.0f) alphaSpeed = -alphaSpeed;              // If we're fully transparent, or fully opaque, reverse the transparancy modifier so it reverses the effect
                                                                                                                                       // IE: If we're fading OUT, start fading IN... If we're fading IN, start fading OUT
            timer += gameTime;                                                                                          // Update our time with the gameTime tick

            if (timer > 50f)                                                                                                    // If we've hit 50ms we need to reset the timer and update our myAlpha for transparency
            {
                timer = 0;                                                                                                       // Reset our timer so we can start counting again
                myAlpha += alphaSpeed;                                                                              // Update our myAlpha so we fade in and out
            }

            if (Position.X > 1850) Velocity.X = -Velocity.X;                                                   // A bit of a safety net intended to keep this Ghost from going out of display bounds
            if (Position.X < 100) Velocity.X = -Velocity.X;                                                     // A bit of a safety net intended to keep this Ghost from going out of display bounds
            if (Position.Y > 950) Velocity.Y = -Velocity.Y;                                                     // A bit of a safety net intended to keep this Ghost from going out of display bounds
            if (Position.Y < 100) Velocity.Y = -Velocity.Y;                                                     // A bit of a safety net intended to keep this Ghost from going out of display bounds

            Position.Offset(Velocity);                                                                                    // Update our Position rectangle by using it's Offset Method with our current Velocity
        }

        public void Render()                                                                                               // Basic Render() Constructor
        {
            WrapperStruct.SpriteBatch.Begin();                                                                    // Start our Rendering run
                WrapperStruct.SpriteBatch.Draw(Asset, Position, Color.White * myAlpha);   // Go ahead and draw this Ghost
            WrapperStruct.SpriteBatch.End();                                                                       // End our Rendering run
        }
    }
}
