using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    int i;
    

    public struct Objects
    {
        public GameObject objeto;
        public bool instanciado;
    }

    public GameObject[] boosters;
    public GameObject[] spawnPoints;
    

    [HideInInspector]
    public Objects[] objectsArr;
    [HideInInspector]
    public int tmp;

   


    // Use this for initialization
    private void Start ()
    {
        spawnPoints = new GameObject[4];
        objectsArr = new Objects[boosters.Length];

        for (int i = 0; i < boosters.Length; i++)
        {
            objectsArr[i].objeto = boosters[i];
            objectsArr[i].instanciado = false;
        }

        InstantiateObjects();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InstantiateObjects()
    {
       
        
        

        for (i = 0; i < 4; i++)
        {
            tmp = Random.Range(0, objectsArr.Length);

            while (IsDup(objectsArr))
            {
                tmp = Random.Range(0, objectsArr.Length);
            }
            objectsArr[tmp].instanciado = true;

            GameObject instBooster = (GameObject)Instantiate(objectsArr[tmp].objeto, spawnPoints[i].transform);
        }

        


    }
    
    private bool IsDup(Objects[] arr)
    {
        foreach (Objects item in arr)
        {
            if (item.instanciado == true)
            {
                return true;
            }
        }

        return false;

    }


}
