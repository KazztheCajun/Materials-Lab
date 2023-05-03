using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialVendor : MonoBehaviour
{
    public GameObject fePrefab;
    public GameObject niPrefab;
    public GameObject crPrefab;
    public GameObject mnPrefab;
    public GameObject cPrefab;
    public GameObject pPrefab;
    public GameObject siPrefab;
    public GameObject sPrefab;
    public GameObject moPrefab;
    public Transform spawnPoint;

    private List<GameObject> fePreload;
    private List<GameObject> niPreload;
    private List<GameObject> crPreload;
    private List<GameObject> mnPreload;
    private List<GameObject> cPreload;
    private List<GameObject> pPreload;
    private List<GameObject> siPreload;
    private List<GameObject> sPreload;
    private List<GameObject> moPreload;

    public void Start()
    {
        fePreload = new List<GameObject>();
        niPreload = new List<GameObject>();
        crPreload = new List<GameObject>();
        mnPreload = new List<GameObject>();
        cPreload = new List<GameObject>();
        pPreload = new List<GameObject>();
        siPreload = new List<GameObject>();
        sPreload = new List<GameObject>();
        moPreload = new List<GameObject>();

        Vector3 loc = new Vector3(1000, 1000, 1000);
        for(int x = 0; x < 100; x++)
        {
            GameObject feTemp = Instantiate(fePrefab, loc, Quaternion.identity);
            GameObject niTemp = Instantiate(niPrefab, loc, Quaternion.identity);
            GameObject crTemp = Instantiate(crPrefab, loc, Quaternion.identity);
            GameObject mnTemp = Instantiate(mnPrefab, loc, Quaternion.identity);
            GameObject cTemp = Instantiate(cPrefab, loc, Quaternion.identity);
            GameObject pTemp = Instantiate(pPrefab, loc, Quaternion.identity);
            GameObject siTemp = Instantiate(siPrefab, loc, Quaternion.identity);
            GameObject sTemp = Instantiate(sPrefab, loc, Quaternion.identity);
            GameObject moTemp = Instantiate(moPrefab, loc, Quaternion.identity);

            feTemp.SetActive(false);
            niTemp.SetActive(false);
            crTemp.SetActive(false);
            mnTemp.SetActive(false);
            cTemp.SetActive(false); 
            pTemp.SetActive(false); 
            siTemp.SetActive(false);
            sTemp.SetActive(false);
            moTemp.SetActive(false);

            fePreload.Add(feTemp);
            niPreload.Add(niTemp);
            crPreload.Add(crTemp);
            mnPreload.Add(mnTemp);
            cPreload.Add(cTemp);
            pPreload.Add(pTemp);
            siPreload.Add(siTemp);
            sPreload.Add(sTemp);
            moPreload.Add(moTemp);
        }
    }

    public void SpawnIron()
    {
        SpawnMaterial("fe");
    }

    public void SpawnNickel()
    {
        SpawnMaterial("ni");
    }

    public void SpawnChromium()
    {
        SpawnMaterial("cr");
    }

    public void SpawnManganese()
    {
        SpawnMaterial("mn");
    }

    public void SpawnCarbon()
    {
        SpawnMaterial("c");
    }

    public void SpawnPhosphorus()
    {
        SpawnMaterial("p");
    }

    public void SpawnSilicon()
    {
        SpawnMaterial("si");
    }

    public void SpawnSulfur()
    {
        SpawnMaterial("s");
    }

    public void SpawnMolybdnum()
    {
        SpawnMaterial("mo");
    }

    private void SpawnMaterial(string mat)
    {
        GameObject o = GetNextPreload(mat);
        if(o != null)
        {
            o.transform.position = spawnPoint.position;
            MeltableObject m = o.GetComponent<MeltableObject>();
            m.Metal = MetalFactory.CreateNewMaterial(mat);
            m.metalName = m.Metal.MetalName;
            o.SetActive(true);
        }
        else
        {
            Debug.Log($"Unable to grab a preloaded object for {mat}.");
        }
        
    }

    private GameObject GetNextPreload(string item)
    {
        switch (item)
        {
            case "fe":
                return NextPrefab(fePreload);
            case "ni":
                return NextPrefab(niPreload);
            case "cr":
                return NextPrefab(crPreload);
            case "mn":
                return NextPrefab(mnPreload);
            case "c":
                return NextPrefab(cPreload);
            case "p":
                return NextPrefab(pPreload);
            case "si":
                return NextPrefab(siPreload);
            case "s":
                return NextPrefab(sPreload);
            case "mo":
                return NextPrefab(moPreload);
            default:
                return null;
        }
    }

    private GameObject NextPrefab(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if(!list[i].activeInHierarchy)
            {
                return list[i];
            }
        }
        return null;
    }

}
