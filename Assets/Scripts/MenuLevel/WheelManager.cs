﻿using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public int speed = 30;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
