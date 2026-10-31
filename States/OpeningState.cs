using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Halloween2027
{
    internal class OpeningState : iGameState
    {
        WrapperStruct WrapperStruct;                                                                                                                // Going to need a class-level reference to the WrapperStruct

        List<OpeningStateBackgroundLayer> backgroundLayers = new List<OpeningStateBackgroundLayer>();           // Create a list to hold all the parallax background layers

        List<Ghost> ghosts1 = new List<Ghost>();                                                                                           // Create a list to hold our floating, fading in and out ghosts
        List<Ghost> ghosts2 = new List<Ghost>();                                                                                           // Create another list for a second set of ghosts - we're going to render them
                                                                                                                                                                        // between background layers so they give the illusion of ghost depth(s)
        List<TextRoll> textRoll = new List<TextRoll>();                                                                                      // Create a list to hold the assets for our scrolling text

        Texture2D FadeToBlack;                                                                                                                          // At the end, we're going to fade to black, so let's set up a Texture2D  for that

        bool paused = true;                                                                                                                                // Need to keep track if we're paused or not
        bool Fade = false;                                                                                                                                   // Is it time to fade to black

        float timer = 0.0f;                                                                                                     // Need to track our runtime so we can introduce events at specific times. Timer is used as a
                                                                                                                                         // trigger to track the passage of seconds

        float activeTime = 0.0f;                                                                                                                           // activeTime is the time the game has been running without being paused
        float alpha = 0.0f;                                                                                                                                   // Transparancy setting for our Fade to Black Asset

        public OpeningState(WrapperStruct wrapperStruct)
        {
            WrapperStruct = wrapperStruct;                                                                                                                 // Create a local copy of the WrapperStruct
            FadeToBlack = WrapperStruct.Content.Load<Texture2D>("Fade");                                                            // Load up our Fade to Black asset, just a huge black rectangle

            // Now we need to add all the objects we will be rendering to the various lists we just setup. For the backgroundLayers, these will be rendered using the painter's
            // algorith, so make sure to add them in the correct order (IE: the farthest away goes first, and closer items go last, in proper order)
            backgroundLayers.Add(new OpeningStateBackgroundLayer("Sky", WrapperStruct));
            backgroundLayers.Add(new OpeningStateBackgroundLayer("B1", WrapperStruct));
            backgroundLayers.Add(new OpeningStateBackgroundLayer("B3", WrapperStruct));
            backgroundLayers.Add(new OpeningStateBackgroundLayer("B2", WrapperStruct));
            backgroundLayers.Add(new OpeningStateBackgroundLayer("B4", WrapperStruct));

            // Add our ghosts for the first list
            ghosts1.Add(new Ghost("G1", WrapperStruct));
            ghosts1.Add(new Ghost("G2", WrapperStruct));
            ghosts1.Add(new Ghost("G3", WrapperStruct));
            ghosts1.Add(new Ghost("G4", WrapperStruct));
            ghosts1.Add(new Ghost("G5", WrapperStruct));
            ghosts1.Add(new Ghost("G1", WrapperStruct));
            ghosts1.Add(new Ghost("G2", WrapperStruct));
            ghosts1.Add(new Ghost("G3", WrapperStruct));
            ghosts1.Add(new Ghost("G4", WrapperStruct));
            ghosts1.Add(new Ghost("G5", WrapperStruct));

            // Add our ghosts for the second list
            ghosts2.Add(new Ghost("G1", WrapperStruct));
            ghosts2.Add(new Ghost("G2", WrapperStruct));
            ghosts2.Add(new Ghost("G3", WrapperStruct));
            ghosts2.Add(new Ghost("G4", WrapperStruct));
            ghosts2.Add(new Ghost("G5", WrapperStruct));
            ghosts2.Add(new Ghost("G1", WrapperStruct));
            ghosts2.Add(new Ghost("G2", WrapperStruct));
            ghosts2.Add(new Ghost("G3", WrapperStruct));
            ghosts2.Add(new Ghost("G4", WrapperStruct));
            ghosts2.Add(new Ghost("G5", WrapperStruct));

            // Add all the assets for our text scrolling. Again, these will appear in the order they are added, so add them as you want them to appear. The additional number at the end of the 
            // TextRoll definition specifies a multiplier for how far appart each of the assets will be
            textRoll.Add(new TextRoll("Thanks", WrapperStruct, 0));
            textRoll.Add(new TextRoll("RBWhitaker", WrapperStruct, 3));
            textRoll.Add(new TextRoll("Apetus", WrapperStruct, 4));
            textRoll.Add(new TextRoll("MooCow", WrapperStruct, 5));
            textRoll.Add(new TextRoll("Lucan", WrapperStruct, 6));
            textRoll.Add(new TextRoll("nkast", WrapperStruct, 7));
            textRoll.Add(new TextRoll("Rhaven67854", WrapperStruct, 8));
            textRoll.Add(new TextRoll("EX (UNRL)", WrapperStruct, 9));
            textRoll.Add(new TextRoll("U-511", WrapperStruct, 10));
            textRoll.Add(new TextRoll("Cosmic Sloth", WrapperStruct, 11));
            textRoll.Add(new TextRoll("Spec-Chum", WrapperStruct, 12));
            textRoll.Add(new TextRoll("paptreek", WrapperStruct, 13));
            textRoll.Add(new TextRoll("Alice", WrapperStruct, 14));
            textRoll.Add(new TextRoll("Nolin", WrapperStruct, 15));
            textRoll.Add(new TextRoll("PiscesMike", WrapperStruct, 16));
            textRoll.Add(new TextRoll("2027", WrapperStruct, 17));
            textRoll.Add(new TextRoll("Halloween", WrapperStruct, 18));
        }

        public void Render()                                                                     // A basic constructor for our Render() method
        {
            backgroundLayers[0].Render();                                                // Render the first background layer

            foreach (Ghost thisGhost in ghosts2) { thisGhost.Render(); }   // Render the ghosts from the second Ghost list right after the background layer that is the farthest away

            backgroundLayers[1].Render();                                                 // Render the Second background layer

            foreach (Ghost thisGhost in ghosts1) { thisGhost.Render(); }   // Render the ghosts from the first Ghost list right after the second background layer

            backgroundLayers[2].Render();                                                 // Render the third background layer
            backgroundLayers[3].Render();                                                 // Render the fourth background layer
            backgroundLayers[4].Render();                                                 // Render the fifth background layer

            foreach (TextRoll thisText in textRoll) { thisText.Render(); }       // Render our scrolling text(s)

            WrapperStruct.SpriteBatch.Begin();                                          // Start our Rendering run
                WrapperStruct.SpriteBatch.Draw(FadeToBlack, new Rectangle(0, 0, 1920, 1080), Color.White * alpha);      // Render our large, black rectanlge. Completely transparent until the end
            WrapperStruct.SpriteBatch.End();                                            // End our Rendering run
        }

        public void Update(float gameTime)                                           // A basic constructor for our Update() method
        {
            timer += gameTime;                                                               // Update our timer float so we can track the running time

            if (Fade) alpha += 0.005f;                                                        // If the Fade boolean has been triggered, increase our alpha value so we go opaque

            if (timer > 1000)                                                                      // Check to see if a full second has passed. If so, increase our activeTime seconds count
            {
                if (!paused) activeTime++;                                                  // Track our activeTime while the game is actually running (not paused)
                timer = 0;                                                                            // Reset our timer trigger so we can track the passage of the next second
            }

            KeyboardState currentKeyState = Keyboard.GetState();         // Get our current KeyState so we can check for user input

            if (currentKeyState.IsKeyDown(Keys.Space)) paused = !paused;    // If the space key has been pressed, changed our paused state

            if (paused) return;                                                                   // If we ARE paused, we simply return and stop any further processing

            float i = -1;                                                                             // We are using a dirty trick here. Each background layer needs to scroll at a different rate. Stuff the farthest away needs to be
                                                                                                           // the slowest, while stuff at the front faster. So, we start moving at 1 pixel to the left (position.Y -1), and each successive pass
            foreach (OpeningStateBackgroundLayer thisBackground in backgroundLayers)        // thru the list, we increase the value that we're moving by 1
            {
                thisBackground.Update(i);                                                 // Update the current backgroud layer
                i--;                                                                                      // Increase the speed of scroll by increasing the number of pixels we move each iteration. This is a negative number since we
            }                                                                                             // are moving to the left

            foreach (Ghost thisGhost in ghosts1) { thisGhost.Update(gameTime); }        // Update the ghosts in the first ghosts list

            foreach (Ghost thisGhost in ghosts2) { thisGhost.Update(gameTime); }        // Update the ghosts in the first ghosts list

            foreach (TextRoll thisText in textRoll) { thisText.Update(); }                             // Update the textRolls in the textRolls list

            if (activeTime == 57) Fade = true;                                                                 // Last Text Roll clears the screen at 60 so we need to trigger the Fade to Black
            if (activeTime == 61) Environment.Exit(0);                                                     // We've finished fading to black after 4 seconds, lets exit this badboy!
        }
    }
}
