using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] private AudioSource itemCollect;

    private int bananaCount = 0;

    [SerializeField] private Text bananaText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananaCount++;
            bananaText.text = "Bananas: " + bananaCount;
            itemCollect.Play();
        }
    }
}
