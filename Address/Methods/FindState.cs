using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// ����� �������� � ������� �����
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
                #region ����
                if (s.Length > 4 && s.Substring(s.Length - 4, 4) == "����")
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
                    Answer.Data += " ����";
                }
                #endregion

                #region �������
                if (s.Length > 7 && s.Substring(s.Length - 7, 7) == "�������")
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
                    Answer.Data += " �������";
                }
                #endregion

                #region ���
                if (s.Length > 3 && s.Substring(s.Length - 3, 3) == "���")
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
                    Answer.Data += " �������";
                }
                #endregion

                #region ���.
                if (s.Length > 4 && s.Substring(s.Length - 4, 4) == "���.")
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
                    Answer.Data += " �������";
                }
                #endregion
            }
            return Answer;
        }
    }
}
