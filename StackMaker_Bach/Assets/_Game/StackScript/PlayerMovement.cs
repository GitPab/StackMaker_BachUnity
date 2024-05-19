using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.StackScript
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement Instance;
        private Rigidbody rb;
        [SerializeField] public float speed;

        public GameObject BrickParent;
        public GameObject PrevBrick;

        private bool isMoving = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || InputManeger.Instance.swipeLeft && isMoving)
            {
                isMoving = true;
                rb.velocity = Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || InputManeger.Instance.swipeRight && isMoving)
            {
                isMoving = true;
                rb.velocity = Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || InputManeger.Instance.swipeUp && isMoving)
            {
                isMoving = true;
                rb.velocity = Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || InputManeger.Instance.swipeDown && isMoving)
            {
                isMoving = true;
                rb.velocity = -Vector3.forward * speed * Time.deltaTime;
            }
            if (rb.velocity == Vector3.zero)
            {
                isMoving = false;
            }
        }
        public void PickBrick(GameObject brickob)
        {
            brickob.transform.SetParent(BrickParent.transform);
            Vector3 pos = PrevBrick.transform.localPosition;
            pos.y -= 0.5f;
            brickob.transform.localPosition = pos;

            Vector3 Characterpos = transform.localPosition;
            Characterpos.y += 0.5f;
            transform.localPosition = Characterpos;
            PrevBrick.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
