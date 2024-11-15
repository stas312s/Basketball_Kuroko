using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class ResolutionsAdaptive: MonoBehaviour
    {
        [SerializeField] private Transform topWall;
        [SerializeField] private Transform bottomWall;
        [SerializeField] private Transform leftWall;
        [SerializeField] private Transform rightWall;
        [SerializeField] private Camera mainCamera; 
        [SerializeField] private SpriteRenderer Basket;
        private void Start()
        {
            SetupBoundaries();
        }

        private void SetupBoundaries()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main; 
            }

            
            float screenWidth = mainCamera.orthographicSize * Screen.width / Screen.height;
            float screenHeight = mainCamera.orthographicSize;

           
            topWall.position = new Vector3(0, screenHeight + topWall.localScale.y * 10, 0);
            topWall.localScale = new Vector3(screenWidth * 2, topWall.localScale.y, 1);

           
            bottomWall.position = new Vector3(0, -screenHeight, 0);
            bottomWall.localScale = new Vector3(screenWidth * 2, bottomWall.localScale.y, 1);

          
            leftWall.position = new Vector3(-screenWidth - leftWall.localScale.y , 0, 0);
            leftWall.localScale = new Vector3(leftWall.localScale.x, 0.5f, 1);

           
            rightWall.position = new Vector3(screenWidth, 0, 0);
            rightWall.localScale = new Vector3(rightWall.localScale.x, 0.5f, 1);
            
            float StandWidth = Basket.bounds.size.x / 2;
            Basket.transform.position = new Vector3( screenWidth - StandWidth, Basket.transform.position.y ,1);
        }
    }
}