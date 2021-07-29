using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int wood = 10;
    [SerializeField] GameObject label;

    public enum EquippableItems
    {
        Axe  = 0,
        Wood = 1
    }

    private EquippableItems equippedItem = EquippableItems.Axe;
    public EquippableItems EquippedItem
    {
        get
        {
            return equippedItem;
        }
        set
        {
            equippedItem = value;
        }
    }

    public int Wood
    {
        get
        {
            return wood;
        }
        set
        {
            wood = value;
            label.GetComponent<TextMeshProUGUI>().text = "Wood: " + wood;
        }
    }
}
