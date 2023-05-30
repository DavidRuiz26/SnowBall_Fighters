//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StartGameUI : UIElement
{
    public GameObject spawnZone;
	public GameObject startMenu;
	
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        startMenu.SetActive(false);
        spawnZone.GetComponent<SpawnZone>().Activate();
    }
}
