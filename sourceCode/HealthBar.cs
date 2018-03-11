using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{
    
    class HealthBar
    {

        EnemyManager zombies;
        bossOne sultana;
        bossTwo saulMander;
        private Texture2D container, lifebar;
        private Vector2 position;
        private Texture2D Sultanochan;
        private Texture2D SaulaMander;
        private Texture2D containAhead;
        private Texture2D containAhealth;
        public Vector2 positions
        {
            set { position = value; }
        }
        private int fullHealth;
        private int currentHealth = 100;
        private int currentHealth2 = 300;
        public HealthBar()
        {



        }

        public void LoadContent(ContentManager Content, EnemyManager Manager)
        {
            zombies = Manager;

            if (levelManager.levelIndicator == levelManager.levels.levelOne)
            {
                containAhealth = Content.Load<Texture2D>("containAhealth");
                containAhead = Content.Load<Texture2D>("containAhead");
                Sultanochan = Content.Load<Texture2D>("sultanaSukeHP");
                container = Content.Load<Texture2D>("emptybar");
                lifebar = Content.Load<Texture2D>("health_full");
            }

            if (levelManager.levelIndicator == levelManager.levels.levelTwo)
            {
                containAhealth = Content.Load<Texture2D>("containAhealth");
                containAhead = Content.Load<Texture2D>("containAhead");
                SaulaMander = Content.Load<Texture2D>("saulamander2");
                container = Content.Load<Texture2D>("emptybar");
                lifebar = Content.Load<Texture2D>("health_full");
            }

            fullHealth = lifebar.Width;
        }

        public void Update(GameTime gameTime)
        {

            if (EnemyManager.bossIsActive)
            {
                if (levelManager.levelIndicator == levelManager.levels.levelOne)
                {
                    if (EnemyManager.bossIsActive)
                    {
                        if (sultana.sultanaHealth <= currentHealth)
                        {
                            currentHealth--;
                        }
                    }
                }
            }
            if (EnemyManager.bossIsActive)
            {
                if (levelManager.levelIndicator == levelManager.levels.levelTwo)
                {
                    if (saulMander.saulManderHealth <= currentHealth2)
                    {
                        currentHealth2--;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (levelManager.levelIndicator == levelManager.levels.levelOne)
            {

                spriteBatch.Draw(containAhead, new Rectangle((int)position.X + 1090, (int)position.Y, 95, 95), Color.White);
                spriteBatch.Draw(Sultanochan, new Rectangle((int)position.X + 1090, (int)position.Y, 80, 80), Color.White);
                spriteBatch.Draw(container, new Rectangle((int)position.X + 996, (int)position.Y + 3, 99, 45), Color.White);
                spriteBatch.Draw(lifebar, new Rectangle((int)position.X + 996, (int)position.Y + 3, currentHealth, 45), Color.White);
                spriteBatch.Draw(containAhealth, new Rectangle((int)position.X + 995, (int)position.Y + 10, 100, 29), Color.White);

            }
            else if (levelManager.levelIndicator == levelManager.levels.levelTwo)
            {

                spriteBatch.Draw(containAhead, new Rectangle((int)position.X + 1090, (int)position.Y, 86, 95), Color.White);
                spriteBatch.Draw(SaulaMander, new Rectangle((int)position.X + 1090, (int)position.Y + 6, 80, 75), Color.White);
                spriteBatch.Draw(container, new Rectangle((int)position.X + 895, (int)position.Y + 5, 200, 45), Color.White);
                spriteBatch.Draw(lifebar, new Rectangle((int)position.X + 895, (int)position.Y + 5, currentHealth2, 45), Color.White);
                spriteBatch.Draw(containAhealth, new Rectangle((int)position.X + 885, (int)position.Y + 10, 313, 31), Color.White);

            }
        }

        public void getBoss(bossOne sultana)
        {
            this.sultana = sultana;
        }
        public void getBoss(bossTwo saulMander)
        {
            this.saulMander = saulMander;
        }
    }   
}
