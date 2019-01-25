using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleCalculatorMgr : MonoBehaviour
{
    private Text result;
    private Text expression;
    private Text category;
    // 정수 + 소수 합쳐서 16자리 까지 입력 가능
    // 무조건 정수 다음에 소수
    string num;
    string s_expression;
    double sum;
    int digit_limit;

    bool input_check = false;
    bool dot_check = true;
    bool equal_check = false;

    List<string> calculate = new List<string>();
    ArrayList formula = new ArrayList();

    List<int> bracket_order = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        result = GameObject.Find("Canvas/Google/result").GetComponent<Text>();
        expression = GameObject.Find("Canvas/Google/expression").GetComponent<Text>();
        category = GameObject.Find("Canvas/Google/category").GetComponent<Text>();
        sum = 0;
        digit_limit = 0;
        category.text = "Google";
        PrintResult(sum.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Calculate(string button, double c_num)
    {
        switch (button)
        {
            case "+":
                sum += c_num;
                break;
            case "-":
                sum -= c_num;
                break;
            case "*":
                sum *= c_num;
                break;
            case "/":
                sum /= c_num;
                break;
        }
        PrintResult(sum.ToString());
    }

    void PrintResult(string input)
    {
        result.text = input;
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
        if (digit_limit < 16)
        {
            num += button;
            input_check = true;
            equal_check = false;
            PrintResult(num);
            digit_limit++;
        }
    }

    // 점은 한 번만 허용
    public void OnClick_Dotbutton()
    {
        if (input_check == true && dot_check == true)
        {
            num += ".";
            dot_check = false;
            PrintResult(num);
        }
    }

    public void OnClick_Calculatebutton(string button)
    {
        input_check = false;
        dot_check = true;
        digit_limit = 0;

        var a = double.Parse(num);
        int order = calculate.Count;


        if (order == 0)
            sum = a;
        else
            Calculate(calculate[order - 1], a);


        if (button == "=")
        {
            Printexpression("clear");
            num = sum.ToString();
            equal_check = true;
        }
        else
        {
            if (equal_check == true)
                Printexpression(sum.ToString());
            else
                Printexpression(num);
            num = null;
            Printexpression(button);
        }
        calculate.Add(button);
    }

    public void OnClick_Clearbutton(string button)
    {
        if (button == "clear" && input_check == true)
        {
            num = num.Substring(0, num.Length - 1);
            PrintResult(num);
        }

        if (button == "AC")
        {
            num = null;
            sum = 0;
            s_expression = null;
            calculate.Clear();
            PrintResult(sum.ToString());
            Printexpression(s_expression);
        }

    }

    public void OnClick_Bracketbutton(string button)
    {

    }
}
