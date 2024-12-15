using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private Camera cam;
        public Trajectory trajectory;
        public Ball ball;
        [SerializeField] private float pushForce = 4f;
        private bool isDragging = false;

        public static GameManager Instance;
        private Vector2 startPoint;
        private Vector2 endPoint;
        private Vector2 direction;
        private Vector2 force;
        private float distance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            cam = Camera.main;
            ball.DesativateRb();
            
#if UNITY_EDITOR
            isDragging = true;
            OnDragStart();
#else
            trajectory.Hide();
#endif
        }

        private void Update()
        {
            if (ball.IsLaunched)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) && PauseMenu.instance.CanInput && !isDragging)
            {
                isDragging = true;
                OnDragStart();
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                isDragging = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();
            }
        }

        private void OnDragStart()
        {
            ball.DesativateRb();
#if UNITY_EDITOR
            startPoint = cam.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
#else
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
#endif
            trajectory.Show();
        }

        private void OnDrag()
        {

            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;
            Debug.DrawLine(startPoint, endPoint);

            trajectory.UpdateDots(ball.HumanPose, force);
        }

        private void OnDragEnd()
        {
            ball.ActivateRb();

            ball.Push(force);

            trajectory.Hide();
        }
    }
}
