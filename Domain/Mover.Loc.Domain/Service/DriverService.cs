using System.Text;
using IET.Common.Extensions;
using IET.Common.Monitoring.Contract;
using IET.Common.Patterns.DomainDriver.Services.MongoDb;
using IET.Common.Patterns.DomainNotification.Interface;
using Mover.Loc.Domain.Contract.Repository;
using Mover.Loc.Domain.Contract.Service;
using Mover.Loc.Domain.Entities;
using static IET.Common.Extensions.ByteExtensions;

namespace Mover.Loc.Domain.Service
{
    public class DriverService : ServiceBase<Driver>, IDriverService
    {
        public DriverService(IDriverRepository repository, INotify notify, ITreatLogContract logContract) : base(repository, notify, logContract)
        {
        }

        public override async Task<Driver> Add(Driver model)
        {
            model.ThrowIfNull();

            var driverExist = await base.GetSingle(x=> x.NumberCnh == model.NumberCnh || x.Cnpj == model.Cnpj);
            if(driverExist != null)
            {
                _notify.NewNotification("Add Driver", "Driver already exists");
            }
            else
            {
                SaveImage(model);

                return await base.Add(model);
            }

            return default;
        }

        public void SaveImage(Driver driver)
        {
            if(!string.IsNullOrWhiteSpace(driver.CnhImage))
            {
                var imageFormat = driver.CnhImageByte.GetImageFormat();
                
                if(imageFormat == ImageFormat.png && imageFormat == ImageFormat.bmp)
                {
                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{driver.NumberCnh}.{imageFormat.ToString()}");                

                    File.WriteAllBytes(filePath, driver.CnhImageByte);

                    driver.CnhImage = filePath;
                }
            }
        }
    }
}