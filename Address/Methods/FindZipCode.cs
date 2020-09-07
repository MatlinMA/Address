using System;

namespace Address
{
    public partial class AddressController
    {
        /// <summary>
        /// ѕоиск почтового индекса в массиве строк
        /// </summary>
        /// <param name="addressPart"></param>
        /// <returns></returns>
        public Output FindZipCode (string[] addressPart)
        {
            var Answer = new Output();
            Answer.Data = "";
            Answer.Status = null;
            foreach (string s in addressPart)
            {
                if (s.Length == 6 && Int32.TryParse(s, out int i))
                {
                    if (Answer.Status == null)
                    {
                        Answer.Data = s;
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
                }
            }
            return Answer;
        }
    }
}
