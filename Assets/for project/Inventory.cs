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
            istrue = !istrue; // ��� ������ (�� true �� false ������)
        }

        inventoryimage.SetActive(istrue); // ���� ���� �����������


    }



}
