using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {
    //キューブの移動速度
    private float speed = -0.2f;

    //消滅位置
    private float deadLine = -10;

    //地面の位置
    private float groundLevel = -3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;

        //地面に接触しているとき効果音を鳴らす
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	
	}

    void OnCollisionEnter(Collision other)
    {
        GetComponent<AudioSource>().volume = (other.transform.tag == "CubePrefab") ? 1 : 0;
    }
}
