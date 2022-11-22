using System;
using System.Collections.Generic;
using CrazyArcade.CAFramework;
using CrazyArcade.Singletons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace CrazyArcade.CAFrameWork.SoundEffectSystem
{
	public class CASoundSystem: IGameSystem
	{
        private Dictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>();
		public CASoundSystem()
		{
		}

        public void AddSprite(IEntity sprite)
        {
            if (sprite is ISoundEntity)
            {
                ISoundEntity sound = sprite as ISoundEntity;
                if (soundEffects.ContainsKey(sound.FileName))
                {
                    soundEffects[sound.FileName].CreateInstance().Play();
                } else
                {
                    soundEffects.Add(sound.FileName, SoundSource.Manager.GetSoundEffect(sound.FileName));
                }
            }
        }

        public void RemoveAll()
        {
        }

        public void RemoveSprite(IEntity sprite)
        {
        }

        public void Update(GameTime time)
        {
        }
    }
}

