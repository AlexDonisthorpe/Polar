using UnityEngine;

public class TL_AnimationFiniteStateMachine : MonoBehaviour
{
    public Animation MovingAnimation;
    public Animation JumpingAnimation;
    public Animation DashingAnimation;
    public Animation ShoulderTackleAnimation;
    public Animation GrabbingAnimation;
    public Animation ThrowingAnimation;
    private Animator CharacterAnimator;


    public enum CharacterState
    {
        Idle, Move, Jump, Dash, ShoulderTackle, Grab, Throw
    }
    [SerializeField]
    private CharacterState DefaultState = CharacterState.Idle;


    //Sets a new state
    public void SetNewState(CharacterState NewState)
    {
        DefaultState = NewState;
    }

    //Returns the current state
    public CharacterState ReturnCurrentState()
    {
        return DefaultState;
    }

    void Start()
    {
        CharacterAnimator = GetComponent<Animator>();
    }

    //Plays the new animation
    void PlayNewAnimation(string TriggerName, bool IsNewStateTrue)
    {
        CharacterAnimator.SetBool(TriggerName, IsNewStateTrue);
    }

    //Manages animation states depending on the character's state
    void ManageAnimationStates()
    {
        switch (DefaultState)
        {
            case CharacterState.Move:
                PlayNewAnimation("IsMoving", true);
                break;

            case CharacterState.Jump:
                PlayNewAnimation("IsJumping", true);
                break;

            case CharacterState.Dash:
                PlayNewAnimation("IsDashing", true);
                break;

            case CharacterState.ShoulderTackle:
                PlayNewAnimation("IsShoulderTackling", true);
                break;

            case CharacterState.Grab:
                PlayNewAnimation("IsGrabbing", true);
                break;

            case CharacterState.Throw:
                PlayNewAnimation("IsThrowing", true);
                break;
        }
    }

    void Update()
    {
        ManageAnimationStates();
    }

}
