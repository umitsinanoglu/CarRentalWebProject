using Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using System;

namespace Core.Aspects.Autofac.Maintenance
{
    public class MaintenanceAspect : MethodInterception
    {
        private readonly int _maintenanceHour;

        public MaintenanceAspect(int maintenanceHour)
        {
            _maintenanceHour = maintenanceHour;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            if (IsMaintenanceTime())
            {
                // Eğer bakım zamanı ise, isteği engelle ve kullanıcıya bakım modu mesajını gönder.
                throw new Exception("Bakım modu aktif. Lütfen daha sonra tekrar deneyin.");
            }
        }

        private bool IsMaintenanceTime()
        {
            // Örnek: Eğer saat 21:00 ise, bakım modunu aktif hale getir.
            return DateTime.Now.Hour == _maintenanceHour;
        }
    }
}
