using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InputController : MonoBehaviour
{
    private const string negativeError = "Введено отрицательное число";
    private const string emptyError = "Заполнены не все поля";

    [SerializeField] private TMP_InputField _distanceInput;
    [SerializeField] private TMP_InputField _speedInput;
    [SerializeField] private TMP_InputField _delayInstance;

    [SerializeField] private TMP_Text _errorText;

    private float _distance;
    private float _speed;
    private float _delay;

    public float Distance => _distance;
    public float Speed => _speed;
    public float Delay => _delay;
    public bool IsFilled => CheckSetUp();


    private void Start()
    {
        _distanceInput.onEndEdit.AddListener(CheckDistance);
        _speedInput.onEndEdit.AddListener(CheckSpeed);
        _delayInstance.onEndEdit.AddListener(CheckDelay);
    }

    private void CheckDistance(string value)
    {
        if (value != "")
        {
            _distance = CheckNegative(float.Parse(value));
        }           
    }
        
    private void CheckSpeed(string value)
    {
        if(value != "")
        {
            _speed = CheckNegative(float.Parse(value));
        }
    }

    private void CheckDelay(string value)
    {
        if(value != "")
        {
            _delay = CheckNegative(float.Parse(value));
        }        
    } 

    private float CheckNegative(float value)
    {
        if (value < 0)
        {
            ShowError(true,negativeError);
            return 0f;
        }
        else
        {
            ShowError(false,negativeError);
            return value;
        }
    }

    private bool CheckSetUp()
    {
        bool result = Delay > 0 && Speed > 0 && Distance > 0;

        if (!result)
        {
            ShowError(true, emptyError);
        }

        return result;
    }

    private void ShowError(bool isActive,string text)
    {
        _errorText.gameObject.SetActive(isActive);
        _errorText.text = text;
        _errorText.color = Color.red;
    }
}
