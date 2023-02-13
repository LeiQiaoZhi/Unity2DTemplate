using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("The event to listen to")]
    public GameEvent @event;

    [Tooltip("The response once the event is raised")]
    public UnityEvent response;

    private void OnEnable()
    {
        @event.RegisterGameEventListener(this);
    }

    private void OnDisable()
    {
        @event.UnregisterGameEventListener(this);
    }

    public void OnRaise()
    {
        response.Invoke();
    }
}
