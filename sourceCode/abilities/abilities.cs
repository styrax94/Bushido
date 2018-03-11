using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Bushido
{


    class ninjaZone : spriteAnimation
    {
        bool nzActive;
        public bool nzactive 
        {
            get { return nzActive; }
        }

        int counter = 0;
        int limit = 10;
        float countDuration = 1f;
        float currentTime = 0f;

        int effectCounter = 0;
        int effectLimit = 10;
        float effectCount = 1f;
        float currentEffectTime = 0f;

        public Vector2 position
        {
            get { return sPosition; }
        }

        public ninjaZone(Vector2 position) : base(position)
        {
            AddAnimation(1, 0, 0, "scroll", 30, 30, new Vector2(0, 0));
        }

        public void Initialize()
        {
            nzActive = true;

        }

        public void loadContent(ContentManager Content)
        {
            sTexture = Content.Load<Texture2D>("abilities/ninjaZone");
        }

        public void update(GameTime gametime)
        {
         
                playAnimation("scroll", false);
                runTimer(gametime);

       

            base.Update(gametime);
        }


        public void abilityTimer(GameTime gametime)
        {
           

            currentEffectTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentEffectTime >= effectCount)
            {
                effectCounter++;
                currentEffectTime -= effectCount;

            }
            if (effectCounter >= effectLimit)
            {
                nzActive = false;
            }
        }
        public void runTimer(GameTime gametime)
        {
          

            currentTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= countDuration)
            {
                counter++;
                currentTime -= countDuration;

            }
            if (counter >= limit)
            {
                counter = 0;
                Actives = false;
            }
        }

        
    }


    class movementSpeed  : spriteAnimation
    {
        bool msActive;
        int counter = 0;
        int limit = 10;
        float countDuration = 1f;
        float currentTime = 0f;

        int effectCounter = 0;
        int effectLimit = 10;
        float effectCount = 1f;
        float currentEffectTime = 0f;

        public Vector2 position
        {
            get { return sPosition; }
        }

        public movementSpeed(Vector2 position) : base(position)
        {
            AddAnimation(1, 0, 0, "scroll", 30, 30, new Vector2(0, 0));
        }

        public void Initialize()
        {
            msActive = true;

        }

        public void loadContent(ContentManager Content)
        {
            sTexture = Content.Load<Texture2D>("abilities/movementSpeed");
        }

        public void update(GameTime gametime)
        {
           
            
                playAnimation("scroll", false);
                runTimer(gametime);
           
            base.Update(gametime);
        }

        public void abilityTimer(GameTime gametime)
        {
            currentEffectTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentEffectTime >= effectCount)
            {
                effectCounter++;
                currentEffectTime -= effectCount;

            }
            if (effectCounter >= effectLimit)
            {
                msActive = false;
            }
        }
        public void runTimer(GameTime gametime)
        {


            currentTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= countDuration)
            {
                counter++;
                currentTime -= countDuration;

            }
            if (counter >= limit)
            {
                counter = 0;
                Actives = false;
            }
        }
    }
    class fireRate : spriteAnimation
    {
        bool frActive;
        int counter = 0;
        int limit = 10;
        float countDuration = 1f;
        float currentTime = 0f;

        int effectCounter = 0;
        int effectLimit = 10;
        float effectCount = 1f;
        float currentEffectTime = 0f;

        public Vector2 position
        {
            get { return sPosition; }
        }

        public fireRate(Vector2 position) : base(position)
        {
            AddAnimation(1, 0, 0, "scroll", 30, 30, new Vector2(0, 0));
        }

        public void Initialize()
        {
            frActive = true;

        }

        public void loadContent(ContentManager Content)
        {
            sTexture = Content.Load<Texture2D>("abilities/fireSpeed");
        }

        public void update(GameTime gametime)
        {
           
                playAnimation("scroll", false);
                runTimer(gametime);
            
            base.Update(gametime);
        }

        public void abilityTimer(GameTime gametime)
        {
           
            currentEffectTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentEffectTime >= effectCount)
            {
                effectCounter++;
                currentEffectTime -= effectCount;

            }
            if (effectCounter >= effectLimit)
            {
                frActive = false;
            }
        }
        public void runTimer(GameTime gametime)
        {


            currentTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= countDuration)
            {
                counter++;
                currentTime -= countDuration;

            }
            if (counter >= limit)
            {
                counter = 0;
                Actives = false;
            }
        }
    }

    class shurikenMegaSize : spriteAnimation
    {
        bool msActive;
        int counter = 0;
        int limit = 10;
        float countDuration = 1f;
        float currentTime = 0f;

        int effectCounter = 0;
        int effectLimit = 10;
        float effectCount = 1f;
        float currentEffectTime = 0f;

        public Vector2 position
        {
            get { return sPosition; }
        }

        public shurikenMegaSize(Vector2 position) : base(position)
        {
            AddAnimation(1, 0, 0, "scroll", 30, 30, new Vector2(0, 0));
        }

        public void Initialize()
        {
            msActive = false;

        }

        public void loadContent(ContentManager Content)
        {
            sTexture = Content.Load<Texture2D>("abilities/shurikenMegaSize");
        }

        public void update(GameTime gametime)
        {

                playAnimation("scroll", false);
                runTimer(gametime);
            

            base.Update(gametime);
        }
        public void abilityTimer(GameTime gametime)
        {
            currentEffectTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentEffectTime >= effectCount)
            {
                effectCounter++;
                currentEffectTime -= effectCount;

            }
            if (effectCounter >= effectLimit)
            {
                msActive = false;
            }
        }
        public void runTimer(GameTime gametime)
        {


            currentTime += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= countDuration)
            {
                counter++;
                currentTime -= countDuration;

            }
            if (counter >= limit)
            {
                counter = 0;
                Actives = false;
            }
        }
    }
}
