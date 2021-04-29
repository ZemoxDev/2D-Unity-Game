using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    [SerializeField]
    public Animator anim;

    [SerializeField]
    private GameObject deathBloodParticle;

    private GameManager GM;

    public PlayerCombatController PCC;
    public PlayerController PC;

    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(attacked == true)
            PC.camShake.Shake(0.2f, 0.4f);
    }

    private bool attacked;
    public void DecreaseHealth(float amount)
    {
        StartCoroutine(Attacked());
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }

        PlayerPrefs.SetFloat("health", maxHealth);
        PlayerPrefs.SetFloat("damage", PCC.attack1Damage);
        PlayerPrefs.SetFloat("speed", PC.movementSpeed);
        PlayerPrefs.SetFloat("intelligence", PC.dashSpeed);
    }

    public void Die()
    {
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
        GM.Respawn();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Spikes")
        {
            PlayerPrefs.SetFloat("health", maxHealth);
            PlayerPrefs.SetFloat("damage", PCC.attack1Damage);
            PlayerPrefs.SetFloat("speed", PC.movementSpeed);
            PlayerPrefs.SetFloat("intelligence", PC.dashSpeed);
            Die();
        }
    }

    IEnumerator Attacked()
    {
        attacked = true;

        yield return new WaitForSeconds(0.5f);

        attacked = false;
    }
}
