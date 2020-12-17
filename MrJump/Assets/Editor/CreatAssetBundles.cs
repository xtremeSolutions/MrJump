using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatAssetBundles  : Editor
{
	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
		BuildPipeline.BuildAssetBundles(@"C:\Users\M.Arsalan\Desktop\AssetBundles", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
	}
}
