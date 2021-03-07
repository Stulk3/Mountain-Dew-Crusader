using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Button : MonoBehaviour
{

    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject DialogueWindow;

    bool enb;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            
            Button.SetActive(true);
            Debug.Log("Игрок в зоне");
            enb = true;

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Button.SetActive(false);
            enb = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && enb == true )
            {
                DialogueWindow.SetActive(true);
            }
               

    }
}
