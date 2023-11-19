using UnityEngine;


namespace EventChannel
{
    public readonly struct EmptyEvent { }

    [CreateAssetMenu(menuName = "Events/EventChannel")]
    public class EmptyEventChannel : EventChannel<EmptyEvent> { }

}