using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace Doggy
{
	/// <summary>
	/// frmProgress 用来在测试服务器连接时的进度条。
	/// </summary>
	public class frmProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar progMail;
		private System.Windows.Forms.Label lblProcess;
		private System.Windows.Forms.Label lblLog;
		private System.Windows.Forms.Timer tmrConnect;
		private System.ComponentModel.IContainer components;

		// 自定义变量
		private Thread mthMail;	// 线程
		private bool mFlagTested;	// 是否完测试标志
		private int imax;	// 连接阶段时的进度条最大值

		public frmProgress()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			this.mFlagTested = false;
			this.imax = 70;
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmProgress));
			this.progMail = new System.Windows.Forms.ProgressBar();
			this.lblLog = new System.Windows.Forms.Label();
			this.lblProcess = new System.Windows.Forms.Label();
			this.tmrConnect = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// progMail
			// 
			this.progMail.Location = new System.Drawing.Point(24, 56);
			this.progMail.Name = "progMail";
			this.progMail.Size = new System.Drawing.Size(288, 24);
			this.progMail.Step = 7;
			this.progMail.TabIndex = 0;
			// 
			// lblLog
			// 
			this.lblLog.Image = ((System.Drawing.Image)(resources.GetObject("lblLog.Image")));
			this.lblLog.Location = new System.Drawing.Point(16, 8);
			this.lblLog.Name = "lblLog";
			this.lblLog.Size = new System.Drawing.Size(40, 30);
			this.lblLog.TabIndex = 1;
			// 
			// lblProcess
			// 
			this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblProcess.Location = new System.Drawing.Point(72, 16);
			this.lblProcess.Name = "lblProcess";
			this.lblProcess.Size = new System.Drawing.Size(240, 24);
			this.lblProcess.TabIndex = 2;
			// 
			// tmrConnect
			// 
			this.tmrConnect.Tick += new System.EventHandler(this.tmrConnect_Tick);
			// 
			// frmProgress
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 94);
			this.Controls.Add(this.lblProcess);
			this.Controls.Add(this.lblLog);
			this.Controls.Add(this.progMail);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(336, 128);
			this.MinimumSize = new System.Drawing.Size(336, 128);
			this.Name = "frmProgress";
			this.Text = "测试连接中";
			this.Load += new System.EventHandler(this.frmProgress_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public void TestConnect()
		{
			// 检测邮件，POP3Client是一个自定义的支持POP3收取邮件的类
			POP3Client pop3Client = new POP3Client(frmDoggy.mstrMailPop3, 110, frmDoggy.mstrMailUser, frmDoggy.mstrMailPwd);
			int iCount = 0;	// 邮箱中的总邮件数
			int iTotalSize = 0;	// 邮件总大小，没有实际用处
			this.lblProcess.Text = "正在连接中...";
			this.Text = "测试连接";

			try
			{
				pop3Client.Connect();	// 连接
			}
			catch (System.Exception error)
			{
				this.tmrConnect.Stop();
				MessageBox.Show("连接服务器错误：" + error.Message, "测试失败");
				this.Close();
				mthMail.Abort();
			}

			this.progMail.Value = 70;
			this.lblProcess.Text = "已连接,正测试查看邮件...";
			this.Text = "测试查看邮件";
			try
			{
				pop3Client.Stat(ref iCount, ref iTotalSize);	// 查看邮件
			}
			catch (System.Exception error)
			{
				this.tmrConnect.Stop();
				MessageBox.Show("无法查看邮件：" + error.Message, "测试失败");
				this.Close();
				mthMail.Abort();
			}
			this.progMail.Value = 100;
			this.lblProcess.Text = "连接成功";
			this.Text = "测试成功";
			MessageBox.Show("测试连接正常", "测试正常");
			
			this.tmrConnect.Stop();
			this.Close();
			mthMail.Abort();
		}

		private void frmProgress_Load(object sender, System.EventArgs e)
		{
			// 初始化
			this.tmrConnect.Interval = 1000;
			this.tmrConnect.Start();
			mthMail = new Thread(new ThreadStart(TestConnect));	// 新线程
			mthMail.IsBackground = true;	// 后台运行
			mthMail.Start();	// 线程开始
		}

		private void tmrConnect_Tick(object sender, System.EventArgs e)
		{
			// 进度条增加
			if ((this.mFlagTested == false && this.progMail.Value <= imax) || (this.mFlagTested && this.progMail.Value <= 100))
			{
				this.progMail.PerformStep();
			}
		}
	}
}
