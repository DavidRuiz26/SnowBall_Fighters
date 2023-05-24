//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class EndGameUI : UIElement
{
    public GameObject spawnZone;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
