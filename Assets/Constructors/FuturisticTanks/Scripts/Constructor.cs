using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Constructors.FuturisticTanks.Scripts
{
    public class Constructor : MonoBehaviour
    {
        public Tank Tank;
        public SpriteRenderer Hull;
        public Transform HullPosition;
        public SpriteRenderer Hatch;
        public Transform HatchPosition;
        public SpriteRenderer Gun;
        public Transform GunPosition;
        public SpriteRenderer Tower;
        public Transform TowerPosition;
        public SpriteRenderer Pipe;
        public Transform PipePosition;
        public SpriteRenderer Bumper;
        public Transform BumperPosition;
        public SpriteRenderer[] Track;
        public UnityEngine.U2D.Animation.SpriteLibrary[] TrackLibrary;

        public SpriteRenderer Label;
        public Transform LabelPosition;

        public List<Sprite> Towers;
        public List<Vector2> TowerPositions;
        public List<Sprite> Hatches;
        public List<Vector2> HatchPositions;
        public List<Sprite> Guns;
        public List<Vector2> GunPositions;
        public List<Sprite> Hulls;
        public List<Sprite> Pipes;
        public List<Sprite> Bumpers;
        public List<Vector2> BumperPositions;
        public List<Sprite> Tracks;
        public List<UnityEngine.U2D.Animation.SpriteLibraryAsset> TrackLibraryAssets;
        public List<Sprite> Labels;
        public List<Vector2> LabelPositions;

        public AudioSource AudioSourceFx;
        public AudioClip SwitchAudio;

        private int _tower;
        private int _hatch;
        private int _gun;
        private int _hull;
        private int _pipe;
        private int _bumper;
        private int _track;
        private int _label;

        private Vector3 _hatchPosition;
        private Vector3 _gunPosition;
        private Vector3 _hullPosition;
        private Vector3 _pipePosition;
        private Vector3 _bumperPosition;
        private Vector3 _labelPosition;

        public void Start()
        {
            _hatchPosition = HatchPosition.localPosition;
            _hullPosition = HullPosition.localPosition;
            _gunPosition = GunPosition.localPosition;
            _pipePosition = PipePosition.localPosition;
            _bumperPosition = BumperPosition.localPosition;
            _labelPosition = LabelPosition.localPosition;
        }

        public void SwitchTower(int direction)
        {
            _tower = LoopIndex(_tower + direction, Towers.Count);
            Tower.sprite = Towers[_tower];
            GunPosition.localPosition = GunPositions[_tower];
            HatchPosition.localPosition = HatchPositions[_tower];
            LabelPosition.localPosition = LabelPositions[_tower];
        }

        public void SwitchHatch(int direction)
        {
            _hatch = LoopIndex(_hatch + direction, Hatches.Count);
            Hatch.sprite = Hatches[_hatch];
        }

        public void SwitchGun(int direction)
        {
            _gun = LoopIndex(_gun + direction, Guns.Count);
            Gun.sprite = Guns[_gun];
        }

        public void SwitchHull(int direction)
        {
            _hull = LoopIndex(_hull + direction, Hulls.Count);
            Hull.sprite = Hulls[_hull];
            TowerPosition.localPosition = TowerPositions[_hull];
            BumperPosition.localPosition = BumperPositions[_hull];
        }

        public void MoveHullByX(int direction)
        {
            HullPosition.localPosition += new Vector3(0.1f * direction, 0);
        }

        public void MoveHullByY(int direction)
        {
            HullPosition.localPosition += new Vector3(0, 0.1f * direction);
        }

        public void ResetHullPosition()
        {
            HullPosition.localPosition = _hullPosition;
        }

        public void SwitchPipe(int direction)
        {
            _pipe = LoopIndex(_pipe + direction, Pipes.Count);
            Pipe.sprite = Pipes[_pipe];
        }

        public void MovePipeByX(int direction)
        {
            PipePosition.localPosition += new Vector3(0.1f * direction, 0);
        }

        public void MovePipeByY(int direction)
        {
            PipePosition.localPosition += new Vector3(0, 0.1f * direction);
        }

        public void ResetPipePosition()
        {
            PipePosition.localPosition = _pipePosition;
        }

        public void SwitchBumper(int direction)
        {
            _bumper = LoopIndex(_bumper + direction, Bumpers.Count);
            Bumper.sprite = Bumpers[_bumper];
            Bumper.enabled = Bumper.sprite != null;
        }

        public void MoveBumperByX(int direction)
        {
            BumperPosition.localPosition += new Vector3(0.1f * direction, 0);
        }

        public void MoveBumperByY(int direction)
        {
            BumperPosition.localPosition += new Vector3(0, 0.1f * direction);
        }

        public void ResetBumperPosition()
        {
            BumperPosition.localPosition = _bumperPosition;
        }

        public void SwitchTrack(int direction)
        {
            _track = LoopIndex(_track + direction, Tracks.Count);
            //Track[0].sprite = Tracks[_track];
            //Track[1].sprite = Tracks[_track];
            TrackLibrary[0].spriteLibraryAsset = TrackLibraryAssets[_track];
            TrackLibrary[1].spriteLibraryAsset = TrackLibraryAssets[_track];
        }

        public void SwitchLabel(int direction)
        {
            _label = LoopIndex(_label + direction, Labels.Count);
            Label.sprite = Labels[_label];
            Label.enabled = Label.sprite != null;
        }

        public void MoveLabelByX(int direction)
        {
            LabelPosition.localPosition += new Vector3(0.1f * direction, 0);
        }

        public void MoveLabelByY(int direction)
        {
            LabelPosition.localPosition += new Vector3(0, 0.1f * direction);
        }

        public void ResetLabelPosition()
        {
            LabelPosition.localPosition = _labelPosition;
        }

        public string Path;

        #if UNITY_EDITOR

        /// <summary>
        /// Save as prefab.
        /// </summary>
        public void Save()
        {
            var path = UnityEditor.EditorUtility.SaveFilePanel("Save as prefab (should be inside Assets folder)", Path, "New tank", "prefab");

            if (path.Length > 0)
            {
                if (!path.Contains("/Assets/")) throw new Exception("Unity can save prefabs only inside Assets folder!");

                Save("Assets" + path.Replace(Application.dataPath, null));
                Path = path;
            }
        }

        private void Save(string path)
		{
			#if UNITY_2018_3_OR_NEWER

			UnityEditor.PrefabUtility.SaveAsPrefabAsset(Tank.gameObject, path);

			#else

			UnityEditor.PrefabUtility.CreatePrefab(path, Tank.gameObject);

			#endif

            Debug.LogFormat("Prefab saved as {0}", path);
        }

        #endif

        public void Review()
        {
            Application.OpenURL("http://u3d.as/2R6N");
        }

        protected int LoopIndex(int index, int listCount)
        {
            if (index < 0) index = listCount - 1;
            if (index == listCount) index = 0;

            AudioSourceFx.PlayOneShot(SwitchAudio);

            return index;
        }
    }
}