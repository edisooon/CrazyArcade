using System;
using CrazyArcade.CAFramework;
using Microsoft.Xna.Framework.Audio;


namespace CrazyArcade.CAFrameWork.SoundEffectSystem
{
    /* You can add a sound entity by add it to the scene
     * e.g. SceneDelegate.ToAddEntity(new CASoundEffect("filename"));
     */
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

