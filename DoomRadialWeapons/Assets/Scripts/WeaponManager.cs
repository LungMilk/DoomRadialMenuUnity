using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //based off of brackeys gun switching tutorial
    //personally I theorise that a scriptable object and weapon list might be better but that would need a player controller and I ain't making that.
    //this is just a prototype

    //base function is that scroll wheel and numberkeys set an integer then the integer is what determines the active weapon that is a child to this scripts object. 0 = blue, 1 = red, 2 = yellow and so on
    public int selectedWeapon = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") >0)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            selectedWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            selectedWeapon = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            selectedWeapon = 2;

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    public void SetWeapon(int i)
    {
        selectedWeapon = i;
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
