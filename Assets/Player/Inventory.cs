using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int wood = 200;
    [SerializeField] GameObject label;

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
