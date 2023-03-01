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

    void Start()
    {
        ResetBalancingValues();
    }

    public void GetValues()
    {
        _balancingContainerSO.pipeSpeed = float.Parse(_pipeSpeedInputField.text, CultureInfo.InvariantCulture.NumberFormat);
        _balancingContainerSO.timeSpawn = float.Parse(_timeSpawnInputField.text, CultureInfo.InvariantCulture.NumberFormat);
    }

    void ResetBalancingValues()
    {
        _balancingContainerSO.pipeSpeed = 0f;
        _balancingContainerSO.timeSpawn = 0f;
    }
}
