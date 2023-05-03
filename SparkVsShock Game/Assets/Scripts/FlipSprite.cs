using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipSprite : MonoBehaviour
{

    private string input;

    public GameObject textbox;
    public GameObject character;
    public GameObject drew;
    [SerializeField] private InputField inputText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (textbox.active)
            {
                textbox.SetActive(false);
                Time.timeScale = 1f;
            } else {
                textbox.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }

    public void ReadStringInput(string s)
    {
        input = s.ToLower();
        inputText.text = "";
        Debug.Log(input);
        if (s == "iamdrew")
        {
            character.SetActive(false);
            drew.SetActive(true);
            textbox.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
