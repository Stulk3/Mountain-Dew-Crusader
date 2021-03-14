using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;



public class Action_Button : MonoBehaviour
{

    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject DialogueWindow;

    bool check = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && check==false)
        {
            if (check == false)

            Button.SetActive(true);



        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || DialogueWindow.activeSelf) 
        {
            Button.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            DialogueWindow.SetActive(true);
            check = true;
        }


    }
}
