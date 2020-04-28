using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    // ScrollViewの中にButtonを複数並べた構成を想定（ScrollViewのコンポーネントに追加）

    public class ObjectController : MonoBehaviour
    {
        [SerializeField] private GameObject CreateButtonObj;
        [SerializeField] private GameObject DeleteButtonObj;

        private List<GameObject> objList = new List<GameObject>();
        private GameObject resourceButtonObj;
        private GameObject objChild;

        // 作成するボタン番号
        public int CreateButtonNumber { get; private set; } = 1;

        private System.Func<GameObject, int> callBack;

        // Start is called before the first frame update
        void Start()
        {
            // nullの場合エラーメッセージ出力
            Debug.Assert(CreateButtonObj, "CreateButtonObj が null");
            Debug.Assert(DeleteButtonObj, "DeleteButtonObj が null");

            // Buttonコンポーネントにクリックイベント追加
            CreateButtonObj.GetComponent<Button>().onClick.AddListener(OnClickCreateButton);
            DeleteButtonObj.GetComponent<Button>().onClick.AddListener(OnClickDeletButton);

            // Resorcesフォルダからプレハブを取得
            resourceButtonObj = Resources.Load("Button") as GameObject;
            Debug.Assert(resourceButtonObj, "resourceButtonObj が null");
            // 不要になったらリソースは開放する
            // Resources.UnloadUnusedAssets();

            callBack = delegate (GameObject callObj)
            {
                Debug.Log("No Delet Obj");
                return 1;
            };

            // 自身のオブジェクト取得
            GameObject obj = this.gameObject;

            // オブジェクトを検索して取得（非アクティブオブジェクトは検索できない）
            // GameObject.Findは処理が重いのでなるべく使わないこと
            GameObject canvas = GameObject.Find("Canvas");

            // ルートオブジェクト取得（このオブジェクトのルートはCanvas）
            GameObject rootObj = this.transform.root.gameObject;
            Debug.Assert(canvas == rootObj, "オブジェクトが違う");

            // シーンが移動しても消えないオブジェクトを登録
            // シーンが呼ばれるごとに増えてしまうため登録するオブジェクトはシングルトンにする
            DontDestroyOnLoad(rootObj);

            // 孫オブジェクトを検索して取得（階層を/で指定）（非アクティブオブジェクトも検索可能）
            objChild = this.gameObject.transform.Find("Viewport/Content").gameObject;

            // 子オブジェクトの数取得
            int a = objChild.transform.childCount;

            // 子オブジェクトを複数取得
            int number = 0;
            foreach (Transform childTransform in objChild.transform)
            {
                GameObject child = childTransform.gameObject;

                // Buttonコンポーネントの取得
                Button button = child.GetComponent<Button>();
                // Buttonコンポーネントにクリックイベント追加（引数あり）
                button.onClick.AddListener(() => OnClickButton(child));

                // Buttonのテキスト変更（番号順）
                number++;
                child.transform.GetComponentInChildren<Text>().text += number;
            }

        }

        // Update is called once per frame
        void Update()
        {
            // Find系の処理は重いのでUpdate内では使わないこと

            // 現在選択中のオブジェクト
            //    Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);

            // フォーカスを一番上のボタンに移動
            if (Input.GetKeyDown(KeyCode.A))
            {
                int number = 0;
                foreach (Transform childTransform in objChild.transform)
                {
                    GameObject child = childTransform.gameObject;
                    if (number == 0)
                    {
                        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(child);
                        break;
                    }
                }
            }

            // フォーカスを一番下のボタンに移動
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // 子オブジェクトの数取得
                int count = objChild.transform.childCount;

                int number = 0;
                foreach (Transform childTransform in objChild.transform)
                {
                    GameObject child = childTransform.gameObject;
                    if (number == (count - 1))
                    {
                        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(child);
                        break;
                    }
                    number++;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject nullObj = null;
                nullObj.name = "null";
            }
        }

        /// <summary>
        /// スクロールに新しいボタン追加
        /// </summary>
        public void OnClickCreateButton()
        {
            // プレハブを元にオブジェクトを生成する
            GameObject instance = Instantiate(resourceButtonObj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

            // Buttonのテキスト変更（作成番号順）
            instance.transform.GetComponentInChildren<Text>().text += CreateButtonNumber + " Create";
            CreateButtonNumber++;

            // Buttonの色を変える
            instance.GetComponent<Image>().color = new Color32(255, 0, 0, 128);

            // 生成したオブジェクトを子として登録
            instance.transform.SetParent(objChild.transform);

            objList.Add(instance);
        }

        /// <summary>
        /// スクロールに新しいボタン追加（下にスクロール）
        /// </summary>
        public void OnClickCreateButtonScroll()
        {
            // メソッドを呼び出す（引数は１つだけ持たせられるが戻り値は持てない）
            // 参照関係がわからなくなるためなるべく使用しない（非アクティブなオブジェクトにも使えない）
            SendMessage("OnClickCreateButton");

            // オブジェクトを検索して取得
            GameObject obj = GameObject.Find("Scrollbar Vertical");
            // スクロールを下に移動
            obj.GetComponent<Scrollbar>().value = 0.0f;
        }

        /// <summary>
        /// 生成したボタンオブジェクトを破棄
        /// </summary>
        public void OnClickDeletButton()
        {
            if (objList.Count != 0)
            {
                // オブジェクトを破棄
                Destroy(objList[0]);
                objList.Remove(objList[0]);
            }
            else
            {
                int a = callBack(this.gameObject);
            }
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="buttonObj">ボタンオブジェクト</param>
        public void OnClickButton(GameObject buttonObj)
        {
            // 同階層におけるオブジェクトの順序取得
            int index = buttonObj.transform.GetSiblingIndex();
            // 押されたボタンの名前出力
            Debug.Log(buttonObj.name + " index : " + index);

            if (index < 10)
            {
                // 親オブジェクトを取得
                GameObject parentObj = buttonObj.transform.parent.gameObject;

                // 子オブジェクトの数取得
                int childMax = parentObj.transform.childCount;

                // Buttonオブジェクトの順序を一番下に移動（セットした時点で移動する）
                // buttonObj.transform.SetAsLastSibling(); でもいい
                buttonObj.transform.SetSiblingIndex(childMax - 1);
            }
            else
            {
                // Buttonオブジェクトの順序を一番上に移動（セットした時点で移動する）
                // buttonObj.transform.SetAsFirstSibling(); でもいい
                buttonObj.transform.SetSiblingIndex(0);
            }

            // スクロールバーをコルーチンを使って移動
            StartCoroutine(ScrollDelay(index));
        }

        /// <summary>
        /// ゆっくりスクロール
        /// Animation使った方が滑らかなスクロールになるかも
        /// </summary>
        /// <param name="bar">Scrollbarコンポーネント</param>
        /// <returns></returns>
        private IEnumerator ScrollDelay(int index)
        {
            // 子オブジェクトを検索して取得
            GameObject obj = this.gameObject.transform.Find("Scrollbar Vertical").gameObject;
            // Scrollbarコンポーネント取得
            Scrollbar bar = obj.GetComponent<Scrollbar>();

            //コルーチンの内容
            while (true)
            {
                // 0.01秒処理を待つ
                yield return new WaitForSeconds(0.01f);

                // 1フレーム待つ（フレーム時間によって時間が変わるので注意）
                // yield return null;

                if (index < 10)
                {
                    // スクロールバーを徐々に1番下へ移動
                    bar.value -= 0.2f;
                }
                else
                {
                    // スクロールバーを徐々に1番上へ移動
                    bar.value += 0.2f;
                }

                if (bar.value <= 0.0f || bar.value >= 1.0f)
                {
                    // コルーチン終了
                    yield break;
                }
            }
        }

        SaveData save = new SaveData();

        /// <summary>
        /// リストのボタン名一覧を保存
        /// </summary>
        public void OnClickSaveButton()
        {
            save.PlayerHP += 100;
            save.EnemyHP += 10;
            save.Obj = this.gameObject;

            string json = JsonUtility.ToJson(save);

            PlayerPrefs.SetString("SaveData", json);
        }

        /// <summary>
        /// 保存したデータ読み込み
        /// </summary>
        public void OnClickLoadButton()
        {
            string json = PlayerPrefs.GetString("SaveData");
            Debug.Log(json);

            JsonUtility.FromJsonOverwrite(json, save);
            Debug.Log(save.PlayerHP);
            Debug.Log(save.EnemyHP);
            Debug.Log(save.Obj.name);
        }

        /// <summary>
        /// セーブデータ削除ボタン
        /// </summary>
        public void OnClickSaveDeletButton()
        {
            PlayerPrefs.DeleteKey("SaveData");
        }

        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        /// <summary>
        /// 例外検出時のコールバック
        /// </summary>
        /// <param name="logString"></param>
        /// <param name="stackTrace"></param>
        /// <param name="type"></param>
        void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (type == LogType.Exception)
            {
                Debug.Log(logString);
                Debug.Log(stackTrace);
                Debug.Log(type);

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                UnityEngine.Application.Quit();
#endif
            }
        }
    }
}
