﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool firstDoorKey = false;
    public bool internalDoorKey;
    public static bool leftEye = false;
    public static bool rightEye = false;

    void Update()
    {
        internalDoorKey = firstDoorKey;
    }
}
