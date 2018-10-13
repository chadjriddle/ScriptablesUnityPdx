namespace Scriptables.GameEvents
{
    public interface IHasEventRaised<in T>
    {
        void OnEventRaised(T value);
    }
}