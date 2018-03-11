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
    class abilityManager
    {
        Hero styrax;
        int megaCounter = 0;
        //Random rand = new Random();
        ContentManager Content;
        List<fireRate> fireRateList = new List<fireRate>();
        List<movementSpeed> movementSpeedList = new List<movementSpeed>();
        List<ninjaZone> ninjaZoneList = new List<ninjaZone>();
        List<shurikenMegaSize> megaList = new List<shurikenMegaSize>();

        public void Initialize(ContentManager content,Hero styrax)
        {
            Content = content;
            this.styrax = styrax;
            
        }


        public void dropAbility(int i, Vector2 position)
        {
            if (i>0 && i <4)
            {
                fireRate firerate = new fireRate(position);
                firerate.Initialize();
                firerate.loadContent(Content);
                fireRateList.Add(firerate);

            }

            if (i>=4 && i < 6)
            {
                movementSpeed movementspeed = new movementSpeed(position);
                movementspeed.Initialize();
                movementspeed.loadContent(Content);
                movementSpeedList.Add(movementspeed);
            }

            if (i == 6)
            {
                ninjaZone ninjazone = new ninjaZone(position);
                ninjazone.Initialize();
                ninjazone.loadContent(Content);
                ninjaZoneList.Add(ninjazone);
            }
            if (i == 19)
            {
                shurikenMegaSize shurikenSize = new shurikenMegaSize(position);
                shurikenSize.Initialize();
                shurikenSize.loadContent(Content);
                megaList.Add(shurikenSize);
            }




        }

        public void activateAbility(int i)
        {
            
            if (i == 1)
            {
                styrax.inventoryFireRate = 1;
            }

            else if(i== 2)
            {
                styrax.inventoryMovementSpeed = 1;
            }
            else if (i == 3)
            {
                styrax.inventoryNinjaZone = 1;
            }
            else if (i == 4)
            {
                    styrax.megaSize = 1;
                
            }
        }

        public void Update(GameTime gametime)
        {







            for (int i = 0; i < fireRateList.Count; i++)
            {
                Rectangle itemRectangle = new Rectangle((int)fireRateList[i].position.X, (int)fireRateList[i].position.Y, 30, 30);
                Rectangle heroRectangle = new Rectangle((int)styrax.position.X + 20, (int)styrax.position.Y + 12, 22, 53);
                if (heroRectangle.Intersects(itemRectangle))
                {
                    fireRateList[i].Actives = false;
                    activateAbility(1);
                    fireRateList.Remove(fireRateList[i]);
                }


                
            }

            for (int i = 0; i < fireRateList.Count; i++)
            {
                 fireRateList[i].update(gametime);
                if (!fireRateList[i].Actives)
                {
                    fireRateList.Remove(fireRateList[i]);
                }

            }



                for (int i = 0; i < movementSpeedList.Count; i++)
            {
                Rectangle itemRectangle = new Rectangle((int)movementSpeedList[i].position.X, (int)movementSpeedList[i].position.Y, 30, 30);
                Rectangle heroRectangle = new Rectangle((int)styrax.position.X + 20, (int)styrax.position.Y + 12, 22, 53);
                if (heroRectangle.Intersects(itemRectangle))
                {
                    movementSpeedList[i].Actives = false;
                    activateAbility(2);
                     movementSpeedList.Remove(movementSpeedList[i]);
                }
              
            }

            for (int i = 0; i < movementSpeedList.Count; i++)
            {
                movementSpeedList[i].update(gametime);
                if (!movementSpeedList[i].Actives)
                {
                    movementSpeedList.Remove(movementSpeedList[i]);
                }
            }

                for (int i = 0; i < ninjaZoneList.Count; i++)
            {
                Rectangle itemRectangle = new Rectangle((int)ninjaZoneList[i].position.X, (int)ninjaZoneList[i].position.Y, 30, 30);
                Rectangle heroRectangle = new Rectangle((int)styrax.position.X + 20, (int)styrax.position.Y + 12, 22, 53);
                if (heroRectangle.Intersects(itemRectangle))
                {
                    ninjaZoneList[i].Actives = false;
                    activateAbility(3);
                    ninjaZoneList.Remove(ninjaZoneList[i]);
                }
                
            }
            for (int i = 0; i < ninjaZoneList.Count; i++)
            {
                ninjaZoneList[i].update(gametime);

                if (!ninjaZoneList[i].Actives)
                {
                    ninjaZoneList.Remove(ninjaZoneList[i]);
                }
            }

                for (int i = 0; i < megaList.Count; i++)
            {
                Rectangle itemRectangle = new Rectangle((int)megaList[i].position.X, (int)megaList[i].position.Y, 30, 30);
                Rectangle heroRectangle = new Rectangle((int)styrax.position.X + 20, (int)styrax.position.Y + 12, 22, 53);
                if (heroRectangle.Intersects(itemRectangle))
                {
                    megaList[i].Actives = false;
                    activateAbility(4);
                    megaList.Remove(megaList[i]);
                }

            }
            for (int i = 0; i < megaList.Count; i++)
            {
                megaList[i].update(gametime);
                if (!megaList[i].Actives)
                {
                    megaList.Remove(megaList[i]);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            foreach (fireRate item in fireRateList)
            {
                item.Draw(spriteBatch);
            }

            foreach (movementSpeed item in movementSpeedList)
            {
                item.Draw(spriteBatch);
            }

            foreach (ninjaZone item in ninjaZoneList)
            {
                item.Draw(spriteBatch);
            }

            foreach (shurikenMegaSize item in megaList)
            {
                item.Draw(spriteBatch);
            }
        }

    }
}
   

