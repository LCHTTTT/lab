using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cb : MonoBehaviour
 {
        [SerializeField] bool isClick;//是否点击
        [SerializeField] float tempTime = 0;//计时器
        [SerializeField] private Button leftBtn;
        void Awake()
        {
            leftBtn.onClick.AddListener(OnClick);//注册按钮事件
        }
        void Update()
        {
            if (isClick)//如果被点击
            {
                tempTime += Time.deltaTime;
                //间隔时长
                if (tempTime > 0.5f)
                {
                    tempTime = 0;
                    leftBtn.enabled = true;
                    isClick = false;
                }
            }
        }

        private void OnClick()
        {
            isClick = true;
            leftBtn.enabled = false;
        }
    }
