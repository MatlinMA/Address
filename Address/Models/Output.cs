using System;

namespace Address
{
    public struct Output
    {
        /// <summary>
        /// Результат поиска в строке
        /// </summary>
        public string Data { get; set; } 

        /// <summary>
        ///true - часть адреса найдена, она одна; 
        ///false - подходящих частей адреса больше одной; 
        ///null - часть адреса не найдена
        /// </summary>
        public bool? Status { get; set; } 
    }
}
