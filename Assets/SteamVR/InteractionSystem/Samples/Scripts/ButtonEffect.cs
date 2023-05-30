//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect : MonoBehaviour
    {
        public int maxBalls = 21;

        public void OnButtonDown(Hand fromHand)
        {
            ColorSelf(Color.cyan);
            //fromHand.TriggerHapticPulse(1000);
        }

        public void OnButtonUp(Hand fromHand)
        {
            ColorSelf(Color.white);
        }

        public async void GenerateBalls(Hand fromHand)
        {
            var balls = GameObject.FindGameObjectsWithTag("Ball");
            var ball = GameObject.FindGameObjectWithTag("Ball");

            if (balls.Length < maxBalls)
            {
                var newBall = GameObject.Instantiate(ball);
                Debug.Log(gameObject.transform.position);
                Debug.Log(gameObject.transform.name);
                Debug.Log(gameObject.transform.position - gameObject.transform.localPosition);
                newBall.transform.position = (gameObject.transform.position - gameObject.transform.localPosition) + new Vector3(-1, 1.25f, -1f);
            }
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}