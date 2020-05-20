using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermiYokEt : MonoBehaviour
{
    void OnCollisionExit(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
