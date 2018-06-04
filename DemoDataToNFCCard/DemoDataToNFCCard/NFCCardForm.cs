using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class NFCCardForm : Form
    {
        public NFCCardForm()
        {
            InitializeComponent();
        }

        #region 全局变量声明
        public int retCode, hContext, hCard, Protocol, ReaderCount, nBytesRet, blockCount, blockNum, ShanQuNum, yuShu;
        public bool connActive = false;
        public byte[] SendBuff = new byte[263];//最多可以放752个
        public byte[] RecvBuff = new byte[263];
        public byte[] SendBuffAll = new byte[263];//全部
        public byte[] RecvBuffAll = new byte[263];
        public byte[] bytes = new byte[263];
        public int SendLen, RecvLen, ReaderLen, ATRLen, dwState, dwActProtocol;
        public int reqType, Aprotocol, dwProtocol, cbPciLength;
        public ModWinsCard.SCARD_IO_REQUEST pioSendRequest;
        string readStr = "";
        public static string writeStr = "";
        bool isReadAll = false;
        #endregion

        #region 窗体事件
        private void Form1_Load(object sender, EventArgs e)
        {
            InitMenu();
        }

        /// <summary>
        /// 读卡器初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bInit_Click(object sender, EventArgs e)
        {
            string ReaderList = "" + Convert.ToChar(0);
            int indx;
            int pcchReaders = 0;
            string rName = "";

            //Establish Context
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                displayOut(1, retCode, "");
                return;
            }

            // 2. List PC/SC card readers installed in the system

            retCode = ModWinsCard.SCardListReaders(this.hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                displayOut(1, retCode, "");
                return;
            }
            EnableButtons();
            byte[] ReadersList = new byte[pcchReaders];
            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(this.hContext, null, ReadersList, ref pcchReaders);
            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                mMsg.AppendText("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode));
                return;
            }
            else
            {
                displayOut(0, 0, " ");
            }

            rName = "";
            indx = 0;

            //Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {
                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }
                //Add reader name to list
                cbReader.Items.Add(rName);
                rName = "";
                indx = indx + 1;
            }

            if (cbReader.Items.Count > 0)
            {
                cbReader.SelectedIndex = 0;
            }
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            retCode = ModWinsCard.SCardConnect(hContext, cbReader.SelectedItem.ToString(), ModWinsCard.SCARD_SHARE_SHARED,
                                           ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                retCode = ModWinsCard.SCardConnect(hContext, cbReader.SelectedItem.ToString(), ModWinsCard.SCARD_SHARE_DIRECT,
                                            0, ref hCard, ref Protocol);
                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                    displayOut(1, retCode, "");
                else
                {
                    displayOut(0, 0, "成功连接到" + cbReader.Text);//Successful connection to
                }
            }
            else
            {
                displayOut(0, 0, "成功连接到" + cbReader.Text);
            }
            GetUID();
            connActive = true;
            gbLoadKeys.Enabled = true;
            gbAuth.Enabled = true;
            gbBinOps.Enabled = true;
            groupBox1.Enabled = true;
            tKeyNum.Focus();
            rbKType1.Checked = true;
            btnClear.Enabled = true;
            btnRead.Enabled = true;
            btnWrite.Enabled = true;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            mMsg.Clear();
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            if (connActive)
            {
                retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
            }

            retCode = ModWinsCard.SCardReleaseContext(hCard);
            InitMenu();
        }

        private void bQuit_Click(object sender, EventArgs e)
        {
            // terminate the application
            retCode = ModWinsCard.SCardReleaseContext(hContext);
            retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
            System.Environment.Exit(0);
        }

        private void bLoadKey_Click(object sender, EventArgs e)
        {
            byte tmpLong;
            string tmpStr;

            if (tKey1.Text == "" | !byte.TryParse(tKey1.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tKey1.Focus();
                tKey1.Text = "";
                return;
            }

            if (tKey2.Text == "" | !byte.TryParse(tKey2.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tKey2.Focus();
                tKey2.Text = "";
                return;
            }

            if (tKey3.Text == "" | !byte.TryParse(tKey3.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tKey3.Focus();
                tKey3.Text = "";
                return;
            }

            if (tKey4.Text == "" | !byte.TryParse(tKey4.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tKey4.Focus();
                tKey4.Text = "";
                return;
            }

            if (tKey5.Text == "" | !byte.TryParse(tKey5.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tKey5.Focus();
                tKey5.Text = "";
                return;
            }

            if (tKey6.Text == "" | !byte.TryParse(tKey6.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tKey6.Focus();
                tKey6.Text = "";
                return;
            }

            ClearBuffers();
            // Load Authentication Keys command
            SendBuff[0] = 0xFF;                                                                        // Class
            SendBuff[1] = 0x82;                                                                        // INS
            SendBuff[2] = 0x00;                                                                        // P1 : Key Structure
            SendBuff[3] = byte.Parse(tKeyNum.Text, System.Globalization.NumberStyles.HexNumber);
            SendBuff[4] = 0x06;                                                                        // P3 : Lc
            SendBuff[5] = byte.Parse(tKey1.Text, System.Globalization.NumberStyles.HexNumber);        // Key 1 value
            SendBuff[6] = byte.Parse(tKey2.Text, System.Globalization.NumberStyles.HexNumber);        // Key 2 value
            SendBuff[7] = byte.Parse(tKey3.Text, System.Globalization.NumberStyles.HexNumber);        // Key 3 value
            SendBuff[8] = byte.Parse(tKey4.Text, System.Globalization.NumberStyles.HexNumber);        // Key 4 value
            SendBuff[9] = byte.Parse(tKey5.Text, System.Globalization.NumberStyles.HexNumber);        // Key 5 value
            SendBuff[10] = byte.Parse(tKey6.Text, System.Globalization.NumberStyles.HexNumber);       // Key 6 value

            SendLen = 11;
            RecvLen = 2;

            retCode = SendAPDU(1, false, 0);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (int indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }
            }
            if (tmpStr.Trim() != "90 00")
            {
                displayOut(4, 0, "载入密钥失败!");//Load authentication keys error
            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            int tempInt, indx;
            byte tmpLong;
            string tmpStr;

            // Validate input
            if (tBlkNo.Text == "" | !int.TryParse(tBlkNo.Text, out tempInt))
            {
                tBlkNo.Focus();
                tBlkNo.Text = "";
                return;
            }

            if (int.Parse(tBlkNo.Text) > 319)
            {
                tBlkNo.Text = "319";
            }

            if (tAuthenKeyNum.Text == "" | !byte.TryParse(tAuthenKeyNum.Text, System.Globalization.NumberStyles.HexNumber, null, out tmpLong))
            {
                tAuthenKeyNum.Focus();
                tAuthenKeyNum.Text = "";
                return;
            }
            else if (int.Parse(tAuthenKeyNum.Text) > 1)
            {
                tAuthenKeyNum.Text = "1";
                return;
            }

            ClearBuffers();

            SendBuff[0] = 0xFF;                             // Class
            SendBuff[1] = 0x86;                             // INS
            SendBuff[2] = 0x00;                             // P1
            SendBuff[3] = 0x00;                             // P2
            SendBuff[4] = 0x05;                             // Lc
            SendBuff[5] = 0x01;                             // Byte 1 : Version number
            SendBuff[6] = 0x00;                             // Byte 2
            SendBuff[7] = (byte)int.Parse(tBlkNo.Text);     // Byte 3 : Block number

            if (rbKType1.Checked == true)
            {
                SendBuff[8] = 0x60;
            }
            else if (rbKType2.Checked == true)
            {
                SendBuff[8] = 0x61;
            }

            SendBuff[9] = byte.Parse(tAuthenKeyNum.Text, System.Globalization.NumberStyles.HexNumber);        // Key 5 value

            SendLen = 10;
            RecvLen = 2;

            retCode = SendAPDU(1, false, 0);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }
            }
            if (tmpStr.Trim() == "90 00")
            {
                displayOut(0, 0, "验证成功!");//Authentication success
            }
            else
            {
                displayOut(4, 0, "验证失败!");//Authentication failed
            }
        }

        private void bBinRead_Click(object sender, EventArgs e)
        {
            string tmpStr;
            int indx;

            // Validate Inputs
            tBinData.Text = "";

            if (tBinBlk.Text == "")
            {
                tBinBlk.Focus();
                return;
            }

            if (int.Parse(tBinBlk.Text) > 319)
            {
                tBinBlk.Text = "319";
                return;
            }

            if (tBinLen.Text == "")
            {
                tBinLen.Focus();
                return;
            }

            ClearBuffers();
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xB0;
            SendBuff[2] = 0x00;
            SendBuff[3] = (byte)int.Parse(tBinBlk.Text);
            SendBuff[4] = (byte)int.Parse(tBinLen.Text);

            SendLen = 5;
            RecvLen = SendBuff[4] + 2;

            retCode = SendAPDU(1, false, 0);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }
            }
            if (tmpStr.Trim() == "90 00")
            {
                tmpStr = "";
                tmpStr = System.Text.Encoding.Default.GetString(RecvBuff);
                byte[] c = new byte[263];
                if (tmpStr.Contains('?'))
                {
                    if (IsBase64String(tmpStr.Split('?')[0]))
                    {
                        c = Convert.FromBase64String(tmpStr.Split('?')[0]);
                        tmpStr = System.Text.Encoding.Default.GetString(c);
                    }
                }
                else
                {
                    if (IsBase64String(tmpStr))
                    {
                        c = Convert.FromBase64String(tmpStr);
                        tmpStr = System.Text.Encoding.Default.GetString(c);
                    }
                }
                tBinData.Text = tmpStr;
                displayOut(3, 0, tmpStr);
            }
            else
            {
                displayOut(4, 0, "读取块失败!");//Read block error
            }
        }

        private void bBinUpd_Click(object sender, EventArgs e)
        {
            string tmpStr;
            int indx, tempInt;

            if (tBinBlk.Text == "" | !int.TryParse(tBinBlk.Text, out tempInt))
            {
                tBinBlk.Focus();
                tBinBlk.Text = "";
                return;
            }

            if (int.Parse(tBinBlk.Text) > 319)
            {
                tBinBlk.Text = "319";
                return;
            }

            if (tBinLen.Text == "" | !int.TryParse(tBinLen.Text, out tempInt))
            {
                tBinLen.Focus();
                tBinLen.Text = "";
                return;
            }

            if (tBinData.Text == "")
            {
                tBinData.Focus();
                return;
            }

            tmpStr = tBinData.Text;
            byte[] b = System.Text.Encoding.Default.GetBytes(tmpStr);
            //转成 Base64 形式的 System.String  
            tmpStr = Convert.ToBase64String(b);
            //将base64转成字符数组然后写入卡中
            bytes = System.Text.Encoding.Default.GetBytes(tmpStr);
            if (bytes.Length > 16)
            {
                MessageBox.Show("写入的数据长度超过16，请重新输入");
                return;
            }
            ClearBuffers();
            SendBuff[0] = 0xFF;                                     // CLA
            SendBuff[1] = 0xD6;                                     // INS
            SendBuff[2] = 0x00;                                     // P1
            SendBuff[3] = (byte)int.Parse(tBinBlk.Text);            // P2 : Starting Block No.
            SendBuff[4] = (byte)bytes.Length;  //(byte)int.Parse(tBinLen.Text);            // P3 : Data length

            for (indx = 0; indx <= bytes.Length - 1; indx++)
            {
                SendBuff[indx + 5] = bytes[indx];
            }
            SendLen = SendBuff[4] + 5;// 
            RecvLen = 0x02;

            retCode = SendAPDU(2, false, 0);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }
            }
            if (tmpStr.Trim() == "90 00")
            {
                tBinData.Text = "";
            }
            else
            {
                displayOut(2, 0, tmpStr.Trim());//""
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string readData = readStr;
            AuthAllBootSector(1);
            if (readStr == null)
                return;

            if (IsBase64String(readStr.Split('?')[0]))
            {
                byte[] c = Convert.FromBase64String(readStr);
                readData = System.Text.Encoding.Default.GetString(c);
                if (readData.Contains("结"))
                    readData = readData.Substring(0, readData.IndexOf("结"));
            }
            readStr = null;
            displayOut(3, 0, readData);

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            AuthAllBootSector(2);
            blockCount = 0;
        }

        /// <summary>
        /// 当文本框里的值发生改变时，动态显示出写入数据的长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBinData_TextChanged(object sender, EventArgs e)
        {
            string tmpStr = tBinData.Text;
            byte[] b = System.Text.Encoding.Default.GetBytes(tmpStr);
            //转成 Base64 形式的 System.String  
            tmpStr = Convert.ToBase64String(b);
            //将base64转成字节数组然后写入卡中
            bytes = System.Text.Encoding.Default.GetBytes(tmpStr);
            lblWriteLength.Text = bytes.Length.ToString();
        }

        /// <summary>
        /// 在写入新的内容时，先将卡里的原数据清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            int result;
            for (int index = 0; index <= 63; index += 4)//验证
            {
                ClearBuffers();
                SendBuff[0] = 0xFF;                             // Class
                SendBuff[1] = 0x86;                             // INS
                SendBuff[2] = 0x00;                             // P1
                SendBuff[3] = 0x00;                             // P2
                SendBuff[4] = 0x05;                             // Lc
                SendBuff[5] = 0x01;                             // Byte 1 : Version number
                SendBuff[6] = 0x00;                             // Byte 2
                SendBuff[7] = (byte)index;//区块                  // Byte 3 : Block number

                result = PartAuthBlock(0, index);
                if (result == 0)
                    break;
            }
        }
        #endregion

        #region 自定义方法
        private void InitMenu()
        {
            connActive = false;
            cbReader.Text = "";
            cbReader.Items.Clear();
            mMsg.Text = "";
            tKeyNum.SelectedIndex = 0;
            tAuthenKeyNum.SelectedIndex = 0;
            bInit.Enabled = true;
            bConnect.Enabled = false;
            bClear.Enabled = false;
            displayOut(0, 0, "程序准备就绪");//Program ready
            bReset.Enabled = false;
            gbLoadKeys.Enabled = false;
            gbAuth.Enabled = false;
            gbBinOps.Enabled = false;
            groupBox1.Enabled = false;
            btnClear.Enabled = false;
            btnRead.Enabled = false;
            btnWrite.Enabled = false;
        }

        private void displayOut(int errType, int retVal, string PrintText)
        {
            switch (errType)
            {
                case 0:
                    mMsg.SelectionColor = Color.Green;
                    break;
                case 1:
                    mMsg.SelectionColor = Color.Red;
                    PrintText = ModWinsCard.GetScardErrMsg(retVal);
                    break;
                case 2:
                    mMsg.SelectionColor = Color.Black;
                    PrintText = "<" + PrintText;
                    break;
                case 3:
                    mMsg.SelectionColor = Color.Black;
                    PrintText = ">" + PrintText;
                    break;
                case 4:
                    break;
            }
            mMsg.AppendText(PrintText);
            mMsg.AppendText("\n");
            mMsg.SelectionColor = Color.Black;
            mMsg.Focus();
        }

        private void EnableButtons()
        {
            bInit.Enabled = false;
            bConnect.Enabled = true;
            bClear.Enabled = true;
            bReset.Enabled = true;
        }

        private void ClearBuffers()
        {
            long indx;

            for (indx = 0; indx <= 262; indx++)
            {
                RecvBuff[indx] = 0;
                SendBuff[indx] = 0;
                RecvBuffAll[indx] = 0;
                SendBuffAll[indx] = 0;
            }
        }

        //private static byte[] StringToByteSequence(string sourceString)
        //{
        //    int i = 0, n = 0;
        //    int j = (sourceString.Length) / 2;

        //    byte[] a = new byte[j];
        //    for (i = 0, n = 0; n < j; i += 2, n++)
        //    {
        //        a[n] = Convert.ToByte(sourceString.Substring(i, 2), 16);
        //    }
        //    return a;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handleFlag">是否是更新操作</param>
        /// <param name="isReadOrWriteAll">是不是全部读取或写入</param>
        /// <returns></returns>
        public int SendAPDU(int handleFlag, bool isReadOrWriteAll, int dataLength)
        {
            int indx;
            string tmpStr;

            pioSendRequest.dwProtocol = Aprotocol;
            pioSendRequest.cbPciLength = 8;

            // Display Apdu In
            tmpStr = "";
            if (handleFlag == 2)//更新
            {
                if (isReadOrWriteAll)
                {
                    for (indx = 0; indx <= 4; indx++)
                    {
                        tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuffAll[indx]);//更新的APDU命令
                    }
                    for (int i = 0; i <= SendLen - 6; i++)
                    {
                        SendBuffAll[i + 5] = bytes[i + dataLength];
                    }
                    SendLen = 21;
                }
                else
                {
                    for (indx = 0; indx <= 4; indx++)
                    {
                        tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);//更新的APDU命令
                    }
                    for (int i = 0; i <= SendLen - 6; i++)
                    {
                        SendBuff[i + 5] = bytes[i];
                    }
                }
            }
            else if (handleFlag == 1)//读取
            {
                if (isReadOrWriteAll)//全部
                {
                    for (indx = 0; indx <= SendLen - 1; indx++)
                    {
                        tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuffAll[indx]);
                    }
                }
                else
                {
                    for (indx = 0; indx <= SendLen - 1; indx++)
                    {
                        tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuff[indx]);
                    }
                }
            }
            else if (handleFlag == 0)//清空
            {
                for (indx = 0; indx <= 4; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", SendBuffAll[indx]);//更新的APDU命令
                }
                for (int i = 0; i <= SendLen - 6; i++)
                {
                    SendBuffAll[i + 5] = 0x00;
                }
            }
            
            displayOut(2, 0, tmpStr);
            if (!isReadOrWriteAll)
                retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, ref SendBuff[0], SendLen, ref pioSendRequest, ref RecvBuff[0], ref RecvLen);
            else
                retCode = ModWinsCard.SCardTransmit(hCard, ref pioSendRequest, ref SendBuffAll[0], SendLen, ref pioSendRequest, ref RecvBuffAll[0], ref RecvLen);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                displayOut(1, retCode, "");
                return retCode;
            }

            tmpStr = "";
            if (isReadOrWriteAll)
            {
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuffAll[indx]);
                }
            }
            else
            {
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }
            }
            displayOut(3, 0, tmpStr);
            return retCode;
        }

        #region GetUID()
        /// <summary>
        /// 获取UID
        /// </summary>
        private void GetUID()
        {
            // Get the firmaware version of the reader
            string tmpStr;
            int intIndx;
            ClearBuffers();

            #region GetFirmware APDU
            //SendBuff[0] = 0xFF;
            //SendBuff[1] = 0x00;
            //SendBuff[2] = 0x48;
            //SendBuff[3] = 0x00;
            //SendBuff[4] = 0x00;
            //SendLen = 5;
            //RecvLen = 10; 
            #endregion

            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xCA;
            SendBuff[2] = 0x00;
            SendBuff[3] = 0x00;
            SendBuff[4] = 0x00;
            SendLen = 5;
            RecvLen = 10;
            retCode = SendAPDU(1, false, 0);
            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                return;

            // Interpret firmware data
            //tmpStr = "Firmware Version（版本）: ";
            tmpStr = "UID: ";
            for (intIndx = 0; intIndx <= RecvLen - 3; intIndx++)
            {
                tmpStr = tmpStr + string.Format("{0:X2}", RecvBuff[intIndx]);
            }
            displayOut(3, 0, tmpStr);
        }
        #endregion

        /// <summary>
        /// 验证所有区块
        /// </summary>
        /// <param name="handleFlag">处理操作的标志handleFlag 0清空,1读取,2写入</param>
        private void AuthAllBootSector(int handleFlag)
        {
            int result;

            if (handleFlag == 2)
            {
                string data = "我是要往卡里写入的数据，耶耶耶~";//获取要写入的字符串
                byte[] b = System.Text.Encoding.Default.GetBytes(data);
                //转成 Base64 形式的 System.String  
                data = Convert.ToBase64String(b);
                bytes = System.Text.Encoding.Default.GetBytes(data);
                if (bytes.Length % 16 != 0)
                {
                    b = null;
                    string endSign = "结结结结结结结";
                    //for (int i = 0; i < (bytes.Length % 16); i++)
                    //{
                        //endSign = "结结结结结结结"; //写入的数据不够填充满16位，最后的base64容易混乱，所以加个汉字，填满16位
                    //}
                    string str = writeStr + endSign;
                    b = System.Text.Encoding.Default.GetBytes(str);
                    data = "";
                    data = Convert.ToBase64String(b);
                }

                //将base64转成16进制然后写入卡中
                bytes = System.Text.Encoding.Default.GetBytes(data);
                //写入的数据需要的区块数量
                blockNum = (bytes.Length % 16 == 0 ? (bytes.Length / 16) : (bytes.Length / 16 + 1));
                //需要验证的扇区的数量,把有两个数据块的0扇区加上
                ShanQuNum = (blockNum - 2) % 3 == 0 ? (blockNum - 2) / 3 + 1 : (blockNum - 2) / 3 + 2;
                //获取最后一个扇区的写入的块的数量，yushu==0，则正好写满当前验证块（3块数据块）；
                //yushu==1，则写入当前验证块；yushu==2，则写入当前验证块+1
                yuShu = (blockNum - 2) % 3;
                for (int i = 0; i < 4 * ShanQuNum; i += 4) //验证 块  
                {
                    ClearBuffers();
                    SendBuff[0] = 0xFF;                             // Class
                    SendBuff[1] = 0x86;                             // INS
                    SendBuff[2] = 0x00;                             // P1
                    SendBuff[3] = 0x00;                             // P2
                    SendBuff[4] = 0x05;                             // Lc
                    SendBuff[5] = 0x01;                             // Byte 1 : Version number
                    SendBuff[6] = 0x00;                             // Byte 2
                    SendBuff[7] = (byte)i;                   // Byte 3 : Block number

                    result = PartAuthBlock(handleFlag, i);
                    if (result == 0)
                        break;
                }
            }
            else if (handleFlag == 1)
            {
                for (int index = 0; index <= 63; index += 4)//验证
                {
                    ClearBuffers();
                    SendBuff[0] = 0xFF;                             // Class
                    SendBuff[1] = 0x86;                             // INS
                    SendBuff[2] = 0x00;                             // P1
                    SendBuff[3] = 0x00;                             // P2
                    SendBuff[4] = 0x05;                             // Lc
                    SendBuff[5] = 0x01;                             // Byte 1 : Version number
                    SendBuff[6] = 0x00;                             // Byte 2
                    SendBuff[7] = (byte)index;//块                  // Byte 3 : Block number

                    result = PartAuthBlock(handleFlag, index);
                    if (result == 0)
                        break;
                }
            }
        }

        /// <summary>
        /// 在读取或写入操作前需要验证区块
        /// </summary>
        /// <param name="handleFlag">是否为写入、更新操作</param>
        /// <param name="index">验证的区块号</param>
        /// <returns></returns>
        private int PartAuthBlock(int handleFlag, int index)
        {
            int indx;
            string tmpStr;
            if (rbKType1.Checked == true)
            {
                SendBuff[8] = 0x60;//keyA
            }
            else if (rbKType2.Checked == true)
            {
                SendBuff[8] = 0x61;//keyB
            }

            SendBuff[9] = byte.Parse(tAuthenKeyNum.Text, System.Globalization.NumberStyles.HexNumber);        // Key 5 value

            SendLen = 10;
            RecvLen = 2;

            retCode = SendAPDU(1, false, 0);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return 2;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuff[indx]);
                }
            }
            if (tmpStr.Trim() == "90 00")
            {
                displayOut(0, 0, "验证成功!");//Authentication success
                if (handleFlag == 0)//清空
                {
                    if (index == 0)
                    {
                        index += 1;//从块1开始写入
                        for (int i = index; i <= 2; i++)
                        {
                            AllBlockClear(i);
                        }
                    }
                    else
                    {
                        for (int i = index; i <= index + 2; i++)
                        {
                            AllBlockClear(i);
                        }
                    }
                }
                else if (handleFlag == 1)//读取
                {
                    ReadAllBlock(index);
                }
                else if (handleFlag == 2)//写入
                {
                    bool isLastBlock = false;
                    if (index == 0)
                    {
                        index += 1;//从块1开始写入
                        if ((index + 1) < blockNum)
                        {
                            for (int i = index; i <= index + 1; i++)
                            {
                                AllBlockWrite(i, false);//这里写每个块的写入循环
                            }
                        }
                        else
                        {
                            for (int i = index; i <= blockNum; i++)
                            {
                                if (i == blockNum)
                                    isLastBlock = true;
                                AllBlockWrite(i, isLastBlock);//这里写每个块的写入循环
                            }
                        }
                    }
                    else
                    {
                        int temp = yuShu == 0 ? (ShanQuNum-1) * 4 : (ShanQuNum - 2) * 4;
                        if (index < (ShanQuNum - 1) * 4)
                        {
                            for (int i = index; i < index + 3; i++)
                            {
                                AllBlockWrite(i, false);//这里写每个块的写入循环
                            }
                        }
                        else
                        {
                            if (yuShu == 0 && index == (ShanQuNum - 1) * 4)
                            {
                                for (int i = index; i < index + 3; i++)
                                {
                                    if (i == index + 2)
                                        isLastBlock = true;
                                    AllBlockWrite(i, isLastBlock);//这里写每个块的写入循环
                                }
                            }
                            else
                            {
                                for (int i = index; i <= index + yuShu - 1; i++)
                                {
                                    if (i == index + yuShu - 1)
                                        isLastBlock = true;
                                    AllBlockWrite(i, isLastBlock);//这里写每个块的写入循环
                                }
                            }
                        }
                    }
                }
                return 1;
            }
            else
            {
                displayOut(4, 0, "验证失败!");//Authentication failed
                return 0;
            }
        }

        private void ReadAllBlock(int index)
        {
            string tmpStr;
            int indx;
            isReadAll = true;
            for (int i = index; i < index + 4; i++)
            {
                ClearBuffers();
                SendBuffAll[0] = 0xFF;
                SendBuffAll[1] = 0xB0;
                SendBuffAll[2] = 0x00;
                SendBuffAll[3] = (byte)i;//块
                SendBuffAll[4] = (byte)16;

                SendLen = 5;
                RecvLen = SendBuffAll[4] + 2;

                retCode = SendAPDU(1, true, 0);

                if (retCode != ModWinsCard.SCARD_S_SUCCESS)
                {
                    return;
                }
                else
                {
                    tmpStr = "";
                    for (indx = RecvLen - 2; indx <= RecvLen - 1; indx++)
                    {
                        tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuffAll[indx]);
                    }
                }
                if (tmpStr.Trim() == "90 00")
                {
                    tmpStr = "";
                    tmpStr = System.Text.Encoding.Default.GetString(RecvBuffAll);
                    byte[] c = new byte[263];
                    if (isReadAll)
                    {
                        if (tmpStr.Contains('?'))
                        {
                            if (IsBase64String(tmpStr.Split('?')[0]))
                            {
                                c = Convert.FromBase64String(tmpStr.Split('?')[0]);
                                readStr = readStr + tmpStr.Split('?')[0];
                            }
                        }
                        //if (tmpStr.Contains('='))
                        //{
                        //    string endStr = tmpStr.Split('=')[0] + "=";
                        //    if (IsBase64String(endStr))
                        //    {
                        //        c = Convert.FromBase64String(endStr);
                        //        readStr = readStr + endStr;
                        //    }
                        //    isReadAll = false;
                        //}
                        else
                        {
                            if (IsBase64String(tmpStr))
                            {
                                c = Convert.FromBase64String(tmpStr);
                                readStr = readStr + tmpStr.Split('?')[0];
                                //tmpStr = System.Text.Encoding.Default.GetString(c);
                            }
                        }
                    }
                    displayOut(3, 0, tmpStr);
                }
                else
                {
                    displayOut(4, 0, "读取块失败!");//Read block error
                }
            }
        }

        /// <summary>
        /// 验证读取出来的数据是否是Base64格式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsBase64String(string s)
        {
            try { Convert.FromBase64String(s); }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// 写入\更新所有区块
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isLastBlock"></param>
        private void AllBlockWrite(int index, bool isLastBlock)
        {
            string tmpStr;
            int indx, dataLength,leftBytes;
            blockCount++;

            int blolen = bytes.Length % 16 == 0 ? (bytes.Length / 16) : bytes.Length / 16 + 1;
            leftBytes = bytes.Length % 16 == 0 ? 16 : bytes.Length % 16;
            //int blockNum = (blolen - 2) % 3 == 0 ? (blolen - 2) / 3 : (blolen - 2) / 3 + 1;
            ClearBuffers();
            SendBuffAll[0] = 0xFF;                                     // CLA
            SendBuffAll[1] = 0xD6;                                     // INS
            SendBuffAll[2] = 0x00;                                     // P1
            SendBuffAll[3] = (byte)index;                                  // P2 : Starting Block No.
            if (isLastBlock)//最后一段要写入的数据
            {
                SendBuffAll[4] = (byte)16; //(bytes.Length % 16)              // P3 : Data length
                dataLength = bytes.Length - leftBytes; //(blockCount - 1) * 16;
                blockCount = 0;
            }
            else
            {
                SendBuffAll[4] = (byte)16;                                 // P3 : Data length
                //if (blockCount > blolen)
                //    blockCount = 0;
                dataLength = index == 1 ? 0 : (blockCount - 1) * 16;
            }
            if (isLastBlock)
                SendLen = leftBytes + 5;
            else
                SendLen = SendBuffAll[4] + 5;// 
            RecvLen = 0x02;

            retCode = SendAPDU(2, true, dataLength);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuffAll[indx]);
                }
            }
            if (tmpStr.Trim() == "90 00")
            {
                displayOut(3, 0, "写入成功");
            }
            else
            {
                displayOut(2, 0, "");
            }
        }

        private void AllBlockClear(int index)
        {
            string tmpStr;
            int indx;
            ClearBuffers();
            SendBuffAll[0] = 0xFF;                                     // CLA
            SendBuffAll[1] = 0xD6;                                     // INS
            SendBuffAll[2] = 0x00;                                     // P1
            SendBuffAll[3] = (byte)index;                                  // P2 : Starting Block No.
            SendBuffAll[4] = (byte)16;                                 // P3 : Data length
            SendLen = SendBuffAll[4] + 5;
            RecvLen = 0x02;

            retCode = SendAPDU(0, true, 0);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }
            else
            {
                tmpStr = "";
                for (indx = 0; indx <= RecvLen - 1; indx++)
                {
                    tmpStr = tmpStr + " " + string.Format("{0:X2}", RecvBuffAll[indx]);
                }
            }
            if (tmpStr.Trim() == "90 00")
            {
                displayOut(3, 0, "写入成功");
            }
            else
            {
                displayOut(2, 0, "写卡失败");
            }
        }

        /// <summary>
        ///  汉字转换到16进制
        /// </summary>
        /// <param name="s"></param>
        /// <param name="charset">编码,如"gb2312","gb2312"</param>
        /// <param name="fenge">是否每字符用空格分隔</param>
        /// <returns></returns>
        //public string ToHex(string s, string charset, bool fenge)
        //{
        //    if ((s.Length % 2) != 0)
        //    {
        //        s += " ";//空格
        //    }
        //    System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
        //    byte[] bytes = chs.GetBytes(s);
        //    string str = "";
        //    for (int i = 0; i < bytes.Length; i++)
        //    {
        //        str += string.Format("{0:X}", bytes[i]);
        //        if (fenge && (i != bytes.Length - 1))
        //        {
        //            str += string.Format("{0}", " ");
        //        }
        //    }
        //    return str.ToUpper();
        //}

        public byte[] ToHex(string s, string charset, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s += " ";//空格
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes = chs.GetBytes(s);
            //string str = "";
            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    str += string.Format("{0:X}", bytes[i]);
            //    if (fenge && (i != bytes.Length - 1))
            //    {
            //        str += string.Format("{0}", " ");
            //    }
            //}
            return bytes;
        }

        /// <summary>
        /// 16进制转换成汉字
        /// </summary>
        /// <param name="hex"></param>
        /// <param name="charset">编码,如"gb2312","gb2312"</param>
        /// <returns></returns>
        public string UnHex(string hex, string charset)
        {
            if (hex == null)
                throw new ArgumentNullException("hex");
            hex = hex.Replace(",", "");
            hex = hex.Replace("/n", "");
            hex = hex.Replace("//", "");
            hex = hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex += "20";//空格
            }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }
        #endregion
    }
}
