using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// ����� ���������� ������ � ������� �����
        /// </summary>
        /// <param name="addressPart"></param>
        /// <returns></returns>
        public Output FindCity (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                #region �����
                if (s.Length > 5 && s.Substring(0, 5) == "�����" && char.IsUpper(s.Substring(5).Trim()[0]))
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
                    char.ToUpper(Answer.Data[0]);
                    Answer.Data = "�. " + Answer.Data;
                }
                #endregion

                #region ���
                if (s.Length > 3 && s.Substring(0, 3) == "���" && char.IsUpper(s.Substring(3).Trim()[0]))
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
                    char.ToUpper(Answer.Data[0]);
                    Answer.Data = "�. " + Answer.Data;
                }
                #endregion

                #region ���.
                if (s.Length > 4 && s.Substring(0, 4) == "���." && char.IsUpper(s.Substring(4).Trim()[0]))
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
                    char.ToUpper(Answer.Data[0]);
                    Answer.Data = "�. " + Answer.Data;
                }
                #endregion

                #region �.
                if (s.Length > 2 && s.Substring(0, 2) == "�." && char.IsUpper(s.Substring(2).Trim()[0]))
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
                    Answer.Data = "�. " + Answer.Data;
                }
                #endregion

                #region �
                if (s.Length > 1 && s.Substring(0, 1) == "�" && char.IsUpper(s.Substring(1).Trim()[0]))
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
                    Answer.Data = "�. " + Answer.Data;
                }
                #endregion
            }
            return Answer;
        }
    }
}
