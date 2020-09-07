using System;

namespace Address
{
    public struct Address
    {
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Название субьекта
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Название населённый пункт
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Номер корпуса
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string Apartment { get; set; }
    }
}
