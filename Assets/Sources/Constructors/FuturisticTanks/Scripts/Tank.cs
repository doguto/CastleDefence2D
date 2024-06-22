using UnityEngine;

namespace Assets.Constructors.FuturisticTanks.Scripts
{
    public class Tank : MonoBehaviour
    {
        public Animator Animator;

        public void Idle()
        {
            Animator.SetBool("Idle", true);
            Animator.SetBool("Move", false);
            Animator.SetBool("Destroy", false);
        }

        public void Move()
        {
            Animator.SetBool("Idle", false);
            Animator.SetBool("Move", true);
            Animator.SetBool("Destroy", false);
        }

        public void Destroy()
        {
            Animator.SetBool("Idle", false);
            Animator.SetBool("Move", false);
            Animator.SetBool("Destroy", true);
        }

        public void Shot()
        {
            Animator.SetTrigger("Shot");
        }
    }
}