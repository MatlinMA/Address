using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// Поиск субъекта в массиве строк
        /// </summary>
        /// <param name="addressPart"></param>
        /// <returns></returns>
        public Output FindState (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                #region край
                if (s.Length > 4 && s.Substring(s.Length - 4, 4) == "край")
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(0, s.Length - 4);
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
                    Answer.Data += " край";
                }
                #endregion

                #region область
                if (s.Length > 7 && s.Substring(s.Length - 7, 7) == "область")
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(0, s.Length - 7);
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
                    Answer.Data += " область";
                }
                #endregion

                #region обл
                if (s.Length > 3 && s.Substring(s.Length - 3, 3) == "обл")
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(0, s.Length - 3);
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
                    Answer.Data += " область";
                }
                #endregion

                #region обл.
                if (s.Length > 4 && s.Substring(s.Length - 4, 4) == "обл.")
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s.Substring(0, s.Length - 4);
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
                    Answer.Data += " область";
                }
                #endregion
            }
            return Answer;
        }
    }
}
