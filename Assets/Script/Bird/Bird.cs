using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;
    
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void AddPoint(int points)
    {
        _score += points;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _mover.ResetBird();
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
