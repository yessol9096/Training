using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NemoLogicMgr : MonoBehaviour
{
    public Text horizon;
    public Text vertical;
    public Text name;

    public GameObject Nemo;
    public GameObject panel;

    List<GameObject> Go = new List<GameObject>();
    

    int row_count;
    int column_count;
    // Start is called before the first frame update
    void Start()
    {
        row_count = 0;
        column_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Create_NemoNemo()
    {

        row_count = int.Parse(horizon.text);
        column_count = int.Parse(vertical.text);

        Vector2 pos;
    
        for (int i = 0; i < column_count; ++i)
        {
            pos.y = (column_count*10) - (20 * i);

            for (int j = 0; j < row_count; ++j)
            {
                pos.x = -(row_count*10) + (20 * j);

                GameObject go = Instantiate(Nemo, new Vector3(0,0,0), Quaternion.identity);
                go.transform.SetParent(panel.transform);
                go.transform.localPosition = pos;
            }
        }
    }

    public void Save_NemoNemo()
    {
        for (int i = 0; i < column_count; ++i)
        {
            for (int j = 0; j < row_count; ++j)
            {
               
            }
        }
    }
}
