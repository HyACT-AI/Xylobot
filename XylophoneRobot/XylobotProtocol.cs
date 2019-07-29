using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XylophoneRobot
{
    class XylobotProtocol
    {
        #region Decleare
        const int PACKET_LENGTH = 10;
        // Xylobol Protocol ver 1.3 사용
        // Packet 구성(10byte 고정)
        // Header 1 | Header 2 | Instruction | Para 1 | Para 2 | Para 3 | Para 4 | Para 5 | Para 6 | Check Sum

        // - Headers --------------------------------------------------- //
        const byte HEADER_1 = 0xFF;
        const byte HEADER_2 = 0xFF;

        // - Instructions ---------------------------------------------- //
        // - Flash Memory ---------------------------------------------- //
        const byte IST_R_PRODUCT_NUMBER = 0x01;
        const byte IST_R_FIRMWARE_VERSION = 0x02;
        const byte IST_R_BAUD_RATE_SERIAL_PORT = 0x03;
        const byte IST_W_BAUD_RATE_SERIAL_PORT = 0x04;
        const byte IST_R_BAUD_RATE_BLUETOOTH = 0x05;
        const byte IST_W_BAUD_RATE_BLUETOOTH = 0x06;
        const byte IST_R_BAUD_RATE_DEVICE_LINE = 0x07;
        const byte IST_W_BAUD_RATE_DEVICE_LINE = 0x08;
        const byte IST_R_POSITION_ZERO_POINT = 0x09;
        const byte IST_W_POSITION_ZERO_POINT = 0x0A;
        const byte IST_R_POSITION_C = 0x0B;
        const byte IST_W_POSITION_C = 0x0C;
        const byte IST_R_POSITION_D = 0x0D;
        const byte IST_W_POSITION_D = 0x0E;
        const byte IST_R_POSITION_E = 0x0F;
        const byte IST_W_POSITION_E = 0x10;
        const byte IST_R_POSITION_F = 0x11;
        const byte IST_W_POSITION_F = 0x12;
        const byte IST_R_POSITION_G = 0x13;
        const byte IST_W_POSITION_G = 0x14;
        const byte IST_R_POSITION_A = 0x15;
        const byte IST_W_POSITION_A = 0x16;
        const byte IST_R_POSITION_B = 0x17;
        const byte IST_W_POSITION_B = 0x18;
        const byte IST_R_POSITION_HIGH_C = 0x19;
        const byte IST_W_POSITION_HIGH_C = 0x1A;
        const byte IST_R_GAIN = 0x1B;
        const byte IST_W_GAIN = 0x1C;
        const byte IST_R_LINK_LENGTH = 0x1D;
        const byte IST_W_LINK_LENGTH = 0x1E;
        const byte IST_R_TIME_H_MOVING = 0x1F;
        const byte IST_W_TIME_H_MOVING = 0x20;
        const byte IST_R_TIME_V_MOVING = 0x21;
        const byte IST_W_TIME_V_MOVING = 0x22;
        const byte IST_R_OFFSET_H_MOVING = 0x23;
        const byte IST_W_OFFSET_H_MOVING = 0x24;
        const byte IST_R_OFFSET_V_MOVING = 0x25;
        const byte IST_W_OFFSET_V_MOVING = 0x26;
        const byte IST_R_OFFSET_H_POSITION = 0x27;
        const byte IST_W_OFFSET_H_POSITION = 0x28;
        const byte IST_R_OFFSET_V_POSITION = 0x29;
        const byte IST_W_OFFSET_V_POSITION = 0x2A;
        const byte IST_R_SYSTEM_LOCK = 0x3E;
        const byte IST_W_SYSTEM_LOCK = 0x3F;
        // - Instructions ---------------------------------------------- //
        // - RAM ------------------------------------------------------- //
        const byte IST_R_OPERATION_MODE = 0x40;
        const byte IST_W_OPERATION_MODE = 0x41;
        const byte IST_R_LED_RGB = 0x42;
        const byte IST_W_LED_RGB = 0x43;
        const byte IST_R_LED_XYLOPHONE_MATCH = 0x44;
        const byte IST_W_LED_XYLOPHONE_MATHC = 0x45;
        const byte IST_R_LED_OPERATION = 0x46;
        const byte IST_W_LED_OPERATION = 0x47;
        const byte IST_R_PLAY_SCALE = 0x48;
        const byte IST_W_PLAY_SCALE = 0x49;
        // - Instructions ---------------------------------------------- //
        // - Device Memory --------------------------------------------- //
        const byte IST_R_ALL_ID = 0xA0;
        const byte IST_W_ALL_ID = 0xA1;
        const byte IST_R_ALL_BAUD_RATE = 0xA2;
        const byte IST_W_ALL_BAUD_RATE = 0xA3;
        const byte IST_R_ALL_TORQUE_ENABLE = 0xA4;
        const byte IST_W_ALL_TORQUE_ENABLE = 0xA5;
        const byte IST_R_1_TORQUE_ENABLE = 0xA6;
        const byte IST_W_1_TORQUE_ENABLE = 0xA7;
        const byte IST_R_2_TORQUE_ENABLE = 0xA8;
        const byte IST_W_2_TORQUE_ENABLE = 0xA9;
        const byte IST_R_3_TORQUE_ENABLE = 0xAA;
        const byte IST_W_3_TORQUE_ENABLE = 0xAB;
        const byte IST_R_ALL_TARGET_POSITION = 0xAC;
        const byte IST_W_ALL_TARGET_POSITION = 0xAD;
        const byte IST_R_1_TARGET_POSITION = 0xAE;
        const byte IST_W_1_TARGET_POSITION = 0xAF;
        const byte IST_R_2_TARGET_POSITION = 0xB0;
        const byte IST_W_2_TARGET_POSITION = 0xB1;
        const byte IST_R_3_TARGET_POSITION = 0xB2;
        const byte IST_W_3_TARGET_POSITION = 0xB3;
        const byte IST_R_ALL_MOVING_SPEED = 0xB4;
        const byte IST_W_ALL_MOVING_SPEED = 0xB5;
        const byte IST_R_1_MOVING_SPEED = 0xB6;
        const byte IST_W_1_MOVING_SPEED = 0xB7;
        const byte IST_R_2_MOVING_SPEED = 0xB8;
        const byte IST_W_2_MOVING_SPEED = 0xB9;
        const byte IST_R_3_MOVING_SPEED = 0xBA;
        const byte IST_W_3_MOVING_SPEED = 0xBB;
        const byte IST_R_ALL_GAIN = 0xBC;
        const byte IST_W_ALL_GAIN = 0xBD;
        const byte IST_R_1_GAIN = 0xBE;
        const byte IST_W_1_GAIN = 0xBF;
        const byte IST_R_2_GAIN = 0xC0;
        const byte IST_W_2_GAIN = 0xC1;
        const byte IST_R_3_GAIN = 0xC2;
        const byte IST_W_3_GAIN = 0xC3;
        const byte IST_R_ALL_MOVING_TORQUE = 0xC4;
        const byte IST_W_ALL_MOVING_TORQUE = 0xC5;
        const byte IST_R_ALL_PRESENT_POSITION = 0xCC;
        const byte IST_R_1_PRESENT_POSITION = 0xCD;
        const byte IST_R_2_PRESENT_POSITION = 0xCE;
        const byte IST_R_3_PRESENT_POSITION = 0xCF;
        const byte IST_R_ALL_PRESENT_SPEED = 0xD0;
        const byte IST_R_ALL_PRESENT_LOAD = 0xD4;
        const byte IST_R_ALL_PRESENT_VOLTAGE = 0xD8;

        #endregion


        #region Make Packet
        // -- Read 패킷 생성 --------------------------------------------------
        // :: Packet에 Instruction 정보만 포함 (모든 Read 패킷에 해당함)
        // --------------------------------------------------------------------
        private byte[] MakePacket(byte instruction)
        {
            byte[] packet = new byte[PACKET_LENGTH];

            packet[0] = 0xFF;        // Header 1
            packet[1] = 0xFF;        // Header 2
            packet[2] = instruction; // Instruction
            packet[3] = 0x00;        // Empty
            packet[4] = 0x00;        // Empty
            packet[5] = 0x00;        // Empty
            packet[6] = 0x00;        // Empty
            packet[7] = 0x00;        // Empty
            packet[8] = 0x00;        // Empty
            for (int i = 0; i <= 8; i++)
            {
                packet[9] += packet[i];    // Check Sum
            }
            return packet;
        }


        // -- Write 패킷 생성 (2byte) -----------------------------------------
        // :: Packet에 Instruction 정보와 2byte 정수(ushort) 1개만 포함
        // --------------------------------------------------------------------
        private byte[] MakePacket(byte instruction, ushort data)
        {
            byte[] packet = new byte[PACKET_LENGTH];

            packet[0] = 0xFF;              // Header 1
            packet[1] = 0xFF;              // Header 2
            packet[2] = instruction;       // Instruction
            packet[3] = (byte)(data >> 8); // High Byte of data
            packet[4] = (byte)data;        // Low Byte of data
            packet[5] = 0x00;              // Empty
            packet[6] = 0x00;              // Empty
            packet[7] = 0x00;              // Empty
            packet[8] = 0x00;              // Empty
            for (int i = 0; i <= 8; i++)
            {
                packet[9] += packet[i];    // Check Sum
            }
            return packet;
        }


        // -- Write 패킷 생성 (2 Byte // 2 Byte // 2 Byte) --------------------
        // :: Packet에 Instruction 정보와 2byte 정수(ushort) 3개가 포함
        // --------------------------------------------------------------------
        private byte[] MakePacket(byte instruction, ushort firstData, ushort secondData, ushort thirdData)
        {
            byte[] packet = new byte[PACKET_LENGTH];

            packet[0] = 0xFF;                    // Header 1
            packet[1] = 0xFF;                    // Header 2
            packet[2] = instruction;             // Instruction
            packet[3] = (byte)(firstData >> 8);  // High Byte of First Data
            packet[4] = (byte)firstData;         // Low Byte of First Data
            packet[5] = (byte)(secondData >> 8); // High Byte of Second Data
            packet[6] = (byte)secondData;        // Low Byte of Second Data
            packet[7] = (byte)(thirdData >> 8);  // High Byte of Third Data
            packet[8] = (byte)thirdData;         // Low Byte of Third Data
            for (int i = 0; i <= 8; i++)
            {
                packet[9] += packet[i];          // Check Sum
            }
            return packet;
        }


        // -- Write 패킷 생성 (4 Byte) ----------------------------------------
        // :: Packet에 Instruction 정보와 4byte 정수(uint) 1개가 포함
        // --------------------------------------------------------------------
        private byte[] MakePacket(byte instruction, uint data)
        {
            byte[] packet = new byte[PACKET_LENGTH];

            packet[0] = 0xFF;                 // Header 1
            packet[1] = 0xFF;                 // Header 2
            packet[2] = instruction;          // Instruction
            packet[3] = (byte)(data >> 24);   // High Byte of Data
            packet[4] = (byte)(data >> 16);   // Thrid Byte of Data
            packet[5] = (byte)(data >> 8);    // Second Byte of Data
            packet[6] = (byte)data;           // Low Byte of Data
            packet[7] = 0x00;                 // Empty
            packet[8] = 0x00;                 // Empty
            for (int i = 0; i <= 8; i++)
            {
                packet[9] += packet[i];       // Check Sum
            }
            return packet;
        }

        // -- 패킷 디코딩 ------------------------------------------------------
        // :: 입력받은 패킷을 분석하여 데이터를 추출.
        // --------------------------------------------------------------------
        public int[] Decoding(byte[] packet, int[] data)
        {
            switch (packet[2])
            {
                // 2Byte 1개의 정수값을 읽는 Protocol -----------------------------------------------------
                case IST_R_PRODUCT_NUMBER :
                case IST_R_FIRMWARE_VERSION:
                case IST_R_TIME_H_MOVING:
                case IST_R_TIME_V_MOVING:
                case IST_R_OFFSET_H_MOVING:
                case IST_R_OFFSET_V_MOVING:
                case IST_R_OPERATION_MODE:
                case IST_R_LED_XYLOPHONE_MATCH:
                case IST_R_LED_OPERATION:
                case IST_R_PLAY_SCALE:
                case IST_R_1_TORQUE_ENABLE:
                case IST_R_2_TORQUE_ENABLE:
                case IST_R_3_TORQUE_ENABLE:
                case IST_R_1_TARGET_POSITION:
                case IST_R_2_TARGET_POSITION:
                case IST_R_3_TARGET_POSITION:
                case IST_R_1_MOVING_SPEED:
                case IST_R_2_MOVING_SPEED:
                case IST_R_3_MOVING_SPEED:
                case IST_R_1_GAIN:
                case IST_R_2_GAIN:
                case IST_R_3_GAIN:
                case IST_R_1_PRESENT_POSITION:
                case IST_R_2_PRESENT_POSITION:
                case IST_R_3_PRESENT_POSITION:
                    data[0] = (packet[3] << 8) | packet[4];
                    break;
                case IST_R_OFFSET_H_POSITION:
                case IST_R_OFFSET_V_POSITION:
                    if(packet[3] == 128)
                    {
                        data[0] = packet[4] * (-1);
                    }
                    else
                    {
                        data[0] = packet[4];
                    }
                    break;

                // 4Byte(매우 큰 값:예-Baudrate) 1개의 정수값을 읽는 Protocol -----------------------------
                case IST_R_BAUD_RATE_SERIAL_PORT:
                case IST_R_BAUD_RATE_BLUETOOTH:
                case IST_R_BAUD_RATE_DEVICE_LINE:
                case IST_R_ALL_BAUD_RATE:
                    data[0] = (packet[3] << 24) | (packet[4] << 16) | (packet[5] << 8) | packet[6];
                    break;

                // 2Byte 3개의 정수값을 읽는 Protocol -----------------------------------------------------
                case IST_R_POSITION_ZERO_POINT:
                case IST_R_POSITION_C:
                case IST_R_POSITION_D:
                case IST_R_POSITION_E:
                case IST_R_POSITION_F:
                case IST_R_POSITION_G:
                case IST_R_POSITION_A:
                case IST_R_POSITION_B:
                case IST_R_POSITION_HIGH_C:
                case IST_R_GAIN:
                case IST_R_LINK_LENGTH:
                case IST_R_LED_RGB:
                case IST_R_ALL_ID:
                case IST_R_ALL_TORQUE_ENABLE:
                case IST_R_ALL_TARGET_POSITION:
                case IST_R_ALL_MOVING_SPEED:
                case IST_R_ALL_GAIN:
                case IST_R_ALL_MOVING_TORQUE:
                case IST_R_ALL_PRESENT_POSITION:
                case IST_R_ALL_PRESENT_SPEED:
                case IST_R_ALL_PRESENT_LOAD:
                case IST_R_ALL_PRESENT_VOLTAGE:
                    data[0] = (packet[3] << 8) | packet[4];
                    data[1] = (packet[5] << 8) | packet[6];
                    data[2] = (packet[7] << 8) | packet[8];
                    break;
            }
            return data;
        }

        #endregion


        #region Protocol 활용
        //모터의 목표 위치값 쓰기
        public byte[] Write_TargetPosition(int nID, ushort position1, ushort position2 = 0, ushort position3 = 0)
        {
            if (nID == 1) return MakePacket(IST_W_1_TARGET_POSITION, position1, position2, position3);
            else if (nID == 2) return MakePacket(IST_W_2_TARGET_POSITION, position1, position2, position3);
            else if (nID == 3) return MakePacket(IST_W_3_TARGET_POSITION, position1, position2, position3);
            else return MakePacket(0xAD, position1, position2, position3);
        }

        //모터의 현재 위치값 읽기
        public byte[] Read_PresentPosition(int nID)
        {
            if (nID == 1) return MakePacket(IST_R_1_PRESENT_POSITION);
            else if (nID == 2) return MakePacket(IST_R_2_PRESENT_POSITION);
            else if (nID == 3) return MakePacket(IST_R_3_PRESENT_POSITION);
            else return MakePacket(IST_R_ALL_PRESENT_POSITION);
        }

        // 모터의 게인 값들을 읽기 ==> 추후 개별 게인 읽는 것도 추가    
        public byte[] Read_Gain()
        {
            return MakePacket(IST_R_GAIN);
        }

        // 모터의 게인 값들을 쓰기 ==> 추후 개별 게인 쓰는 것도 추가    
        public byte[] Write_Gain(ushort gain1, ushort gain2, ushort gain3)
        {
            return MakePacket(IST_W_GAIN, gain1, gain2, gain3);
        }

        // 모든 모터의 토크 상태 값 읽기 ==> 추후 개별 토크 읽는 것도 추가    
        public byte[] Read_AllDevice_TorqueEnable()
        {
            return MakePacket(IST_R_ALL_TORQUE_ENABLE);
        }

        // 모든 모터의 토크 상태 값 쓰기 ==> 추후 개별 토크 쓰는 것도 추가    
        public byte[] Write_AllDevice_TorqueEnable(ushort enable1, ushort enable2, ushort enable3)
        {
            return MakePacket(IST_W_ALL_TORQUE_ENABLE, enable1, enable2, enable3);
        }

        // 모든 모터의 제어 속력 값 읽기 ==> 추후 개별 속력값 읽는 것도 추가    
        public byte[] Read_AllDevice_MovingSpeed()
        {
            return MakePacket(IST_R_ALL_MOVING_SPEED);
        }

        // 모든 모터의 제어 속력 값 쓰기 ==> 추후 개별 속력값 쓰는 것도 추가    
        public byte[] Write_AllDevice_MovingSpeed(ushort speed1, ushort speed2, ushort speed3)
        {
            return MakePacket(IST_W_ALL_MOVING_SPEED, speed1, speed2, speed3);
        }

        // 실로봇이 연주하기 위해 티칭값에서 수직방향으로 Position Offset값(3번모터 위치) 읽기
        public byte[] Read_OffsetVerticalPosition()
        {
            return MakePacket(IST_R_OFFSET_V_POSITION);
        }

        // 실로봇이 연주하기 위해 티칭값에서 수직방향으로 Position Offset값(3번모터 위치) 쓰기
        public byte[] Write_OffsetVerticalPosition(short position)
        {
            if (position < 0) position = (short)((position * (-1)) | 0x8000);
            return MakePacket(IST_W_OFFSET_V_POSITION, (ushort)position);
        }

        // 실로봇이 연주하기 위해 티칭값에서 수직방향으로 Position Offset값(3번모터 위치) 읽기
        public byte[] Read_OffsetHorizontalPosition()
        {
            return MakePacket(IST_R_OFFSET_H_POSITION);
        }

        // 실로봇이 연주하기 위해 티칭값에서 수직방향으로 Position Offset값(3번모터 위치) 쓰기
        public byte[] Write_OffsetHorizontalPosition(short position)
        {
            if (position < 0) position = (short)((position * (-1)) | 0x8000);
            return MakePacket(IST_W_OFFSET_H_POSITION, (ushort)position);
        }

        //실로봇이 연주하기 위해 수직방향으로 들어 올리는 Offset값 읽기
        public byte[] Read_OffsetVerticalMoving()
        {
            return MakePacket(IST_R_OFFSET_V_MOVING);
        }

        //실로봇이 연주하기 위해 수직방향으로 들어 올리는 Offset값 쓰기
        public byte[] Write_OffsetVerticalMoving(ushort position)
        {
            return MakePacket(IST_W_OFFSET_V_MOVING, position);
        }

        // 실로봇 동작 모드 설정 : 1:준비모드, 2:데모모드, 3:기본모드, 4:VBA모드, 5:엔트리모드, 6:스크레치모드, 7:모바일모드
        public byte[] Write_OperationMode(ushort mode)
        {
            return MakePacket(IST_W_OPERATION_MODE, mode);
        }

        // 실로봇 동작 모드 읽어옴
        public byte[] Read_OperationMode()
        {
            return MakePacket(IST_R_OPERATION_MODE);
        }

        // Xylobot의 LED 밝기를 쓰기
        public byte[] Write_LEDControl(ushort red, ushort green, ushort blue)
        {
            return MakePacket(IST_W_LED_RGB, red, green, blue);
        }

        // Xylobot의 LED 밝기를 읽기
        public byte[] Read_LEDControl()
        {
            return MakePacket(IST_R_LED_RGB);
        }
        #endregion
    }
}
