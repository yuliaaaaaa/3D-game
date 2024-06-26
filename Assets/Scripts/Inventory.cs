using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int inventorySpace = 2;
    public bool empty = true;
    public bool isBeg = false;

    private GameObject rightHand;
    private GameObject leftHand;
    private Character character;
    private UIInventory uiInventory;

    public List<GameObject> inventoryItems = new List<GameObject>();

    void Start()
    {
        rightHand = GameObject.FindGameObjectWithTag("right hand");
        leftHand = GameObject.FindGameObjectWithTag("left hand");

        // Перевірте, чи знайдені руки
        if (rightHand == null)
        {
            Debug.LogError("Right hand не знайдено.");
        }
        if (leftHand == null)
        {
            Debug.LogError("Left hand не знайдено.");
        }
        
        // Перевірка і ініціалізація character, якщо потрібно
        character = GetComponent<Character>();
        if (character == null)
        {
            Debug.LogError("Character компонент не знайдено на об'єкті.");
        }
        
        uiInventory = GetComponent<UIInventory>();
    }

    public void EnterItem(GameObject item)
    {
        if (inventoryItems.Count < inventorySpace)
        {
            if (inventoryItems.Count == 1)
            {
                // Перемістити попередній об'єкт в ліву руку
                inventoryItems[0].transform.position = leftHand.transform.position;
                inventoryItems[0].transform.parent = leftHand.transform;
                // Установити локальну позицію об'єкта відносно лівої руки
                inventoryItems[0].transform.localPosition = Vector3.zero;
            }

            // Розмістити новий об'єкт в правій руці
            item.transform.parent = rightHand.transform;
            item.transform.localPosition = Vector3.zero;

            // Додати новий об'єкт до інвентарю
            inventoryItems.Add(item);

            // Оновити стан інвентарю
            if (inventoryItems.Count == inventorySpace)
            {
                empty = false;
            }
            else
            {
                empty = true;
            }
            
            uiInventory.UpdateInventory(inventoryItems);
        }
    }
}
