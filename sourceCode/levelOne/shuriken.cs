using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bushido
{
    class shuriken : spriteAnimation
    {
        float laserMoveSpeed = 10f;
        Hero styrax;
        public int Width
        {
            get { return sTexture.Width; }

        }

        public int Height
        {
            get { return sTexture.Height; }
        }

        private int shurikenDirection;
   
        public shuriken(Vector2 position) : base(position){
            framesperSecond = 25;
            AddAnimation(2, 0, 0, "shootShuriken", 27, 30, new Vector2(0, 0));
            
            }
        public void Initialize(int direction, Hero styrax)
        {
            this.styrax = styrax;
            shurikenDirection = direction;
            
        }
        public void LoadContent(Texture2D texture)
        {

            sTexture = texture;
            
        }

        public void Update(GameTime gameTime, Hero styrax)
        {
            var direct = styrax.shootDirection;
            
            if (shurikenDirection == 1)
            {
                playAnimation("shootShuriken",true);
                sPosition.Y -= laserMoveSpeed;
                Update(gameTime);
            }
            else if (shurikenDirection == 2)
            {

                playAnimation("shootShuriken", true);
                sPosition.X += laserMoveSpeed;
                Update(gameTime);
            }
            else if (shurikenDirection == 3)
            {

                playAnimation("shootShuriken", true);
                sPosition.Y += laserMoveSpeed;
                Update(gameTime);
            }
            else if (shurikenDirection == 4)
            {
                playAnimation("shootShuriken", true);
                sPosition.X -= laserMoveSpeed;
                Update(gameTime);
            }
            else if (shurikenDirection == 5)
            {
                playAnimation("shootShuriken", true);
                sPosition.Y -= laserMoveSpeed - 3;
                sPosition.X += laserMoveSpeed - 2;
                Update(gameTime);
            }
            else if (shurikenDirection == 6)
            {
                playAnimation("shootShuriken", true);
                sPosition.Y += laserMoveSpeed - 3;
                sPosition.X += laserMoveSpeed - 2;
                Update(gameTime);
            }
            else if (shurikenDirection == 7)
            {
                playAnimation("shootShuriken", true);
                sPosition.Y += laserMoveSpeed - 3;
                sPosition.X -= laserMoveSpeed - 2;
                Update(gameTime);
            }
            else if (shurikenDirection == 8)
            {
                playAnimation("shootShuriken", true);
                sPosition.Y -= laserMoveSpeed - 3;
                sPosition.X -= laserMoveSpeed - 2;
                Update(gameTime);
            }
            else
            {
                playAnimation("shootShuriken", true);
                sPosition.Y -= laserMoveSpeed;
                Update(gameTime);
            }
            base.Update(gameTime);

        }

        public bool Active
        {
            get { return active; }
        }

        public Vector2 Position
        {
            get { return sPosition; }
        }
    }
}
