using System.Collections.Generic;
using UnityEngine;


namespace EventChannel
{
    public abstract class EventChannel<T> : ScriptableObject
    {
        readonly HashSet<EventListener<T>> listeners = new();

        // Replace with a EventManager class to persistently store the state of the event
        [System.NonSerialized]
        private bool isInvoked = false;

        public void Invoke(T value)
        {
            isInvoked = true;
            foreach (var listener in listeners)
            {
                listener.Raise(value);
            }
        }

        public void Register(EventListener<T> listener) => listeners.Add(listener);
        public void Unregister(EventListener<T> listener) => listeners.Remove(listener);
        public bool IsInvoked() => isInvoked;
    }
}