using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
//this was to have some sort of enlarging thing but is another package which is why there are the IPointerHandlers
//using DG.Tweening;
public class RadialMenuEntry : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //based off of pablomakes radial menu tutorial
    [SerializeField]
    TextMeshProUGUI label;
    //forgot the quicker {get; set stuff}
    private int itemReference;

    public event Action<int> OnButtonClicked;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked " + label.text);
        OnButtonClicked?.Invoke(itemReference);
        //when it is clicked how does it set the item reference,
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //unnecesesary now as the tutorial I was following wanted some cool tweening and maybe Ill look into it but right now its pointless
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    //when i was watching the tutorial the video had pText and I do not understand why it would be p then Text as a naming convention. Public Variable?
    public void SetLabel(string text)
    {
        label.text = text;
    }
    public void SetitemReference(int item)
    {
        itemReference = item;
    }
    public int GetItemreference()
    {
        return itemReference;
    }

}
