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
			manager = new SoundSource(content);
		}
		private SoundSource(ContentManager content)
		{

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

