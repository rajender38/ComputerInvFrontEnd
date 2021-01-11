using ComputersInventory.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersInventory.Tests
{
    public class TestData
    {
        public void InitializeDbForTests(ComputerInventoryContext db)
        {
            db.ComputerTypes.AddRange(new ComputerType()
            {
                Name = "test",
                Processor=true,
                Brand=true

                
            });
            db.SaveChanges();

   

    

        }

    }
}
