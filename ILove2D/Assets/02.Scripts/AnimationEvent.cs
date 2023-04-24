using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private BoxCollider2D _boxCol;


    readonly int AttackHash = Animator.StringToHash("IsAttack");
    readonly int Dead = Animator.StringToHash("Dead");
    readonly int OnAir = Animator.StringToHash("OnAir");
    readonly int Door_In = Animator.StringToHash("Door_In");
    readonly int Door_Out = Animator.StringToHash("Door_Out");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        Debug.Log("Ω√¿€");
        _boxCol.enabled = true;
    }

    public void EndAttack()
    {
        Debug.Log("≥°");
        _boxCol.enabled = false;
        _anim.SetBool(AttackHash, false);   
    }

}
