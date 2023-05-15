using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    //[SerializeField]
    //private GameObject target;

    // Update is called once per frame
    void Update()
    {
        var target = GameObject.FindGameObjectWithTag("Player");

        Vector3 targetOrientation = target.transform.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.red);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
}
