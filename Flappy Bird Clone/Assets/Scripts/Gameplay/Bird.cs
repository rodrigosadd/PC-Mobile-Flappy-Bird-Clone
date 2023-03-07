using UnityEngine;

public class Bird : MonoBehaviour, ICollidable
{
    [Header("Sprites")]
    [SerializeField] private Animator[] _birdColorSprites;

    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;
    [SerializeField] private BoolEventChannelSO _setActiveBirdAnimatorBoolChannel;

    void OnEnable()
    {
        _setActiveBirdAnimatorBoolChannel.OnBoolRequested += SetActiveAnimator;
    }

    void OnDisable()
    {
        _setActiveBirdAnimatorBoolChannel.OnBoolRequested -= SetActiveAnimator;        
    }

    void Start()
    {
        DrawRandomSprites();
    }

    public void Collision()
    {
        _collisionVoidChannel.RaiseEvent();
    }

    void DrawRandomSprites()
    {
        int random = Random.Range(0, _birdColorSprites.Length);

        for (int i = 0; i < _birdColorSprites.Length; i++)
        {
            if (i == random)
            {
                _birdColorSprites[i].gameObject.SetActive(true);
            }
            else
            {
                _birdColorSprites[i].gameObject.SetActive(false);
            }
        }
    }

    void SetActiveAnimator(bool value)
    {
        for (int i = 0; i < _birdColorSprites.Length; i++)
        {
            _birdColorSprites[i].enabled = value;
        }
    }
}
