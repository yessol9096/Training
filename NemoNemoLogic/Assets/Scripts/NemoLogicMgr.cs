using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NemoLogicMgr : MonoBehaviour
{
    class nemo
    {
        public string name;
        public bool check;

        public nemo(string n, bool c)
        {
            this.name = n;
            this.check = c;
        }
    }

    public Text horizon;
    public Text vertical;
    public Text name;

    public GameObject Nemo;
    public GameObject Panel;
    public GameObject NemoNemo_Pan;


    int row_count;
    int column_count;

    GameObject nemo_pan;

    List<nemo> save_nemo = new List<nemo>();

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

    void Delete_NemoNemo()
    {
        Destroy(nemo_pan);
    }

    public void Create_NemoNemo()
    {

        row_count = int.Parse(horizon.text);
        column_count = int.Parse(vertical.text);

        Vector2 pos;

        nemo_pan = Instantiate(NemoNemo_Pan, new Vector3(0, 0, 0), Quaternion.identity);
        nemo_pan.transform.SetParent(Panel.transform);
        nemo_pan.transform.localPosition = new Vector2(0,0);

        for (int i = 0; i < column_count; ++i)
        {
            pos.y = (column_count*10) - (20 * i);

            for (int j = 0; j < row_count; ++j)
            {
                pos.x = -(row_count*10) + (20 * j);

                GameObject go = Instantiate(Nemo, new Vector3(0,0,0), Quaternion.identity);
                go.name = i.ToString() + j.ToString();
                go.transform.SetParent(nemo_pan.transform);
                go.transform.localPosition = pos;
            }
        }
    }

    public void Save_NemoNemo()
    {
        bool temp_bool;
        nemo temp_nemo;

        for (int i = 0; i < column_count; ++i)
        {
            for (int j = 0; j < row_count; ++j)
            {
                temp_bool = GameObject.Find(i.ToString() + j.ToString()).GetComponent<UnityEngine.UI.Toggle>().isOn;
                temp_nemo = new nemo(i.ToString() + j.ToString(), temp_bool);
                save_nemo.Add(temp_nemo);
            }
        }
    }

    public void Play_NemoNemo()
    {
        Delete_NemoNemo();
        Create_NemoNemo();
    }

    
}
