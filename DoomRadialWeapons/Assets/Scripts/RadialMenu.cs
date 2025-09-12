using UnityEngine;
using System.Collections.Generic;
public class RadialMenu : MonoBehaviour
{
    [SerializeField]
    GameObject EntryPrefab;

    List<RadialMenuEntry> Entries;

    public float radius = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Entries = new List<RadialMenuEntry>();
    }

    void AddEntry(string label)
    {
        GameObject entry = Instantiate(EntryPrefab, transform);
        RadialMenuEntry radialMenuEntry = entry.GetComponent<RadialMenuEntry>();
        radialMenuEntry.SetLabel(label);

        Entries.Add(radialMenuEntry);
    }

    public void Open()
    {
        for(int i=0; i<5; i++)
        {
            AddEntry("Button" + i.ToString());
        }
        Rearrange();
    }
    public void Close()
    {
        for (int i = 0; i < 5; i++)
        {
            //RectTransform rect = Entries[i].GetComponent<RectTransform>();
            GameObject entry = Entries[i].gameObject;
            //from tutorial: he used an interpolate function then called a delegate on complete
            //delegate ()
            //{
                Destroy(entry);
            //};
        }
        Entries.Clear();
    }
    public void Toggle()
    {
        if (Entries.Count ==0)
        {
            Open();
        }else
        {
            Close();
        }
    }
    void Rearrange()
    {
        float radiansOfSeparation = (Mathf.PI * 2 )/ Entries.Count;   
        for(int i = 0; i <Entries.Count; i++)
        {
            float x = Mathf.Sin(radiansOfSeparation * i) * radius;
            float y = Mathf.Sin(radiansOfSeparation * i) * radius;

            Entries[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0);
        }
    
    }
}
