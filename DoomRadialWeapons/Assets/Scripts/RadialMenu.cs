using UnityEngine;
using System.Collections.Generic;
public class RadialMenu : MonoBehaviour
{
    [SerializeField]
    GameObject EntryPrefab;

    public List<RadialMenuEntry> Entries;
    //I now realize I never needed a game object I can just set the weapon manager to select the weapon as the weapon should handle everything.
    //private Dictionary<int,GameObject> entryDictionary;
    //a get set would be a good idea here
    public bool radialMenuOpen = false;
    public int maxEntries = 3;

    public float radius = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Entries = new List<RadialMenuEntry>();
    }
 
    //how can we avoid update cause I think the radial menu should handle communication with all the buttons and can have the most recent selected value;
    //when we add an entry we could also assign it a weapon reference (but then the weapon references are not connected and The programmer just has to know)
    //I do not think the answer is to have a refernce to the weapons whmeselves nor the player inventory.
    //public void InitializeData(Dictionary<int,GameObject> objectDictionary)
    //{
    //    entryDictionary = objectDictionary;
    //}
    void AddEntry( int i)
    {
        GameObject entry = Instantiate(EntryPrefab, transform);
        RadialMenuEntry radialMenuEntry = entry.GetComponent<RadialMenuEntry>();

        //string label = entryRef.name.ToString();
        radialMenuEntry.SetLabel("Button " + i.ToString());
        radialMenuEntry.SetitemReference(i);
        Entries.Add(radialMenuEntry);
    }
    public void Open()
    {
        //how can each button with its label correspond to the selected object reference
        for(int i=0; i<maxEntries; i++)
        {
            //the For is the gun reference with I
            AddEntry(i);
        }
        Rearrange();
    }
    public void Close()
    {
        for (int i = 0; i < maxEntries; i++)
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
    [ContextMenu("Toggle")]
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
            //float y = Mathf.Sin(radiansOfSeparation * i) * radius;
            float y = Mathf.Cos(radiansOfSeparation * i) * radius;

            Entries[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0);
        }
    
    }
}
