using UnityEngine;
using TMPro;
using System.Globalization;

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

    void Start()
    {
        UpdateTexts();
    }

    public void GetValues()
    {
        _balancingContainerSO.pipeSpeed = float.Parse(_pipeSpeedInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.timeToNextSpawn = float.Parse(_timeSpawnInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.jumpForce = float.Parse(_jumpForceInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.fallForce = float.Parse(_fallForceInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.groundSpeed = _balancingContainerSO.pipeSpeed / 100f;
    }

    public void UpdateTexts()
    {
        _pipeSpeedText.text = _balancingContainerSO.pipeSpeed.ToString();
        _timeSpawnText.text = _balancingContainerSO.timeToNextSpawn.ToString();
        _jumpForceText.text = _balancingContainerSO.jumpForce.ToString();
        _fallForceText.text = _balancingContainerSO.fallForce.ToString();
    }
}
