namespace WindowsFormsApplication1
{
    partial class NFCCardForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bInit = new System.Windows.Forms.Button();
            this.bConnect = new System.Windows.Forms.Button();
            this.cbReader = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.mMsg = new System.Windows.Forms.RichTextBox();
            this.gbLoadKeys = new System.Windows.Forms.GroupBox();
            this.tKeyNum = new System.Windows.Forms.ComboBox();
            this.bLoadKey = new System.Windows.Forms.Button();
            this.tKey6 = new System.Windows.Forms.TextBox();
            this.tKey5 = new System.Windows.Forms.TextBox();
            this.tKey4 = new System.Windows.Forms.TextBox();
            this.tKey3 = new System.Windows.Forms.TextBox();
            this.tKey1 = new System.Windows.Forms.TextBox();
            this.tKey2 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.gbAuth = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bAuth = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.gbKType = new System.Windows.Forms.GroupBox();
            this.gbBinOps = new System.Windows.Forms.GroupBox();
            this.lblWriteLength = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bBinUpd = new System.Windows.Forms.Button();
            this.bBinRead = new System.Windows.Forms.Button();
            this.tBinData = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.tBinLen = new System.Windows.Forms.TextBox();
            this.tBinBlk = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tAuthenKeyNum = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAutn = new System.Windows.Forms.Button();
            this.tBlkNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbKType2 = new System.Windows.Forms.RadioButton();
            this.rbKType1 = new System.Windows.Forms.RadioButton();
            this.bReset = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bQuit = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbLoadKeys.SuspendLayout();
            this.gbAuth.SuspendLayout();
            this.gbBinOps.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bInit
            // 
            this.bInit.Location = new System.Drawing.Point(93, 31);
            this.bInit.Name = "bInit";
            this.bInit.Size = new System.Drawing.Size(178, 25);
            this.bInit.TabIndex = 0;
            this.bInit.Text = "初始化";
            this.bInit.UseVisualStyleBackColor = true;
            this.bInit.Click += new System.EventHandler(this.bInit_Click);
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(93, 62);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(178, 25);
            this.bConnect.TabIndex = 28;
            this.bConnect.Text = "连接读卡器";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // cbReader
            // 
            this.cbReader.FormattingEnabled = true;
            this.cbReader.Location = new System.Drawing.Point(93, 6);
            this.cbReader.Name = "cbReader";
            this.cbReader.Size = new System.Drawing.Size(178, 20);
            this.cbReader.TabIndex = 26;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(4, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 12);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "选择读卡器类型";
            // 
            // mMsg
            // 
            this.mMsg.Location = new System.Drawing.Point(319, 6);
            this.mMsg.Name = "mMsg";
            this.mMsg.Size = new System.Drawing.Size(357, 481);
            this.mMsg.TabIndex = 29;
            this.mMsg.Text = "";
            // 
            // gbLoadKeys
            // 
            this.gbLoadKeys.Controls.Add(this.tKeyNum);
            this.gbLoadKeys.Controls.Add(this.bLoadKey);
            this.gbLoadKeys.Controls.Add(this.tKey6);
            this.gbLoadKeys.Controls.Add(this.tKey5);
            this.gbLoadKeys.Controls.Add(this.tKey4);
            this.gbLoadKeys.Controls.Add(this.tKey3);
            this.gbLoadKeys.Controls.Add(this.tKey1);
            this.gbLoadKeys.Controls.Add(this.tKey2);
            this.gbLoadKeys.Controls.Add(this.Label3);
            this.gbLoadKeys.Controls.Add(this.Label2);
            this.gbLoadKeys.Location = new System.Drawing.Point(6, 93);
            this.gbLoadKeys.Name = "gbLoadKeys";
            this.gbLoadKeys.Size = new System.Drawing.Size(296, 111);
            this.gbLoadKeys.TabIndex = 46;
            this.gbLoadKeys.TabStop = false;
            this.gbLoadKeys.Text = "加载密码到读卡器，不是每次都要做";
            // 
            // tKeyNum
            // 
            this.tKeyNum.FormattingEnabled = true;
            this.tKeyNum.Items.AddRange(new object[] {
            "0",
            "1"});
            this.tKeyNum.Location = new System.Drawing.Point(108, 20);
            this.tKeyNum.Name = "tKeyNum";
            this.tKeyNum.Size = new System.Drawing.Size(36, 20);
            this.tKeyNum.TabIndex = 12;
            // 
            // bLoadKey
            // 
            this.bLoadKey.Location = new System.Drawing.Point(169, 80);
            this.bLoadKey.Name = "bLoadKey";
            this.bLoadKey.Size = new System.Drawing.Size(118, 21);
            this.bLoadKey.TabIndex = 11;
            this.bLoadKey.Text = "加载到读卡器";
            this.bLoadKey.UseVisualStyleBackColor = true;
            this.bLoadKey.Click += new System.EventHandler(this.bLoadKey_Click);
            // 
            // tKey6
            // 
            this.tKey6.Location = new System.Drawing.Point(262, 53);
            this.tKey6.MaxLength = 2;
            this.tKey6.Name = "tKey6";
            this.tKey6.Size = new System.Drawing.Size(25, 21);
            this.tKey6.TabIndex = 10;
            // 
            // tKey5
            // 
            this.tKey5.Location = new System.Drawing.Point(231, 53);
            this.tKey5.MaxLength = 2;
            this.tKey5.Name = "tKey5";
            this.tKey5.Size = new System.Drawing.Size(25, 21);
            this.tKey5.TabIndex = 9;
            // 
            // tKey4
            // 
            this.tKey4.Location = new System.Drawing.Point(200, 53);
            this.tKey4.MaxLength = 2;
            this.tKey4.Name = "tKey4";
            this.tKey4.Size = new System.Drawing.Size(25, 21);
            this.tKey4.TabIndex = 8;
            // 
            // tKey3
            // 
            this.tKey3.Location = new System.Drawing.Point(169, 53);
            this.tKey3.MaxLength = 2;
            this.tKey3.Name = "tKey3";
            this.tKey3.Size = new System.Drawing.Size(25, 21);
            this.tKey3.TabIndex = 7;
            // 
            // tKey1
            // 
            this.tKey1.Location = new System.Drawing.Point(107, 53);
            this.tKey1.MaxLength = 2;
            this.tKey1.Name = "tKey1";
            this.tKey1.Size = new System.Drawing.Size(25, 21);
            this.tKey1.TabIndex = 5;
            // 
            // tKey2
            // 
            this.tKey2.Location = new System.Drawing.Point(138, 53);
            this.tKey2.MaxLength = 2;
            this.tKey2.Name = "tKey2";
            this.tKey2.Size = new System.Drawing.Size(25, 21);
            this.tKey2.TabIndex = 6;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(34, 56);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 12);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "密码输入：";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 25);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 12);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "密码存放位置：";
            // 
            // gbAuth
            // 
            this.gbAuth.Controls.Add(this.label6);
            this.gbAuth.Controls.Add(this.bAuth);
            this.gbAuth.Controls.Add(this.Label5);
            this.gbAuth.Controls.Add(this.Label4);
            this.gbAuth.Controls.Add(this.gbKType);
            this.gbAuth.Location = new System.Drawing.Point(6, 209);
            this.gbAuth.Name = "gbAuth";
            this.gbAuth.Size = new System.Drawing.Size(297, 146);
            this.gbAuth.TabIndex = 47;
            this.gbAuth.TabStop = false;
            this.gbAuth.Text = "校验密码,每次都要校验密码之后才能读写";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(20, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 60);
            this.label6.TabIndex = 14;
            this.label6.Text = "注意:若扇区编号为0,\r\n则块编号为0-3;\r\n扇区编号为1,\r\n则块编号为4-7,\r\n随后以此类推";
            // 
            // bAuth
            // 
            this.bAuth.Location = new System.Drawing.Point(169, 118);
            this.bAuth.Name = "bAuth";
            this.bAuth.Size = new System.Drawing.Size(118, 21);
            this.bAuth.TabIndex = 13;
            this.bAuth.Text = "验证";
            this.bAuth.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(20, 48);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 12);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "密码存放位置:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(68, 26);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(35, 12);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "块号:";
            // 
            // gbKType
            // 
            this.gbKType.Location = new System.Drawing.Point(169, 23);
            this.gbKType.Name = "gbKType";
            this.gbKType.Size = new System.Drawing.Size(109, 79);
            this.gbKType.TabIndex = 1;
            this.gbKType.TabStop = false;
            this.gbKType.Text = "密钥类型";
            // 
            // gbBinOps
            // 
            this.gbBinOps.Controls.Add(this.lblWriteLength);
            this.gbBinOps.Controls.Add(this.label13);
            this.gbBinOps.Controls.Add(this.bBinUpd);
            this.gbBinOps.Controls.Add(this.bBinRead);
            this.gbBinOps.Controls.Add(this.tBinData);
            this.gbBinOps.Controls.Add(this.Label9);
            this.gbBinOps.Controls.Add(this.tBinLen);
            this.gbBinOps.Controls.Add(this.tBinBlk);
            this.gbBinOps.Controls.Add(this.Label8);
            this.gbBinOps.Controls.Add(this.Label7);
            this.gbBinOps.Location = new System.Drawing.Point(6, 362);
            this.gbBinOps.Name = "gbBinOps";
            this.gbBinOps.Size = new System.Drawing.Size(297, 125);
            this.gbBinOps.TabIndex = 48;
            this.gbBinOps.TabStop = false;
            this.gbBinOps.Text = "二进制块的操作";
            // 
            // lblWriteLength
            // 
            this.lblWriteLength.AutoSize = true;
            this.lblWriteLength.ForeColor = System.Drawing.Color.Red;
            this.lblWriteLength.Location = new System.Drawing.Point(163, 56);
            this.lblWriteLength.Name = "lblWriteLength";
            this.lblWriteLength.Size = new System.Drawing.Size(0, 12);
            this.lblWriteLength.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(115, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "长度：";
            // 
            // bBinUpd
            // 
            this.bBinUpd.Location = new System.Drawing.Point(140, 98);
            this.bBinUpd.Name = "bBinUpd";
            this.bBinUpd.Size = new System.Drawing.Size(116, 21);
            this.bBinUpd.TabIndex = 19;
            this.bBinUpd.Text = "写入/更新块";
            this.bBinUpd.UseVisualStyleBackColor = true;
            this.bBinUpd.Click += new System.EventHandler(this.bBinUpd_Click);
            // 
            // bBinRead
            // 
            this.bBinRead.Location = new System.Drawing.Point(27, 98);
            this.bBinRead.Name = "bBinRead";
            this.bBinRead.Size = new System.Drawing.Size(107, 21);
            this.bBinRead.TabIndex = 18;
            this.bBinRead.Text = "读取块";
            this.bBinRead.UseVisualStyleBackColor = true;
            this.bBinRead.Click += new System.EventHandler(this.bBinRead_Click);
            // 
            // tBinData
            // 
            this.tBinData.Location = new System.Drawing.Point(12, 72);
            this.tBinData.Multiline = true;
            this.tBinData.Name = "tBinData";
            this.tBinData.Size = new System.Drawing.Size(252, 21);
            this.tBinData.TabIndex = 17;
            this.tBinData.TextChanged += new System.EventHandler(this.tBinData_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(12, 57);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(53, 12);
            this.Label9.TabIndex = 16;
            this.Label9.Text = "数据文本";
            // 
            // tBinLen
            // 
            this.tBinLen.Location = new System.Drawing.Point(199, 23);
            this.tBinLen.MaxLength = 2;
            this.tBinLen.Name = "tBinLen";
            this.tBinLen.Size = new System.Drawing.Size(33, 21);
            this.tBinLen.TabIndex = 15;
            this.tBinLen.Text = "16";
            // 
            // tBinBlk
            // 
            this.tBinBlk.Location = new System.Drawing.Point(55, 23);
            this.tBinBlk.MaxLength = 3;
            this.tBinBlk.Name = "tBinBlk";
            this.tBinBlk.Size = new System.Drawing.Size(33, 21);
            this.tBinBlk.TabIndex = 14;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(108, 27);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(89, 12);
            this.Label8.TabIndex = 1;
            this.Label8.Text = "长度(字节数)：";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(12, 27);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(41, 12);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "块号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tAuthenKeyNum);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnAutn);
            this.groupBox1.Controls.Add(this.tBlkNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(6, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 146);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "校验密码,每次都要校验密码之后才能读写";
            // 
            // tAuthenKeyNum
            // 
            this.tAuthenKeyNum.FormattingEnabled = true;
            this.tAuthenKeyNum.Items.AddRange(new object[] {
            "0",
            "1"});
            this.tAuthenKeyNum.Location = new System.Drawing.Point(108, 49);
            this.tAuthenKeyNum.Name = "tAuthenKeyNum";
            this.tAuthenKeyNum.Size = new System.Drawing.Size(36, 20);
            this.tAuthenKeyNum.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(20, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 60);
            this.label10.TabIndex = 14;
            this.label10.Text = "注意:若扇区编号为0,\r\n则块编号为0-3;\r\n扇区编号为1,\r\n则块编号为4-7,\r\n随后以此类推";
            // 
            // btnAutn
            // 
            this.btnAutn.Location = new System.Drawing.Point(169, 118);
            this.btnAutn.Name = "btnAutn";
            this.btnAutn.Size = new System.Drawing.Size(109, 21);
            this.btnAutn.TabIndex = 13;
            this.btnAutn.Text = "验证";
            this.btnAutn.UseVisualStyleBackColor = true;
            this.btnAutn.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // tBlkNo
            // 
            this.tBlkNo.Location = new System.Drawing.Point(109, 22);
            this.tBlkNo.MaxLength = 3;
            this.tBlkNo.Name = "tBlkNo";
            this.tBlkNo.Size = new System.Drawing.Size(35, 21);
            this.tBlkNo.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "密码存放位置：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "块号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbKType2);
            this.groupBox2.Controls.Add(this.rbKType1);
            this.groupBox2.Location = new System.Drawing.Point(169, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "密钥类型";
            // 
            // rbKType2
            // 
            this.rbKType2.AutoSize = true;
            this.rbKType2.Location = new System.Drawing.Point(16, 49);
            this.rbKType2.Name = "rbKType2";
            this.rbKType2.Size = new System.Drawing.Size(53, 16);
            this.rbKType2.TabIndex = 2;
            this.rbKType2.TabStop = true;
            this.rbKType2.Text = "Key B";
            this.rbKType2.UseVisualStyleBackColor = true;
            // 
            // rbKType1
            // 
            this.rbKType1.AutoSize = true;
            this.rbKType1.Location = new System.Drawing.Point(16, 18);
            this.rbKType1.Name = "rbKType1";
            this.rbKType1.Size = new System.Drawing.Size(53, 16);
            this.rbKType1.TabIndex = 1;
            this.rbKType1.TabStop = true;
            this.rbKType1.Text = "Key A";
            this.rbKType1.UseVisualStyleBackColor = true;
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(442, 493);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(113, 21);
            this.bReset.TabIndex = 51;
            this.bReset.Text = "复位";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(324, 493);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(102, 21);
            this.bClear.TabIndex = 50;
            this.bClear.Text = "清除";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bQuit
            // 
            this.bQuit.Location = new System.Drawing.Point(567, 493);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(101, 21);
            this.bQuit.TabIndex = 52;
            this.bQuit.Text = "退出";
            this.bQuit.UseVisualStyleBackColor = true;
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(8, 493);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(74, 21);
            this.btnRead.TabIndex = 18;
            this.btnRead.Text = "读取(&All)";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(93, 493);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(100, 21);
            this.btnWrite.TabIndex = 19;
            this.btnWrite.Text = "写入/更新(&All)";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(199, 493);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 21);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "清空卡";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // NFCCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 521);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bQuit);
            this.Controls.Add(this.gbLoadKeys);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAuth);
            this.Controls.Add(this.gbBinOps);
            this.Controls.Add(this.mMsg);
            this.Controls.Add(this.bInit);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.cbReader);
            this.Controls.Add(this.Label1);
            this.Name = "NFCCardForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLoadKeys.ResumeLayout(false);
            this.gbLoadKeys.PerformLayout();
            this.gbAuth.ResumeLayout(false);
            this.gbAuth.PerformLayout();
            this.gbBinOps.ResumeLayout(false);
            this.gbBinOps.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button bInit;
        internal System.Windows.Forms.Button bConnect;
        internal System.Windows.Forms.ComboBox cbReader;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.RichTextBox mMsg;
        internal System.Windows.Forms.GroupBox gbLoadKeys;
        internal System.Windows.Forms.Button bLoadKey;
        internal System.Windows.Forms.TextBox tKey6;
        internal System.Windows.Forms.TextBox tKey5;
        internal System.Windows.Forms.TextBox tKey4;
        internal System.Windows.Forms.TextBox tKey3;
        internal System.Windows.Forms.TextBox tKey1;
        internal System.Windows.Forms.TextBox tKey2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox gbAuth;
        internal System.Windows.Forms.Button bAuth;
        //internal System.Windows.Forms.TextBox tAuthenKeyNum;
        //internal System.Windows.Forms.TextBox tBlkNo;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox gbKType;
        //internal System.Windows.Forms.RadioButton rbKType2;
        //internal System.Windows.Forms.RadioButton rbKType1;
        internal System.Windows.Forms.GroupBox gbBinOps;
        internal System.Windows.Forms.Button bBinUpd;
        internal System.Windows.Forms.Button bBinRead;
        internal System.Windows.Forms.TextBox tBinData;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox tBinLen;
        internal System.Windows.Forms.TextBox tBinBlk;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.ComboBox tKeyNum;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Button btnAutn;
        internal System.Windows.Forms.TextBox tBlkNo;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.RadioButton rbKType2;
        internal System.Windows.Forms.RadioButton rbKType1;
        internal System.Windows.Forms.Button bReset;
        internal System.Windows.Forms.Button bClear;
        internal System.Windows.Forms.Button bQuit;
        private System.Windows.Forms.ComboBox tAuthenKeyNum;
        internal System.Windows.Forms.Button btnRead;
        internal System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblWriteLength;
        internal System.Windows.Forms.Button btnClear;
    }
}

