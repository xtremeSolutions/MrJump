using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle environment;
    public string path;
   public void Start()
    {
        LoadAssetBundle(path);
        instantiateEnvironment("environment");
    }

    public void LoadAssetBundle(string url)
    {
        environment = AssetBundle.LoadFromFile(url);  
    }

    void instantiateEnvironment(string path)
    {
        var prefeb = environment.LoadAsset("environment");
        Instantiate(prefeb);
    }


}

