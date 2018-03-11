using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{
    class explosionDeath : spriteAnimation
    {

        Hero styrax;
        Vector2 Position;
        bossTwo saulMander;

        public explosionDeath(Vector2 position) : base(position)
        {
            framesperSecond = 10;
            AddAnimation(12, 0, 0, "zombieDeath", 500, 500, new Vector2(-150, -200));

        }


        public void Initialize(bossTwo saulMander, Hero styrax)
        {
            this.styrax = styrax;
            Position = sPosition;
            this.saulMander = saulMander;
            
        }

        public void Loadcontent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("explo");

        }

       public override void Update(GameTime gameTime)
       {
           
            if(frameIndex == 6)
            {
                saulMander.Actives = false;
            }
            if(frameIndex == 11)
            {
                styrax.hasFallen = true;
                active = false;
            }
            
            base.Update(gameTime);
        }

        public bool enActive
        {
            get { return active; }
        }

        public Vector2 enPosition
        {
            set { sPosition = value; }
            get { return sPosition; }
        }

    }
}
