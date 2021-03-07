using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Editor
{
	public class SpriteAnimationCreatorBranch : IBranch
	{
		[ShowInInspector, Required, AssetSelector] private Texture2D _texture = null;
		[ShowInInspector, Min(0f)] private float _frameRate = 60f;
		[ShowInInspector] private WrapMode _wrapMode = WrapMode.Once;
		[ShowInInspector, FolderPath, OnValueChanged(nameof(OnPathChanged))] private string _savePath = "Assets";

		public string Path => "ToolBox/Sprite Animation Creator";

		private const string PATH_SAVE_KEY = "AnimationPath";

		public void Setup(OdinMenuTree tree) =>
			_savePath = EditorPrefs.GetString(PATH_SAVE_KEY, "Assets");

		[Button]
		private void CreateAnimation()
		{
			var path = AssetDatabase.GetAssetPath(_texture);
			var sprites = AssetDatabase.LoadAllAssetsAtPath(path).OfType<Sprite>().ToArray();

			var animation = new AnimationClip
			{
				frameRate = _frameRate,
				wrapMode = _wrapMode
			};

			var spriteBinding = new EditorCurveBinding
			{
				type = typeof(SpriteRenderer),
				path = "",
				propertyName = "m_Sprite"
			};

			var spriteKeyFrames = new ObjectReferenceKeyframe[sprites.Length + 1];
			for (int i = 0; i < spriteKeyFrames.Length - 1; i++)
				spriteKeyFrames[i] = CreateKeyFrame(i, sprites[i]);

			var index = spriteKeyFrames.Length - 1;
			spriteKeyFrames[index] = CreateKeyFrame(index, sprites[index - 1]);

			AnimationUtility.SetObjectReferenceCurve(animation, spriteBinding, spriteKeyFrames);

			var savePath = AssetDatabase.GenerateUniqueAssetPath($"{_savePath}/{_texture.name}.anim");
			AssetDatabase.CreateAsset(animation, savePath);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			EditorUtility.FocusProjectWindow();
			Selection.activeObject = animation;
		}

		private void OnPathChanged() =>
			EditorPrefs.SetString(PATH_SAVE_KEY, _savePath);

		private ObjectReferenceKeyframe CreateKeyFrame(float time, Object sprite)
		{
			return new ObjectReferenceKeyframe
			{
				time = time,
				value = sprite
			};
		}
	}
}
