using SolarCoffee.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCoffee.Services.Inventory
{
   public interface IInventoryService
    {
        public List<ProductInventory> GetAllInventory();
        public ServiceResponse<bool> UpdateUnitsAvailable(int id, int adjustments);
        public ProductInventory GetByProductId(int productId);
        public List<ProductInventorySnapshot> GetSnapShotHistory();
        public void CreateShanshot();

    }
}
