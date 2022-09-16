using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipSlot_Weapon : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    // ������ ����
    Item Item;
    [SerializeField]
    Image ItemImage;
    Item TempItem;

    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.TargetSlot != null)
        {
            Slot TargetSlot = DragSlot.instance.TargetSlot;

            RegistSlot(TargetSlot);
        }
    }
    public void RegistSlot(Slot _slot)
    {
        if (_slot.item.equiptype == Item.EquipType.Weapon)
        {
            if (_slot.item.RequiredLevel <= GameMgr.GetInstance().PLevel)
            {
                if (Item != null)                                            // �̹� �������� ��� ���� ��� �ӽ����� �� �κ��丮�� �߰�
                    TempItem = Item;
                Item = _slot.item;                                         // �����ۿ� ���� ���
                ItemImage.sprite = _slot.item.ItemImage;                   // �̹��� ���� ��� �� ������ȭ
                SetColor(1);
                _slot.UpdateSlotCount(-1);                                 // �κ��丮 ���Կ��� ����
                if (TempItem != null)
                {
                    _slot.AddItem(TempItem);
                    GameMgr.GetInstance().PWeaponDmg -= TempItem.AttackDamage;
                }
                GameMgr.GetInstance().PWeaponDmg += Item.AttackDamage;
                TempItem = null;
            }
            else
            {
                Debug.Log("������ �����մϴ�." + _slot.item.RequiredLevel + "�̻��� �Ǿ�� ������ �� �ֽ��ϴ�.");
            }

        }
        else
        {
            Debug.Log("���⸸ ���� �� �� �ֽ��ϴ�.");
        }

    }




    public void OnPointerClick(PointerEventData eventData)
    {
        if (Item != null && eventData.button == PointerEventData.InputButton.Right)     // ��Ŭ�� ��
        {
            GameMgr.GetInstance().PWeaponDmg -= Item.AttackDamage;
            InventoryMgr.GetInstance().GainItem(Item);      // ������ �κ��丮�� �߰�
            ClearSlot();                                    // ���ĭ Ŭ����
        }
    }
    void ClearSlot()
    {
        Item = null;
        ItemImage.sprite = null;
        SetColor(0);
    }

    void SetColor(float _alpha) // ������ ������ ������ ����
    {
        Color color = ItemImage.color;
        color.a = _alpha;
        ItemImage.color = color;
    }
}