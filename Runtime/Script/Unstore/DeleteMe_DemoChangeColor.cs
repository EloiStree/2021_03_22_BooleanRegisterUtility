using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BooleanRegisterUtilityAPI;
using System;

public class DeleteMe_DemoChangeColor : MonoBehaviour
{

    public RefRegisterMono m_target;
    public NamedRegBooleanChangeListener m_listener;
    public string m_booleanObserved = "up";
    public Light m_lightOnOff;


    public string m_logicObserved = "up+down + right";
    public LogicBlock m_logic;
    public string m_logicDebug  ;
    public LogicbooleanChangeObserver m_logicObserver;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        NewMethod();
    }

    private void NewMethod()
    {
        m_listener = new NamedRegBooleanChangeListener(m_booleanObserved, m_target.GetRef());
        m_listener.AddListener(DoTheThing);

        BL.PreStoreLogic(m_logicObserved, out m_logic);
        m_logicDebug = "" + m_logic;
        m_logicObserver = new LogicbooleanChangeObserver(m_logic);
        m_logicObserver.GetUniThreadListener().AddListener(ChangeColor);
    }

  

    private void Update()
    {
        if(m_logicObserver!=null)
         m_logicObserver.Compute();
    }

    private void ChangeColor(bool previous, bool current)
    {
        m_lightOnOff.color = current ? Color.red : Color.white;
    }

    private void DoTheThing(string booleanName, bool previous, bool current)
    {
        m_lightOnOff.enabled = !current;
    }

}
