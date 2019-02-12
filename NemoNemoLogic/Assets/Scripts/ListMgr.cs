using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListMgr : MonoBehaviour
{
    private NemoList nemoData;
    public GameObject Panel;
    public GameObject Button;
   
    // Start is called before the first frame update
    void Start()
    {
        nemoData = GameObject.Find("NemoData").GetComponent<NemoList>();
        Create_Button();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create_Button()
    {
        for (int i = 0; i < nemoData.GetNemoCount(); ++i)
        {
            GameObject list_button = Instantiate(Button, new Vector3(0, 0, 0), Quaternion.identity);
            list_button.transform.SetParent(Panel.transform);
            list_button.transform.localPosition = new Vector2(0, 100 - 35*i);
            list_button.name = nemoData.GetName(i);
            list_button.GetComponentInChildren<Text>().text = nemoData.GetName(i);
        }
    }
    public void Change_CreateScene()
    {
        SceneManager.LoadScene("CreateNemo");
    }
}
