using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionScript : MonoBehaviour
{
    [SerializeField] GameObject buttonPressText;
    [SerializeField] GameObject missionManager;

    private bool isInRange;

    [SerializeField] GameObject grasslandDifficulty;
    [SerializeField] GameObject cavesDifficulty;
    [SerializeField] GameObject castleDifficulty;
    [SerializeField] GameObject mountainTopDifficulty;

    private int grassland;
    private int caves;
    private int castle;
    private int mountainTop;


    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            missionManager.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            buttonPressText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
            buttonPressText.SetActive(false);
            missionManager.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Grassland()
    {
        grasslandDifficulty.SetActive(true);
        cavesDifficulty.SetActive(false);
        castleDifficulty.SetActive(false);
        mountainTopDifficulty.SetActive(false);
    }

    public void Caves()
    {
        cavesDifficulty.SetActive(true);
        grasslandDifficulty.SetActive(false);
        castleDifficulty.SetActive(false);
        mountainTopDifficulty.SetActive(false);
    }

    public void Castle()
    {
        castleDifficulty.SetActive(true);
        cavesDifficulty.SetActive(false);
        grasslandDifficulty.SetActive(false);
        mountainTopDifficulty.SetActive(false);
    }

    public void MountainTop()
    {
        mountainTopDifficulty.SetActive(true);
        castleDifficulty.SetActive(false);
        cavesDifficulty.SetActive(false);
        grasslandDifficulty.SetActive(false);
    }

    public void GrasslandEasy()
    {
        grassland = 1;
        caves = 0;
        castle = 0;
        mountainTop = 0;
    }

    public void GrasslandMedium()
    {
        grassland = 2;
        caves = 0;
        castle = 0;
        mountainTop = 0;
    }

    public void GrasslandHard()
    {
        grassland = 3;
        caves = 0;
        castle = 0;
        mountainTop = 0;
    }

    public void CavesEasy()
    {
        caves = 1;
        grassland = 0;
        castle = 0;
        mountainTop = 0;
    }

    public void CavesMedium()
    {
        caves = 2;
        grassland = 0;
        castle = 0;
        mountainTop = 0;
    }

    public void CavesHard()
    {
        caves = 3;
        grassland = 0;
        castle = 0;
        mountainTop = 0;
    }

    public void CastleEasy()
    {
        castle = 1;
        grassland = 0;
        caves = 0;
        mountainTop = 0;
    }

    public void CastleMedium()
    {
        castle = 2;
        grassland = 0;
        caves = 0;
        mountainTop = 0;
    }

    public void CastleHard()
    {
        castle = 3;
        grassland = 0;
        caves = 0;
        mountainTop = 0;
    }

    public void MountainTopEasy()
    {
        mountainTop = 1;
        grassland = 0;
        caves = 0;
        castle = 0;
    }

    public void MountainTopMedium()
    {
        mountainTop = 2;
        grassland = 0;
        caves = 0;
        castle = 0;
    }

    public void MountainTopHard()
    {
        mountainTop = 3;
        grassland = 0;
        caves = 0;
        castle = 0;

    }

    public void Play()
    {
        if(grassland == 1)
        {
            SceneManager.LoadScene("EasyGrassland");
        }

        if (grassland == 2)
        {
            SceneManager.LoadScene("MediumGrassland");
        }

        if (grassland == 3)
        {
            SceneManager.LoadScene("HardGrassland");
        }
    }

}
