
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace ConsoleUi
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarManagerTest();
            UserManager userManager = new UserManager(new EfUserDal());
            var random = new Random();

            string GetRandomFirstName()
            {
                string[] firstNames = { "Acun", "Adin", "Afşin", "Ahu", "Akil", "Alpay", "Aral", "Aram", "Aras", "Arzu", "Aylin", "Azze", "Bangu", "Barlas", "Batır", "Belgin", "Bengi", "Berfu", "Besim", "Bihter", "Birtan", "Boran", "Burcu", "Canset", "Cenk", "Cilve", "Çağatay", "Çelebi", "Çelik", "Çınar", "Çisil", "Dalan", "Dalga", "Deren", "Deva", "Devin", "Dide", "Doruk", "Duha", "Esen", "Esin", "Evin", "Eylül", "Faruk", "Fulya", "Gece", "Gökçek", "Gönenç", "Ildır", "Irak", "Işık", "Işın", "İlayda", "İmran", "İsra", "Janset", "Karmen", "Kıvılcım", "Kumru", "Kurtuluş", "Lalezar", "Lila", "Mehir", "Melisa", "Mercan", "Nida", "Olcay", "Orbey", "Orçun", "Orhun", "Orkide", "Ortan", "Ozan", "Özbey", "Özdel", "Payam", "Poyraz", "Rana", "Sakman", "Turna", "Ufuk", "Uluberk", "Uman", "Umar", "Usbay", "Ülkü", "Yasemin", "Yaşıl", "Yeşim", "Yıldıray" };
                return firstNames[random.Next(firstNames.Length)];
            }

            string GetRandomLastName()
            {
                string[] lastNames = { "ALTAŞ", "ARIKBOĞA", "ARSLANOĞLU", "ASENA", "ASIG", "ATAR", "ATAY", "AVCI", "AY GÜNEY", "BABUŞ", "BEKAR", "BÖYÜK", "CİNDEMİR", "CÖMERT", "ÇAYLI", "ÇELİK", "ÇINAR", "ÇOBANYILDIZI", "DAYLAK", "DEĞİRMENCİ AKAR", "DEMİRGAN", "DOĞAN", "DÜZ", "EMELİ", "ERTEKİN", "EŞFER", "GAYRETLİ AYDIN", "GÖKÇEK", "GÖNCÜ", "GÖZCÜ", "GÜLTEKİN", "GÜNDÜZ", "HALİS", "İRİS", "KALA", "KALYONCU UÇAR", "KANDEMİR", "KANYILMAZ", "KAPLAN", "KARAAĞAÇ", "KEŞKEK", "KISA", "KISA KARAKAYA", "KIZANOĞLU", "KOCAYİĞİT", "KÖYLÜ", "KUŞ", "MUTLU", "NOZOĞLU", "OKÇU", "ÖZ", "ÖZEL", "PEYNİRCİ", "SADIÇ", "SAĞCAN", "SARIEKİZ", "SAVAŞ", "SAYYİĞİT", "SERVET", "SU KURT", "SULHAN", "SÜRÜCÜ", "ŞAHBAZ", "ŞEKERLER", "ŞENER", "ŞİRZAİ", "TAY", "TOKAT", "TOLA", "TOPTAŞ", "TÜTEN", "ULAŞ", "UYĞUN", "UZ", "UZUN", "ÜLKEVAN", "YADİGAROĞLU", "YAĞCI", "YAKIŞAN", "YILDIZ ALTUN", "ZENGİN", "ZUBAROĞLU" };
                return lastNames[random.Next(lastNames.Length)];
            }

            string GetRandomEmail()
            {
                string[] domains = { "gmail.com", "outlook.com", "mailinator.com", "hotmail.com" };
                return $"{GetRandomFirstName().ToLower()}.{GetRandomLastName().ToLower()}@{domains[random.Next(domains.Length)]}";
            }

            string GetRandomPassword()
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            }

            var userList = new List<User>
            {
                new User { Email = GetRandomEmail(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName()  },
                new User { Email = GetRandomEmail(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName() },
                new User { Email = GetRandomEmail(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName() },
                new User { Email = GetRandomEmail(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName() },
                new User { Email = GetRandomEmail(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName() },
                new User { Email = GetRandomEmail(), FirstName = GetRandomFirstName(), LastName = GetRandomLastName() }
            };

            foreach (var user in userList)
            {
                userManager.Add(user);
            }

            //var customerList = new List<Customer>
            //{
            //    new Customer{CompanyName="Kiralama", UserID=1},
            //    new Customer{CompanyName="Kiralama", UserID=2},
            //    new Customer{CompanyName="Kiralama", UserID=3},
            //    new Customer{CompanyName="Kiralama", UserID=4},
            //    new Customer{CompanyName="Kiralama", UserID=5}
            //};
            //
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //
            //foreach (var customer in customerList)
            //{
            //    customerManager.Add(customer);
            //}


            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var rental = new Rental { Id = 3, CarId = 8, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(5) };
            rentalManager.Add(rental);

            Console.WriteLine("*/*/*/*/Kiralana Araçlar -/*/*/*/*/*/ ");
            var kiralananAraclar = rentalManager.GetList().Data;

            foreach (var rentCar in kiralananAraclar)
            {
                Console.WriteLine($"{rentCar.CarId} {rentCar.RentDate} {rentCar.ReturnDate} ");
            }



        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal()); // Örnek oluşturulduğunu varsayalım

            Random random = new Random();

            // Rastgele car değerler oluşturma
            int randomId = random.Next(1, 1000); // 1 ile 100 arasında rastgele bir Id
            int randomBrandId = random.Next(1, 10); // 1 ile 10 arasında rastgele bir BrandId
            int randomColorId = random.Next(1, 10); // 1 ile 10 arasında rastgele bir ColorId
            decimal randomDailyPrice = (decimal)(random.NextDouble() * (1000000 - 50000) + 50000); // 50,000 ile 1,000,000 arasında rastgele bir DailyPrice
            int randomModelYear = random.Next(DateTime.Now.Year, DateTime.Now.Year + 5); // Şu anki yıldan başlayarak 5 yıl ileriye kadar rastgele bir ModelYear
            string[] carNames = { "Renault Clio", "Ford Focus", "Toyota Corolla", "BMW 3 Series", "Mercedes-Benz C-Class" };
            string randomName = carNames[random.Next(0, carNames.Length)]; // Örnek araba isimlerinden rastgele bir Name

            // Oluşturulan rastgele değerlerle Car nesnesini oluşturma ve ekleme
            carManager.Add(new Car()
            {
                Id = randomId,
                BrandId = randomBrandId,
                ColorId = randomColorId,
                ModelName = $"{randomName} {randomId}",
                DailyPrice = randomDailyPrice,
                Description = "Rastgele Açıklama",
                ModelYear = randomModelYear
            });
            var result = carManager.GetList();
            if (result.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName);
                }
            }
            Console.WriteLine("*******************************************1");
            var result1 = carManager.GetById(randomId);
            Console.WriteLine(result1.Data.ModelName);

            Console.WriteLine("*******************************************2");

            Console.WriteLine("*******************************************3");
            var result2 = carManager.GetAllByDailyPriceRange(9000, 990000);
            if (result2.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName + " - " + car.DailyPrice);
                }
            }
            Console.WriteLine("*******************************************4");

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result3 = carManager.GetCarsByBrandId(randomBrandId);
            if (result.IsSuccess == true)
            {
                foreach (var car in result3.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName + " - " + brandManager.GetById(car.BrandId).Data.name);
                }
            }

            Console.WriteLine("*******************************************5");
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result4 = carManager.GetCarsByColorId(randomColorId);
            if (result.IsSuccess == true)
            {
                foreach (var car in result4.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.ModelName + " - " + colorManager.GetById(car.ColorId).Data.name);
                }
            }

            Console.WriteLine("*******************************************6");

            // Rastgele car değerler oluşturma
            int randomBrandId1 = random.Next(1, 1000); // 1 ile 100 arasında rastgele bir Id
            string[] carBrandNames = {
                                        "Audi", "BMW", "Chevrolet", "Dodge", "Ferrari", "Ford", "Honda", "Hyundai",
                                        "Jaguar", "Jeep", "Kia", "Lamborghini", "Lexus", "Maserati", "Mazda",
                                        "Mercedes-Benz", "Mini", "Mitsubishi", "Nissan", "Porsche", "Ram",
                                        "Renault", "Rolls-Royce", "Subaru", "Tesla", "Toyota", "Volkswagen",
                                        "Volvo", "Alfa Romeo", "Aston Martin", "Bentley", "Bugatti", "Buick",
                                        "Cadillac", "Chrysler", "Fiat", "Genesis", "Infiniti", "Lincoln", "McLaren" };


            string randomBrandName1 = carBrandNames[random.Next(0, carBrandNames.Length)]; // Örnek araba isimlerinden rastgele bir Name

            Console.WriteLine("***Örnek araba isimlerinden rastgele bir Name***7");
            var result5 = carManager.GetById(40);
            Car carToUpdate = result5.Data;

            carToUpdate.BrandId = random.Next(1, 16);
            carToUpdate.ColorId = random.Next(1, 11);
            carToUpdate.ModelName = randomBrandName1 + " new model";
            carToUpdate.ModelYear = 2024;
            carToUpdate.DailyPrice = 1250000;
            carToUpdate.Description = "Some Description Text";

            carManager.Update(carToUpdate);

            Console.WriteLine("*******************************************8");
            var result6 = carManager.GetById(971);
            Car carToDelete = result6.Data;
            carManager.Delete(carToDelete);
            Console.WriteLine("*****Araç Detayları*************************9");
            var result7 = carManager.GetCarDetails();
            if (result7.IsSuccess == true)
            {
                foreach (var car in result7.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
        }
    }
}
