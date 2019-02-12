using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NemoLogicMgr : MonoBehaviour
{
    public Text horizon;
    public Text vertical;
    public Text pan_name;

    public GameObject Nemo;
    public GameObject NemoNemo_Pan;
    public GameObject Count_Text;
    public GameObject Answer;
    public GameObject WrongAnswer;

    GameObject Panel;

    private NemoList nemoData;
    private NemoData tempData;

    int row_count;
    int column_count;
    // 네모리스트 순서
    int list_index;

    GameObject nemo_pan;

 
    // Start is called before the first frame update
    void Start()
    {
        nemoData = GameObject.Find("NemoData").GetComponent<NemoList>();
        //tempData = GameObject.Find("NemoData").GetComponent<NemoData>();
        tempData = new NemoData();
        row_count = 0;
        column_count = 0;
        list_index = 0;
        Panel = GameObject.Find("Canvas/Panel");

        if (SceneManager.GetActiveScene().name == "PlayNemo")
            Play_NemoNemo();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Delete_NemoNemo()
    {
        Destroy(nemo_pan);
    }

    public void Create_NemoNemo(int row, int column)
    {
        row_count = row;
        column_count = column;

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

                GameObject nemo = Instantiate(Nemo, new Vector3(0,0,0), Quaternion.identity);
                nemo.name = i.ToString() + j.ToString();
                nemo.transform.SetParent(nemo_pan.transform);
                nemo.transform.localPosition = pos;
            }
        }
    }

    public void Save_NemoNemo()
    {
        tempData.name = pan_name.text.ToString();
        tempData.row = row_count;
        tempData.column = column_count;

        for (int i = 0; i < column_count; ++i)
        {
            for (int j = 0; j < row_count; ++j)
            {
                tempData.nemos.Add(GameObject.Find(i.ToString() + j.ToString()).GetComponent<UnityEngine.UI.Toggle>().isOn);
            }
        }

        nemoData.AddList(tempData);

    }

    public void Create_ColumnCountText(string count, float pos_y, int row_count, int line_count)
    {
        Vector2 pos;
        pos.x = pos_y;
        pos.y = (row_count * 17) - (15 * line_count);

        GameObject count_text = Instantiate(Count_Text, new Vector3(0, 0, 0), Quaternion.identity);

        count_text.GetComponent<UnityEngine.UI.Text>().text = count;
        count_text.transform.SetParent(nemo_pan.transform);
        count_text.transform.localPosition = pos;
    }

    public void Create_CountText(string count, float pos_y, int row_count, int line_count)
    {
        Vector2 pos;
        pos.y = pos_y;
        pos.x = -(row_count * 17) + (15 * line_count);

        GameObject count_text = Instantiate(Count_Text, new Vector3(0, 0, 0), Quaternion.identity);

        count_text.GetComponent<UnityEngine.UI.Text>().text = count;
        count_text.transform.SetParent(nemo_pan.transform);
        count_text.transform.localPosition = pos;
    }

    public void Count_NemoNemo()
    {
        Vector2 pos;

        bool check = true;
        int row_count = nemoData.GetRow(list_index);
        int column_count = nemoData.GetColumn(list_index);
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
                condition = nemoData.GetNemos(list_index, i * row_count + j);
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
        int row_count = nemoData.GetRow(list_index);
        int column_count = nemoData.GetColumn(list_index);
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
                condition = nemoData.GetNemos(list_index, j * row_count + i);

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

    public void Click_CreateButton()
    {
        Create_NemoNemo(int.Parse(horizon.text), int.Parse(vertical.text));
    }

    public void Play_NemoNemo()
    {
        Delete_NemoNemo();
        Create_NemoNemo(nemoData.GetRow(list_index), nemoData.GetColumn(list_index));
        Count_NemoNemo();
        Count_ColumnNemoNemo();
    }

    public void Check_NemoNemo()
    {
        bool check = true;
        for (int i = 0; i < column_count; ++i)
        {
            for (int j = 0; j < row_count; ++j)
            {
                if(GameObject.Find(i.ToString() + j.ToString()).GetComponent<UnityEngine.UI.Toggle>().isOn != nemoData.GetNemos(list_index, i * row_count + j))
                {
                    check = false;
                    goto ExitGUIException;
                }
            }
        }
        if (check == true)
        {
            GameObject answer = Instantiate(Answer, new Vector3(0, 0, 0), Quaternion.identity);
            answer.transform.SetParent(nemo_pan.transform);
            answer.transform.localPosition = new Vector3(0, 0, 0);
            //Debug.Log("맞혔습니다.");
        }

    ExitGUIException:
        if (check == false)
        {
            GameObject wrong_answer = Instantiate(WrongAnswer, new Vector3(0, 0, 0), Quaternion.identity);
            wrong_answer.transform.SetParent(nemo_pan.transform);
            wrong_answer.transform.localPosition = new Vector3(0, 0, 0);
            //Debug.Log("틀렸습니다.");
        }
    }

    public void Change_PlayScene()
    {
        Save_NemoNemo();
        SceneManager.LoadScene("PlayNemo");
    }

    public void Change_CreateScene()
    {
        SceneManager.LoadScene("CreateNemo");
    }

    public void Change_ListScene()
    {
        SceneManager.LoadScene("List");
    }

    
}
