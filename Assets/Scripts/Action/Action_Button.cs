using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Button : MonoBehaviour
{

    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Dialogue;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            
            Button.SetActive(true);


            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialogue.SetActive(true);
            }



            return;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Button.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
