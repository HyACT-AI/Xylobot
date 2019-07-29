using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace XylophoneRobot
{
    class Music
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


        #region Decleare
        struct MusicScaleData
        {
            public int nScale;      // 음높이 1~8:도,레,미,파,솔,라,시,도, 9: 쉼표
            public int nScaleLen;   // 0~5, 0:8분음표, 1:4분음표, 2:점4분음표, 3:2분음표, 4:점2분음표, 5:온음표
            public float fLocation; // 악보상에서 음표를 표시하기 위한 위치를 결정하기 위한 변수임. (1.0f=4분음표, 0.5f=8분음표의 길이를 의미함.)  
        }

        List<MusicScaleData> ListMusic = new List<MusicScaleData>();
        public string MusicTitle = "";
        public int Tempo;            // = 90;
        #endregion


        #region 생성자
        // ---------------------------------------------------------------------------------------------------------------
        // -- 생성자
        // ---------------------------------------------------------------------------------------------------------------
        public Music()
        {
        }
        #endregion


        #region 음 추가, 음높이 변경, 음길이 변경 및 필드값 관련 Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- 음 추가, 음높이 변경, 음길이 변경 및 필드값 관련 Part
        // ---------------------------------------------------------------------------------------------------------------

        // -- 음을 추가함 -----------------------------------------------------------------------------------
        public void AddScale(int Idx, int Scale, int ScaleLen)
        {
            MusicScaleData CurScale;

            CurScale.nScale = Scale;       // 음높이 지정
            CurScale.nScaleLen = ScaleLen; // 음길이 지정 (1, 2, 3, 4, 6, 8)

            if(ListMusic.Count == 0)
            {
                CurScale.fLocation = 0.0f;
            }
            else
            {
                CurScale.fLocation = ListMusic[Idx - 1].fLocation + ListMusic[Idx - 1].nScaleLen; //음계의 위치는 바로 이전 음의 위치 + 바로 이전 음의 길이
            }

            ListMusic.Insert(Idx, CurScale);

            if (Idx != ListMusic.Count - 1) //마지막에 추가되는 것이 아니면, 추가되는 위치에서 마지막까지 음 위치값 업데이트 해줌
            {
                for (int nNum = Idx; nNum < ListMusic.Count(); nNum++)
                {
                    CurScale = ListMusic[nNum];

                    if (ListMusic.Count == 0)
                    {
                        CurScale.fLocation = 0.0f;
                    }
                    else
                    {
                        CurScale.fLocation = ListMusic[nNum - 1].fLocation + ListMusic[nNum - 1].nScaleLen; //음계의 위치는 바로 이전 음의 위치 + 바로 이전 음의 길이
                    }

                    ListMusic[nNum] = CurScale;
                }
            }
        }


        // -- 음을 삭제함 -----------------------------------------------------------------------------------
        public void RemoveScaleAt(int Idx)
        {
            if (Idx < 0) return;

            ListMusic.RemoveAt(Idx);

            MusicScaleData TmpScale;
            for (int nNum = Idx; nNum < ListMusic.Count(); nNum++)
            {
                TmpScale = ListMusic[nNum];

                if (ListMusic.Count == 0)
                {
                    TmpScale.fLocation = 0.0f;
                }
                else
                {
                    if (nNum == 0)
                    {
                        TmpScale.fLocation = 0.0f;
                    }
                    else
                    {
                        TmpScale.fLocation = ListMusic[nNum - 1].fLocation + ListMusic[nNum - 1].nScaleLen; //음계의 위치는 바로 이전 음의 위치 + 바로 이전 음의 길이
                    }
                }
                ListMusic[nNum] = TmpScale;
            }
        }


        // -- 한음 높임 -------------------------------------------------------------------------------------
        public void SetPitchUp(int Idx)
        {
            MusicScaleData TmpScale;
            TmpScale = ListMusic[Idx];
            if (TmpScale.nScale < 8)
            {
                TmpScale.nScale = TmpScale.nScale + 1;
            }
            ListMusic[Idx] = TmpScale;
        }


        // -- 한음 낮춤 -------------------------------------------------------------------------------------
        public void SetPitchDown(int Idx)
        {
            MusicScaleData TmpScale;
            TmpScale = ListMusic[Idx];
            if ((TmpScale.nScale < 9) && (TmpScale.nScale > 1))
            {
                TmpScale.nScale = TmpScale.nScale - 1;
            }
            ListMusic[Idx] = TmpScale;
        }


        // -- 음길이 증가 -----------------------------------------------------------------------------------
        public void SetLengthUp(int Idx)
        {
            MusicScaleData TmpScale;
            TmpScale = ListMusic[Idx];

            switch (ListMusic[Idx].nScaleLen)
            {
                case 1: TmpScale.nScaleLen = 2; break;
                case 2: TmpScale.nScaleLen = 3; break;
                case 3: TmpScale.nScaleLen = 4; break;
                case 4: TmpScale.nScaleLen = 6; break;
                case 6: TmpScale.nScaleLen = 8; break;
            }
            ListMusic[Idx] = TmpScale;

            for (int nNum = Idx; nNum < ListMusic.Count(); nNum++)
            {
                TmpScale = ListMusic[nNum];

                if (nNum == 0)
                {
                    TmpScale.fLocation = 0.0f;
                }
                else
                {
                    TmpScale.fLocation = ListMusic[nNum - 1].fLocation + ListMusic[nNum - 1].nScaleLen; 
                }
                ListMusic[nNum] = TmpScale;
            }
        }


        // -- 음길이 감소 -----------------------------------------------------------------------------------
        public void SetLengthDown(int Idx)
        {
            MusicScaleData TmpScale;
            TmpScale = ListMusic[Idx];

            switch (ListMusic[Idx].nScaleLen)
            {
                case 2: TmpScale.nScaleLen = 1; break;
                case 3: TmpScale.nScaleLen = 2; break;
                case 4: TmpScale.nScaleLen = 3; break;
                case 6: TmpScale.nScaleLen = 4; break;
                case 8: TmpScale.nScaleLen = 6; break;
            }
            ListMusic[Idx] = TmpScale;

            for (int nNum = Idx; nNum < ListMusic.Count(); nNum++)
            {
                TmpScale = ListMusic[nNum];

                if (nNum == 0)
                {
                    TmpScale.fLocation = 0.0f;
                }
                else
                {
                    TmpScale.fLocation = ListMusic[nNum - 1].fLocation + ListMusic[nNum - 1].nScaleLen;
                }

                ListMusic[nNum] = TmpScale;
            }
        }


        // -- 음계의 길이에 따른 위치 반환 ------------------------------------------------------------------
        public float GetMusicScaleLocation(int Idx)
        {
            if (Idx < 0)
                return 0.0f;
            else
                return ListMusic[Idx].fLocation;
        }


        // -- 음계 값 반환 ----------------------------------------------------------------------------------
        public int GetMusicScale(int Idx)
        {
            if (Idx < 0)
                return 0;
            else
                return ListMusic[Idx].nScale;
        }


        // -- 현재음 다음의 음계 값 반환 --------------------------------------------------------------------
        public int GetNextMusicScale(int Idx)
        {
            int NextScale = 9;

            for (int nNum = Idx + 1; nNum < ListMusic.Count; nNum++)
            {
                if (ListMusic[nNum].nScale < 9)
                {
                    NextScale = ListMusic[nNum].nScale;
                    break;
                }
            }
            return NextScale;
        }


        // -- 음계의 길이 값 반환 -------------------------------------------------------------------------
        public int GetMusicScaleLen(int Idx)
        {
            if (Idx < 0)
                return 0;
            else
                return ListMusic[Idx].nScaleLen;
        }


        // -- 전체 음계 수 반환 -----------------------------------------------------------------------------
        public int GetMusicScaleCount()
        {
            return ListMusic.Count();
        }
        #endregion


        #region 음악 불러오기, 저장 관련 Part
        // ---------------------------------------------------------------------------------------------------------------
        // -- 음악 불러오기, 저장 관련 Part
        // ---------------------------------------------------------------------------------------------------------------

        // -- 저장된 음악 불러오기 --------------------------------------------------------------------------
        public void LoadMusic(string FilePath)
        {
            int nIdx = 0;
            int rtn = 0;
            string tmpString;
            string[] MusicSplit;
            string[] curScale;
            MusicScaleData curMusicScale;
            StringBuilder strValue = new StringBuilder(1024);

            rtn = GetPrivateProfileString("Music", "Title", "", strValue, 1024, FilePath);
            MusicTitle = strValue.ToString();

            rtn = GetPrivateProfileString("Music", "Tempo", "", strValue, 1024, FilePath);
            Tempo = int.Parse(strValue.ToString());

            rtn = GetPrivateProfileString("Music", "Melody", "", strValue, 1024, FilePath);
            tmpString = strValue.ToString();

            ListMusic.Clear();
            MusicSplit = tmpString.Split(',');

            foreach (string curString in MusicSplit)
            {
                curScale = curString.Split('.');
                curMusicScale.nScale = int.Parse(curScale[0].Trim());
                curMusicScale.nScaleLen = int.Parse(curScale[1].Trim());
                if (nIdx == 0)
                {
                    curMusicScale.fLocation = 0;
                }
                else
                {
                    curMusicScale.fLocation = ListMusic[nIdx - 1].fLocation + ListMusic[nIdx - 1].nScaleLen;
                }
                ListMusic.Add(curMusicScale);
                nIdx++;
            }
        }

        // -- 음악을 파일로 저장하기 ------------------------------------------------------------------------
        public void SaveMusic(string FilePath)
        {
            int nNum = 0;
            long rtn = 0;
            string strValue = "";

            strValue = MusicTitle;
            rtn = WritePrivateProfileString("Music", "Title", strValue, FilePath);

            strValue = Tempo.ToString();
            rtn = WritePrivateProfileString("Music", "Tempo", strValue, FilePath);

            strValue = "";
            for (nNum=0; nNum < ListMusic.Count;nNum++)
            {
                strValue = strValue + ListMusic[nNum].nScale + "." + ListMusic[nNum].nScaleLen;
                if(nNum < (ListMusic.Count-1))
                {
                    strValue = strValue + ", ";
                }
            }
            rtn = WritePrivateProfileString("Music", "Melody", strValue, FilePath);
        }
        #endregion
    }
}
