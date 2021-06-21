using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundEffects : MonoBehaviour
{
    public void ThrowSoundEvent()
    {
        FindObjectOfType<AudioManager>().Play("SpearThrowSound");
    }

    public void SwordHitEvent()
    {
        FindObjectOfType<AudioManager>().Play("SwordSound1");
    }

    public void AttackEvent()
    {
        FindObjectOfType<AudioManager>().Play("AttackSound");
    }

    public void PlopEvent()
    {
        FindObjectOfType<AudioManager>().Play("PlopSound");
    }

    public void ImpactEvent()
    {
        FindObjectOfType<AudioManager>().Play("ImpactSound");
    }
}
