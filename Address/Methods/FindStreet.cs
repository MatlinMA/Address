using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// Поиск улицы в массиве строк
        /// </summary>
        /// <param name="addressPart"></param>
        /// <returns></returns>
        public Output FindStreet (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                #region улица
                if (s.Length > 5 && s.Substring(0, 5) == "улица" && char.IsUpper(s.Substring(5).Trim()[0]))
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
                    Answer.Data = "ул. " + Answer.Data;
                }
                #endregion

                #region ул.
                if (s.Length > 3 && s.Substring(0, 3) == "ул." && char.IsUpper(s.Substring(3).Trim()[0]))
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
                    Answer.Data = "ул. " + Answer.Data;
                }
                #endregion

                #region ул
                if (s.Length > 2 && s.Substring(0, 2) == "ул" && char.IsUpper(s.Substring(2).Trim()[0]))
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
                    char.ToUpper(Answer.Data[0]);
                    Answer.Data = "ул. " + Answer.Data;
                }
                #endregion
            }
            return Answer;
        }
    }
}
