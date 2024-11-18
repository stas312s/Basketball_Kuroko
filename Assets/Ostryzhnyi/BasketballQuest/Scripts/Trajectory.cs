using UnityEngine;

namespace Ostryzhnyi.BasketballQuest.Scripts
{
    public class Trajectory : MonoBehaviour
    {

        [SerializeField] private int dotsNumber;

        [SerializeField] private GameObject dotsParent;
        [SerializeField] private GameObject dotsPrefab;
        [SerializeField] private float dotSpacing;

        private Transform[] dotsList;

        private Vector3 pos;
        private float timeStamp;

        void Start()
        {
            Hide();
            PrepareDots();
        }

        void PrepareDots()
        {
            dotsList = new Transform[dotsNumber];

            for (int i = 0; i < dotsNumber; i++)
            {
                dotsList[i] = Instantiate(dotsPrefab, dotsParent.transform).transform;
            }
        }

        public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
        {
            timeStamp = dotSpacing;

            for (int i = 0; i < dotsNumber; i++)
            {
                pos.x = (ballPos.x + forceApplied.x * timeStamp);
                pos.y = (ballPos.y + forceApplied.y * timeStamp) -
                        (Physics2D.gravity.magnitude * timeStamp * timeStamp) / 2f;
                pos.z = 0f;

                dotsList[i].position = pos;
                timeStamp += dotSpacing;
            }
        }

        public void Show()
        {
            dotsParent.SetActive(true);
        }

        public void Hide()
        {
            dotsParent.SetActive(false);
        }
    }
}