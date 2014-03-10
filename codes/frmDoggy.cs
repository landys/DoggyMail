using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;	// �����ʼ�ʱÿ�μ�������һ���߳�

namespace Doggy
{
	/// <summary>
	/// ����������ڡ�
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

		// ��̬��������
		public static string mstrMailAddr;	// �û������ַ
		public static string mstrMailUser;	// �û������û���
		public static string mstrMailPwd;	// �û���������
		public static string mstrMailPop3;	// �û�����POP3������
		public static string mstrMailSmtp;	// �û�����SMTP������
		public static int miInterval;	// ÿmiInterval���Ӽ���������ʼ�
		public static string[] mstrNickName;	// ���Ӷ����ǳƼ�
		public static string[] mstrScanAddr;	// ���Ӷ��������ַ��
		private frmProgress mfrmProg;	// �Զ��崰�����
		private Thread mthMail;	// �̶߳���
		private bool mFlagRunning;	// ��־�Ƿ��ڼ���

		public frmDoggy()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			// ��ʹ��
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
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.btnScan.Text = "��ʼ����";
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
			this.btnUser.Text = "�û���Ϣ����";
			this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
			// 
			// btnOption
			// 
			this.btnOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOption.Location = new System.Drawing.Point(24, 62);
			this.btnOption.Name = "btnOption";
			this.btnOption.Size = new System.Drawing.Size(152, 32);
			this.btnOption.TabIndex = 2;
			this.btnOption.Text = "���Ӷ�������";
			this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
			// 
			// lblIntro
			// 
			this.lblIntro.BackColor = System.Drawing.SystemColors.Control;
			this.lblIntro.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblIntro.Location = new System.Drawing.Point(200, 24);
			this.lblIntro.Name = "lblIntro";
			this.lblIntro.Size = new System.Drawing.Size(168, 144);
			this.lblIntro.TabIndex = 3;
			this.lblIntro.Text = "  Doggy ��һ����ȡ�ʼ��Զ����ѵ�С����������֮�������������û��趨���ض������ַ�������ʼ������Է�������û��������������ͬʱ�����ܶ�ĳ�������ض�����" +
				"�������ʼ�����ʵʱ�ļ�أ�ʹר�Ĺ������޺��֮�ǡ�";
			// 
			// btnTest
			// 
			this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTest.Location = new System.Drawing.Point(24, 100);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(152, 32);
			this.btnTest.TabIndex = 4;
			this.btnTest.Text = "�����ʼ�����������";
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
			this.mnuScan.Text = "��ʼ����";
			this.mnuScan.Click += new System.EventHandler(this.mnuScan_Click);
			// 
			// mnuStop
			// 
			this.mnuStop.Index = 1;
			this.mnuStop.Text = "��ͣ����";
			this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "�˳�";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// btnStop
			// 
			this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnStop.Location = new System.Drawing.Point(24, 176);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(152, 32);
			this.btnStop.TabIndex = 5;
			this.btnStop.Text = "ֹͣ����";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(232, 176);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(112, 32);
			this.btnHelp.TabIndex = 6;
			this.btnHelp.Text = "����";
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
			this.Text = "Doggy�ʼ�������";
			this.Resize += new System.EventHandler(this.frmDoggy_Resize);
			this.Load += new System.EventHandler(this.frmDoggy_Load);
			this.Activated += new System.EventHandler(this.frmDoggy_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmDoggy());
		}

		private void btnUser_Click(object sender, System.EventArgs e)
		{
			frmUserInfo user = new frmUserInfo();	// ���û���Ϣ���ô���
			user.Visible = true;
		}

		private void btnOption_Click(object sender, System.EventArgs e)
		{
			frmOption opt = new frmOption();	// �򿪼��Ӷ�����Ϣ���ô���
			opt.Visible = true;
		}

		private void btnScan_Click(object sender, System.EventArgs e)
		{
			mthMail = new Thread(new ThreadStart(ScanMail));	// �������߳�
			mthMail.IsBackground = true;	// ����Ϊ��̨����
			mthMail.Start();	// �߳̿�ʼ
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

		private void ScanMail()	// ���̺߳���
		{
			while (true)
			{
				// ����ʼ���POP3Client��һ���Զ����֧��POP3��ȡ�ʼ�����
				POP3Client pop3Client = new POP3Client(frmDoggy.mstrMailPop3, 110, frmDoggy.mstrMailUser, frmDoggy.mstrMailPwd);
				int iCount = 0;	// �����е����ʼ���
				int iTotalSize = 0;	// �ʼ��ܴ�С��û��ʵ���ô�
				String strMailContent = "";	// �ʼ�����

				try
				{
					pop3Client.Connect();
					pop3Client.Stat(ref iCount, ref iTotalSize);
				}
				catch
				{
					// ʲô������
				}
				if (iCount <= 0)
				{
					Thread.Sleep(frmDoggy.miInterval * 60000);	// �̹߳���ʱ��
					continue;
				}
				if (frmDoggy.mstrNickName == null)	// �û�δָ���ض����󣬼��������ʼ�
				{
					MessageBox.Show(iCount.ToString() + "�����ʼ����������п����ʼ���ַ", "�����ʼ�");
				}
				else	// �����ض��ʼ�
				{
					int k = frmDoggy.mstrNickName.Length;	// ���Ӷ�����Ŀ
					int[] ia = new int[k];	// Ϊÿ�����������ʼ�����
					for (int ii=0; ii<k; ii++)	// ��ʼ��
					{
						ia[ii] = 0;
					}
					bool iflag = false;

					for (int i=1; i<=iCount; i++)
					{
						try
						{
							pop3Client.RetrSender(i, ref strMailContent);
							for (int j=0; j<k; j++)	// ���ÿһ���ʼ��ķ�����
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
							// ʲô������
						}
					}

					if (iflag)	// ���ض������ʼ�
					{
						string text = "��";
						for (int j=0; j<k; j++)
						{
							if (ia[j] != 0)
							{
								text += ia[j].ToString() + "�����ʼ�������" + frmDoggy.mstrNickName[j] + "(" + frmDoggy.mstrScanAddr[j] + ")\n";
							}
						}
						MessageBox.Show(text, "�����ʼ�");	// ��ʾ��ʾ
					}
				}

				Thread.Sleep(frmDoggy.miInterval * 60000);	// �̹߳���ʱ��
			}
		}

		private void btnTest_Click(object sender, System.EventArgs e)
		{
			mfrmProg = new frmProgress();	// �������磬��������ʾ����
			mfrmProg.Visible = true;
			this.btnUser.Enabled = false;
			this.btnOption.Enabled = false;
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			// �˳�����
			this.Close();
			this.ntfDoggy.Visible = false;
			Application.Exit();
		}

		private void mnuScan_Click(object sender, System.EventArgs e)
		{
			// ��ʼ���
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
			// ֹͣ���
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
			// ��ť��ʹֵ
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
			MessageBox.Show("  Doggy ��һ����ȡ�ʼ��Զ����ѵ�С�����\n  �����֮��������" +
				"ÿ��һ��ʱ�䣨�û��趨�������ض������ַ���û��趨���������ʼ������Է�" +
				"������û��������������ͬʱ�����ܶ�ĳ�������ض����巢�����ʼ�����ʵ" +
				"ʱ�ļ�أ�ʹר�Ĺ������޺��֮�ǡ�\n  ����ʹ�÷ǳ��򵥣���Ӳ��Ҳ����û" +
				"ʲôҪ�󡣱�������Ҫ���������硣\n  ��������֮����������档�ڽ��ж���" +
				"�����м���ǰ������С��û���Ϣ���á���\n  �û����԰�����ʾ��Ϣ�����Լ�" +
				"Ҫ�鿴�������ַ���������롢�����ʼ��������������ʼ��������������ʼ�ʱ" +
				"����������֮��Ϳ��Խ����ʼ����������Ӳ��Ի���ֱ�ӿ�ʼ���ӡ�\n  �û�" +
				"Ҳ���Խ��м��Ӷ������ã�����ͨ�����ı����������ǳƺ������ַ��Ȼ����" +
				"�Ӱ�ť��ӵ��б��С�Ҳ���Խ���ɾ�����޸ġ���ղ�����Ū�ú�ȷ�����ɡ�\n " + 
				" �����ø�ѡ��󣬿����Ȳ��������ʼ����������ɹ����ٰ���ʼ���Ӱ�ť���м�" +
				"�ӣ�Ҳ���Բ�����ֱ�ӿ�ʼ����������ʱ�ᵯ��һ�����������ɹ���ʧ�ܶ��ᵯ" +
				"����Ϣ�򣬻�������ӡ����ʾ��\n  �����ӵ�ĳ�ض����䷢���ʼ��󣬾ͻ��Զ�" +
				"������Ϣ����ʾ�û�������ʼ���Ӱ�ťͬʱ��Ͱ�����������С����ťһ����" +
				"ʹ�������أ���ֻ��������ͼ�ꡣ�ڼ����п��԰�ֹͣ����ֹͣ��\n  ��������" +
				"�����߰������ܣ�ֱ�Ӱ�������ť���ɡ�", "����");
		}

		private void frmDoggy_Activated(object sender, System.EventArgs e)
		{
			// ���ð�ť״̬
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
			// ��С��ʱ���ش��壬��ʾ����ͼ��
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;
				this.ntfDoggy.Visible = true;
			}
		}

		private void mnuStop_Click(object sender, System.EventArgs e)
		{
			// ֹͣ���
			btnStop_Click(sender, e);
		}
	}
}
