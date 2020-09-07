using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// ѕоиск номера квартиры в массиве строк
        /// </summary>
        /// <param name="addressPart">ћассив входных данных</param>
        /// <returns></returns>
        public Output FindApartment (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                #region квартира
                if (s.Length > 8 && s.Substring(0, 8) == "квартира" && char.IsDigit(s.Substring(8).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(8);
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
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion

                #region кв.
                if (s.Length > 3 && s.Substring(0, 3) == "кв." && char.IsDigit(s.Substring(3).Trim()[0]))
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
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion

                #region кв
                if (s.Length > 2 && s.Substring(0, 2) == "кв" && char.IsDigit(s.Substring(2).Trim()[0]))
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
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion

                #region кварт.
                if (s.Length > 6 && s.Substring(0, 6) == "кварт." && char.IsDigit(s.Substring(6).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(6);
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
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion

                #region кварт
                if (s.Length > 5 && s.Substring(0, 5) == "кварт" && char.IsDigit(s.Substring(5).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(5);
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
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion

                #region к.
                if (s.Length > 2 && s.Substring(0, 2) == "к." && char.IsDigit(s.Substring(2).Trim()[0]))
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
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion

                #region к
                if (s.Length > 1 && s.Substring(0, 1) == "к" && char.IsDigit(s.Substring(1).Trim()[0]))
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
                    char.ToUpper(Answer.Data[0]);
                    Answer.Data = "кв. " + Answer.Data;
                }
                #endregion
            }
            return Answer;
        }
    }
}
