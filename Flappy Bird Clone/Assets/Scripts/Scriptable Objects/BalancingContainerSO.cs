using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Balancing Container")]
public class BalancingContainerSO : ScriptableObject
{
    public float timeToNextSpawn;
    public float pipeSpeed;
    public float groundSpeed;
    public float jumpForce;
    public float fallForce;
}
