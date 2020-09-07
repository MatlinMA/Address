using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Address
{
    [ApiController]
    [Route("api/")]
    public partial class AddressController : ControllerBase
    {
        /// <summary>
        /// Определение POST запроса, возвращающего строку с адресом
        /// </summary>
        /// <param name="userAddress">Адрес из запроса</param>
        [HttpPost]
        [Route("AddressString")]
        public ActionResult PostAddressString(string userAddress)
        {
            if (userAddress == "")
                return BadRequest("Пустая строка");

            else
            {
                //Проверка на количество элементов адреса в строке
                if (userAddress.ToCharArray().Where(c => c == ',').Count() > 6)
                    return BadRequest("Некорректный адрес");

                #region Распознавание и вывод адреса в строку
                else
                {
                    var addressParts = (userAddress).Split(','); //массив частей адреса
                    var findResult = new Output(); // результат поиска части адреса в массиве
                    var stringBuilder = new StringBuilder(); // выходная строка адреса через stringbuilder

                    for (int i = 0; i < addressParts.Length; i++) //отбрасываем пробелы в начале и конце строк в массиве частей адреса
                    {
                        addressParts[i] = addressParts[i].Trim();
                    }

                    #region Поиск индекса
                    findResult = FindZipCode(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(findResult.Data);
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного индекса");
                        }

                        if (findResult.Status == null)
                        {
                            stringBuilder.Append("614000");
                        }
                    }
                    #endregion

                    #region Поиск субъекта
                    findResult = FindState(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(findResult.Data);
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного субъекта");
                        }
                        if (findResult.Status == null)
                        {
                            stringBuilder.Append(", Пермский край");
                        }
                    }
                    #endregion

                    #region Поиск населённого пункта
                    findResult = FindCity(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(findResult.Data);
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного населённого пункта");
                        }
                        if (findResult.Status == null)
                        {
                            stringBuilder.Append(", г. Пермь");
                        }
                    }
                    #endregion

                    #region Поиск улицы
                    findResult = FindStreet(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(findResult.Data);
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одной улицы");
                        }
                    }
                    #endregion

                    bool isHouseExist = false;

                    #region Поиск номера дома
                    findResult = FindHouse(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(findResult.Data);
                        isHouseExist = true;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного номера дома");
                        }
                        if (findResult.Status == null)
                        {
                            isHouseExist = false;
                        }
                    }
                    #endregion

                    #region Поиск корпуса дома
                    findResult = FindBuilding(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(findResult.Data);
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного корпуса дома");
                        }
                        if (findResult.Status == null)
                        {
                            if (isHouseExist == false) //Может быть дом без номера, но с номером корпуса
                            {
                                return BadRequest("Не указан номер дома или корпуса");
                            }
                        }
                    }
                    #endregion

                    #region Поиск квартиры
                    findResult = FindApartment(addressParts);
                    if (findResult.Status == true)
                    {
                        stringBuilder.Append(", ");
                        stringBuilder.Append(findResult.Data);
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного номера квартиры");
                        }
                    }
                    #endregion

                    return Ok(stringBuilder.ToString());
                }
                #endregion
            }
        }

        /// <summary>
        /// Определение POST запроса, возвращающего структуру с адресом
        /// </summary>
        /// <param name="userAddress">Адрес из запроса</param>
        [HttpPost]
        [Route("AddressStruct")]
        public ActionResult PostAddressStruct(string userAddress)
        {
            if (userAddress == null)
                return BadRequest("Пустая строка");

            else
            {
                //Проверка на количество элементов адреса в строке
                if (userAddress.ToCharArray().Where(c => c == ',').Count() > 6)
                    return BadRequest("Некорректный адрес");

                #region Распознавание и вывод адреса структурой
                else
                {
                    var addressParts = (userAddress).Split(','); //массив частей адреса
                    var findResult = new Output(); // результат поиска части адреса в массиве
                    var outputAddress = new Address(); // выходная строка адреса


                    for (int i = 0; i < addressParts.Length; i++) //отбрасываем пробелы в начале и конце строк в массиве частей адреса
                    {
                        addressParts[i] = addressParts[i].Trim();
                    }

                    #region Поиск индекса
                    findResult = FindZipCode(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.ZipCode = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного индекса");
                        }

                        if (findResult.Status == null)
                        {
                            outputAddress.ZipCode = "614000";
                        }
                    }
                    #endregion

                    #region Поиск субъекта
                    findResult = FindState(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.State = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного субъекта");
                        }
                        if (findResult.Status == null)
                        {
                            outputAddress.State = "Пермский край";
                        }
                    }
                    #endregion

                    #region Поиск населённого пункта
                    findResult = FindCity(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.City = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного населённого пункта");
                        }
                        if (findResult.Status == null)
                        {
                            outputAddress.City = "г. Пермь";
                        }
                    }
                    #endregion

                    #region Поиск улицы
                    findResult = FindStreet(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.Street = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одной улицы");
                        }
                        if (findResult.Status == null)
                        {
                            outputAddress.Street = null;
                        }
                    }
                    #endregion

                    #region Поиск номера дома
                    findResult = FindHouse(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.House = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного номера дома");
                        }
                        if (findResult.Status == null)
                        {
                            outputAddress.Building = null;
                        }
                    }
                    #endregion

                    #region Поиск номера корпуса
                    findResult = FindBuilding(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.Building = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного номера корпуса дома");
                        }
                        if (findResult.Status == null)
                        {

                            if (outputAddress.House != null) //Может быть дом без номера, но с номером корпуса
                            {
                                outputAddress.Building = null;
                            }
                            else
                            {
                                return BadRequest("Не указан номер дома или корпуса");
                            }

                        }
                    }
                    #endregion

                    #region Поиск квартиры
                    findResult = FindApartment(addressParts);
                    if (findResult.Status == true)
                    {
                        outputAddress.Apartment = findResult.Data;
                    }
                    else
                    {
                        if (findResult.Status == false)
                        {
                            return BadRequest("Обнаружено больше одного номера квартиры");
                        }
                        if (findResult.Status == null)
                        {
                            outputAddress.Apartment = null;
                        }
                    }
                    #endregion

                    return Ok(outputAddress);
                }
                #endregion

            }
        }
    }
}

