using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleCalculatorMgr : MonoBehaviour
{
    private Text result;
    private Text expression;
    private Text category;
   
    // 무조건 정수 다음에 소수
    string s_result;
    string s_num;
    string s_expression;

    double sum;
    //int digit_limit;

    bool input_check = false;
    bool dot_check = true;
    bool equal_check = false;

    List<string> calculate = new List<string>();
    List<double> number = new List<double>();

    // Start is called before the first frame update
    void Start()
    {
        result = GameObject.Find("Canvas/Google/result").GetComponent<Text>();
        expression = GameObject.Find("Canvas/Google/expression").GetComponent<Text>();
        category = GameObject.Find("Canvas/Google/category").GetComponent<Text>();

        sum = 0;

        category.text = "Google";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Calculate(int index)
    {
        switch (calculate[index])
        {
            case "+":
                number[index] += number[index + 1];
                break;
            case "-":
                number[index] -= number[index + 1];
                break;
            case "*":
                number[index] *= number[index + 1];
                break;
            case "/":
                number[index] /= number[index + 1];
                break;
        }
        number.RemoveAt(index + 1);
        calculate.RemoveAt(index);
    }

    void Multi_cal(int index)
    {
        if (index + 1 < calculate.Count)
        {
            if (calculate[index] == "*" || calculate[index] == "/")
            {
                Calculate(index);
                Multi_cal(index);
            }
            else
            {
                Multi_cal(index++);
            }
        }
    }

    void Plus_cal(int index)
    {
        if (0 < calculate.Count && index + 1 < calculate.Count)
        {
            if (calculate[index] == "+" || calculate[index] == "-")
            {
                Calculate(index);
                Plus_cal(index);
            }
            else
            {
                Plus_cal(index++);
            }
        }
    }

    void Calculate()
    {
        int count = calculate.Count;

        Multi_cal(0);
        Plus_cal(0);

        result.text = number[0].ToString();
    }

    void PrintResult(string input)
    {
        s_result += input;
        result.text = s_result;
    }

    void Printexpression(string input)
    {
        if (input == "clear")
            s_expression = null;
        else
            s_expression += input;

        expression.text = s_expression;
    }

    // 숫자 버튼 
    public void OnClick_Numbutton(string button)
    {
        input_check = true;
        equal_check = false;

        s_num += button;
        PrintResult(button);
    }

    // 점은 한 번만 허용
    public void OnClick_Dotbutton()
    {
        if (input_check == true && dot_check == true)
        {
            s_num += ".";
            dot_check = false;
            PrintResult(".");
        }
    }

    public void OnClick_Calculatebutton(string button)
    {
        input_check = false;
        dot_check = true;

        // string to double 
        var d_num = double.Parse(s_num);
        number.Add(d_num);
        s_num = null;


        int order = calculate.Count;


        ////////// = 눌렀을 때 상황 
        if (button == "=")
        {
            Calculate();
            equal_check = true;
        }
        else
        {
            calculate.Add(button);
            PrintResult(button);
        }
        ///////////////////////////
    }

    public void OnClick_Clearbutton(string button)
    {
        if (button == "clear")
        {
            s_result = s_result.Substring(0, s_result.Length - 1);
            PrintResult(null);
        }

        if (button == "AC")
        {
            s_num = null;
            s_result = null;
            sum = 0;
            s_expression = null;

            calculate.Clear();
            number.Clear();

            result.text = null;
        }

    }

    public void OnClick_Bracketbutton(string button)
    {

    }
}
