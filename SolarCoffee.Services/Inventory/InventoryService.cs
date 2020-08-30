using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffee.Data;
using SolarCoffee.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCoffee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly SolarDbContext _db;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(SolarDbContext db, ILogger<InventoryService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void CreateShanshot()
        {
            var inventories = _db.ProductInventories
                .Include(inv => inv.Product)
                .ToList();
            foreach (var inventory in inventories)
            {
                var snapshot = new ProductInventorySnapshot
                {
                    SnapshotTime = DateTime.UtcNow,
                    Product = inventory.Product,
                    QuantityOnHand = inventory.QuantityOnHand
                };

                _db.Add(snapshot);
            }
        }

        public List<ProductInventory> GetAllInventory()
        {
            throw new NotImplementedException();
        }

        public ProductInventory GetByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductInventorySnapshot> GetSnapShotHistory()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> UpdateUnitsAvailable(int id, int adjustments)
        {
            throw new NotImplementedException();
        }
    }
}
