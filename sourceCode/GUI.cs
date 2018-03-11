using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;
namespace Bushido
{
	class GUI
	{


        Hero styrax;

        public Texture2D scroll;
        public Texture2D ab1;
        public Texture2D ab2;
        public Texture2D ab3;
        public Texture2D ab4;
        public Texture2D wave1;
        public Texture2D wave2;
        public Texture2D wave3;
        public Texture2D container;


        public SpriteFont font;
        public Vector2 position;


        public GUI(ContentManager Content, Hero styrax)
        {
            loadContent(Content);
            this.styrax = styrax;
        }
        public void loadContent(ContentManager Content)
        {

            scroll = Content.Load<Texture2D>("scroll");
            ab1 = Content.Load<Texture2D>("abilities/fireSpeed");
            ab3 = Content.Load<Texture2D>("abilities/movementSpeed");
            ab4 = Content.Load<Texture2D>("abilities/shurikenMegaSize");
            ab2 = Content.Load<Texture2D>("abilities/ninjaZone");
            font = Content.Load<SpriteFont>("Font/font1");
            wave1 = Content.Load<Texture2D>("wave1");
            wave2 = Content.Load<Texture2D>("wave2");
            wave3 = Content.Load<Texture2D>("wave3");



        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(scroll, new Rectangle((int)position.X + 10, (int)position.Y + 25, 100, 230), Color.White);
            //spriteBatch.Draw(container, new Rectangle((int)position.X+100, (int)position.Y+20, 300, 130), Color.White);


            if (styrax.fireRateInventory > 0)
            {
                spriteBatch.Draw(ab1, new Rectangle((int)position.X + 10, (int)position.Y + 48, 45, 45), Color.White);
                spriteBatch.DrawString(font, string.Format("x" + styrax.fireRateInventory), position + new Vector2(50, 45), Color.White);
            }
            else if (styrax.fireRateInventory == 0) { }

            if (styrax.movementSpeedInventory > 0)
            {
                spriteBatch.Draw(ab3, new Rectangle((int)position.X + 10, (int)position.Y + 90, 45, 45), Color.White);
                spriteBatch.DrawString(font, string.Format("x" + styrax.movementSpeedInventory), position + new Vector2(50, 80), Color.White);
            }
            else if (styrax.movementSpeedInventory == 0) { }

            if (styrax.ninjaInventory > 0)
            {
                spriteBatch.Draw(ab2, new Rectangle((int)position.X + 10, (int)position.Y + 135, 45, 45), Color.White);
                spriteBatch.DrawString(font, string.Format("x" + styrax.ninjaInventory), position + new Vector2(50, 125), Color.White);
            }
            else if (styrax.ninjaInventory == 0) { }

            if (styrax.MegaSize > 0)
            {
                spriteBatch.Draw(ab4, new Rectangle((int)position.X + 10, (int)position.Y + 185, 45, 45), Color.White);
                spriteBatch.DrawString(font, string.Format("x" + styrax.MegaSize), position + new Vector2(50, 175), Color.White);
            }
            else if (styrax.MegaSize == 0) { }

            if (waveManager.waveOne)
            {
                spriteBatch.Draw(wave1, new Rectangle((int)position.X + 130, (int)position.Y + 30, 250, 45), Color.White);

            }
            else if (waveManager.waveTwo)
            {
                spriteBatch.Draw(wave2, new Rectangle((int)position.X + 130, (int)position.Y + 30, 250, 45), Color.White);
            }
            else if (waveManager.waveThree)
            {
                spriteBatch.Draw(wave3, new Rectangle((int)position.X + 130, (int)position.Y + 30, 250, 45), Color.White);
            }

        }

    }
}
