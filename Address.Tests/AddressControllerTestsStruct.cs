using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Address.Tests

{
    /// <summary>
    /// Тесты для контроллера AddressController
    /// </summary>
    public partial class AddressControllerTests
    {

        #region Верная строка
        /// <summary>
        /// Тест для возврата верной структуры
        /// </summary>
        [Fact]
        public void PostAddressStruct_RightStruct()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var address = new Address()
            {
                ZipCode = "618426",
                State = "Московская область",
                City = "г. Кубинка",
                Street = "ул. Мира",
                House = "д. 55",
                Building = "корп. 7",
                Apartment = "кв. 5"
            };
            var result = controller.PostAddressStruct("ул. Мира,  д.   55 , корп7, кв.5, Московскаяобласть,618426, гКубинка") as OkObjectResult;

            // Assert
            Assert.Equal(address, result.Value);
        }
        #endregion

        #region Превышено количество элементов адреса
        /// <summary>
        /// Тест на превышение количества элементов адреса
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongParts()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("ул. Мира,  д.   55 , корп7, кв.5, Московскаяобласть,618426, гКубинка, гРеутов") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Некорректный адрес", result.Value);
        }
        #endregion

        #region Пустая строка
        /// <summary>
        /// Тест на передачу пустой строки
        /// </summary>
        [Fact]
        public void PostAddressString_StructNullString()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct(null) as BadRequestObjectResult;

            // Assert
            Assert.Equal("Пустая строка", result.Value);
        }
        #endregion

        #region Два индекса
        /// <summary>
        /// Тест на передачу двух индексов
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongZipCodeCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("614000, 618000, дом 55") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одного индекса", result.Value);
        }
        #endregion

        #region Два субъекта
        /// <summary>
        /// Тест на передачу двух субъектов
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongStateCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("Пермская область, Пермский край, д.55, ул. Мира") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одного субъекта", result.Value);
        }
        #endregion

        #region Два города
        /// <summary>
        /// Тест на передачу двух городов
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongCityCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("Пермская область, г.Пермь, г. Сочи,  д.55, ул. Мира") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одного населённого пункта", result.Value);
        }
        #endregion

        #region Две улицы
        /// <summary>
        /// Тест на передачу двух улиц
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongStreetCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("Пермская область, г.Пермь, улМира, ул.  Ленина,   д.55, ул. Мира") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одной улицы", result.Value);
        }
        #endregion

        #region Два дома
        /// <summary>
        /// Тест на передачу двух номеров домов
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongHouseCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("Пермская область, г.Пермь, улМира, дом 12,   д.55") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одного номера дома", result.Value);
        }
        #endregion

        #region Два номера корпуса
        /// <summary>
        /// Тест на передачу двух номеров корпуса домов
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongBuildingCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("Пермская область, г.Пермь, улМира, дом 12, корп. 5, корп 10") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одного номера корпуса дома", result.Value);
        }
        #endregion

        #region Два номера квартиры
        /// <summary>
        /// Тест на передачу двух номеров квартир
        /// </summary>
        [Fact]
        public void PostAddressString_StructWrongApartmentsCount()
        {
            // Arrange
            AddressController controller = new AddressController();

            // Act
            var result = controller.PostAddressStruct("Пермская область, г.Пермь, улМира, дом 12, к10, кв.5") as BadRequestObjectResult;

            // Assert
            Assert.Equal("Обнаружено больше одного номера квартиры", result.Value);
        }
        #endregion
    }
}