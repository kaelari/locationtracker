using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    
    public Dropdown jova1;
    public Dropdown jova2;
    public Dropdown jova3;
    public Dropdown veros1;
    public Dropdown veros2;
    public Dropdown flame;
    public Dropdown aljiba1;
    public Dropdown aljiba2;
    public Dropdown aljiba3;
    public Dropdown aljiba4;
    public Dropdown alba1;
    public Dropdown alba2;
    public Dropdown alba3;
    public Dropdown duck;
    public Dropdown ondol1;
    public Dropdown ondol2;
    public Dropdown berkley1;
    public Dropdown berkley2;
    public Dropdown rover1;
    public Dropdown rover2;
    public Dropdown diamond;
    public Dropdown brahm1;
    public Dropdown brahm2;
    public Dropdown death;
    public Dropdown doina;
    public Dropdown bodley1;
    public Dropdown bodley2;
    public Dropdown flamewhip;
    public Dropdown laruba1;
    public Dropdown laruba2;
    public Dropdown laruba3;
    public Dropdown laruba4;
    public TextMeshProUGUI laurelcount;
    public TextMeshProUGUI whipcount;
    public TextMeshProUGUI garliccount;
    public TextMeshProUGUI stakecount;
    public TextMeshProUGUI crystalcount;

    public int garlic = 0;
    public int laurels = 0;
    public Dictionary<string, bool> curitems = new Dictionary<string, bool>();
    public Dictionary<string, bool> olditems = new Dictionary<string, bool>();
    public Dictionary<string, int> selected = new Dictionary<string, int>();
    public Dictionary<string, Dropdown> dropdowns = new Dictionary<string, Dropdown>();
    
    public int whip = 0;
    public int writing = 0;

    public int crystalnum = 3;
    public int garlicnum = 2;
    public int laurelnum = 5;
    public int whipnum = 4;
    public int stakenum = 5;

    public void updatecounts () 
    {
        int laurels = 18;
        int crystal = 3;
        int whips = 2;
        int garlic = 19;
        int stake = 17;
        int crystalcur = crystalnum;
        int laurelscur = laurelnum;
        int whipscur = whipnum;
        int stakecur = stakenum;
        int garliccur = garlicnum;

        foreach (Dropdown item in dropdowns.Values )
        {
            if (item.value == laurels)
            {
                laurelscur -= 1;
            }

            if (item.value == crystal)
            {
                crystalcur -= 1;
            }
            if (item.value == whips )
            {
                whipscur -= 1;
            }
            if (item.value == stake)
            {
                stakecur -= 1;
            }
            if (item.value == garlic)
            {
                garliccur -= 1;
            }

        }


        stakecount.text = stakecur.ToString();
        garliccount.text = garliccur.ToString();
        whipcount.text = whipscur.ToString();
        laurelcount.text = laurelscur.ToString();
        crystalcount.text = crystalcur.ToString();

    }

    void updatedisplay(Dropdown dd, string item)
    {
        if (item == "checked")
        {
            if (dd.value > 0)
            {
                return;
            }
        }
        if (dd.value <= 1)
        {
            dd.value = selected[item];
            dd.RefreshShownValue();

        }
    }
    public void record (string where, string item)
    {
        Debug.Log("trying to update where item was found:" +where +item);
        
        if (where == "jova1")
        {
            updatedisplay(jova1, item);
        }
        if (where =="jova2")
        {
            updatedisplay(jova2, item);
        }
        if (where == "jova3")
        {
            updatedisplay(jova3, item);
        }
        if (where == "veros1")
        {
            updatedisplay(veros1, item);
        }
        if (where == "veros2")
        {
            updatedisplay(veros2, item);
        }
        if (where == "flame")
        {
            updatedisplay(flame, item);
        }
        if (where == "aljiba1")
        {
            updatedisplay(aljiba1, item);
        }
        if (where == "aljiba2")
        {
            updatedisplay(aljiba2, item);
        }
        if (where == "aljiba3")
        {
            updatedisplay(aljiba3, item);
        }
        if (where == "aljiba4")
        {
            updatedisplay(aljiba4, item);
        }
        if (where == "alba1")
        {
            updatedisplay(alba1, item);
        }
        if (where == "alba2")
        {
            updatedisplay(alba2, item);
        }
        if (where == "alba3")
        {
            updatedisplay(alba3, item);
        }
        if (where == "duck")
        {
            updatedisplay(duck, item);
        }
        if (where == "ondol1")
        {
            updatedisplay(ondol1, item);
        }
        if (where == "ondol2")
        {
            updatedisplay(ondol2, item);
        }
        if (where == "berkley orb")
        {
            updatedisplay(berkley2, item);
        }
        if (where == "berkley merchant")
        {
            updatedisplay(berkley1, item);
        }
        if (where == "rover merchant")
        {
            updatedisplay(rover1, item);
        }
        if (where == "rover orb")
        {
            updatedisplay(rover2, item);
        }
        if (where == "diamond")
        {
            updatedisplay(diamond, item);
        }
        if (where == "brahm merchant")
        {
            updatedisplay(brahm1, item);
        }
        if (where == "death")
        {
            updatedisplay(death, item);
        }
        if (where == "brahm orb")
        {
            updatedisplay(brahm2, item);
        }
        if (where == "doina")
        {
            updatedisplay(doina, item);
        }
        if (where == "bodley merchant")
        {
            updatedisplay(bodley1, item);
        }
        if (where == "bodley orb")
        {
            updatedisplay(bodley2, item);
        }
        if (where == "flamewhip dude")
        {
            updatedisplay(flamewhip, item);
        }
        if (where == "laruba merchant")
        {
            updatedisplay(laruba1, item);
        }
        if (where == "laruba laurels")
        {
            updatedisplay(laruba2, item);
        }
        if (where == "carmilla")
        {
            updatedisplay(laruba3, item);
        }
        if (where == "laruba orb")
        {
            updatedisplay(laruba4, item);
        }


    }
    void Start()
    {
        selected["unchecked"] = 0;
        selected["checked"] = 1;
        selected["whip"] = 2;
        selected["crystal"] = 3;
        selected["cross"] = 4;
        selected["bag"] = 5;
        selected["rib"] = 6;
        selected["eyeball"] = 7;
        selected["heart"] = 8;
        selected["nail"] = 9;
        selected["ring"] = 10;
        selected["dagger"] = 11;
        selected["silver dagger"] = 12;
        selected["gold knife"] = 13;
        selected["holy water"] = 14;
        selected["diamond"] = 15;
        selected["sacred flame"] = 16;
        selected["oak stake"] = 17;
        selected["laurels"] = 18;
        selected["garlic"] = 19;

        olditems["holy water"] = false;
        olditems["wcrystal"] = false;
        olditems["rcrystal"] = false;
        olditems["bcrystal"] = false;
        olditems["dagger"] = false;
        olditems["silver dagger"] = false;
        olditems["gold knife"] = false;
        olditems["diamond"] = false;
        olditems["flame"] = false;
        olditems["stake"] = false;
        olditems["garlic"] = false;
        olditems["laurels"] = false;
        olditems["rib"] = false;
        olditems["eyeball"] = false;
        olditems["heart"] = false;
        olditems["nail"] = false;
        olditems["ring"] = false;
        olditems["cross"] = false;
        olditems["bag"] = false;

        dropdowns["jova1"] = jova1;
        dropdowns["jova2"] = jova2;
        dropdowns["jova3"] = jova3;
        dropdowns["veros1"] = veros1;
        dropdowns["veros2"] = veros2;
        dropdowns["flame"] = flame;
        dropdowns["aljiba1"] = aljiba1;
        dropdowns["aljiba2"] = aljiba2;
        dropdowns["aljiba3"] = aljiba3;
        dropdowns["aljiba4"] = aljiba4;
        dropdowns["alba1"] = alba1;
        dropdowns["alba2"] = alba2;
        dropdowns["alba3"] = alba3;
        dropdowns["duck"] = duck;
        dropdowns["ondol1"] = ondol1;
        dropdowns["ondol2"] = ondol2;
        dropdowns["berkley1"] = berkley1;
        dropdowns["berkley2"] = berkley2;
        dropdowns["rover1"] = rover1;
        dropdowns["rover2"] = rover2;
        dropdowns["diamond"] = diamond;
        dropdowns["brahm1"] = brahm1;
        dropdowns["brahm2"] = brahm2;
        dropdowns["death"] = death;
        dropdowns["doina"] = doina;
        dropdowns["bodley1"] = bodley1;
        dropdowns["bodley2"] = bodley2;
        dropdowns["flamewhip"] = flamewhip;
        dropdowns["laruba1"] = laruba1;
        dropdowns["laruba2"] = laruba2;
        dropdowns["laruba3"] = laruba3;
        dropdowns["laruba4"] = laruba4;

    }
  
    // Update is called once per frame
    void Update()
    {
        foreach (var item in curitems.Keys)
        {
            if (curitems[item] == true)
            {
                olditems[item] = true;
            }
        }
        curitems.Clear();

        updatecounts();

    }
}
