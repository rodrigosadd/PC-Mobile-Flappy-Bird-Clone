using UnityEngine;
using TMPro;
using System.Globalization;
using System;

public class GetBalancingValues : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private BalancingContainerSO _balancingContainerSO;

    [Header("Input Fields")]
    [SerializeField] private TMP_InputField _pipeSpeedInputField;
    [SerializeField] private TMP_InputField _timeSpawnInputField;
    [SerializeField] private TMP_InputField _jumpForceInputField;
    [SerializeField] private TMP_InputField _fallForceInputField;

    [Header("Texts")]
    [SerializeField] private TMP_Text _pipeSpeedText;
    [SerializeField] private TMP_Text _timeSpawnText;
    [SerializeField] private TMP_Text _jumpForceText;
    [SerializeField] private TMP_Text _fallForceText;
    [SerializeField] private TMP_Text _warningText;

    [Header("Reset Values")]
    [SerializeField] private float _pipeSpeed;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallForce;
    [SerializeField] private float _groundSpeed;

    void Start()
    {
        UpdateTexts();
    }

    public void GetValues()
    {
        if (String.IsNullOrEmpty(_pipeSpeedInputField.text) ||
            String.IsNullOrEmpty(_timeSpawnInputField.text) ||
            String.IsNullOrEmpty(_jumpForceInputField.text) ||
            String.IsNullOrEmpty(_fallForceInputField.text))
        {
            SetWarningText("Some field is empty!!!");
            _warningText.color = Color.red;
            return;
        }

        if (!float.TryParse(_pipeSpeedInputField.text, out float value) ||
            !float.TryParse(_timeSpawnInputField.text, out float value2) ||
            !float.TryParse(_jumpForceInputField.text, out float value3) ||
            !float.TryParse(_fallForceInputField.text, out float value4))
        {
            SetWarningText("All values must be numbers!!!");
            _warningText.color = Color.red;
            return;
        }

        _balancingContainerSO.pipeSpeed = float.Parse(_pipeSpeedInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.timeToNextSpawn = float.Parse(_timeSpawnInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.jumpForce = float.Parse(_jumpForceInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.fallForce = float.Parse(_fallForceInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.groundSpeed = _balancingContainerSO.pipeSpeed / 100f;
        SetWarningText("Updated values :)");
        _warningText.color = Color.green;
    }

    public void UpdateTexts()
    {
        _pipeSpeedText.text = _balancingContainerSO.pipeSpeed.ToString();
        _timeSpawnText.text = _balancingContainerSO.timeToNextSpawn.ToString();
        _jumpForceText.text = _balancingContainerSO.jumpForce.ToString();
        _fallForceText.text = _balancingContainerSO.fallForce.ToString();
    }

    public void SetWarningText(string text)
    {
        _warningText.text = text;
    }

    public void ResetValues()
    {
        _pipeSpeedText.text = _pipeSpeed.ToString();
        _timeSpawnText.text = _timeSpawn.ToString();
        _jumpForceText.text = _jumpForce.ToString();
        _fallForceText.text = _fallForce.ToString();
        _balancingContainerSO.pipeSpeed = _pipeSpeed;
        _balancingContainerSO.timeToNextSpawn = _timeSpawn;
        _balancingContainerSO.jumpForce = _jumpForce;
        _balancingContainerSO.fallForce = _fallForce;
        _balancingContainerSO.groundSpeed = _groundSpeed;
    }
}
