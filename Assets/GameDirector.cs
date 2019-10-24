using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class GameDirector : MonoBehaviour
{
    //SerializeField = privateフィールドをインスペクタに表示する際に付けるおまじない
    [SerializeField]
    private GameObject Enemy;
    
    private List<GameObject> enemyList;
     
     [SerializeField]
    Text killText;
    [SerializeField]
    Text countText;
    //[SerializeField]
    //Image timeUp;

    private const int KILL_VALUE = 10;
    public int point;

    private const int MAX_COUNT = 150;
    private int count;
    private int frame;

    //bool = 変数の型名 trueまたはfalse
    private bool gamePlay;

    // Start is called before the first frame update
    void Start()
    {
        //Random = 乱数を生成する際のクラス
        //System = 名前空間であり、Randomクラスとセットで使われる
        System.Random random = new System.Random();

        //Create Enemy
        enemyList = new List<GameObject>();
        for(int i = 0; i < MAX_COUNT; i++)
        {
            //Instantiate = ゲーム中に表示される主人公や敵キャラクターなどの動的なオブジェクトを生成する関数
            //var = メソッド内のローカル変数を宣言する際に型宣言の代わりに使用する。コンパイラが自動で型を判断してくれる
            //var = 長い型名の代わりに var を使うとコードをスッキリする
            //var = 右辺から型が明らかでない場合、var は推奨されない
            var go = Instantiate(Enemy);
            go.GetComponent<Enemy>().SetGameDirector(this);
            //if(go == null)
            //{
            //     Debug.Log("生成できていない");

            //}
            //else if(go.GetComponent<Enemy>() == null)
            //{
              //  Debug.Log("EnemyがAddされていない");
            //}

            //random
            int positionX = random.Next(-100, 100);
            int positionY = random.Next(0, 150);
            
            go.GetComponent<Transform>().position = new Vector3(
                positionX,positionY,
                go.GetComponent<Transform>().position.z
            );

            enemyList.Add(go);
        }
        count = MAX_COUNT;
        frame = 0;
        gamePlay = true;

        SetKillText();

    }

    // Update is called once per frame
    void Update()
    {
        SetKillText();
        /* frame++;
        if(frame >= 60)
        {
            count--;
            frame = 0;

            //SetKillText();
            //SetCountText();
        }
        */
    }
    
    
    private void SetKillText()
    {
        if(gamePlay == false) return;
        this.killText.text = point.ToString();
        Debug.Log("SetKillText");
    }
    public void GetPoint()
    {
        if(gamePlay == false) return;
        this.point += KILL_VALUE;
        Debug.Log("KILL_VALUEED");
    }
}


