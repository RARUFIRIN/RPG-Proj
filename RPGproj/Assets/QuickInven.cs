using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class QuickInven : MonoBehaviour
{
    private QuickInven() { }
    private static QuickInven instance = null;
    public static QuickInven GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("������Ʈ�� ã�� �� �����ϴ�.");
        }
        return instance;
    }
    private void Awake()
    {
        instance = this;
        QuickSlots = this.GetComponentsInChildren<QuickSlot>();
    }
    private void Update()
    {
        UseItem();
    }
    QuickSlot[] QuickSlots;
    void UseItem()
    {
        if (QuickSlots[0].LinkedSlot != null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpendItem(0);
        }
        if (QuickSlots[1].LinkedSlot != null && Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpendItem(1);
        }
        if (QuickSlots[2].LinkedSlot != null && Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpendItem(2);
        }
        if (QuickSlots[3].LinkedSlot != null && Input.GetKeyDown(KeyCode.Alpha4))
        {
            SpendItem(3);
        }
    }

    public void SlotCheck()
    {
        for (int i = 0; i < QuickSlots.Length; i++)
        {
            if (QuickSlots[i].item != null && QuickSlots[i].item == DragSlot.instance.TargetSlot.item)
            {
                ClearSlot(QuickSlots[i]);
            }
        }
    }

    public void ClearSlot(QuickSlot _s)
    {
        _s.item = null;
        _s.itemCount = 0;
        _s.itemImage.sprite = null;
        _s.LinkedSlot = null;
        _s.OnClear = 1;
        _s.SetColor(0);
    }

    void SpendItem(int _i)
    {
        InventoryMgr.GetInstance().InstedUpdateSlotCount(QuickSlots[_i].LinkedSlot);
        switch (QuickSlots[_i].item.itemName)
        {
            case "Apple":
                {
                    Debug.Log("��� ���");
                }
                break;
            case "Beer":
                {
                    Debug.Log("���� ���");
                }
                break;
            case "Bread":
                {
                    Debug.Log("�� ���");
                }
                break;
            case "Cheese":
                {
                    Debug.Log("ġ�� ���");
                }
                break;
            default:
                break;
        }

    }


}