using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MissionScript : MonoBehaviour
{
    [SerializeField] GameObject buttonPressText;
    [SerializeField] GameObject missionManager;

    private bool isInRange;

    [SerializeField] GameObject grasslandDifficulty;
    [SerializeField] GameObject cavesDifficulty;
    [SerializeField] GameObject castleDifficulty;
    [SerializeField] GameObject mountainTopDifficulty;

    [SerializeField] TextMeshProUGUI Strength;
    [SerializeField] TextMeshProUGUI Intelligence;
    [SerializeField] TextMeshProUGUI Agility;
    [SerializeField] TextMeshProUGUI Robustness;


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

        Strength.text = "15 Strength";
        Intelligence.text = "40 Intelligence";
        Agility.text = "10 Agility";
        Robustness.text = "70 Robustness";
    }

    public void Caves()
    {
        cavesDifficulty.SetActive(true);
        grasslandDifficulty.SetActive(false);
        castleDifficulty.SetActive(false);
        mountainTopDifficulty.SetActive(false);

        Strength.text = "20 Strength";
        Intelligence.text = "42 Intelligence";
        Agility.text = "10 Agility";
        Robustness.text = "80 Robustness";
    }

    public void Castle()
    {
        castleDifficulty.SetActive(true);
        cavesDifficulty.SetActive(false);
        grasslandDifficulty.SetActive(false);
        mountainTopDifficulty.SetActive(false);

        Strength.text = "35 Strength";
        Intelligence.text = "44 Intelligence";
        Agility.text = "10 Agility";
        Robustness.text = "100 Robustness";
    }

    public void MountainTop()
    {
        mountainTopDifficulty.SetActive(true);
        castleDifficulty.SetActive(false);
        cavesDifficulty.SetActive(false);
        grasslandDifficulty.SetActive(false);

        Strength.text = "45 Strength";
        Intelligence.text = "47 Intelligence";
        Agility.text = "12 Agility";
        Robustness.text = "160 Robustness";
    }

    public void GrasslandEasy()
    {
        grassland = 1;
        caves = 0;
        castle = 0;
        mountainTop = 0;

        Strength.text = "15 Strength";
        Intelligence.text = "40 Intelligence";
        Agility.text = "10 Agility";
        Robustness.text = "70 Robustness";
    }

    public void GrasslandMedium()
    {
        grassland = 2;
        caves = 0;
        castle = 0;
        mountainTop = 0;

        Strength.text = "20 Strength";
        Intelligence.text = "44 Intelligence";
        Agility.text = "11 Agility";
        Robustness.text = "110 Robustness";
    }

    public void GrasslandHard()
    {
        grassland = 3;
        caves = 0;
        castle = 0;
        mountainTop = 0;

        Strength.text = "35 Strength";
        Intelligence.text = "47 Intelligence";
        Agility.text = "11 Agility";
        Robustness.text = "160 Robustness";
    }

    public void CavesEasy()
    {
        caves = 1;
        grassland = 0;
        castle = 0;
        mountainTop = 0;

        Strength.text = "20 Strength";
        Intelligence.text = "42 Intelligence";
        Agility.text = "10 Agility";
        Robustness.text = "80 Robustness";
    }

    public void CavesMedium()
    {
        caves = 2;
        grassland = 0;
        castle = 0;
        mountainTop = 0;

        Strength.text = "30 Strength";
        Intelligence.text = "46 Intelligence";
        Agility.text = "11 Agility";
        Robustness.text = "130 Robustness";
    }

    public void CavesHard()
    {
        caves = 3;
        grassland = 0;
        castle = 0;
        mountainTop = 0;

        Strength.text = "40 Strength";
        Intelligence.text = "47 Intelligence";
        Agility.text = "11 Agility";
        Robustness.text = "190 Robustness";
    }

    public void CastleEasy()
    {
        castle = 1;
        grassland = 0;
        caves = 0;
        mountainTop = 0;

        Strength.text = "35 Strength";
        Intelligence.text = "44 Intelligence";
        Agility.text = "10 Agility";
        Robustness.text = "100 Robustness";
    }

    public void CastleMedium()
    {
        castle = 2;
        grassland = 0;
        caves = 0;
        mountainTop = 0;

        Strength.text = "45 Strength";
        Intelligence.text = "47 Intelligence";
        Agility.text = "12 Agility";
        Robustness.text = "160 Robustness";
    }

    public void CastleHard()
    {
        castle = 3;
        grassland = 0;
        caves = 0;
        mountainTop = 0;

        Strength.text = "55 Strength";
        Intelligence.text = "50 Intelligence";
        Agility.text = "12 Agility";
        Robustness.text = "230 Robustness";
    }

    public void MountainTopEasy()
    {
        mountainTop = 1;
        grassland = 0;
        caves = 0;
        castle = 0;

        Strength.text = "45 Strength";
        Intelligence.text = "47 Intelligence";
        Agility.text = "12 Agility";
        Robustness.text = "160 Robustness";
    }

    public void MountainTopMedium()
    {
        mountainTop = 2;
        grassland = 0;
        caves = 0;
        castle = 0;

        Strength.text = "70 Strength";
        Intelligence.text = "47 Intelligence";
        Agility.text = "12 Agility";
        Robustness.text = "190 Robustness";
    }

    public void MountainTopHard()
    {
        mountainTop = 3;
        grassland = 0;
        caves = 0;
        castle = 0;

        Strength.text = "90 Strength";
        Intelligence.text = "52 Intelligence";
        Agility.text = "12 Agility";
        Robustness.text = "240 Robustness";
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

        if(caves == 1)
        {

        }

        if(caves == 2)
        {

        }

        if(caves == 3)
        {

        }

        if(castle == 1)
        {
            SceneManager.LoadScene("EasyCastle");
        }

        if (castle == 2)
        {
            SceneManager.LoadScene("MediumCastle");
        }

        if (castle == 3)
        {
            SceneManager.LoadScene("HardCastle");
        }

        if(mountainTop == 1)
        {
            SceneManager.LoadScene("EasyMountaintop");
        }


        if (mountainTop == 2)
        {
            SceneManager.LoadScene("MediumMountaintop");
        }


        if (mountainTop == 3)
        {
            SceneManager.LoadScene("HardMountaintop");
        }

    }

}
