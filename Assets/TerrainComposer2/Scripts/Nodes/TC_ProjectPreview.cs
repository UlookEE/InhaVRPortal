using UnityEngine;
using System.Collections;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class TC_ProjectPreview : MonoBehaviour
	{
		static public TC_ProjectPreview instance;
		public Material matProjector;

		private void Awake()
		{
			instance = this;
		}

		private void OnEnable()
		{
			instance = this;
		}

		private void OnDestroy()
		{
			instance = null;
		}

		public void SetPreview(TC_ItemBehaviour item)
		{
			matProjector.SetTexture("_MainTex", item.rtDisplay);
		}
	}
}
