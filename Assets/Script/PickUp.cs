using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime);
    }
}
