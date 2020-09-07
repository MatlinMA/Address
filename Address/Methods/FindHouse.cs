using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// Поиск номера дома в массиве строк
        /// </summary>
        /// <param name="addressPart">Массив входных данных</param>
        /// <returns></returns>
        public Output FindHouse (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                #region дом
                if (s.Length > 3 && s.Substring(0, 3) == "дом" && char.IsDigit(s.Substring(3).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(3);
                        Answer.Status = true;
                    }
                    else
                    {
                        if (Answer.Status == true)
                        {
                            Answer.Status = false;
                            Answer.Data = null;
                            return Answer;
                        }
                    }
                    Answer.Data = Answer.Data.Trim();
                    Answer.Data = "д. " + Answer.Data;
                }
                #endregion

                #region д.
                if (s.Length > 2 && s.Substring(0, 2) == "д." && char.IsDigit(s.Substring(2).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(2);
                        Answer.Status = true;
                    }
                    else
                    {
                        if (Answer.Status == true)
                        {
                            Answer.Status = false;
                            Answer.Data = null;
                            return Answer;
                        }
                    }
                    Answer.Data = Answer.Data.Trim();
                    Answer.Data = "д. " + Answer.Data;
                }
                #endregion

                #region д
                if (s.Length > 1 && s.Substring(0, 1) == "д" && char.IsDigit(s.Substring(1).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(1);
                        Answer.Status = true;
                    }
                    else
                    {
                        if (Answer.Status == true)
                        {
                            Answer.Status = false;
                            Answer.Data = null;
                            return Answer;
                        }
                    }
                    Answer.Data = Answer.Data.Trim();
                    Answer.Data = "д. " + Answer.Data;
                }
                #endregion
            }
            return Answer;
        }
    }
}
