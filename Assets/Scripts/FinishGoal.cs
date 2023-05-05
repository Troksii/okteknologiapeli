using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishGoal : MonoBehaviour
{
    [SerializeField] private GameObject stats;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SaveManager.instance.DeleteSaveData();
            Time.timeScale = 0;
            stats.SetActive(true);
        }
    }
}
