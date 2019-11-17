using UnityEngine;
using System.Collections;

/// <summary>
/// Un GameObject Es destruible si tiene el Componente Destroyable y escucha el mensaje DestroyGameObject.
/// </summary>
public class Destroyable : MonoBehaviour
{
 
	public bool m_desactive = true;
    private SpawnerMgr m_spawnerMgr;

    //Mensaje
    void DestroyGameObject()
	{
        GameMgr.GetInstance().GetSpawnerMgr().DestroyGameObject(gameObject);
    }
 
}
