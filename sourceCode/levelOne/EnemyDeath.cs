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
    class EnemyDeath : spriteAnimation
    {

        
        Vector2 Position;
       

        public EnemyDeath(Vector2 position) : base(position)
        {
            framesperSecond = 12;
            AddAnimation(15, 0, 0, "zombieDeath", 128, 128, new Vector2(-30, -64));
            
        }


        public void Initialize()
        {
           
            Position = sPosition;
           
            
        }

        public void Loadcontent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("FinalSmoke");

        }
        public void loadMyContent(ContentManager content)
        {
            sTexture = content.Load<Texture2D>("explo");
        }
       public override void Update(GameTime gameTime)
       {
           


            if (frameIndex == 14)
            {
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
            get { return sPosition; }
        }

    }
}
