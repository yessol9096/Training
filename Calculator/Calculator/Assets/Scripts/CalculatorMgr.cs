using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalculatorMgr : MonoBehaviour
{
    private Text result;
    private Text express;
    // 정수 + 소수 합쳐서 16자리 까지 입력 가능
    // 무조건 정수 다음에 소수 
    string num1;
    string num2;
    string calculate;

    
    ArrayList number = new ArrayList();

    int order_check = 1;

    // Start is called before the first frame update
    void Start()
    {
        result = GameObject.Find("Canvas/Panel/result").GetComponent<Text>();
        express = GameObject.Find("Canvas/Panel/express").GetComponent<Text>();

        Debug.Log(result.text);
        var a = double.Parse("12345.123");
        var b = double.Parse("11111.111");
        //Debug.Log("a + b = " + (a + b));
    }

    // Update is called once per frame
    void Update()
    {
    }

	void Input()
	{
		
	}

	void Calculate()
	{
		
	}

	void Print()
	{
		
	}


	public void OnClick_Numbutton(string button)
	{
        if (order_check == 1)
            num1 += button;
        else if (order_check == 2)
            num2 += button;

        if (order_check == 1)
            result.text = num1;
        else if (order_check == 2)
            result.text = num2;
        //result.text = num1;
    }

	public void OnClick_Calculatebutton(string button)
	{
        calculate += button;
        if (order_check == 1)
        {
            order_check = 2;
            var a = double.Parse("num1");
            number.Add(a);
        }
        else if (order_check == 2)
        {
            order_check = 3;
            var b = double.Parse("num2");
            number.Add(b);
        }
        else
        {
            switch (button)
            {
                case "+":
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
            }
        }
    }

    public void OnClick_Clearbutton(string button)
    {

    }

}
