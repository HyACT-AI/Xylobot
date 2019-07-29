using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO;

namespace XylophoneRobot
{
    class RobotParameter
    {
        #region Dll Import for file Access
        //Dll Import for file Access
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileInt(String section, String key, int def, String filePath);
        [DllImport("kernel32.dll")]
        public static extern long WritePrivateProfileString(String section, String key, String val, String filePath);
        #endregion


        #region Robot Parameter Part
        //Const Declare
        public double ANGLE_RATIO = 0.2932551319;
        public double PI = 3.1415926535;
        public double SCALEOFFSET = 28.28; //건반과 건반사이 거리(mm)

        //Default Value
        public int[] RangeMin = new int[3] { 252, 210, 200 };     //축별 Jog 범위-최소값
        public int[] RangeMax = new int[3] { 762, 525, 525 };     //축별 Jog 범위-최대값
        public double[] Dir = new double[3] { +1.0, -1.0, -1.0 }; //축별 방향 설정

        //Robot Parameter Part
        public int H_Moving_Time = 70;             // 연주중 수평으로 이동하는 시간(ms)
        public int V_Moving_Time = 50;             // 연주중 수직으로 이동하는 시간(ms)
        public int V_Moving_Offset = 75;           // 연주중 실로폰을 치기 위해 3번째 축을 들어 올리는 값(1=0.29도)
        public int V_Position_defaultOffset = -20; // Teaching값중 3번째 축의 값을 조종하기위한 기본 Offset 설정 값(1=0.29도) - 높이 보정

        public int V_Position_Offset = 0; // Teaching값중 3번째 축의 값을 조종하기위한 Offset 값(1=0.29도) - 높이 보정
        public int H_Position_Offset = 0; // Teaching값중 1번째 축의 값을 조종하기위한 Offset 값(1=0.29도) - 좌/우 보정

        public int[] OriginVal = new int[3] { 512, 512, 512 };  //로봇이 Home Pose를 하는 값(정면을 향하고, 수직으로 세운 자세)
        public int[] LinkLen   = new int[3] { 30, 44, 210 };    //로봇 링크 길이
        public int[] Teaching  = new int[3] { 430, 323, 361 };  //높은 C음에 닫는 위치값

        //Robot Teaching Parameter Part
        public double[,] Angle = new double[10, 3]; //1~9(도레미파솔라시도쉼표)의 1축(1), 2축(2), 3축(값) 값  배열
        public double[,] Point = new double[10, 3]; //1~9(도레미파솔라시도쉼표)의 x(1) ,y(2) ,z(3) 좌표값(mm) 배열
        public double[] Ang = new double[3] { 0.0, 0.0, 0.0 }; //계산을 위한 변수
        public double[] Pos = new double[3] { 0.0, 0.0, 0.0 }; //계산을 위한 변수
        #endregion


        #region 생성자
        // ---------------------------------------------------------------------------------------------------------------
        // -- 생성자
        // ---------------------------------------------------------------------------------------------------------------
        public RobotParameter()
        {
            Ang[0] = (double)(Teaching[0] - OriginVal[0]) * ANGLE_RATIO * Dir[0];
            Ang[1] = (double)(Teaching[1] - OriginVal[1]) * ANGLE_RATIO * Dir[1];
            Ang[2] = (double)(Teaching[2] - OriginVal[2]) * ANGLE_RATIO * Dir[2];

            Pos[0] = Calculate_X(Ang[0], Ang[1], Ang[2]);
            Pos[1] = Calculate_Y(Ang[0], Ang[1], Ang[2]);
            Pos[2] = Calculate_Z(Ang[0], Ang[1], Ang[2]);

            RobotTeaching(Pos[0], Pos[1], Pos[2]);
        }
        #endregion


        #region Robot Teaching Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- Robot Teaching Part
        // ---------------------------------------------------------------------------------------------------------------

        // -- Robot Teaching --------------------------------------------------------------------------------
        public void RobotTeaching(double P1, double P2, double P3)
        {
            int nNum;

            double x, y, z;
            double p, a, b;
            double le, ca, cb;
            double q1, q2, q3;

            Point[8, 0] = P1;
            Point[8, 1] = P2;
            Point[8, 2] = P3;

            for (nNum = 1; nNum <= 8; nNum++)
            {
                Point[nNum, 0] = Point[8, 0]; //음계에 따라 x값 불변
                Point[nNum, 1] = Point[8, 1] + (8 - nNum) * SCALEOFFSET; //음계에 따라 Y값은 SCALEOFFSET만큼 변함
                Point[nNum, 2] = Point[8, 2]; //음계에 따라 z값 불변

                x = Point[nNum, 0];
                y = Point[nNum, 1];
                z = Point[nNum, 2];

                le = Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0) + Math.Pow(z - LinkLen[0], 2.0));
                ca = (Math.Pow(LinkLen[1], 2.0) + Math.Pow(le, 2.0) - Math.Pow(LinkLen[2], 2.0)) / (2.0 * LinkLen[1] * le);
                cb = (Math.Pow(LinkLen[1], 2.0) - Math.Pow(le, 2.0) + Math.Pow(LinkLen[2], 2.0)) / (2.0 * LinkLen[1] * LinkLen[2]);

                p = Math.Atan2(z - LinkLen[0], Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0)));
                a = Math.Atan2(Math.Sqrt(1.0 - Math.Pow(ca, 2.0)), ca);
                b = Math.Atan2(Math.Sqrt(1.0 - Math.Pow(cb, 2.0)), cb);

                // Original InverseKinematics
                q1 = Math.Atan2(y, x);  //the angle of the 1st joint
                q2 = PI / 2.0 - p - a;  //the angle of the 2nd joint
                q3 = PI - b;            //the angle of the 3rd joint

                Angle[nNum, 0] = R2D(q1);
                Angle[nNum, 1] = R2D(q2);
                Angle[nNum, 2] = R2D(q3);
            }
        }

        //생성자, Robot Kinematics --------------------------------------
        public double Calculate_X(double A1, double A2, double A3)
        {
            double dValue;
            double[] RAng = new double[3];
            RAng[0] = D2R(A1);
            RAng[1] = D2R(A2);
            RAng[2] = D2R(A3);
            dValue = (LinkLen[1] * Math.Sin(RAng[1]) + LinkLen[2] * Math.Sin(RAng[1] + RAng[2])) * Math.Cos(RAng[0]);
            return dValue;
        }

        public double Calculate_Y(double A1, double A2, double A3)
        {
            double dValue;
            double[] RAng = new double[3];
            RAng[0] = D2R(A1);
            RAng[1] = D2R(A2);
            RAng[2] = D2R(A3);
            dValue = (LinkLen[1] * Math.Sin(RAng[1]) + LinkLen[2] * Math.Sin(RAng[1] + RAng[2])) * Math.Sin(RAng[0]);
            return dValue;
        }

        public double Calculate_Z(double A1, double A2, double A3)
        {
            double dValue;
            double[] RAng = new double[3];
            RAng[0] = D2R(A1);
            RAng[1] = D2R(A2);
            RAng[2] = D2R(A3);
            dValue = (LinkLen[1] * Math.Cos(RAng[1]) + LinkLen[2] * Math.Cos(RAng[1] + RAng[2])) + LinkLen[0];
            return dValue;
        }

        private double D2R(double DValue)
        {
            return (PI / 180.0) * DValue;
        }

        private double R2D(double RValue)
        {
            return (180.0 / PI) * RValue;
        }
        #endregion
    }
}
