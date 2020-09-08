using System;

namespace Address
{
    public struct Output
    {
        /// <summary>
        /// ��������� ������ � ������
        /// </summary>
        public string Data { get; set; } 

        /// <summary>
        ///true - ����� ������ �������, ��� ����; 
        ///false - ���������� ������ ������ ������ �����; 
        ///null - ����� ������ �� �������
        /// </summary>
        public bool? Status { get; set; } 
    }
}
