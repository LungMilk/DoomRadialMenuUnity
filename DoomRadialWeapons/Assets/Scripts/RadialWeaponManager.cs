using UnityEngine;
using System.Collections.Generic;
public class RadialWeaponManager : MonoBehaviour
{
    public RadialMenu radialMenu;
    public WeaponManager weaponManager;
    //when would I pass the dictionary then?? cause I feel open should be just open the thing, maybe an instantiate funct
    //[SerializeField]
    //public Dictionary<int,GameObject> gunDictionary;
    private void Start()
    {
        //I never needed an gun object reference as the weapon manager just selects it and already has a reference
        //radialMenu.InitializeData(gunDictionary);
        // the on button clicked event has a int parameter so SetWeapon(int) is automatically taking the parameter of the action
        // so we need to first go throug every button entry and assign the action on button clicked to some function which in this case is set weapon
        //I didnt use select weapon as that is mostly seting the active and falses of the weapon script

        //set weapon is not being called
        BindButtonEvents();
    }

    private void BindButtonEvents()
    {
        //tghe for each needs to be called when it is opened as ther is not data on start
        foreach (RadialMenuEntry entry in radialMenu.Entries)
        {
            Debug.Log(entry.name + " is hooked up to Weapon manager");
            entry.OnButtonClicked += weaponManager.SetWeapon;
        }
    }

    void Update()
    {
        //i also feel like this should not be here as it is kinda glue code but what eves
        if (Input.GetKey(KeyCode.Q))
        {
            radialMenu.radialMenuOpen = true;

        }
        else { radialMenu.radialMenuOpen = false; }
        //how can this be called once
        if (radialMenu.radialMenuOpen && radialMenu.Entries.Count < radialMenu.maxEntries)
        {
            radialMenu.Open();
            BindButtonEvents();
        }
        //i am starting to rethink having the weapons spawn and despawn as radial menu entires every thime I press the button but its a messy prototype, kinda
        else if (radialMenu.Entries.Count > 0 && radialMenu.radialMenuOpen == false)
        {
            radialMenu.Close();
        }

    }
    //now we need this object to set maxEntries and assign which label goes where and how it should work
    //my vague knowledge on how dictionaries work is it has a type (weapon) and an index so I could feed my radial menu a dictionary that creates objects for each in the dicitonary

}
