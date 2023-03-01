using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/Load Channel")]
public class LoadEventChannelSO : ScriptableObject
{
    public UnityAction<GameSceneSO> OnLoadRequested;

    public void RaiseEvent(GameSceneSO gameScene)
    {
        if (OnLoadRequested != null)
        {
            OnLoadRequested.Invoke(gameScene);
        }
        else
        {
            Debug.LogError("Load Requested is Null!!!");
        }
    }
}
