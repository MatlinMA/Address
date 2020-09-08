using System;

namespace Address
{
    public struct Address
    {
        /// <summary>
        /// �������� ������
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// �������� ��������
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// �������� ��������� �����
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// �������� �����
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// ����� ����
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// ����� �������
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// ����� ��������
        /// </summary>
        public string Apartment { get; set; }
    }
}
