using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCamera : MonoBehaviour
{
    public Transform head;
    public GameObject menu;
    public InputActionProperty showButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized;

        menu.transform.LookAt(new Vector3( head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1; 
    }
}

