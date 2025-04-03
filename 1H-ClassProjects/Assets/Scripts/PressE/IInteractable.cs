
/// <summary>
/// Interface for things to interact with
/// Every game object you can interact with should implement this interface
/// Therefore you can address them in a uniform way:
/// - if the game object has a component of type IInteractable (or: a component that implements IInteractable)
///   - then, that object _will_ have a function called Interact that you can call.
/// </summary>
public interface IInteractable
{
    void Interact();
}
