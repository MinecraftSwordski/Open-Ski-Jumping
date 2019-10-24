﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ListDisplayElement : MonoBehaviour
{
    public ListDisplay listDisplay;
    public int index;
    public void OnValueChanged(bool flag)
    {
        // Debug.Log("Index: " + index);
        if (flag)
        {
            listDisplay.OnListElementClick(index);
        }
    }
}