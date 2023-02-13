using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    #if UNITY_EDITOR
    [Multiline]
    public string developerDescription = "";
    #endif

    private readonly List<GameEventListener> _gameEventListeners = new List<GameEventListener>();

    public void Raise()
    {
        for (int i = _gameEventListeners.Count-1; i >= 0; i--)
        {
            _gameEventListeners[i].OnRaise();
        }
    }

    public void RegisterGameEventListener(GameEventListener listener)
    {
        if (!_gameEventListeners.Contains(listener))
        {
            _gameEventListeners.Add(listener); 
        }
    }

    public void UnregisterGameEventListener(GameEventListener listener)
    {
        if (_gameEventListeners.Contains(listener))
        {
            _gameEventListeners.Remove(listener);
        }
    }

}
