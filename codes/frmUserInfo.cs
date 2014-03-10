using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Doggy
{
	/// <summary>
	/// UserOptions ��ժҪ˵����
	/// </summary>
	public class frmUserInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblMailPwd;
		private System.Windows.Forms.TextBox txtMailPwd;
		private System.Windows.Forms.Label lblMailAddr;
		private System.Windows.Forms.TextBox txtMailAddr;
		private System.Windows.Forms.Button btnOptYes;
		private System.Windows.Forms.Button btnOptNo;
		private System.Windows.Forms.ErrorProvider errpUserOptions;
		private System.Windows.Forms.TextBox txtMailSmtp;
		private System.Windows.Forms.TextBox txtMailPop3;
		private System.Windows.Forms.Label lblMailSmtp;
		private System.Windows.Forms.Label lblMailPop3;
		private System.Windows.Forms.TextBox txtInterval;
		private System.Windows.Forms.Label lblInterval;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUserInfo()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUserInfo));
			this.lblMailPwd = new System.Windows.Forms.Label();
			this.txtMailPwd = new System.Windows.Forms.TextBox();
			this.lblMailAddr = new System.Windows.Forms.Label();
			this.txtMailAddr = new System.Windows.Forms.TextBox();
			this.btnOptYes = new System.Windows.Forms.Button();
			this.btnOptNo = new System.Windows.Forms.Button();
			this.errpUserOptions = new System.Windows.Forms.ErrorProvider();
			this.txtMailSmtp = new System.Windows.Forms.TextBox();
			this.txtMailPop3 = new System.Windows.Forms.TextBox();
			this.lblMailSmtp = new System.Windows.Forms.Label();
			this.lblMailPop3 = new System.Windows.Forms.Label();
			this.txtInterval = new System.Windows.Forms.TextBox();
			this.lblInterval = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblMailPwd
			// 
			this.lblMailPwd.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMailPwd.Location = new System.Drawing.Point(16, 49);
			this.lblMailPwd.Name = "lblMailPwd";
			this.lblMailPwd.Size = new System.Drawing.Size(208, 18);
			this.lblMailPwd.TabIndex = 2;
			this.lblMailPwd.Text = "��������(********)��";
			// 
			// txtMailPwd
			// 
			this.txtMailPwd.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMailPwd.Location = new System.Drawing.Point(224, 49);
			this.txtMailPwd.Name = "txtMailPwd";
			this.txtMailPwd.PasswordChar = '*';
			this.txtMailPwd.Size = new System.Drawing.Size(152, 22);
			this.txtMailPwd.TabIndex = 2;
			this.txtMailPwd.Text = "";
			// 
			// lblMailAddr
			// 
			this.lblMailAddr.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMailAddr.Location = new System.Drawing.Point(16, 16);
			this.lblMailAddr.Name = "lblMailAddr";
			this.lblMailAddr.Size = new System.Drawing.Size(208, 18);
			this.lblMailAddr.TabIndex = 12;
			this.lblMailAddr.Text = "����(cc@tom.com)��";
			// 
			// txtMailAddr
			// 
			this.txtMailAddr.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMailAddr.Location = new System.Drawing.Point(224, 16);
			this.txtMailAddr.Name = "txtMailAddr";
			this.txtMailAddr.Size = new System.Drawing.Size(152, 22);
			this.txtMailAddr.TabIndex = 1;
			this.txtMailAddr.Text = "";
			this.txtMailAddr.Leave += new System.EventHandler(this.txtMailAddr_Leave);
			// 
			// btnOptYes
			// 
			this.btnOptYes.Location = new System.Drawing.Point(64, 184);
			this.btnOptYes.Name = "btnOptYes";
			this.btnOptYes.Size = new System.Drawing.Size(80, 24);
			this.btnOptYes.TabIndex = 6;
			this.btnOptYes.Text = "ȷ��";
			this.btnOptYes.Click += new System.EventHandler(this.btnOptYes_Click);
			// 
			// btnOptNo
			// 
			this.btnOptNo.Location = new System.Drawing.Point(208, 184);
			this.btnOptNo.Name = "btnOptNo";
			this.btnOptNo.Size = new System.Drawing.Size(80, 24);
			this.btnOptNo.TabIndex = 7;
			this.btnOptNo.Text = "ȡ��";
			this.btnOptNo.Click += new System.EventHandler(this.btnOptNo_Click);
			// 
			// errpUserOptions
			// 
			this.errpUserOptions.BlinkRate = 200;
			this.errpUserOptions.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errpUserOptions.ContainerControl = this;
			// 
			// txtMailSmtp
			// 
			this.txtMailSmtp.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMailSmtp.Location = new System.Drawing.Point(224, 115);
			this.txtMailSmtp.Name = "txtMailSmtp";
			this.txtMailSmtp.Size = new System.Drawing.Size(152, 22);
			this.txtMailSmtp.TabIndex = 4;
			this.txtMailSmtp.Text = "";
			// 
			// txtMailPop3
			// 
			this.txtMailPop3.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtMailPop3.Location = new System.Drawing.Point(224, 82);
			this.txtMailPop3.Name = "txtMailPop3";
			this.txtMailPop3.Size = new System.Drawing.Size(152, 22);
			this.txtMailPop3.TabIndex = 3;
			this.txtMailPop3.Text = "";
			// 
			// lblMailSmtp
			// 
			this.lblMailSmtp.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMailSmtp.Location = new System.Drawing.Point(16, 115);
			this.lblMailSmtp.Name = "lblMailSmtp";
			this.lblMailSmtp.Size = new System.Drawing.Size(208, 18);
			this.lblMailSmtp.TabIndex = 17;
			this.lblMailSmtp.Text = "�����ʼ�������(smtp.tom.com)��";
			// 
			// lblMailPop3
			// 
			this.lblMailPop3.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMailPop3.Location = new System.Drawing.Point(16, 82);
			this.lblMailPop3.Name = "lblMailPop3";
			this.lblMailPop3.Size = new System.Drawing.Size(208, 18);
			this.lblMailPop3.TabIndex = 16;
			this.lblMailPop3.Text = "�����ʼ�������(pop.tom.com)��";
			// 
			// txtInterval
			// 
			this.txtInterval.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtInterval.Location = new System.Drawing.Point(224, 148);
			this.txtInterval.Name = "txtInterval";
			this.txtInterval.Size = new System.Drawing.Size(152, 22);
			this.txtInterval.TabIndex = 5;
			this.txtInterval.Text = "";
			// 
			// lblInterval
			// 
			this.lblInterval.Font = new System.Drawing.Font("������", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInterval.Location = new System.Drawing.Point(16, 148);
			this.lblInterval.Name = "lblInterval";
			this.lblInterval.Size = new System.Drawing.Size(208, 18);
			this.lblInterval.TabIndex = 22;
			this.lblInterval.Text = "ʱ����(6)��";
			// 
			// frmUserInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 222);
			this.Controls.Add(this.lblInterval);
			this.Controls.Add(this.txtInterval);
			this.Controls.Add(this.txtMailSmtp);
			this.Controls.Add(this.txtMailPop3);
			this.Controls.Add(this.txtMailAddr);
			this.Controls.Add(this.txtMailPwd);
			this.Controls.Add(this.lblMailSmtp);
			this.Controls.Add(this.lblMailPop3);
			this.Controls.Add(this.btnOptNo);
			this.Controls.Add(this.btnOptYes);
			this.Controls.Add(this.lblMailAddr);
			this.Controls.Add(this.lblMailPwd);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(400, 256);
			this.MinimumSize = new System.Drawing.Size(400, 256);
			this.Name = "frmUserInfo";
			this.Text = "�û���Ϣ����";
			this.Load += new System.EventHandler(this.frmUserInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOptYes_Click(object sender, System.EventArgs e)
		{
			// ���������Ϣ����������ʾ
			bool flag = true;
			
			// �������������ı�
			if (this.txtMailAddr.Text.Trim().IndexOf('@') <= 1 || this.txtMailAddr.Text.Trim().EndsWith("@") ||
				this.txtMailAddr.Text.Trim().LastIndexOf('@') != this.txtMailAddr.Text.Trim().IndexOf('@'))
			{
				this.errpUserOptions.SetError(this.txtMailAddr, "��������ȷ�����ַ(�磺cc@tom.com)");
				flag = false;
			}
			else
			{
				this.errpUserOptions.SetError(this.txtMailAddr, "");
			}
			
			// �������Ľ����ʼ��������ı�
			if (this.txtMailPop3.Text.Trim().IndexOf('.') <= 1 || this.txtMailPop3.Text.EndsWith("."))
			{
				this.errpUserOptions.SetError(this.txtMailPop3, "��������ȷ�Ľ����ʼ�������(�磺pop@tom.com)");
				flag = false;
			}
			else
			{
				this.errpUserOptions.SetError(this.txtMailPop3, "");
			}
			
			// �������ķ����ʼ��������ı�
			if (this.txtMailSmtp.Text.Trim().IndexOf('.') <= 1 || this.txtMailSmtp.Text.EndsWith("."))
			{
				this.errpUserOptions.SetError(this.txtMailSmtp, "��������ȷ�ķ����ʼ�������(�磺smtp@tom.com)");
				flag = false;
			}
			else
			{
				this.errpUserOptions.SetError(this.txtMailSmtp, "");
			}
			
			// �����������������ı�
			if (this.txtMailPwd.Text.Trim() == "")
			{
				this.errpUserOptions.SetError(this.txtMailPwd, "��������������");
				flag = false;
			}
			else
			{
				this.errpUserOptions.SetError(this.txtMailPwd, "");
			}
			
			// ��������ʱ�����ı�
			int i = 0;
			for (i=0; i<this.txtInterval.Text.Trim().Length; i++)
			{
				if (this.txtInterval.Text.Trim()[i] < '0' || this.txtInterval.Text.Trim()[i] > '9')
				{
					this.errpUserOptions.SetError(this.txtInterval, "��������ȷ������(2-1000)");
					flag = false;
					break;
				}
			}
			if (i == this.txtInterval.Text.Trim().Length)
			{
				if (Int32.Parse(this.txtInterval.Text.Trim()) > 1000 || Int32.Parse(this.txtInterval.Text.Trim()) < 2)
				{
					flag = false;
					this.errpUserOptions.SetError(this.txtInterval, "��������ȷ������(2-1000)");
				}
				else
				{
					this.errpUserOptions.SetError(this.txtInterval, "");
				}
			}

			if (flag)
			{
				// �޴���ֵ
				frmDoggy.mstrMailAddr = this.txtMailAddr.Text.Trim();
				frmDoggy.mstrMailPwd = this.txtMailPwd.Text.Trim();
				frmDoggy.mstrMailPop3 = this.txtMailPop3.Text.Trim();
				frmDoggy.mstrMailSmtp = this.txtMailSmtp.Text.Trim();
				string[] strTotal = this.txtMailAddr.Text.Split(new char[]{'@'}, 2);
				frmDoggy.mstrMailUser = strTotal[0];
				frmDoggy.miInterval = Int32.Parse(this.txtInterval.Text.Trim());
				
				this.Close();
			}
		}

		private void btnOptNo_Click(object sender, System.EventArgs e)
		{
			// �˳�
			this.Close();
		}

		private void txtMailAddr_Leave(object sender, System.EventArgs e)
		{
			// ���������ַ���Զ�����POP3��SMTP��������ַ
			if (!(this.txtMailAddr.Text.Trim().IndexOf('@') <= 1 || this.txtMailAddr.Text.Trim().EndsWith("@") ||
				this.txtMailAddr.Text.Trim().LastIndexOf('@') != this.txtMailAddr.Text.Trim().IndexOf('@')))
			{
				string[] strTotal = this.txtMailAddr.Text.Split(new char[]{'@'}, 2);
				this.txtMailPop3.Text = "pop." + strTotal[1];
				this.txtMailSmtp.Text = "smtp." + strTotal[1];
			}
		}

		private void frmUserInfo_Load(object sender, System.EventArgs e)
		{
			// ���ó�ʹֵ
			if (frmDoggy.mstrMailAddr != "")
			{
				this.txtMailAddr.Text = frmDoggy.mstrMailAddr;
				this.txtMailPop3.Text = frmDoggy.mstrMailPop3;
				this.txtMailSmtp.Text = frmDoggy.mstrMailSmtp;
				this.txtMailPwd.Text = frmDoggy.mstrMailPwd;
			}
			this.txtInterval.Text = frmDoggy.miInterval.ToString();
		}
	}
}
