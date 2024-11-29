using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ScrollingBG : MonoBehaviour
{
    public Renderer TheRenderer;
    public float Speed = 1;
    // Update is called once per frame
    void Update()
    {
       TheRenderer.material.mainTextureOffset += new Vector2(0, Speed*Time.deltaTime);
    }
}
