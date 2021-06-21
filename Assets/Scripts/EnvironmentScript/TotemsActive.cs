using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemsActive : MonoBehaviour
{
    public GameObject totem1;
    public GameObject totem2;
    public GameObject totem3;
    public GameObject totem4;
    public GameObject totem5;

    public GameObject rotatingPortal;

    void Update()
    {
        if(totem1.active == true && totem2.active == true && totem3.active == true && totem4.active == true && totem5.active == true)
        {
            rotatingPortal.SetActive(true);
        }
    }
}
