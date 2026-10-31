using System.Collections.Generic;

namespace Halloween2027
{
    internal class StateManager
    {
        iGameState CurrentState;                                                                                                                              // Need to know the current game state
        List<iGameState> States = new List<iGameState>();                                                                                   // Need to know which states we're going to be using 

        public StateManager(iGameState currentState, List<iGameState> states)                                                   // Our Constructor
        {
            CurrentState = currentState;                                                                                                                     // Set the CurrentState
            States.AddRange(states);                                                                                                                          // Add the states to our internal list<iGameState>
        }

        public void Update(float gameTime)                                                                                                            // A basic constructor for our Update method.
        {
            CurrentState.Update(gameTime);                                                                                                             // Update the CurrentState
        }

        public void Render()                                                                                                                                     // A basic constructor for our Render method.
        {
            CurrentState.Render();                                                                                                                              // Render the CurrentState, our favorite
        }
    }
}
