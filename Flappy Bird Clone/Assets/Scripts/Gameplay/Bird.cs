using UnityEngine;

public class Bird : MonoBehaviour, ICollidable, IScorable
{
    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;
    [SerializeField] private IntEventChannelSO _scoreIntChannel;

    [Header("Sprites")]
    [SerializeField] private GameObject[] _birdColorSprites;

    void Start()
    {
        RandomDraw();
    }

    public void Collision()
    {
        _collisionVoidChannel.RaiseEvent();
    }

    public void ScoredAPoint()
    {
        _scoreIntChannel.RaiseEvent(1);
    }

    void RandomDraw()
    {
        int random = Random.Range(0, _birdColorSprites.Length);

        for (int i = 0; i < _birdColorSprites.Length; i++)
        {
            if (i == random)
            {
                _birdColorSprites[i].SetActive(true);
            }
            else
            {
                _birdColorSprites[i].SetActive(false);
            }
        }
    }
}
