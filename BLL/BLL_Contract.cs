using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.DTO;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.BLL
{
    public class BLL_Contract
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
            return QuanLy.Instance.Contracts.Select(p=>p).ToList();
        }

        public void AddContract(Contract contract)
        {
            QuanLy.Instance.Contracts.Add(contract);
            QuanLy.Instance.SaveChanges();
        }

        public void UpdateContract(Contract contract)
        {
            Contract tam = QuanLy.Instance.Contracts.Find(contract.ContractId);
            if (tam == null) return;
            else
            {
                tam.ContractId = contract.ContractId;
                tam.CustomerID = contract.CustomerID;
                tam.RoomID = contract.RoomID;
                tam.CustomerName = contract.CustomerName;
                tam.CreatedAt = contract.CreatedAt;
                QuanLy.Instance.SaveChanges();
            }
        }
    }
}
