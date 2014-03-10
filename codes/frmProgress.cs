using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace Doggy
{
	/// <summary>
	/// frmProgress �����ڲ��Է���������ʱ�Ľ�������
	/// </summary>
	public class frmProgress : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar progMail;
		private System.Windows.Forms.Label lblProcess;
		private System.Windows.Forms.Label lblLog;
		private System.Windows.Forms.Timer tmrConnect;
		private System.ComponentModel.IContainer components;

		// �Զ������
		private Thread mthMail;	// �߳�
		private bool mFlagTested;	// �Ƿ�����Ա�־
		private int imax;	// ���ӽ׶�ʱ�Ľ��������ֵ

		public frmProgress()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			this.mFlagTested = false;
			this.imax = 70;
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			this.Text = "����������";
			this.Load += new System.EventHandler(this.frmProgress_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public void TestConnect()
		{
			// ����ʼ���POP3Client��һ���Զ����֧��POP3��ȡ�ʼ�����
			POP3Client pop3Client = new POP3Client(frmDoggy.mstrMailPop3, 110, frmDoggy.mstrMailUser, frmDoggy.mstrMailPwd);
			int iCount = 0;	// �����е����ʼ���
			int iTotalSize = 0;	// �ʼ��ܴ�С��û��ʵ���ô�
			this.lblProcess.Text = "����������...";
			this.Text = "��������";

			try
			{
				pop3Client.Connect();	// ����
			}
			catch (System.Exception error)
			{
				this.tmrConnect.Stop();
				MessageBox.Show("���ӷ���������" + error.Message, "����ʧ��");
				this.Close();
				mthMail.Abort();
			}

			this.progMail.Value = 70;
			this.lblProcess.Text = "������,�����Բ鿴�ʼ�...";
			this.Text = "���Բ鿴�ʼ�";
			try
			{
				pop3Client.Stat(ref iCount, ref iTotalSize);	// �鿴�ʼ�
			}
			catch (System.Exception error)
			{
				this.tmrConnect.Stop();
				MessageBox.Show("�޷��鿴�ʼ���" + error.Message, "����ʧ��");
				this.Close();
				mthMail.Abort();
			}
			this.progMail.Value = 100;
			this.lblProcess.Text = "���ӳɹ�";
			this.Text = "���Գɹ�";
			MessageBox.Show("������������", "��������");
			
			this.tmrConnect.Stop();
			this.Close();
			mthMail.Abort();
		}

		private void frmProgress_Load(object sender, System.EventArgs e)
		{
			// ��ʼ��
			this.tmrConnect.Interval = 1000;
			this.tmrConnect.Start();
			mthMail = new Thread(new ThreadStart(TestConnect));	// ���߳�
			mthMail.IsBackground = true;	// ��̨����
			mthMail.Start();	// �߳̿�ʼ
		}

		private void tmrConnect_Tick(object sender, System.EventArgs e)
		{
			// ����������
			if ((this.mFlagTested == false && this.progMail.Value <= imax) || (this.mFlagTested && this.progMail.Value <= 100))
			{
				this.progMail.PerformStep();
			}
		}
	}
}
