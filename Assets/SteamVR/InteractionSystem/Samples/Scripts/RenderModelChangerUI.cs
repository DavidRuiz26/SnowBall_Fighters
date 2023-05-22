﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class RenderModelChangerUI : UIElement
    {
        public GameObject leftPrefab;
        public GameObject rightPrefab;

        protected SkeletonUIOptions ui;

        protected override void Awake()
        {
            base.Awake();

            ui = this.GetComponentInParent<SkeletonUIOptions>();
        }

        protected override void OnButtonClick()
        {
            base.OnButtonClick();

            if (ui != null)
            {
                ui.SetRenderModel(this);
            }
        }
    }
}