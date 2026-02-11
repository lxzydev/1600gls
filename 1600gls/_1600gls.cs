using System;
using System.IO;
using MSCLoader;
using UnityEngine;

namespace _1600gls
{
	public class _1600gls : Mod
	{
		public override string ID => "GlsSorbet1600";
		public override string Name => "GlsSorbet1600";
		public override string Author => "Dom, updated by lxzy";
		public override string Version => "1.0.0";
		public override string Description => "New Sorbet 1600 GLS";
		public override Game SupportedGames => Game.MyWinterCar;

		public override void ModSetup()
		{
			SetupFunction(Setup.ModSettings, Mod_Settings);
			SetupFunction(Setup.OnLoad, Mod_OnLoad);
			SetupFunction(Setup.Update, Mod_OnUpdate);
		}

		private void Mod_Settings()
		{
			Settings.AddHeader("Options", false, true);
			my_slider = Settings.AddSlider("STEERING WHEEL", "Choose", 0, 1, 0, OnSteeringChanged, sliderValues, true);
			Settings.AddHeader("Options1", false, true);
			my_slider2 = Settings.AddSlider("woodpearls", "Choose", 0, 1, 0, OnWoodpearlsChanged, sliderValues2, true);
		}

		private void OnSteeringChanged()
		{
			ModConsole.Log("[GlsSorbet1600] Save and load to apply steering wheel change.");
		}

		private void OnWoodpearlsChanged()
		{
			ModConsole.Log("[GlsSorbet1600] Save and load to apply woodpearls change.");
		}

		private void Mod_OnLoad()
		{
			AssetBundle assetBundle = LoadAssets.LoadBundle(this, "sob.unity3d");
			if (assetBundle == null)
			{
				return;
			}
			SubstituirPeca(assetBundle, "sobo", "SORBET(190-200psi)/GFXpivot/paint");
			SubstituirPeca(assetBundle, "sobhood", "SORBET(190-200psi)/GFXpivot/hood");
			SubstituirPeca(assetBundle, "lanterna", "SORBET(190-200psi)/GFXpivot/lights");
			SubstituirPeca(assetBundle, "PortaL", "SORBET(190-200psi)/Doors/DoorFront(leftx)/FrontL");
			SubstituirPeca(assetBundle, "PortaR", "SORBET(190-200psi)/Doors/DoorFront(right)/FrontR");
			SubstituirPeca(assetBundle, "panel_L", "SORBET(190-200psi)/Doors/DoorFront(leftx)/FrontL/panel");
			SubstituirPeca(assetBundle, "panel_R", "SORBET(190-200psi)/Doors/DoorFront(right)/FrontR/panel");
			SubstituirPeca(assetBundle, "GlassFL", "SORBET(190-200psi)/Doors/DoorFront(leftx)/FrontL/WindowPivot/GlassPivot/GlassFL");
			SubstituirPeca(assetBundle, "GlassFR", "SORBET(190-200psi)/Doors/DoorFront(right)/FrontR/WindowPivot/GlassPivot/GlassFR");
			SubstituirPeca(assetBundle, "Mirror_espelho", "SORBET(190-200psi)/Doors/DoorFront(leftx)/FrontL/mirror");
			SubstituirPeca(assetBundle, "Mirror_espelhoR", "SORBET(190-200psi)/Doors/DoorFront(right)/FrontR/mirror");
			SubstituirPeca(assetBundle, "bootlid_fix_new", "SORBET(190-200psi)/Hatch/Hatch/hatch");
			if (my_slider != null && my_slider.GetValue() == 1)
			{
				SubstituirPeca(assetBundle, "volantenew", "SORBET(190-200psi)/Functions/SteeringColumnPivot/Steering/SteeringPivotSorbett/steering_wheel");
			}
			prefabSetaL = CarregarPrefab(assetBundle, "setasL");
			prefabSetaR = CarregarPrefab(assetBundle, "setasR");
			prefabFarol = CarregarPrefab(assetBundle, "farol");
			prefabre = CarregarPrefab(assetBundle, "luzre");
			prefabMark = CarregarPrefab(assetBundle, "marks-suport");
			prefabMark1 = CarregarPrefab(assetBundle, "marks-suport");
			assetBundle.Unload(false);
		}

		private void Mod_OnUpdate()
		{
			if (!instalacaoConcluida)
			{
				tempoultima += Time.deltaTime;
				if (tempoultima > 2f)
				{
					TentarFinalizar();
					tempoultima = 0f;
				}
				AtualizarAcessorios();
				timerLimpeza += Time.deltaTime;
				if (timerLimpeza > 2f)
				{
					EliminarOBJS();
					timerLimpeza = 0f;
				}
				if (instalacaoConcluida && !adesivoAplicado)
				{
					Newstick();
					adesivoAplicado = true;
				}
			}
		}

		private void AtualizarAcessorios()
		{
			GameObject gameObject = GameObject.Find("SORBET(190-200psi)/GFXpivot/woodpearls");
			if (gameObject != null && my_slider2 != null)
			{
				bool active = my_slider2.GetValue() == 1;
				gameObject.SetActive(active);
			}
		}

		private void TentarFinalizar()
		{
			GameObject gameObject = GameObject.Find("SORBET(190-200psi)");
			if (gameObject == null)
			{
				return;
			}
			Vector3 pos = new Vector3(0f, -0.14f, -0.01f);
			Vector3 rot = new Vector3(270f, 180f, 0f);
			Vector3 sca = new Vector3(1f, 1f, 1f);
			Vector3 pos2 = new Vector3(0f, -0.14f, -0.01f);
			Vector3 rot2 = new Vector3(270f, 180f, 0f);
			Vector3 sca2 = new Vector3(1f, 1f, 1f);
			Vector3 pos3 = new Vector3(0f, -0.38999f, -1.819f);
			Vector3 rot3 = new Vector3(90f, 0f, 0f);
			Vector3 sca3 = new Vector3(1f, 1f, -1f);
			Vector3 pos4 = new Vector3(0f, 2.165f, 0.37999f);
			Vector3 rot4 = new Vector3(5f, 0f, 0f);
			Vector3 sca4 = new Vector3(1f, 1f, -1f);
			Vector3 pos5 = new Vector3(0f, -0.0999f, 0f);
			Vector3 rot5 = new Vector3(0f, 0f, 0f);
			Vector3 sca5 = new Vector3(1.01f, 1.04f, 1.01f);
			Vector3 pos6 = new Vector3(0f, -0.0999f, 0f);
			Vector3 rot6 = new Vector3(0f, 0f, 0f);
			Vector3 sca6 = new Vector3(1.01f, 1.04f, 1.01f);
			bool flag = true & InstalarLuz(gameObject.transform, "Simulation/Electriicity/PowerOn/Indicators/Left", prefabSetaR, pos, rot, sca) & InstalarLuz(gameObject.transform, "Simulation/Electriicity/PowerOn/Indicators/Right", prefabSetaL, pos2, rot2, sca2) & InstalarLuz(gameObject.transform, "Simulation/Electriicity/PowerOn/BeamsShort", prefabFarol, pos3, rot3, sca3) & InstalarLuz(gameObject.transform, "Simulation/Electriicity/PowerOn/BeamsLong", prefabFarol, pos3, rot3, sca3) & InstalarLuz(gameObject.transform, "Simulation/Electriicity/PowerOn/RearAuxLights/Reverse", prefabre, pos4, rot4, sca4) & InstalarLuz(gameObject.transform, "Simulation/Electricity/PowerON/MarkersInstalled/Markers/BeamMarkerRight/lit", prefabMark, pos5, rot5, sca5) & InstalarLuz(gameObject.transform, "Simulation/Electricity/PowerON/MarkersInstalled/Markers/BeamMarkerLeft/lit", prefabMark1, pos6, rot6, sca6);
			AjustarPosicao("SORBET(190-200psi)/Simulation/CarTempSorbet", new Vector3(0f, 0f, -0.06f));
			AjustarPosicao("SORBET(190-200psi)/LOD/marker_light 1", new Vector3(0.4110107f, -0.042f, 1.928015f));
			AjustarPosicao("SORBET(190-200psi)/LOD/marker_light", new Vector3(-0.4110107f, -0.042f, 1.928015f));
			AjustarPosicao("SORBET(190-200psi)/Doors/DoorFront(leftx)/FrontL/mirror/Mirror_espelho(Clone)", new Vector3(-0.012f, 0.075f, -0.215f));
			AjustarScale("SORBET(190-200psi)/Doors/DoorFront(leftx)/FrontL/mirror/Mirror_espelho(Clone)", new Vector3(1.004f, 1.004f, 1.004f));
			AjustarPosicao("SORBET(190-200psi)/Doors/DoorFront(right)/FrontR/mirror/Mirror_espelhoR(Clone)", new Vector3(0.009f, 0.076f, -0.216f));
			AjustarScale("SORBET(190-200psi)/Doors/DoorFront(right)/FrontR/mirror/Mirror_espelhoR(Clone)", new Vector3(-1.004f, 1.004f, 1.004f));
			if (flag)
			{
				instalacaoConcluida = true;
			}
		}

		private bool InstalarLuz(Transform raiz, string caminho, GameObject meuPrefab, Vector3 pos, Vector3 rot, Vector3 sca)
		{
			if (meuPrefab == null)
			{
				return false;
			}
			Transform transform = raiz.Find(caminho);
			if (transform == null)
			{
				string[] array = caminho.Split(new char[]
				{
					'/'
				});
				transform = BuscarFilhoo(raiz, array[array.Length - 1]);
			}
			if (!(transform != null))
			{
				return false;
			}
			Transform transform2 = transform.Find("mesh");
			if (transform2 != null)
			{
				UnityEngine.Object.Destroy(transform2.gameObject);
			}
			if (transform.Find("SorbetMod_Luz") != null)
			{
				return true;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(meuPrefab);
			gameObject.name = "SorbetMod_Luz";
			gameObject.transform.SetParent(transform);
			gameObject.transform.localPosition = pos;
			gameObject.transform.localEulerAngles = rot;
			gameObject.transform.localScale = sca;
			foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>(true))
			{
				meshRenderer.enabled = true;
				meshRenderer.gameObject.layer = transform.gameObject.layer;
			}
			gameObject.SetActive(true);
			MeshRenderer component = transform.GetComponent<MeshRenderer>();
			if (component != null)
			{
				component.enabled = false;
			}
			return true;
		}

		private void EliminarOBJS()
		{
			GameObject gameObject = GameObject.Find("SORBET(190-200psi)");
			if (gameObject != null)
			{
				Transform transform = gameObject.transform.Find("LOD/RegPlateGen");
				if (transform != null)
				{
					transform.gameObject.SetActive(false);
					if (transform.GetComponent<MeshRenderer>())
					{
						transform.GetComponent<MeshRenderer>().enabled = false;
					}
					UnityEngine.Object.Destroy(transform.gameObject);
				}
				Transform transform2 = gameObject.transform.Find("LOD/chassis");
				if (transform2 != null)
				{
					transform2.gameObject.SetActive(false);
					UnityEngine.Object.Destroy(transform2.gameObject);
				}
				Transform transform3 = gameObject.transform.Find("LOD/mudflaps");
				if (transform3 != null)
				{
					transform3.gameObject.SetActive(false);
					UnityEngine.Object.Destroy(transform3.gameObject);
				}
				Transform transform4 = gameObject.transform.Find("Hatch/Hatch/sticker");
				if (transform4 != null)
				{
					transform4.gameObject.SetActive(false);
					UnityEngine.Object.Destroy(transform4.gameObject);
				}
			}
		}

		private void Newstick()
		{
			string gameObjectPath = "SORBET(190-200psi)/GFXpivot/paint/sobo(Clone)/stickes_mesh";
			string gameObjectPath2 = "SORBET(190-200psi)/Hatch/Hatch/hatch/bootlid_fix_new(Clone)/GlassRear_stick";
			string fileName = "sorbet_sticks.png";
			ApplyTextureTransparent(fileName, gameObjectPath);
			ApplyTextureTransparent(fileName, gameObjectPath2);
		}

		private void ApplyTextureTransparent(string fileName, string gameObjectPath)
		{
			if (File.Exists(Path.Combine(ModLoader.GetModAssetsFolder(this), fileName)))
			{
				Texture2D texture2D = LoadAssets.LoadTexture(this, fileName, false);
				if (texture2D != null)
				{
					Material material = new Material(Shader.Find("Transparent/Diffuse"));
					material.mainTexture = texture2D;
					GameObject gameObject = GameObject.Find(gameObjectPath);
					if (gameObject != null)
					{
						Renderer component = gameObject.GetComponent<Renderer>();
						if (component != null)
						{
							component.material = material;
						}
					}
				}
			}
		}

		private void SubstituirPeca(AssetBundle bundle, string prefabName, string pathNoJogo)
		{
			GameObject gameObject = CarregarPrefab(bundle, prefabName);
			if (gameObject == null)
			{
				return;
			}
			GameObject gameObject2 = GameObject.Find(pathNoJogo);
			if (gameObject2 != null)
			{
				MeshRenderer component = gameObject2.GetComponent<MeshRenderer>();
				Material[] array = null;
				if (component != null)
				{
					array = component.sharedMaterials;
				}
				UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshFilter>());
				UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshRenderer>());
				GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(gameObject);
				gameObject3.transform.SetParent(gameObject2.transform);
				gameObject3.transform.localPosition = Vector3.zero;
				gameObject3.transform.localRotation = Quaternion.identity;
				gameObject3.transform.localScale = Vector3.one;
				MeshRenderer meshRenderer = gameObject3.GetComponent<MeshRenderer>() ?? gameObject3.GetComponentInChildren<MeshRenderer>();
				if (meshRenderer != null && array != null)
				{
					meshRenderer.sharedMaterials = array;
				}
			}
		}

		private void AjustarPosicao(string path, Vector3 novaPosicao)
		{
			GameObject gameObject = GameObject.Find(path);
			if (gameObject != null)
			{
				gameObject.transform.localPosition = novaPosicao;
			}
		}

		private void AjustarScale(string path, Vector3 novaScale)
		{
			GameObject gameObject = GameObject.Find(path);
			if (gameObject != null)
			{
				gameObject.transform.localScale = novaScale;
			}
		}

		private GameObject CarregarPrefab(AssetBundle bundle, string nome)
		{
			return bundle.LoadAsset<GameObject>(nome) ?? bundle.LoadAsset<GameObject>(nome + ".prefab");
		}

		private Transform BuscarFilhoo(Transform pai, string nomeAlvo)
		{
			foreach (object obj in pai)
			{
				Transform transform = (Transform)obj;
				if (transform.name == nomeAlvo)
				{
					return transform;
				}
				Transform transform2 = BuscarFilhoo(transform, nomeAlvo);
				if (transform2 != null)
				{
					return transform2;
				}
			}
			return null;
		}

		private GameObject prefabSetaL;
		private GameObject prefabSetaR;
		private GameObject prefabFarol;
		private GameObject prefabre;
		private GameObject prefabMark;
		private GameObject prefabMark1;
		private SettingsSliderInt my_slider;
		private string[] sliderValues = new string[]
		{
			"Stock Steering Wheel",
			"New Steering Wheel"
		};
		private SettingsSliderInt my_slider2;
		private string[] sliderValues2 = new string[]
		{
			"NO woodpearls",
			"YES woodpearls"
		};
		private bool instalacaoConcluida;
		private float timerLimpeza;
		private float tempoultima;
		private bool adesivoAplicado;
	}
}
