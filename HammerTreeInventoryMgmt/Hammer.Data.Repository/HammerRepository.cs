using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hammer.Data.BusinesssModel;

namespace Hammer.Data.Repository
{
    public class HammerRepository
    {
        public List<HammerDTO> GetHammers()
        {
             
            List<HammerDTO> hammerList = new List<HammerDTO>();
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    foreach (var h in entities.Hammers.Where(h => h.IsActive == true).ToList())
                    {
                        HammerDTO dto = new HammerDTO();
                        dto.HammerId = h.HammerId;
                        dto.HammerName = h.HammerName;
                        dto.HammerDescription = h.HammerDescription;
                        dto.IsActive = h.IsActive;
                        dto.Category = h.HammerType.TypeName;
                        hammerList.Add(dto);
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
            return hammerList;
        }

        public HammerDTO SaveHammers(HammerDTO dto)
        {
            Hammer hammer = new Hammer();
            hammer.HammerName = dto.HammerName;
            hammer.HammerDescription = dto.HammerDescription;
            hammer.TypeId = Convert.ToInt32(dto.Category);
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    var newhammer = entities.Hammers.Add(hammer);
                    entities.SaveChanges();
                    dto.HammerId = newhammer.HammerId;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dto;
        }

        public bool DeleteHammers(HammerDTO dto)
        {
            int rows = 0;
            Hammer hammer = new Hammer();
            hammer.HammerId = dto.HammerId;
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    entities.Hammers.Attach(hammer);
                    entities.Hammers.Remove(hammer);
                    rows = entities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rows > 0 ? true : false;
        }

        public HammerDTO UpdateHammers(HammerDTO dto)
        {
            try
            {
                using (HammerEntities entities = new HammerEntities())
                {
                    var oldhammer = entities.Hammers.Find(dto.HammerId);
                    if(oldhammer != null)
                    {
                        oldhammer.HammerName = dto.HammerName;
                        oldhammer.HammerDescription = dto.HammerDescription;
                        oldhammer.TypeId = Convert.ToInt32(dto.Category);
                        entities.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dto;
        }

    }
}
