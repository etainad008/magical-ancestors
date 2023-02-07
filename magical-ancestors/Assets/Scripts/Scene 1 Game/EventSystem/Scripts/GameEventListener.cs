using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CustomGameEvent : UnityEvent<Component, object> { }

public class GameEventListener : MonoBehaviour
{

    [Tooltip("Event to register with.")]
    public GameEvent gameEvent;

    [Tooltip("Response to invoke when Event with GameData is raised.")]
    public CustomGameEvent response;

    private void OnEnable()
    {
        if (gameEvent != null)
        {
            gameEvent.RegisterListener(this);
        }
        else
        {
            Debug.LogWarning("GameEvent not assigned for GameEventListener on gameObject " + gameObject.name);
        }
    }

    private void OnDisable()
    {
        if (gameEvent != null)
        {
            gameEvent.UnregisterListener(this);
        }
        else
        {
            Debug.LogWarning("GameEvent not assigned for GameEventListener on gameObject " + gameObject.name);
        }
    }

    public void OnEventRaised(Component sender, object data)
    {
        response.Invoke(sender, data);
    }

}

