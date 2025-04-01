using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinManager : MonoBehaviour
{
    public SkinInstance skinInst;
    public Renderer sphereRend;

    void Start()
    {
        if (sphereRend == null)
        {
            sphereRend = GetComponent<Renderer>();
        }   
    }

    public void ChangeSkin(int m)
    {
        Skin skin = skinInst.GetSkin(m);
        sphereRend.material = skin.skinMaterial;
    }
}
