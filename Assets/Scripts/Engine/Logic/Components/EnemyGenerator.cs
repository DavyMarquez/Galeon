using UnityEngine;
using System.Collections;

//Generador de enemigos. Puede generar enemigos aleatoriamente hasta un cierto numero.
//Los genera al rededor suyo. 
public class EnemyGenerator : MonoBehaviour
{

	public string m_icon = "Electric_Generator_icon.png";
	public float  m_timeToGenerateS = 5.0f;
	public int m_numMaxEnemies = 20;
	public int m_numEnemies = 0;
	public GameObject[] _prefabs;
	public float _generateRadious = 20;

    private SpawnerMgr m_spawnerMgr;
    private float m_timeToLastEnemyGenerate = 0;
	private Vector3 m_offset = new Vector3(0.5f,0.0f,0.5f);
	//El gizmo debe estar en assets/Gizmos
	void OnDrawGizmos() 
	{
		Gizmos.DrawIcon(transform.position, m_icon,true);
	}
	
	// Use this for initialization
	protected void Start () 
	{
		m_timeToLastEnemyGenerate = m_timeToGenerateS;
        m_spawnerMgr = GameMgr.GetInstance().GetSpawnerMgr();
    }
	
	// Update is called once per frame
	protected void Update(){
		m_timeToLastEnemyGenerate -= Time.deltaTime;
		//Cuando termina el tiempo entre generacion y generacion, creamos un objeto dle pool.
		if(m_timeToLastEnemyGenerate < 0 && _prefabs.Length > 0 && m_numEnemies < m_numMaxEnemies)
		{
			m_numEnemies++;
			m_timeToLastEnemyGenerate = m_timeToGenerateS;
			int enemyIdx = Random.Range(0,_prefabs.Length);
			Vector3 position = transform.position;
			float radious = Random.Range(0.0f,_generateRadious);
			position += m_offset * radious;
            //Par instanciarlo usamos el SpawnerMgr. Si lo usamos podremos utilizar el pool de objetos precargados
            //lo que nos ayudara a reducir la fragmentacio nde memoria.
            ///TODO 1 instanciar usando el spawnerMGr.

            Quaternion rotation = new Quaternion();
            GameObject enemy = m_spawnerMgr.CreateNewGameObject(_prefabs[0], position, rotation);
            
        }
    }
	

}