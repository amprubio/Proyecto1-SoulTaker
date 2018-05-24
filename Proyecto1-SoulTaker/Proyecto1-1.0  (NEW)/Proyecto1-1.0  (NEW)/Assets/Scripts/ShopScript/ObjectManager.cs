using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour {

    int i;
    public ObjectManager objMan;

    public struct Objects
    {
        public GameObject objeto;
        public bool instanciado;
    }

    public GameObject[] boosters;
    public GameObject[] spawnPoints;
    public Text[] textSpawnPoints;
    

    [HideInInspector]
    public Objects[] objectsArr;
    [HideInInspector]
    public int tmp;


    private void Start ()
    {
        objectsArr = new Objects[boosters.Length];

        InstantiateObjects();

        
        for(int i = 0; i < textSpawnPoints.Length; i++)
        {
            textSpawnPoints[i] = GameObject.Find("CanvasObjetos").transform.GetChild(i).GetComponent<Text>();
            textSpawnPoints[i].text = string.Empty;
        }
    }

    void Update()
    {
        
    }

    public void InstantiateObjects()
    {

        for (int i = 0; i < boosters.Length; i++)
        {
            objectsArr[i].objeto = boosters[i];
            objectsArr[i].instanciado = false;
        } 

        for (i = 0; i < spawnPoints.Length; i++)
        {
            tmp = Random.Range(0, objectsArr.Length);

            while (IsDup(objectsArr, tmp))
            {
                tmp = Random.Range(0, objectsArr.Length);
            }
            objectsArr[tmp].instanciado = true;

            GameObject go = Instantiate(objectsArr[tmp].objeto, spawnPoints[i].transform);
            go.transform.parent = spawnPoints[i].transform.parent.transform;
            go.transform.position = spawnPoints[i].transform.position;
            
        }


    }
    
    private bool IsDup(Objects[] arr, int tmp)
    {

        if (arr[tmp].instanciado == true)
        {
            return true;
        }
        else return false;

    }




}
