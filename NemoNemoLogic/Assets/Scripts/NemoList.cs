﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoList : MonoBehaviour
{
    public List<NemoData> nemoData = new List<NemoData>();

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void AddList(NemoData temp)
    {
        nemoData.Add(temp);
    }

    //////

    public string GetName(int index)
    {
        return nemoData[index].name;
    }

    public int GetRow(int index)
    {
        return nemoData[index].row;
    }

    public int GetColumn(int index)
    {
        return nemoData[index].column;
    }

    public bool GetNemos(int list_index, int nemo_index)
    {
        return nemoData[list_index].nemos[nemo_index];
    }

    public int GetNemoCount()
    {
        return nemoData.Count;
    }

}

public class NemoData
{
    public string name;
    public int row;
    public int column;

    public List<bool> nemos = new List<bool>();
}
