using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class AnimalInfo//小鸟对象数据，频率+go
{
    public int frenquncy;
    public GameObject go;
    public float velocity = 0.01f;
}

public class BirdFly : MonoBehaviour
{
    //小鸟游戏对象数据
    public AnimalInfo[] m_Animals;

    private MicrophoneListener listener;
    private Dictionary<int, AnimalInfo> m_AnimalDic;
    private int[] lastArgs = new int[]{0,0};

    void Awake()
    {
        listener = gameObject.GetComponent<MicrophoneListener>();
        listener.FrenquencyEvent.AddListener(OnFrenquencyEvent);//监听频率变化事件
        m_AnimalDic = new Dictionary<int, AnimalInfo>();//存储动物频率和go
        foreach (var animal in m_Animals)
        {
            m_AnimalDic.Add(animal.frenquncy, animal);
        }
    }

    private void OnFrenquencyEvent(int[] args)
    { 
        foreach (var pair in m_AnimalDic)
        {
            //上一帧和本帧频率一样就是长音，不一样就是短音
            if (lastArgs.Contains(pair.Key) && args.Contains(pair.Key))//长音
            {
                var animal = pair.Value;
              

                Vector3 movement = new Vector3(0f, 0f, 0.001f);
                animal.go.transform.Translate(movement);
            }
            else if(args.Contains(pair.Key))//短音
            {
                var animal = pair.Value;

                Vector3 movement = new Vector3(0f, 0.001f, 0f);
                animal.go.transform.Translate(movement);



                Animator animator = animal.go.GetComponent<Animator>();
                animator.SetBool("takeoff", true);
                animator.SetBool("idle", false);
                animator.SetBool("fly", false);
            }
        }
        
        for (int i = 0; i < args.Length; i++)
        {
            lastArgs[i] = args[i];
        }
    }
}