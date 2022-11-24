using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    public int points = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Point")
        {

            points++;
            Destroy(col.gameObject);
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Points: " + points, style);
    }
}
