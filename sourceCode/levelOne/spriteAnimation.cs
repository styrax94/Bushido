using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Bushido
{
    abstract class spriteAnimation
    {

        protected Texture2D sTexture;
        protected Vector2 sPosition;
        private Rectangle[] sRectangles;
        protected int frameIndex;
        private double timeElapsed, timeUpdate;
        protected string currentAnimation;
        protected bool looping, active = true;
        bool dontUpdate = false;
        public int framesperSecond
        {
            set { timeUpdate = (1f / value); }
        }

        protected Vector2 sDirection = Vector2.Zero;
        public enum myDirection { none, up, down, left, right };
        protected myDirection currentDirection = myDirection.none;

        public spriteAnimation(Vector2 position)
        {
            sPosition = position;
            

        }

        private Dictionary<string, Rectangle[]> sAnimation = new Dictionary<string, Rectangle[]>();
        private Dictionary<string, Vector2> sOffset = new Dictionary<string, Vector2>();

        public void AddAnimation(int frames, int yPos, int xStartFrame, string name, int width, int height, Vector2 offset)
        {
            //this.looping = looping;
            Rectangle[] Rectangles = new Rectangle[frames];

            for (int i = 0; i < frames; i++)
            {
                Rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
            sAnimation.Add(name, Rectangles);
            sOffset.Add(name, offset);
        }
        public virtual void Update(GameTime gameTime)
        {
            if (dontUpdate) return;
            if (!active) return;
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeUpdate)
            {
                timeElapsed -= timeUpdate;
                if (currentAnimation != null && frameIndex < sAnimation[currentAnimation].Length - 1)
                {
                    frameIndex++;
                }
                else
                {
                    frameIndex = 0;
                    if (looping == false)
                    {
                        dontUpdate = true;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentAnimation == null || !active)
            {

            }
            else
            {
                spriteBatch.Draw(sTexture, sPosition + sOffset[currentAnimation], sAnimation[currentAnimation][frameIndex], Color.White);
            }
          }

        public void playAnimation(string name, bool looping)
        {
            this.looping = looping;

            if (looping)
            {
                dontUpdate = false;
            }

            if (currentAnimation != name && currentDirection == myDirection.none)
            {
                currentAnimation = name;
                frameIndex = 0;  

            }
        }
 

        public bool Actives
        {
            get { return active; }
            set { active = value; }
        }
    }
}
