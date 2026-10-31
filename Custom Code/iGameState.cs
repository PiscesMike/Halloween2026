
namespace Halloween2027
{
    // An interface for our GameState. For this particular project, this is actually a bit of overkill since there is only one state, but it's a good practice to have it just in
    // case we decide later we do want to add a few different things

    /*
     * An interface in C# is a reference type that defines a strict contract of methods, properties, events, or indexers without providing their actual implementation details. 
     * Any class, struct, or record that implements an interface is legally bound to provide the execution logic for its members. Interfaces are a foundational pillar of 
     * object-oriented programming in C#, primarily used to achieve polymorphism, support mock-based unit testing, decouple software components, and allow a single
     * class to implement multiple behaviors (since C# does not support multiple inheritance for classes).
    */

    internal interface iGameState                         // Our basic interface constructor
    {
        public void Update(float gameTime);         // A GameState will require Updating, of course. Define it to accept gameTime so we're mirroring the standard game loop
        public void Render();                                  // A GameState will require a Render method as well of course, so we can draw things to the display
    }
}
