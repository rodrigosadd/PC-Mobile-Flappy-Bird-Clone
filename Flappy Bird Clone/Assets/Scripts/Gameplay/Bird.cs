using UnityEngine;

public class Bird : MonoBehaviour, ICollidable, IScorable
{
    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;
    [SerializeField] private IntEventChannelSO _scoreIntChannel;
    [SerializeField] private BoolEventChannelSO _setActiveBirdAnimatorBoolChannel;

    [Header("Sprites")]
    [SerializeField] private Animator[] _birdColorSprites;

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
        RandomDrawSprites();
    }

    public void Collision()
    {
        _collisionVoidChannel.RaiseEvent();
    }

    public void ScoredAPoint()
    {
        _scoreIntChannel.RaiseEvent(1);
    }

    void RandomDrawSprites()
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
