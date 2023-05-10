using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class InfoPanel : MonoBehaviour
{
    public Crucible crucible;
    public ElectroSmelter smelter;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI smelterText;
    public TextMeshProUGUI itemsText;
    public TextMeshProUGUI tempText;

    [SerializeField]
    private List<string> itemList;
    private bool hasChanged;
    // Start is called before the first frame update
    void Start()
    {
        costText.text = 999999.ToString("C", CultureInfo.CurrentCulture);
        smelterText.text = "Inactive";
        smelterText.color = Color.red;
        itemsText.text = "";
        tempText.text = "0° F";
        itemList = new List<string>();
        hasChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasChanged)
        {
            StringBuilder text = new StringBuilder("");
            foreach(string s in itemList)
            {
                text.Append($"{s}\n");
            }
            itemsText.text = "";
            itemsText.text = text.ToString();
            hasChanged = false;
            //itemList.Clear();
        }

        tempText.text = crucible.Thermo.temperature.ToString("F2", CultureInfo.CurrentCulture) + "° F";

        if(smelter.effects[0].isPlaying)
        {
            smelterText.text = "Active";
            smelterText.color = Color.green;
        }
        else
        {
            smelterText.text = "Inactive";
            smelterText.color = Color.red;
        }
    }

    public void AddItem(string name)
    {
        itemList.Add(name);
        hasChanged = true;
    }

    public void RemoveItem(string name)
    {
        int i = itemList.IndexOf(name);
        Debug.Log($"Removing {name} from index {i}");
        itemList.RemoveAt(i);
        hasChanged = true;
    }
}
