using SFML.Audio;
using System.Collections.Generic;

namespace Inkscii
{
    public class Sound
    {
        private Dictionary<string, SoundBuffer> soundBuffers;
        private Dictionary<string, Music> musicTracks;

        public Sound()
        {
            soundBuffers = new Dictionary<string, SoundBuffer>();
            musicTracks = new Dictionary<string, Music>();
        }

        public void LoadSound(string soundName, string soundFilePath)
        {
            SoundBuffer soundBuffer = new SoundBuffer(soundFilePath);
            soundBuffers[soundName] = soundBuffer;
        }

        public void PlaySound(string soundName)
        {
            if (soundBuffers.TryGetValue(soundName, out SoundBuffer soundBuffer))
            {
                SFML.Audio.Sound sound = new SFML.Audio.Sound(soundBuffer);
                sound.Play();
            }
        }

        public void LoadMusic(string musicName, string musicFilePath)
        {
            Music music = new Music(musicFilePath);
            musicTracks[musicName] = music;
        }

        public void PlayMusic(string musicName)
        {
            if (musicTracks.TryGetValue(musicName, out Music music))
            {
                music.Play();
            }
        }

        public void StopMusic(string musicName)
        {
            if (musicTracks.TryGetValue(musicName, out Music music))
            {
                music.Stop();
            }
        }
    }
}
