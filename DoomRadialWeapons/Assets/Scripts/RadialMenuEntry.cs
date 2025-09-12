using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//this was to have some sort of enlarging thing but is another package which is why there are the IPointerHandlers
//using DG.Tweening;
public class RadialMenuEntry : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    //based off of pablomakes radial menu tutorial
    [SerializeField]
    TextMeshProUGUI label;

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void SetLabel(string pText)
    {
        label.text = pText;
    }
    
}
