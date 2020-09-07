using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// Поиск номера корпуса дома в массиве строк
        /// </summary>
        /// <param name="addressPart">Массив входных данных</param>
        /// <returns></returns>
        public Output FindBuilding (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                #region корпус
                if (s.Length > 6 && s.Substring(0, 6) == "корпус" && char.IsDigit(s.Substring(6).Trim()[0]))
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
                    Answer.Data = "корп. " + Answer.Data;
                }
                #endregion

                #region корп.
                if (s.Length > 5 && s.Substring(0, 5) == "корп." && char.IsDigit(s.Substring(5).Trim()[0]))
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
                    Answer.Data = "корп. " + Answer.Data;
                }
                #endregion

                #region корп
                if (s.Length > 4 && s.Substring(0, 4) == "корп" && char.IsDigit(s.Substring(4).Trim()[0]))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(4);
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
                    Answer.Data = "корп. " + Answer.Data;
                }
                #endregion
            }
            return Answer;
        }
    }
}
