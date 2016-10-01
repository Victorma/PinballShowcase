using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextureAnimator : MonoBehaviour {

    public RawImage image;

    public Texture[] textures;
    public float timeBetweenMs;

    private int pos = 0;

  /*  [UnityEditor.MenuItem("Test/Fill")]
    public static void FillUp()
    {
        string[] images = UnityEditor.AssetDatabase.FindAssets("output");
        Debug.Log(images.Length);
        ArrayList tmp = new ArrayList();

        foreach (var i in images)
        {
            Debug.Log("loading " + i);
            tmp.Add(UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(UnityEditor.AssetDatabase.GUIDToAssetPath(i)));
        }

        var tas = FindObjectsOfType<TextureAnimator>();
        Debug.Log(tas.Length);
        Debug.Log(tmp[0].GetType());

        Texture[] ta = new Texture[tmp.Count];
        int tn = 0;
        foreach (var t in tmp) ta[tn++] = t as Texture;
        tas[0].textures = ta;
    }*/

	// Use this for initialization
	void Start () {
        StartCoroutine(Play());
	}
	
	private IEnumerator Play()
    {
        while (true)
        {
            image.texture = textures[pos];
            yield return new WaitForSeconds(timeBetweenMs/1000f);
            pos = (pos + 1) % textures.Length;
        }
    }

    public void Restart()
    {
        pos = 0;
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
}
