﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class FreeClimb : MonoBehaviour
    {
        public Animator anim;
        public bool isClimbing;

        bool inPosition;
        bool isLerping;
        float t;
        Vector3 startPos;
        Vector3 targetPos;
        Quaternion startRot;
        Quaternion targetRot;
        public float possitionOffset;
        public float offsetFromWall = 0.3f;
        public float speed_multiplier = 0.2f;
        public float climbSpeed = 3;
        public float rotateSpeed = 5;

        Transform helper;
        float delta;
        void Start()
        {
            Init();
        }

        public void Init()
        {
            helper = new GameObject().transform;
            helper.name = "climb helper";

            CheckForClimb();
        }

        public void CheckForClimb()
        {
            Vector3 origin = transform.position;
            origin.y += 1.4f;
            Vector3 dir = transform.forward;
            RaycastHit hit;
            if (Physics.Raycast(origin, dir, out hit, 5))
            {
                helper.position = PosWithOffset(origin, hit.point);
                InitForClimb(hit);
            }
        }

        void InitForClimb(RaycastHit hit)
        {
            isClimbing = true;
            helper.transform.rotation = Quaternion.LookRotation(-hit.normal);
            startPos = transform.position;
            targetPos = hit.point + (hit.normal * offsetFromWall);
            t = 0;
            inPosition = false;
            anim.CrossFade("climb_idle", 2);

        }

        void Update()
        {
            delta = Time.deltaTime;
            Tick(delta);
        }

        public void Tick(float delta)
        {
            if (!inPosition)
            {
                GetInPosition();
                return;
            }

            if (!isLerping)
            {
                float hor = Input.GetAxis("Horizontal");
                float vert = Input.GetAxis("Vertical");
                float m = Mathf.Abs(hor) + Mathf.Abs(vert);

                Vector3 h = helper.right * hor;
                Vector3 v = helper.up * vert;
                Vector3 moveDir = (h + v).normalized;

                bool canMove = CanMove(moveDir);
                if (!canMove || moveDir == Vector3.zero)
                    return;

                t = 0;
                isLerping = true;
                startPos = transform.position;
                // Vector3 tp = helper.position - transform.position;
                targetPos = helper.position;



            }
            else
            {
                t += delta * climbSpeed;
                if (t > 1)
                {
                    t = 1;
                    isLerping = false;
                }

                Vector3 cp = Vector3.Lerp(startPos, targetPos, t);
                transform.position = cp;
                transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);

            }
        }

        bool CanMove(Vector3 moveDir)
        {
            Vector3 origin = transform.position;
            float dis = possitionOffset;
            Vector3 dir = moveDir;
            Debug.DrawRay(origin, dir * dis);
            RaycastHit hit;

            if (Physics.Raycast(origin, dir, out hit, dis))
            {
                return false;
            }

            origin += moveDir * dis;
            dir = helper.forward;
            float dis2 = 0.5f;

            Debug.DrawRay(origin, dir * dis2);
            if (Physics.Raycast(origin, dir, out hit, dis))
            {
                helper.position = PosWithOffset(origin, hit.point);
                helper.rotation = Quaternion.LookRotation(-hit.normal);
                return true;
            }

            origin += dir * dis2;
            dir = -Vector3.up;

            Debug.DrawRay(origin, dir);
            if (Physics.Raycast(origin, dir, out hit, dis2))
            {
                float angle = Vector3.Angle(helper.up, hit.normal);
                if (angle < 40)
                {
                    helper.position = PosWithOffset(origin, hit.point);
                    helper.rotation = Quaternion.LookRotation(-hit.normal);
                    return true;
                }
            }
            return false;
        }

        void GetInPosition()
        {
            t += delta;
            if (t > 1)
            {
                t = 1;
                inPosition = true;

            }

            Vector3 tp = Vector3.Lerp(startPos, targetPos, t);
            transform.rotation = Quaternion.Slerp(transform.rotation, helper.rotation, delta * rotateSpeed);
        }

        Vector3 PosWithOffset(Vector3 origin, Vector3 target)
        {
            Vector3 direction = origin - target;
            direction.Normalize();
            Vector3 offset = direction * offsetFromWall;
            return target + offset;

        }

    }
}