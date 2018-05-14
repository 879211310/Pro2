using System.Text;

namespace MyProject.Services.Utility
{
    public class EncodeUtility
    {
        /// <summary>
        ///   ���������λ��ת������
        /// </summary>
        public static int GB_SP_DIFF = 160;

        /// <summary>
        /// ��Ź���һ�����ֲ�ͬ��������ʼ��λ�� 
        /// </summary>
        public static int[] SecPosvalueList = { 1601, 1637, 1833, 2078, 2274, 2302, 2433, 2594, 2787, 3106, 3212, 3472,
                                            3635, 3722, 3730, 3858, 4027, 4086, 4390, 4558, 4684, 4925, 5249, 5600 };
        /// <summary>
        /// ��Ź���һ�����ֲ�ͬ��������ʼ��λ���Ӧ����
        /// </summary>
        public static char[] FirstLetter = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm',
                                          'n', 'o', 'p', 'q', 'r', 's', 't', 'w', 'x', 'y', 'z' };

        /// <summary>
        /// ��ȡһ���ַ�����ƴ����
        /// </summary>
        /// <param name="orginString">ԭʼ�ַ���</param>
        /// <returns></returns>
        public static string GetFirstLetters(string orginString)
        {
            var str = orginString.ToLower();
            var buffer = new StringBuilder();
            foreach (var ch in str)
            {
                var temp = new char[] { ch };
                var uniCode = Encoding.Default.GetBytes(temp);
                if (uniCode[0] < 128 && uniCode[0] > 0)
                {
                    //�Ǻ���   
                    buffer.Append(temp);
                }
                else
                {
                    buffer.Append(Convert(uniCode));
                }
            }
            return buffer.ToString();
        }

        /// <summary>
        /// ��ȡһ�����ֵ�ƴ������ĸ��   
        /// GB�������ֽڷֱ��ȥ160��ת����10��������ϾͿ��Եõ���λ��   
        /// ���纺�֡��㡱��GB����0xC4/0xE3���ֱ��ȥ0xA0��160������0x24/0x43   
        /// 0x24ת��10���ƾ���36��0x43��67����ô������λ�����3667���ڶ��ձ��ж���Ϊ��n��  
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static char Convert(byte[] bytes)
        {
            var result = '-';
            var secPosvalue = 0;
            int i;
            for (i = 0; i < bytes.Length; i++)
            {
                bytes[i] -= (byte)GB_SP_DIFF;
            }
            secPosvalue = bytes[0] * 100 + bytes[1];
            for (i = 0; i < 23; i++)
            {
                if (secPosvalue >= SecPosvalueList[i] && secPosvalue < SecPosvalueList[i + 1])
                {
                    result = FirstLetter[i];
                    break;
                }
            }
            return result;
        }
    }
}