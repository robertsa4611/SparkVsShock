using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int shoes = 0;
    [SerializeField] private Image customImage1;
    [SerializeField] private Image customImage2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shoe"))
        {
            Destroy(collision.gameObject);
            shoes++;
        }

        if (shoes == 1)
        {
            customImage1.enabled = true;
        }

        if (shoes == 2)
        {
            customImage2.enabled = true;
        }
    }
}
