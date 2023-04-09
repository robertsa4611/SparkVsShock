using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private AudioSource[] sound;
        private AudioSource shoeSound;
        private AudioSource coinSound;
    public static int shoes = 0;
    private int coins = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private Image customImage1;
    [SerializeField] private Image customImage2;
    [SerializeField] private Text doubleJumpText;

    private void Start()
    {
        sound = GetComponents<AudioSource>();
        shoeSound = sound [0];
        coinSound = sound [1];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoe"))
        {
            shoeSound.Play();
            Destroy(collision.gameObject);
            shoes++;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            coinSound.Play();
            Destroy(collision.gameObject);
            coins++;
            coinText.text = coins.ToString();
        }

        if (shoes == 1)
        {
            customImage1.enabled = true;
        }

        if (shoes == 2)
        {
            customImage2.enabled = true;
            doubleJumpText.enabled = true;
        }
    }
}
