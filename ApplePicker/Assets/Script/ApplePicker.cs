using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [SerializeField] private GameObject basketPrefab;
    [SerializeField] private int numBaskets = 3;
    [SerializeField] private float basketBottomY = -14f;
    [SerializeField] private float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [SerializeField] private Button playAgainButton;
    [SerializeField] private AppleTree appleTree;

    void Start()
    {
        playAgainButton.gameObject.SetActive(false);
        playAgainButton.onClick.AddListener(ReloadScene);

        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in appleArray)
        {
            Destroy(apple);
        }

        int basketindex = basketList.Count - 1;
        GameObject basketGO = basketList[basketindex];
        basketList.RemoveAt(basketindex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            playAgainButton.gameObject.SetActive(true);
            appleTree.GameOver();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
