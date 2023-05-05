using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollection : MonoBehaviour
{
    public int items;

    [SerializeField] public Text itemText;
    //clamStats used upon level complete in stat screen
    [SerializeField] private Text itemStats;

    void start()
    {
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            items++;
            itemText.text = items.ToString();
            itemStats.text = items.ToString();
        }
    }
}
