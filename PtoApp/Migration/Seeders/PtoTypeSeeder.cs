using System;

using PtoApp.Models;

namespace PtoApp.Migration.Seeders
{
	public class PtoTypeSeeder
	{
		public PtoTypeSeeder()
		{
		}

        public static void addPtoType(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<PTOContext>();

            var ptoType1 = new PtoType {
				Id = 1,
				Description = "Sick"
			};

            var ptoType2 = new PtoType
            {
                Id = 2,
                Description = "Personal day"
            };

            var ptoType3 = new PtoType
            {
                Id = 3,
                Description = "Other"
            };

            db?.PtoTypes?.Add(ptoType1);
            db?.PtoTypes?.Add(ptoType2);
            db?.PtoTypes?.Add(ptoType3);

            db?.SaveChanges();
        }
    }
}

