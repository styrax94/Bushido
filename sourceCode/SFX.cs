using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{
   public class SFX
    {
       public SoundEffectInstance ninjastepsInstance;
        public SoundEffectInstance shurikenInstance;
        public SoundEffectInstance megaShurikenInstance;
        public SoundEffectInstance zombieNoiseInstance;
        public SoundEffectInstance sultanaNoiseInstance;
        public SoundEffectInstance zombieNoiseInstance2;
        public SoundEffectInstance blast;
        public SoundEffectInstance ayoubLaugh;

        SoundEffect steps;
        SoundEffect shuriken;
        SoundEffect deathZombie;
        SoundEffect sultanaScream;
        SoundEffect deathZombie2;
        SoundEffect megaShuriken;
        SoundEffect ghost;
        SoundEffect explo;
        SoundEffect evilLaugh;
        public void Initialize(ContentManager content)
        {
            steps = content.Load<SoundEffect>("Music/Walk");
            shuriken = content.Load<SoundEffect>("shurik");
            deathZombie = content.Load<SoundEffect>("Music/ZombieD");
            sultanaScream = content.Load<SoundEffect>("Music/sultanaScream");
            deathZombie2 = content.Load<SoundEffect>("Music/Zombienoise");
            megaShuriken = content.Load<SoundEffect>("Music/megaShuriken");
            ghost = content.Load<SoundEffect>("Music/no");
            explo = content.Load<SoundEffect>("Music/blast");
            evilLaugh = content.Load<SoundEffect>("Music/evilLaugh");
        }

        public void playStep(float i)
        {
            ninjastepsInstance = steps.CreateInstance();
            ninjastepsInstance.Play();
            ninjastepsInstance.Volume = i;
        }
        
        public void playShuriken(float i)
        {
            shurikenInstance = shuriken.CreateInstance();
            shurikenInstance.Play();
            shurikenInstance.Volume = i;
        }

        public void playZombieDeath(float i)
        {
            zombieNoiseInstance = ghost.CreateInstance();
            zombieNoiseInstance.Play();
            zombieNoiseInstance.Volume = i;
        }

        public void playSultanaScream(float i)
        {
            sultanaNoiseInstance = sultanaScream.CreateInstance();
            sultanaNoiseInstance.Play();
            sultanaNoiseInstance.Volume = i;
        }

        public void playZombieDeath1(float i)
        {
            zombieNoiseInstance2 = deathZombie2.CreateInstance();
            zombieNoiseInstance2.Play();
            zombieNoiseInstance2.Volume = i;
        
        }
        public void playMegaShuriken(float i)
        {
            megaShurikenInstance = megaShuriken.CreateInstance();
            megaShurikenInstance.Play();
            megaShurikenInstance.Volume = i;
        }
        public void playBlast(float i)
        {
            blast = explo.CreateInstance();
            blast.Play();
            blast.Volume = i;
        }
        public void playLaugh(float i)
        {
            ayoubLaugh = evilLaugh.CreateInstance();
            ayoubLaugh.Play();
            ayoubLaugh.Volume = i;
        }
    }
}
