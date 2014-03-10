using System;
using System.IO ;
using System.Net;
using System.Net.Sockets ;
using System.Windows.Forms;
using System.Text;

namespace Doggy
{
	/// <summary>
	/// POP3Client 是封装了VS.net下利用POP3协议发邮件的 C#类。
	/// </summary>

	public class POP3Client
	{
		private string mPopServer;	// 邮箱POP3服务器
		private string mUserName;	// 邮箱用户名
		private string mPassword;	// 邮箱密码
		private int mPort;	// 连接邮箱POP3服务器的端口

		private System.Net.Sockets.NetworkStream mNetStream;	// 读POP3服务器返回信息的网络流
		private System.Net.Sockets.TcpClient mTcpClient;	// 用于连接POP3服务器

		public POP3Client()
		{
			// 默认构造函数

			mPort = 110;	// 默认为110
		}

		public POP3Client(string strPopServer, string strUserName, string strPassword)
		{
			// 初使化POP邮件服务器，端口，用户名，密码
			mPopServer = strPopServer;
			mPort = 110;	// 默认为110
			mUserName = strUserName;
			mPassword = strPassword;
		}

		public POP3Client(string strPopServer, int iPort, string strUserName, string strPassword)
		{
			// 初使化POP邮件服务器，端口，用户名，密码
			mPopServer = strPopServer;
			mPort = iPort;
			mUserName = strUserName;
			mPassword = strPassword;
		}

		public void Connect()
		{
			// 连接POP3服务器
			mTcpClient = new TcpClient();
			try
			{
				mTcpClient.Connect(mPopServer, mPort); 
			}
			catch
			{
				throw new System.Exception("无法连接到服务器 " + mPopServer + ":" + mPort.ToString());
			}

			mNetStream = mTcpClient.GetStream();	// 从服务器取得回复
			if (mNetStream == null)
			{
				throw new System.Exception("无法取得回复");
			}
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息

			SendCommand("USER " + mUserName);	// 发送用户名信息
			strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息

			SendCommand("PASS " + mPassword);	// 发送密码信息
			strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
		}

		public void Disconnect()
		{
			// 断开连接
			mNetStream.Close();
			mTcpClient.Close();
		}

		public void Stat(ref int iCount, ref int iTotalSize)
		{
			// 发送POP3的STAT命令到POP3服务器
			SendCommand("STAT");
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
				
			string[] strSplit = strRetMsg.Split(new char[] {' '});	// 拆分信息
			iCount = Int32.Parse(strSplit[1]);
			iTotalSize = Int32.Parse(strSplit[2]);
		}

		public int List(int iIndex)
		{
			// LIST命令
			SendCommand("LIST");
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
				
			string[] strSplit = strRetMsg.Split(new char[] {' '});	// 拆分信息
			return Int32.Parse(strSplit[2]);
		}

		public int Retr(int iIndex, ref String strMailContent)
		{
			// RETR命令
			SendCommand("RETR " + iIndex.ToString());
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
			
			string[] strSplit = strRetMsg.Split(new char[] {' '});
			strMailContent = ReadMultiFromNetStream();
			return Int32.Parse(strSplit[1]);
		}

		public int RetrSender(int iIndex, ref String strMailContent)
		{
			// RETR命令，返回发件人地址所在行
			SendCommand("RETR " + iIndex.ToString());
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
			
			string[] strSplit = strRetMsg.Split(new char[] {' '});
			strMailContent = ReadSenderFromNetStream();
			return Int32.Parse(strSplit[1]);
		}

		public bool Noop()
		{
			// NOOP命令
			SendCommand("NOOP");
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
			return true;
		}

		public bool Dele(int Index)
		{
			// DELE命令
			SendCommand("DELE");
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
			return true;
		}

		public bool Quit()
		{
			// QUIT命令
			SendCommand("QUIT");
			String strRetMsg = ReadSingleFromNetStream();	// 从服务器读返回信息
			CheckForError(strRetMsg);	// 检测返回信息
			return true;
		}

		private void SendCommand(string strCommand)
		{
			// 格式化将发送到POP服务器的命令，并发送
			string strToSend = strCommand + "\r\n";	// POP3默认命令以回车换行结尾
			Byte[] arrToSend = Encoding.ASCII.GetBytes(strToSend.ToCharArray());
			mNetStream.Write(arrToSend, 0, arrToSend.Length);

		}

		private String ReadSingleFromNetStream()
		{
			// 从网络流中读取一行信息
			StreamReader strReader = new StreamReader(mNetStream);
			String strLine = strReader.ReadLine();
			
			return strLine;
		}

		private String ReadSenderFromNetStream()
		{
			// 从网络流中读取信息，用来读到发件人所在行
			StreamReader strReader = new StreamReader(mNetStream);
			String strLine = strReader.ReadLine();

			if(strLine[0] != '-')	// POP3中对一个命令的响应是-OK或-ERR开头
			{
				while(strLine != "." && strLine.IndexOf("From:") == -1 && strLine.IndexOf("from:") == -1)	// POP3中返回的多行信息以单独成行的"."结尾
				{
					strLine = strReader.ReadLine();
				}
			}
			
			return strLine;
		}

		private String ReadMultiFromNetStream()
		{
			// 从网络流中读取多行信息，针对该POP3返回信息方式编写，用来读邮件内容
			StreamReader strReader = new StreamReader(mNetStream);
			String strLine = strReader.ReadLine();
			String strReceiver = "";

			if(strLine[0] != '-')	// POP3中对一个命令的响应是-OK或-ERR开头
			{
				while(strLine != ".")	// POP3中返回的多行信息以单独成行的"."结尾
				{
					strReceiver += strLine + "\r\n";
					strLine = strReader.ReadLine();
				}
			}
			
			return strReceiver;
		}

		private void CheckForError(String strMsg)
		{
			// 检测POP3服务器返回信息的错误码信息，并抛出异常
			if (strMsg.IndexOf("+OK") == -1)
			{
				throw new System.Exception("收到来自邮件服务器的错误信息： " + strMsg);
			}
		}
	}
}
