using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.DTO;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.BLL
{
    public class BLL_Contract: BLL_Main
    {
        private static BLL_Contract _instance;

        public static BLL_Contract Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Contract();
                }
                return _instance;
            }
            private set { }
        }

        public List<Contract> GetAllContract()
        {
            return db.Contracts.Select(p => p).ToList();
        }

        public void AddContract(Contract contract)
        {
            db.Contracts.Add(contract);
            db.SaveChanges();
        }

        public void UpdateContract(Contract contract)
        {
            Contract tam = db.Contracts.Find(contract.ContractId);
            if (tam == null) return;
            else
            {                
                tam.RoomId = contract.RoomId;
                tam.CustomerName = contract.CustomerName;
                tam.CreatedAt = contract.CreatedAt;
                db.SaveChanges();
            }
        }
        public Contract GetContractByCustomerID(int id) //Lấy ra hợp đồng của khách
        {
            return db.Contracts.Where(p => p.ContractId == id).Select(p => p).FirstOrDefault();
        }

        public Contract GetContractByRoomID(int idroom) //Lấy ra Hợp đồng của phòng
        {
            return db.Contracts.Where(p => p.RoomId == idroom).Select(p => p).FirstOrDefault();
        }
    }
}
