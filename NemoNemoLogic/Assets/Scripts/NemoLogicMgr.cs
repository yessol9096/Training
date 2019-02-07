using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NemoLogicMgr : MonoBehaviour
{

    class save_nemo
    {
        public string name;
        public int row;
        public int column;

        public List<bool> nemos = new List<bool> ();

    }

    public Text horizon;
    public Text vertical;
    public Text name;

    public GameObject Nemo;
    public GameObject NemoNemo_Pan;
    public GameObject Count_Text;
    GameObject Panel;

    int row_count;
    int column_count;

    GameObject nemo_pan;

    List<save_nemo> save_pan = new List<save_nemo>();
    

    // Start is called before the first frame update
    void Start()
    {
        row_count = 0;
        column_count = 0;

        Panel = GameObject.Find("Canvas/Panel");
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
        nemo_pan.transform.localPosition = new Vector2(0,-50);

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
        save_nemo temp_save = new save_nemo();

        temp_save.name = name.ToString();
        temp_save.row = row_count;
        temp_save.column = column_count;
        
        for (int i = 0; i < column_count; ++i)
        {
            for (int j = 0; j < row_count; ++j)
            {
                temp_save.nemos.Add(GameObject.Find(i.ToString() + j.ToString()).GetComponent<UnityEngine.UI.Toggle>().isOn);
            }
        }
        save_pan.Add(temp_save);

        Play_NemoNemo();
        Count_NemoNemo();
        Count_ColumnNemoNemo();
    }

    public void Create_ColumnCountText(string count, float pos_y, int row_count, int line_count)
    {
        Vector2 pos;
        pos.x = pos_y;
        pos.y = (row_count * 16) - (15 * line_count);

        GameObject count_text = Instantiate(Count_Text, new Vector3(0, 0, 0), Quaternion.identity);

        count_text.GetComponent<UnityEngine.UI.Text>().text = count;
        count_text.transform.SetParent(nemo_pan.transform);
        count_text.transform.localPosition = pos;
    }

    public void Create_CountText(string count, float pos_y, int row_count, int line_count)
    {
        Vector2 pos;
        pos.y = pos_y;
        pos.x = -(row_count * 20) + (15 * line_count);

        GameObject count_text = Instantiate(Count_Text, new Vector3(0, 0, 0), Quaternion.identity);

        count_text.GetComponent<UnityEngine.UI.Text>().text = count;
        count_text.transform.SetParent(nemo_pan.transform);
        count_text.transform.localPosition = pos;
    }

    public void Count_NemoNemo()
    {
        Vector2 pos;

        bool check = true;
        int column_count = save_pan[0].column;
        int row_count = save_pan[0].row;
        bool condition = true;
        int line_count = 0;
        int count = 0;
        

        for (int i = 0; i < column_count; ++i)
        {
            pos.y = (column_count * 10) - (20 * i);

            check = true;
            line_count = 0;
            for (int j = 0; j < row_count; ++j)
            {
                condition = save_pan[0].nemos[i * row_count + j];
                if (check == false)
                {
                    if (condition == false)
                    {
                        count += 1;
                        if (j == row_count - 1)
                        {
                            Create_CountText(count.ToString(), pos.y, row_count, line_count);
                            line_count += 1;
                        }
                    }
                    else
                    {
                        Create_CountText(count.ToString(), pos.y, row_count, line_count);
                        line_count += 1;
                    }
                }
                else
                {
                    if (condition == false)
                    {
                        count = 1;
                        if (j == row_count - 1)
                        {
                            Create_CountText(count.ToString(), pos.y, row_count, line_count);
                            line_count += 1;
                        }
                    }
                }

                if (condition == false)
                    check = false;
                else
                    check = true;
            }
            
        }
    }

    public void Count_ColumnNemoNemo()
    {
        Vector2 pos;

        bool check = true;
        int column_count = save_pan[0].column;
        int row_count = save_pan[0].row;
        bool condition = true;
        int line_count = 0;
        int count = 0;


        for (int i = 0; i < row_count; ++i)
        {
            pos.x = -(row_count * 10) + (20 * i);

            check = true;
            line_count = 0;
            for (int j = 0; j < column_count; ++j)
            {
                condition = save_pan[0].nemos[j * row_count + i];
                if (check == false)
                {
                    if (condition == false)
                    {
                        count += 1;
                        if (j == column_count - 1)
                        {
                            Create_ColumnCountText(count.ToString(), pos.x, column_count, line_count);
                            line_count += 1;
                        }
                    }
                    else
                    {
                        Create_ColumnCountText(count.ToString(), pos.x, column_count, line_count);
                        line_count += 1;
                    }
                }
                else
                {
                    if (condition == false)
                    {
                        count = 1;
                        if (j == column_count - 1)
                        {
                            Create_ColumnCountText(count.ToString(), pos.x, column_count, line_count);
                            line_count += 1;
                        }
                    }
                }

                if (condition == false)
                    check = false;
                else
                    check = true;
            }

        }
    }


    public void Play_NemoNemo()
    {
        Delete_NemoNemo();
        Create_NemoNemo();
    }

    
}
