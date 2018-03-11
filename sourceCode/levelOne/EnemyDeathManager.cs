using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Bushido
{
    class EnemyDeathManager
    {
        static public List<EnemyDeath> explosionType1 = new List<EnemyDeath>();
        
        ContentManager content;
        
        
        public void initialize(ContentManager content)
        {
            this.content = content;
        }
        

        public void AddExplosions(Vector2 enemyPos)
        {
            
            EnemyDeath EnemyDie = new EnemyDeath(enemyPos);
            EnemyDie.Initialize();
            EnemyDie.Loadcontent(content);

            explosionType1.Add(EnemyDie);
            EnemyDie.playAnimation("zombieDeath",false);
        }

      
        
        public void updateExplosions(GameTime gameTime)
        {
            for (var e = 0; e < explosionType1.Count; e++)
            {
                explosionType1[e].Update(gameTime);

                if (explosionType1[e].Actives == false)
                    explosionType1.Remove(explosionType1[e]);
            }
        }

        public void DrawExplosions(SpriteBatch spriteBatch)
        {
            foreach (var e in explosionType1)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}
