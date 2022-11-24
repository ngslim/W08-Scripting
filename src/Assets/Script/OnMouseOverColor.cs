using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverColor : MonoBehaviour
{
    MeshRenderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void OnMouseOver()
    {
        ChangeColor();
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    void ChangeColor()
    {
        renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
