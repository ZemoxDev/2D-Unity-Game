using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceduralGenerationDead : MonoBehaviour
{
    [SerializeField]
    private string newLevel;

    public GameManager manager;
    public Animator transition;
    public float transitionTime = 1.2f;

    void Update()
    {
        if(manager.respawn == true)
        {
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        PlayerPrefs.SetInt("proceduralDeath", 1);

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(newLevel);
    }
}
