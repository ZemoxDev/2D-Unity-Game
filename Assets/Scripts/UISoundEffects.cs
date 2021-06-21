using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundEffects : MonoBehaviour
{
    public void HoverSoundEvent()
    {
        FindObjectOfType<AudioManager>().Play("HoverSound");
    }

    public void SelectSoundEvent()
    {
        FindObjectOfType<AudioManager>().Play("UISelectSound");
    }
}
