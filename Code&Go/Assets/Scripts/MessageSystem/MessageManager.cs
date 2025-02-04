﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MSG_TYPE
{
    MOVE_LASER, MOVE, ROTATE_LASER, ROTATE, CHANGE_INTENSITY, ACTIVATE_DOOR, CELL_OCCUPIED, CODE_END,
    
    // Mensajes de control
    NUM_OF_TOP_BLOCKS, TOTAL_NUM_OF_BLOCKS, SUBMITTED_CODE
};

public class MessageManager : MonoBehaviour
{
    public static MessageManager Instance = null;

    private List<Listener> listeners;

    private void Awake()
    {
        if (Instance != null) return;

        Instance = this;
        DontDestroyOnLoad(gameObject);
        listeners = new List<Listener>();
    }

    public void SubscribeListener(Listener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnsubscribeListener(Listener listener)
    {
        listeners.Remove(listener);
    }

    public void SendMessage(string msg, MSG_TYPE type)
    {
        foreach (Listener l in listeners)
            l.ReceiveMessage(msg, type);
    }

    public bool SendBoolMessage(string msg, MSG_TYPE type)
    {
        int i = 0;
        while (i < listeners.Count && listeners[i].ReceiveBoolMessage(msg, type))
            i++;
        return i >= listeners.Count;
    }
}
