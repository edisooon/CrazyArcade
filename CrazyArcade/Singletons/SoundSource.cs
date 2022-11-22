using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace CrazyArcade.Singletons
{
	public class SoundSource
	{
		private static SoundSource manager;
		public static SoundSource Manager => manager;
		public static void Load(ContentManager content)
		{
			if (manager == null)
				manager = new SoundSource(content);
		}
		private ContentManager content;
		private SoundSource(ContentManager content)
		{
			this.content = content;
		}
		public SoundEffect GetSoundEffect(string fileName)
		{
			return content.Load<SoundEffect>(fileName);
		}
		private SoundEffect backgroundSong = null;
		public SoundEffect BackgroundSong {
			get
            {
                return backgroundSong;
            }
		}
	}
}

