using Assets.StackScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.StackScript
{
    public enum Direct { None, Forward, Back, Right, Left }


    public class Player : MonoBehaviour
    {


        private Vector3 mouseDown, mouseUp;
        private bool isMoving;
        private bool isControl;
        private bool isCanMove;
        private Vector3 moveNextPoint;

        [SerializeField] private Animator anim;
        [SerializeField] private Transform StartPosition;

        private string currentAnimName;

        private List<Transform> bricksInStack = new List<Transform>();
        public Transform brickStackPrefab;
        public Transform brickStackHolder;

        public Transform player;

        public LayerMask layerBrick;
        public float moveSpeed = 10f;

       private Vector3 offset = new Vector3(0, 3.5f, 0);

        private void Awake()
        {
            transform.position = StartPosition.transform.position;
            
            OnInit();
        }

        private void Update()
        {

            if (GameManeger1.Ins.IsState(GameState.GamePlay) && !isMoving)
            //if (!isMoving)
            {

                ChangeAnim("idle");
                if (Input.GetMouseButtonDown(0) && !isControl)
                {

                    isControl = true;
                    mouseDown = Input.mousePosition;
                }
                if (Input.GetMouseButtonUp(0) && isControl)
                {
                    isControl = false;
                    mouseUp = Input.mousePosition;

                    Direct direct = GetDirect(mouseDown, mouseUp);

                    if (direct != Direct.None)
                    {
                        moveNextPoint = GetNextPoint(direct);
                        isMoving = true;

                    }

                }
            }
            else if (isMoving)
            {


                if (Vector3.Distance(transform.position, moveNextPoint) < 0.001f)
                {
                    isMoving = false;

                }
                ChangeAnim("move");
                transform.position = Vector3.MoveTowards(transform.position, moveNextPoint, Time.deltaTime * moveSpeed);



            }



        }



        private Direct GetDirect(Vector3 mouseDown, Vector3 mouseUp)
        {
            Direct direct = Direct.None;

            float deltaX = mouseUp.x - mouseDown.x;
            float deltaY = mouseUp.y - mouseDown.y;

            if (Vector3.Distance(mouseDown, mouseUp) < 100f)
            {
                direct = Direct.None;
            }
            else
            {
                if (Mathf.Abs(deltaY) > Mathf.Abs(deltaX)) // Vuot theo chieu doc
                {
                    if (deltaY > 0f) // Vuot len tren
                    {
                        direct = Direct.Forward;
                    }
                    else // Vuot xuong duoi
                    {
                        direct = Direct.Back;
                    }
                }
                else // Vuot theo chieu ngang
                {
                    if (deltaX > 0f) // Vuot sang phai
                    {
                        direct = Direct.Right;
                    }
                    else // Vuot sang trai
                    {
                        direct = Direct.Left;
                    }
                }
            }

            return direct;
        }

        private Vector3 GetNextPoint(Direct direct)
        {
            RaycastHit hit;
            Vector3 nextPoint = transform.position;
            Vector3 dir = Vector3.zero;

            switch (direct)
            {
                case Direct.Forward:
                    dir = Vector3.forward;
                    Debug.Log("Up");
                    break;

                case Direct.Back:
                    dir = Vector3.back;
                    Debug.Log("Down");
                    break;

                case Direct.Left:
                    dir = Vector3.left;
                    Debug.Log("Left");
                    break;

                case Direct.Right:
                    dir = Vector3.right;
                    Debug.Log("Right");
                    break;

                case Direct.None:
                    break;

                default:
                    break;


            }


            //for (int i = 0; i < 100; i++)
            //{
            //    Debug.DrawRay(transform.position + dir * i + Vector3.up * 2f, Vector3.down, Color.red, 100f);
            //    if (Physics.Raycast(transform.position + dir * i + Vector3.up * 2f, Vector3.down, out hit, 100f, layerBrick))
            //    {
            //        //nextPoint = hit.collider.transform.position;

            //        Vector3 TempPos = hit.collider.transform.position;
            //        TempPos.y = transform.position.y;
            //        nextPoint = TempPos;
            //        Debug.Log(nextPoint);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            Debug.DrawRay(transform.position, dir, Color.red, 100f);
            if (Physics.Raycast(transform.position, dir, out hit , 100f, layerBrick))
            {

                Vector3 TempPos = hit.collider.transform.position;
                TempPos.y = transform.position.y;
                nextPoint = TempPos - dir * 1f;
                Debug.Log(nextPoint);
            }

            return nextPoint;
        }

        public void ChangeAnim(string animName)
        {
            if (currentAnimName != animName)
            {
                anim.ResetTrigger(animName);
                currentAnimName = animName;
                anim.SetTrigger(currentAnimName);
            }
        }

        public void OnInit()
        {
            isMoving = false;
            isControl = false;
            ChangeAnim("idle");
            transform.position = StartPosition.position;

        }

        public void AddBrick()
        {
            int index = bricksInStack.Count;

            Transform brickStack = Instantiate(brickStackPrefab, brickStackHolder);
            brickStack.localPosition = Vector3.down + index * 0.25f * Vector3.up;

            bricksInStack.Add(brickStack);

           player.localPosition = player.localPosition + Vector3.up * 0.25f;



        }

        public void RemoveBrick()
        {
            int index = bricksInStack.Count - 1;

            if (index >= 0)
            {
                Transform brickStack = bricksInStack[index];
                bricksInStack.RemoveAt(index);
                Destroy(brickStack.gameObject);

                player.localPosition = player.localPosition - Vector3.up * 0.25f;
            }
        }

        public void ClearBrick()
        {
            for (int i = 0; i < bricksInStack.Count; i++)
            {
                Destroy(bricksInStack[i].gameObject);
            }
            bricksInStack.Clear();
        }


    }

}