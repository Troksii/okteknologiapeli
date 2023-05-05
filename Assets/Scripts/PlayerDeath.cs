using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private GameMaster gameMaster;
    public  Movement playerScript;
    private float _respawnTime;
    private bool isDead;
    public int deathCounter;


    private void Start()
    {   
        isDead = false;
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void Update() 
    {
        if (isDead) {   
        Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject enemy = GameObject.FindWithTag("Enemy");
        if (collision.gameObject.CompareTag("Enemy"))
        {
                isDead = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void Die()
     {
        isDead = false;
        SaveManager.instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }

    private void LoadLastCheckpoint()
    {
        player.transform.position = gameMaster.lastCheckpointPosition;
        anim.SetTrigger("life");
    }

}
