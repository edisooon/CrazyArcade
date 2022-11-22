using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework.Audio;

namespace CrazyArcade.CAFrameWork.SoundEffectSystem
{
	public class CASoundEffect: CAEntity, ISoundEntity
	{
		public CASoundEffect(string fname)
		{
            this.fname = fname;
		}
        private string fname;
        public string FileName => fname;

        public override void Load()
        {
            SceneDelegate.ToRemoveEntity(this);
        }
    }
}

