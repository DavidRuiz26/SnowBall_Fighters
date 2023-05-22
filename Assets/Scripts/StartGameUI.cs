//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StartGameUI : UIElement
{
    public GameObject spawnZone;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        spawnZone.GetComponent<SpawnZone>().Activate();
    }
}
