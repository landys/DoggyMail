using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Doggy
{
	/// <summary>
	/// frmOption 的摘要说明。
	/// </summary>
	public class frmOption : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView lstvMailList;
		private System.Windows.Forms.ColumnHeader colNickName;
		private System.Windows.Forms.ColumnHeader colMailAddr;
		private System.Windows.Forms.Splitter splRight;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.GroupBox grpInfo;
		private System.Windows.Forms.Label lblNickName;
		private System.Windows.Forms.Label lblMailAddr;
		private System.Windows.Forms.TextBox txtNickName;
		private System.Windows.Forms.TextBox txtMailAddr;
		private System.Windows.Forms.ErrorProvider errpOption;
		private System.Windows.Forms.Button btnOptYes;
		private System.Windows.Forms.Button btnOptNo;
		private System.Windows.Forms.Label lblHint;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOption()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOption));
			this.lstvMailList = new System.Windows.Forms.ListView();
			this.colNickName = new System.Windows.Forms.ColumnHeader();
			this.colMailAddr = new System.Windows.Forms.ColumnHeader();
			this.splRight = new System.Windows.Forms.Splitter();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnChange = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.grpInfo = new System.Windows.Forms.GroupBox();
			this.txtMailAddr = new System.Windows.Forms.TextBox();
			this.txtNickName = new System.Windows.Forms.TextBox();
			this.lblMailAddr = new System.Windows.Forms.Label();
			this.lblNickName = new System.Windows.Forms.Label();
			this.errpOption = new System.Windows.Forms.ErrorProvider();
			this.btnOptYes = new System.Windows.Forms.Button();
			this.btnOptNo = new System.Windows.Forms.Button();
			this.lblHint = new System.Windows.Forms.Label();
			this.grpInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstvMailList
			// 
			this.lstvMailList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.colNickName,
																						   this.colMailAddr});
			this.lstvMailList.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstvMailList.Location = new System.Drawing.Point(0, 0);
			this.lstvMailList.Name = "lstvMailList";
			this.lstvMailList.Scrollable = false;
			this.lstvMailList.Size = new System.Drawing.Size(352, 104);
			this.lstvMailList.TabIndex = 0;
			this.lstvMailList.View = System.Windows.Forms.View.Details;
			this.lstvMailList.SelectedIndexChanged += new System.EventHandler(this.lstvMailList_SelectedIndexChanged);
			// 
			// colNickName
			// 
			this.colNickName.Text = "昵称";
			this.colNickName.Width = 89;
			// 
			// colMailAddr
			// 
			this.colMailAddr.Text = "邮件地址";
			this.colMailAddr.Width = 263;
			// 
			// splRight
			// 
			this.splRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.splRight.Location = new System.Drawing.Point(349, 104);
			this.splRight.Name = "splRight";
			this.splRight.Size = new System.Drawing.Size(3, 222);
			this.splRight.TabIndex = 1;
			this.splRight.TabStop = false;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(24, 240);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(40, 24);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "添加";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(88, 240);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(48, 23);
			this.btnDel.TabIndex = 3;
			this.btnDel.Text = "删除";
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnChange
			// 
			this.btnChange.Location = new System.Drawing.Point(152, 240);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(48, 23);
			this.btnChange.TabIndex = 4;
			this.btnChange.Text = "修改";
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(224, 240);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(48, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "清空";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// grpInfo
			// 
			this.grpInfo.Controls.Add(this.txtMailAddr);
			this.grpInfo.Controls.Add(this.txtNickName);
			this.grpInfo.Controls.Add(this.lblMailAddr);
			this.grpInfo.Controls.Add(this.lblNickName);
			this.grpInfo.Location = new System.Drawing.Point(16, 136);
			this.grpInfo.Name = "grpInfo";
			this.grpInfo.Size = new System.Drawing.Size(320, 88);
			this.grpInfo.TabIndex = 6;
			this.grpInfo.TabStop = false;
			// 
			// txtMailAddr
			// 
			this.txtMailAddr.Location = new System.Drawing.Point(112, 56);
			this.txtMailAddr.Name = "txtMailAddr";
			this.txtMailAddr.Size = new System.Drawing.Size(192, 20);
			this.txtMailAddr.TabIndex = 3;
			this.txtMailAddr.Text = "";
			// 
			// txtNickName
			// 
			this.txtNickName.Location = new System.Drawing.Point(112, 24);
			this.txtNickName.Name = "txtNickName";
			this.txtNickName.Size = new System.Drawing.Size(192, 20);
			this.txtNickName.TabIndex = 2;
			this.txtNickName.Text = "";
			// 
			// lblMailAddr
			// 
			this.lblMailAddr.Location = new System.Drawing.Point(16, 56);
			this.lblMailAddr.Name = "lblMailAddr";
			this.lblMailAddr.Size = new System.Drawing.Size(64, 16);
			this.lblMailAddr.TabIndex = 1;
			this.lblMailAddr.Text = "邮件地址";
			// 
			// lblNickName
			// 
			this.lblNickName.Location = new System.Drawing.Point(16, 24);
			this.lblNickName.Name = "lblNickName";
			this.lblNickName.Size = new System.Drawing.Size(64, 16);
			this.lblNickName.TabIndex = 0;
			this.lblNickName.Text = "昵称";
			// 
			// errpOption
			// 
			this.errpOption.ContainerControl = this;
			// 
			// btnOptYes
			// 
			this.btnOptYes.Location = new System.Drawing.Point(56, 280);
			this.btnOptYes.Name = "btnOptYes";
			this.btnOptYes.TabIndex = 7;
			this.btnOptYes.Text = "确定";
			this.btnOptYes.Click += new System.EventHandler(this.btnOptYes_Click);
			// 
			// btnOptNo
			// 
			this.btnOptNo.Location = new System.Drawing.Point(176, 280);
			this.btnOptNo.Name = "btnOptNo";
			this.btnOptNo.TabIndex = 8;
			this.btnOptNo.Text = "取消";
			this.btnOptNo.Click += new System.EventHandler(this.btnOptNo_Click);
			// 
			// lblHint
			// 
			this.lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHint.Location = new System.Drawing.Point(24, 112);
			this.lblHint.Name = "lblHint";
			this.lblHint.Size = new System.Drawing.Size(288, 16);
			this.lblHint.TabIndex = 9;
			this.lblHint.Text = "若列表为空，则监视所有邮件";
			// 
			// frmOption
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 326);
			this.Controls.Add(this.lblHint);
			this.Controls.Add(this.btnOptNo);
			this.Controls.Add(this.btnOptYes);
			this.Controls.Add(this.grpInfo);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnChange);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.splRight);
			this.Controls.Add(this.lstvMailList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(360, 360);
			this.MinimumSize = new System.Drawing.Size(360, 360);
			this.Name = "frmOption";
			this.Text = "监视对象设置";
			this.Load += new System.EventHandler(this.frmOption_Load);
			this.grpInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			bool flag = true;

			if (this.txtNickName.Text.Trim() == "")
			{
				this.errpOption.SetError(this.txtNickName, "请输入昵称");
				flag = false;
			}
			else
			{
				this.errpOption.SetError(this.txtNickName, "");
			}

			if (this.txtMailAddr.Text.Trim().IndexOf('@') <= 1 || this.txtMailAddr.Text.Trim().EndsWith("@") ||
				this.txtMailAddr.Text.Trim().LastIndexOf('@') != this.txtMailAddr.Text.Trim().IndexOf('@'))
			{
				this.errpOption.SetError(this.txtMailAddr, "请输入正确邮箱地址");
				flag = false;
			}
			else
			{
				this.errpOption.SetError(this.txtMailAddr, "");
			}

			if (flag)
			{
				this.lstvMailList.Items.Add(new System.Windows.Forms.ListViewItem(new string[] {this.txtNickName.Text.Trim(), this.txtMailAddr.Text.Trim()}));
				this.txtNickName.Text = "";
				this.txtMailAddr.Text = "";
			}
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			while (this.lstvMailList.SelectedItems.Count > 0)
			{
				this.lstvMailList.Items.Remove(this.lstvMailList.SelectedItems[0]);
			}
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.lstvMailList.Items.Clear();
		}

		private void btnChange_Click(object sender, System.EventArgs e)
		{
			if (this.lstvMailList.SelectedItems.Count > 1 || this.lstvMailList.SelectedItems.Count == 0)
			{
				this.errpOption.SetError(this.btnChange, "修改时每次要选并只能选择一项");
			}
			else
			{
				bool flag = true;
				if (this.txtNickName.Text.Trim() == "")
				{
					this.errpOption.SetError(this.txtNickName, "请输入昵称");
					flag = false;
				}
				else
				{
					this.errpOption.SetError(this.txtNickName, "");
				}

				if (this.txtMailAddr.Text.Trim().IndexOf('@') <= 1 || this.txtMailAddr.Text.Trim().EndsWith("@") ||
					this.txtMailAddr.Text.Trim().LastIndexOf('@') != this.txtMailAddr.Text.Trim().IndexOf('@'))
				{
					this.errpOption.SetError(this.txtMailAddr, "请输入正确邮箱地址");
					flag = false;
				}
				else
				{
					this.errpOption.SetError(this.txtMailAddr, "");
				}

				if (flag)
				{
					int k = this.lstvMailList.SelectedIndices[0];
					this.lstvMailList.Items.Insert(k, new System.Windows.Forms.ListViewItem(new string[] {this.txtNickName.Text.Trim(), this.txtMailAddr.Text.Trim()}));
					this.lstvMailList.Items.RemoveAt(k + 1);
					this.txtNickName.Text = "";
					this.txtMailAddr.Text = "";
				}
			}
		}

		private void btnOptYes_Click(object sender, System.EventArgs e)
		{
			int count = this.lstvMailList.Items.Count;
			
			if (count == 0)
			{
				frmDoggy.mstrNickName = null;
				frmDoggy.mstrMailAddr = null;
			}
			else
			{
				frmDoggy.mstrNickName = new string[count];
				frmDoggy.mstrScanAddr = new string[count];
			
				for (int i=0; i<count; i++)
				{
					frmDoggy.mstrNickName[i] = this.lstvMailList.Items[i].SubItems[0].Text;
					frmDoggy.mstrScanAddr[i] = this.lstvMailList.Items[i].SubItems[1].Text;
				}
			}
			this.Close();
		}

		private void lstvMailList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.errpOption.SetError(this.btnChange, "");
		}

		private void frmOption_Load(object sender, System.EventArgs e)
		{
			if (frmDoggy.mstrNickName != null)
			{
				for (int i=0; i<frmDoggy.mstrNickName.Length; i++)
				{
					this.lstvMailList.Items.Add(new System.Windows.Forms.ListViewItem(new string[] {frmDoggy.mstrNickName[i], frmDoggy.mstrScanAddr[i]}));
				}
			}
		}

		private void btnOptNo_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
