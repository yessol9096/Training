using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoData : MonoBehaviour
{
    public string name;
    public int row;
    public int column;

    public List<bool> nemos = new List<bool>();


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
