using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    private GameObject cell_1;
    private GameObject cell_2;

    private RawImage c1Image;
    private RawImage c2Image;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        cell_1 = GameObject.FindGameObjectWithTag("cell 1");
        cell_2 = GameObject.FindGameObjectWithTag("cell 2");

        // Припускаємо, що cell_1 та cell_2 мають компоненти RawImage
        c1Image = cell_1.GetComponent<RawImage>();
        c2Image = cell_2.GetComponent<RawImage>();
    }

    static public void OpenInventory()
    {
        
    }

    public void UpdateInventory(List<GameObject> inventoryItems)
    {
        Debug.Log("UPDATEEEEEEE");
        // Переконуємося, що у нас достатньо елементів для оновлення комірок
        if (inventoryItems.Count > 0)
        {
            // Припускаємо, що елементи інвентарю мають компоненти RawImage або подібні для отримання текстури
            RawImage itemImage1 = inventoryItems[0].GetComponent<RawImage>();
            if (itemImage1 != null && c1Image != null)
            {
                c1Image.texture = itemImage1.texture;
            }
        }

        if (inventoryItems.Count > 1)
        {
            RawImage itemImage2 = inventoryItems[1].GetComponent<RawImage>();
            if (itemImage2 != null && c2Image != null)
            {
                c2Image.texture = itemImage2.texture;
            }
        }
    }

    void Update()
    {
        // Логіка оновлення, якщо потрібно
    }
}