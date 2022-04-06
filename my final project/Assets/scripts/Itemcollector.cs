using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemcollector : MonoBehaviour
{
    [SerializeField] private Text MelonsText;
    private int melons = 0;
    [SerializeField] private AudioSource collectionSoundEffects;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            collectionSoundEffects.Play();
            Destroy(collision.gameObject);
            melons++;
            Debug.Log("melons: " + melons);
            MelonsText.text = "Melons: " + melons;
        }
    }
}
