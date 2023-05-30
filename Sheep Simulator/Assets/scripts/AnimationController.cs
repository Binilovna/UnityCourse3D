using UnityEngine;

namespace Ursaanimation.CubicFarmAnimals
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        private string walkForwardAnimation = "walk_forward";
        private string walkBackwardAnimation = "walk_backwards";
        private string runForwardAnimation = "run_forward";
        private string turn90LAnimation = "turn_90_L";
        private string turn90RAnimation = "turn_90_R";
        private string trotAnimation = "trot_forward";
        private string sittostandAnimation = "sit_to_stand";
        private string standtositAnimation = "stand_to_sit";

        public float speed;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            
            Move();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("IsIdle", false);
                animator.Play(sittostandAnimation);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("IsIdle", false);
                animator.Play(standtositAnimation);
            }
        }

        private void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal"); 
            float verticalInput = Input.GetAxis("Vertical");   

            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
            
            gameObject.GetComponent<CharacterController>().Move(moveDirection * speed * Time.deltaTime);

            if (horizontalInput != 0 || verticalInput != 0 )
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);  // Получаем новую ориентацию, смотрящую в сторону движения
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 10f);  // Плавно поворачиваем персонажа в сторону движения
               
                animator.Play(walkForwardAnimation);
            }
            else
            {
                animator.SetBool("IsIdle", true);
            }
        }
    }
}
