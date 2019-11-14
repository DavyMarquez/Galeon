using UnityEngine;
using System.Collections;

public class ShowGameMenu : MonoBehaviour
{
	
	public string m_menuSceneName;
	public enum TPushSceneType { PUSH_SCENE, POP_SCENE};
	public TPushSceneType m_type = TPushSceneType.PUSH_SCENE;
	public bool m_clearReturnScene = false;
	
	protected void Awake()
	{
        //TODO 1: nos registras en el input al boton return con OnReturnPressed.
        InputMgr imgr = GameMgr.GetInstance().GetServer<InputMgr>();
        imgr.RegisterReturn(OnReturnPressed);
    }

    public void OnEnable()
    {
        m_type = TPushSceneType.PUSH_SCENE;
    }

    public void OnReturnPressed()
    {
        //muestro el menu..
        SceneMgr smgr = GameMgr.GetInstance().GetServer<SceneMgr>();
        //TODO 2 if type == TPushSceneType.PUSH_SCENE => PushScene else ReturnScene
        if (m_type == TPushSceneType.PUSH_SCENE) {
            Debug.LogError("apilamos la escena de menu ");
            smgr.PushScene(m_menuSceneName);
            m_type = TPushSceneType.POP_SCENE;
        }
        else
        {
            Debug.LogError("Desapilamos la escena en la cima de la pila");
            smgr.PopScene(m_clearReturnScene);
            m_type = TPushSceneType.PUSH_SCENE;
        }
    }

    protected void OnDestroy() 
	{
        //TODO 3 desregistrar el return.
        InputMgr input = GameMgr.GetInstance().GetServer<InputMgr>();
        if (input != null)
        {
            input.UnRegisterReturn(OnReturnPressed);
            Debug.LogError("desregistramos");
        }
            

    }

    /*protected virtual void Tick(float deltaTime){}
	protected virtual void Init(){}
	
	protected virtual void End() {}*/
}
