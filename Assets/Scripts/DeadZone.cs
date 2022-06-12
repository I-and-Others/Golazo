using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.LogWarning(other.gameObject.tag);
        other.gameObject.transform.position = new Vector3( 0, 0.16f, 0 );
    }
}
