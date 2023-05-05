using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointalt : MonoBehaviour
{
    private GameMaster gameMaster;
    private SpriteRenderer spriteRend;
    public GameObject player;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Color.red;
        
        if(SaveManager.instance.hasLoaded)
        {
            //tee if else jokaiselle movement scriptille tai muuta uusin toimimaan meressä
            gameMaster.lastCheckpointPosition = SaveManager.instance.activeSave.respawnPosition;
            Movement.instance.transform.position = gameMaster.lastCheckpointPosition;
            player.GetComponent<itemCollection>().itemText.text = SaveManager.instance.activeSave.items.ToString();
            player.GetComponent<itemCollection>().items = SaveManager.instance.activeSave.items;
        }
      

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spriteRend.color = Color.green;
            
            gameMaster.lastCheckpointPosition = transform.position;

            SaveManager.instance.activeSave.items = player.GetComponent<itemCollection>().items;
            
            SaveManager.instance.activeSave.respawnPosition = transform.position;

            SaveManager.instance.Save();

            Debug.Log("checkpoint");
            
        }
    }
}

