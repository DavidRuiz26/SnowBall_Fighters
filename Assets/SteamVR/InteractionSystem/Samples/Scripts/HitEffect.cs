//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class HitEffect : MonoBehaviour
    {
        public Collider targetCollider;

        public Collider floorCollider;

        public Collider enemiesCollider;

        public GameObject spawnObjectOnCollision;

        public bool colorSpawnedObject = true;

        public bool destroyOnTargetCollision = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider == targetCollider || collision.collider == floorCollider)
            {
                Efectos(collision);

                if (destroyOnTargetCollision)
                {
                    var newBall = GameObject.Instantiate(gameObject);
                    newBall.transform.position = new Vector3(1, 1, 1);
                    Destroy(this.gameObject);
                }

            }
            else if (collision.collider == enemiesCollider)
            {
                Efectos(collision);

                if (destroyOnTargetCollision)
                {
                    var newBall = GameObject.Instantiate(gameObject);
                    newBall.transform.position = new Vector3(1, 1, 1);
                    Destroy(this.gameObject);
                    //TODO: Añadir el gameOBject del enemigo
                    //Destroy(enemyGameObject); 
                }
            }
        }
        public void Efectos(Collision collision)
        {
            ContactPoint contact = collision.contacts[0];
            RaycastHit hit;

            float backTrackLength = 1f;
            Ray ray = new Ray(contact.point - (-contact.normal * backTrackLength), -contact.normal);
            if (collision.collider.Raycast(ray, out hit, 2))
            {
                if (colorSpawnedObject)
                {
                    Renderer renderer = collision.gameObject.GetComponent<Renderer>();
                    Texture2D tex = (Texture2D)renderer.material.mainTexture;
                    Color color = tex.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);

                    if (color.r > 0.7f && color.g > 0.7f && color.b < 0.7f)
                        color = Color.yellow;
                    else if (Mathf.Max(color.r, color.g, color.b) == color.r)
                        color = Color.red;
                    else if (Mathf.Max(color.r, color.g, color.b) == color.g)
                        color = Color.green;
                    else
                        color = Color.yellow;

                    color *= 15f;

                    GameObject spawned = GameObject.Instantiate(spawnObjectOnCollision);
                    spawned.transform.position = contact.point;
                    spawned.transform.forward = ray.direction;

                    Renderer[] spawnedRenderers = spawned.GetComponentsInChildren<Renderer>();
                    for (int rendererIndex = 0; rendererIndex < spawnedRenderers.Length; rendererIndex++)
                    {
                        Renderer spawnedRenderer = spawnedRenderers[rendererIndex];
                        spawnedRenderer.material.color = color;
                        if (spawnedRenderer.material.HasProperty("_EmissionColor"))
                        {
                            spawnedRenderer.material.SetColor("_EmissionColor", color);
                        }
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 5, true);
        }
    }
}