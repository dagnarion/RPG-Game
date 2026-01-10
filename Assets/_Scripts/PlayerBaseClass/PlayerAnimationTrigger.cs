using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController; 
    public void AnimationDone()
    {
        _playerController.CompleteAnimation();
    }
}
