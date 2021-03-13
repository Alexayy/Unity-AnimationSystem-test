using UnityEngine;
public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);   
        bool isWalking = animator.GetBool(isWalkingHash);
        bool pressedForward = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        
        if (!isWalking && pressedForward)
        {
            animator.SetBool(isWalkingHash, true);
        }
        
        if (isWalking && !pressedForward)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (pressedForward && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        
        if (isRunning && (!pressedForward || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
