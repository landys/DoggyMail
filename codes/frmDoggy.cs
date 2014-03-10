using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;	// 监视邮件时每次监视生成一个线程

namespace Doggy
{
	/// <summary>
	/// 程序的主窗口。
	/// </summary>
	public class frmDoggy : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.Button btnUser;
		private System.Windows.Forms.Button btnOption;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.NotifyIcon ntfDoggy;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.ContextMenu cmnuDoggy;
		private System.Windows.Forms.MenuItem mnuScan;
		private System.Windows.Forms.MenuItem mnuStop;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.Label lblIntro;
		private System.Windows.Forms.Button btnHelp;

		// 静态变量定义
		public static string mstrMailAddr;	// 用户邮箱地址
		public static string mstrMailUser;	// 用户邮箱用户名
		public static string mstrMailPwd;	// 用户邮箱密码
		public static string mstrMailPop3;	// 用户邮箱POP3服务器
		public static string mstrMailSmtp;	// 用户邮箱SMTP服务器
		public static int miInterval;	// 每miInterval分钟检测邮箱中邮件
		public static string[] mstrNickName;	// 监视对象昵称集
		public static string[] mstrScanAddr;	// 监视对象邮箱地址集
		private frmProgress mfrmProg;	// 自定义窗体对象
		private Thread mthMail;	// 线程对象
		private bool mFlagRunning;	// 标志是否在监视

		public frmDoggy()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			// 初使化
			mstrMailAddr = "";
			mstrMailUser = "";
			mstrMailPwd = "";
			mstrMailPop3 = "";
			mstrMailSmtp = "";
			miInterval = 6;
			mstrNickName = null;
			mstrScanAddr = null;
			this.mFlagRunning = false;
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDoggy));
			this.btnScan = new System.Windows.Forms.Button();
			this.btnUser = new System.Windows.Forms.Button();
			this.btnOption = new System.Windows.Forms.Button();
			this.lblIntro = new System.Windows.Forms.Label();
			this.btnTest = new System.Windows.Forms.Button();
			this.ntfDoggy = new System.Windows.Forms.NotifyIcon(this.components);
			this.cmnuDoggy = new System.Windows.Forms.ContextMenu();
			this.mnuScan = new System.Windows.Forms.MenuItem();
			this.mnuStop = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnHelp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnScan
			// 
			this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScan.Location = new System.Drawing.Point(24, 138);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(152, 32);
			this.btnScan.TabIndex = 0;
			this.btnScan.Text = "开始监视";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnUser
			// 
			this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnUser.Location = new System.Drawing.Point(24, 24);
			this.btnUser.Name = "btnUser";
			this.btnUser.Size = new System.Drawing.Size(152, 32);
			this.btnUser.TabIndex = 1;
			this.btnUser.Text = "用户信息设置";
			this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
			// 
			// btnOption
			// 
			this.btnOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOption.Location = new System.Drawing.Point(24, 62);
			this.btnOption.Name = "btnOption";
			this.btnOption.Size = new System.Drawing.Size(152, 32);
			this.btnOption.TabIndex = 2;
			this.btnOption.Text = "监视对象设置";
			this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
			// 
			// lblIntro
			// 
			this.lblIntro.BackColor = System.Drawing.SystemColors.Control;
			this.lblIntro.Font = new System.Drawing.Font("新宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIntro.Location = new System.Drawing.Point(200, 24);
			this.lblIntro.Name = "lblIntro";
			this.lblIntro.Size = new System.Drawing.Size(168, 144);
			this.lblIntro.TabIndex = 3;
			this.lblIntro.Text = "  Doggy 是一款收取邮件自动提醒的小软件。其独特之处在于它监视用户设定的特定邮箱地址发来的邮件，可以方便地让用户在做其他事情的同时，又能对某个或多个特定对象" +
				"发来的邮件进行实时的监控，使专心工作而无后顾之忧。";
			// 
			// btnTest
			// 
			this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTest.Location = new System.Drawing.Point(24, 100);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(152, 32);
			this.btnTest.TabIndex = 4;
			this.btnTest.Text = "测试邮件服务器连接";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// ntfDoggy
			// 
			this.ntfDoggy.ContextMenu = this.cmnuDoggy;
			this.ntfDoggy.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfDoggy.Icon")));
			this.ntfDoggy.Text = "Doggy";
			this.ntfDoggy.Click += new System.EventHandler(this.ntfDoggy_Click);
			// 
			// cmnuDoggy
			// 
			this.cmnuDoggy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuScan,
																					  this.mnuStop,
																					  this.mnuExit});
			// 
			// mnuScan
			// 
			this.mnuScan.Index = 0;
			this.mnuScan.Text = "开始监视";
			this.mnuScan.Click += new System.EventHandler(this.mnuScan_Click);
			// 
			// mnuStop
			// 
			this.mnuStop.Index = 1;
			this.mnuStop.Text = "暂停监视";
			this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "退出";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// btnStop
			// 
			this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnStop.Location = new System.Drawing.Point(24, 176);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(152, 32);
			this.btnStop.TabIndex = 5;
			this.btnStop.Text = "停止监视";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(232, 176);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(112, 32);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "帮助";
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// frmDoggy
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 238);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.lblIntro);
			this.Controls.Add(this.btnOption);
			this.Controls.Add(this.btnUser);
			this.Controls.Add(this.btnScan);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(408, 272);
			this.MinimumSize = new System.Drawing.Size(408, 272);
			this.Name = "frmDoggy";
			this.Text = "Doggy邮件提醒器";
			this.Resize += new System.EventHandler(this.frmDoggy_Resize);
			this.Load += new System.EventHandler(this.frmDoggy_Load);
			this.Activated += new System.EventHandler(this.frmDoggy_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmDoggy());
		}

		private void btnUser_Click(object sender, System.EventArgs e)
		{
			frmUserInfo user = new frmUserInfo();	// 打开用户信息设置窗体
			user.Visible = true;
		}

		private void btnOption_Click(object sender, System.EventArgs e)
		{
			frmOption opt = new frmOption();	// 打开监视对象信息设置窗体
			opt.Visible = true;
		}

		private void btnScan_Click(object sender, System.EventArgs e)
		{
			mthMail = new Thread(new ThreadStart(ScanMail));	// 创建新线程
			mthMail.IsBackground = true;	// 设置为后台运行
			mthMail.Start();	// 线程开始
			this.mFlagRunning = true;
			this.btnScan.Enabled = false;
			this.mnuScan.Enabled = false;
			this.btnStop.Enabled = true;
			this.mnuStop.Enabled = true;
			this.btnUser.Enabled = false;
			this.btnOption.Enabled = false;

			this.Visible = false;
			this.ntfDoggy.Visible = true;
		}

		private void ScanMail()	// 新线程函数
		{
			while (true)
			{
				// 检测邮件，POP3Client是一个自定义的支持POP3收取邮件的类
				POP3Client pop3Client = new POP3Client(frmDoggy.mstrMailPop3, 110, frmDoggy.mstrMailUser, frmDoggy.mstrMailPwd);
				int iCount = 0;	// 邮箱中的总邮件数
				int iTotalSize = 0;	// 邮件总大小，没有实际用处
				String strMailContent = "";	// 邮件内容

				try
				{
					pop3Client.Connect();
					pop3Client.Stat(ref iCount, ref iTotalSize);
				}
				catch
				{
					// 什么都不做
				}
				if (iCount <= 0)
				{
					Thread.Sleep(frmDoggy.miInterval * 60000);	// 线程挂起时间
					continue;
				}
				if (frmDoggy.mstrNickName == null)	// 用户未指定特定对象，监视所有邮件
				{
					MessageBox.Show(iCount.ToString() + "封新邮件，来自所有可能邮件地址", "您有邮件");
				}
				else	// 监视特定邮件
				{
					int k = frmDoggy.mstrNickName.Length;	// 监视对象数目
					int[] ia = new int[k];	// 为每个对象发来的邮件记数
					for (int ii=0; ii<k; ii++)	// 初始化
					{
						ia[ii] = 0;
					}
					bool iflag = false;

					for (int i=1; i<=iCount; i++)
					{
						try
						{
							pop3Client.RetrSender(i, ref strMailContent);
							for (int j=0; j<k; j++)	// 检测每一封邮件的发件者
							{
								if (strMailContent.ToLower().IndexOf("<" + frmDoggy.mstrScanAddr[j].ToLower() + ">") != -1)
								{
									ia[j]++;
									iflag = true;
								}
							}
						}
						catch
						{
							// 什么都不做
						}
					}

					if (iflag)	// 有特定对象邮件
					{
						string text = "有";
						for (int j=0; j<k; j++)
						{
							if (ia[j] != 0)
							{
								text += ia[j].ToString() + "封新邮件，来自" + frmDoggy.mstrNickName[j] + "(" + frmDoggy.mstrScanAddr[j] + ")\n";
							}
						}
						MessageBox.Show(text, "您有邮件");	// 显示提示
					}
				}

				Thread.Sleep(frmDoggy.miInterval * 60000);	// 线程挂起时间
			}
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			mfrmProg = new frmProgress();	// 测试网络，进度条显示进度
			mfrmProg.Visible = true;
			this.btnUser.Enabled = false;
			this.btnOption.Enabled = false;
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			// 退出程序
			this.Close();
			this.ntfDoggy.Visible = false;
			Application.Exit();
		}

		private void mnuScan_Click(object sender, System.EventArgs e)
		{
			// 开始检测
			btnScan_Click(sender, e);
		}

		private void ntfDoggy_Click(object sender, System.EventArgs e)
		{
			this.Visible = true;
			this.ntfDoggy.Visible = false;
			this.WindowState = FormWindowState.Normal;
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
			// 停止检测
			mthMail.Abort();
			this.mFlagRunning = false;
			this.btnScan.Enabled = true;
			this.mnuScan.Enabled = true;
			this.btnStop.Enabled = false;
			this.mnuStop.Enabled = false;
			this.btnUser.Enabled = true;
			this.btnOption.Enabled = true;
		}

		private void frmDoggy_Load(object sender, System.EventArgs e)
		{
			// 按钮初使值
			this.btnUser.Enabled = true;
			this.btnHelp.Enabled = true;
			this.btnOption.Enabled = true;
			this.mnuScan.Enabled = false;
			this.mnuStop.Enabled = false;
			this.btnTest.Enabled = false;
			this.btnScan.Enabled = false;
			this.btnStop.Enabled = false;
		}

		private void btnHelp_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("  Doggy 是一款收取邮件自动提醒的小软件。\n  其独特之处在于它" +
				"每隔一段时间（用户设定）监视特定邮箱地址（用户设定）发来的邮件，可以方" +
				"便地让用户在做其他事情的同时，又能对某个或多个特定个体发来的邮件进行实" +
				"时的监控，使专心工作而无后顾之忧。\n  程序使用非常简单，对硬件也基本没" +
				"什么要求。本程序需要先连接网络。\n  程序启动之后进入主界面。在进行对邮" +
				"件进行监视前必须进行“用户信息设置”。\n  用户可以按照提示信息输入自己" +
				"要查看的邮箱地址、邮箱密码、接收邮件服务器、发送邮件服务器、监视邮件时" +
				"间间隔。设置之后就可以进行邮件服务器连接测试或者直接开始监视。\n  用户" +
				"也可以进行监视对象设置，可以通过在文本框中输入昵称和邮箱地址，然后按添" +
				"加按钮添加到列表中。也可以进行删除、修改、清空操作，弄好后按确定即可。\n " + 
				" 当设置各选项后，可以先测试连接邮件服务器，成功后再按开始监视按钮进行监" +
				"视，也可以不测试直接开始。测试连接时会弹出一个进度条，成功或失败都会弹" +
				"出消息框，还给出相印的提示。\n  当监视到某特定邮箱发来邮件后，就会自动" +
				"弹出消息框，提示用户。按开始监视按钮同时会和按标题栏的最小化按钮一样，" +
				"使窗体隐藏，而只存在托盘图标。在监视中可以按停止监视停止。\n  本程序提" +
				"供在线帮助功能，直接按帮助按钮即可。", "帮助");
		}

		private void frmDoggy_Activated(object sender, System.EventArgs e)
		{
			// 设置按钮状态
			if (frmDoggy.mstrMailAddr != "")
			{
				this.btnTest.Enabled = true;
				if (this.mFlagRunning)
				{
					this.btnScan.Enabled = false;
					this.mnuScan.Enabled = false;
					this.btnStop.Enabled = true;
					this.mnuStop.Enabled = true;
					this.btnUser.Enabled = false;
					this.btnOption.Enabled = false;
				}
				else
				{
					this.btnScan.Enabled = true;
					this.mnuScan.Enabled = true;
					this.btnStop.Enabled = false;
					this.mnuStop.Enabled = false;
					this.btnUser.Enabled = true;
					this.btnOption.Enabled = true;
				}
			}
			else
			{
				this.btnTest.Enabled = false;
				this.btnScan.Enabled = false;
				this.btnStop.Enabled = false;
				this.mnuScan.Enabled = false;
				this.mnuStop.Enabled = false;
				this.btnUser.Enabled = true;
				this.btnOption.Enabled = true;
			}
		}

		private void frmDoggy_Resize(object sender, System.EventArgs e)
		{
			// 最小化时隐藏窗体，显示托盘图标
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;
				this.ntfDoggy.Visible = true;
			}
		}

		private void mnuStop_Click(object sender, System.EventArgs e)
		{
			// 停止检测
			btnStop_Click(sender, e);
		}
	}
}
