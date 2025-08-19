using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    public GameObject inventoryimage;
    bool istrue;



    void Start()
    {
    istrue = false;    
        inventoryimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            istrue = !istrue; // »œ· «·ﬁÌ„… („‰ true ·‹ false Ê«·⁄ﬂ”)
        }

        inventoryimage.SetActive(istrue); // ÌÕœÀ Õ«·… «·«‰›Ì‰ Ê—Ì


    }



}
