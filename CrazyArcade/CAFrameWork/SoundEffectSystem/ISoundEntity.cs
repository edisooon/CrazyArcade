using System;
using Microsoft.Xna.Framework.Audio;

namespace CrazyArcade.CAFrameWork.SoundEffectSystem
{
    /* You should use CASoundEffect instead of 
	 * implement ISoundEntity in general
	 * You can add a sound entity by add it to the scene
	 * e.g. SceneDelegate.ToAddEntity(new CASoundEffect("filename"));
	 */
    public interface ISoundEntity
	{
		string FileName { get; }
	}
}

