using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public float turnSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(turnSpeed * Time.deltaTime, Vector3.forward);
    }
}
