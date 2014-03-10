using System;
using System.IO ;
using System.Net;
using System.Net.Sockets ;
using System.Windows.Forms;
using System.Text;

namespace Doggy
{
	/// <summary>
	/// POP3Client �Ƿ�װ��VS.net������POP3Э�鷢�ʼ��� C#�ࡣ
	/// </summary>

	public class POP3Client
	{
		private string mPopServer;	// ����POP3������
		private string mUserName;	// �����û���
		private string mPassword;	// ��������
		private int mPort;	// ��������POP3�������Ķ˿�

		private System.Net.Sockets.NetworkStream mNetStream;	// ��POP3������������Ϣ��������
		private System.Net.Sockets.TcpClient mTcpClient;	// ��������POP3������

		public POP3Client()
		{
			// Ĭ�Ϲ��캯��

			mPort = 110;	// Ĭ��Ϊ110
		}

		public POP3Client(string strPopServer, string strUserName, string strPassword)
		{
			// ��ʹ��POP�ʼ����������˿ڣ��û���������
			mPopServer = strPopServer;
			mPort = 110;	// Ĭ��Ϊ110
			mUserName = strUserName;
			mPassword = strPassword;
		}

		public POP3Client(string strPopServer, int iPort, string strUserName, string strPassword)
		{
			// ��ʹ��POP�ʼ����������˿ڣ��û���������
			mPopServer = strPopServer;
			mPort = iPort;
			mUserName = strUserName;
			mPassword = strPassword;
		}

		public void Connect()
		{
			// ����POP3������
			mTcpClient = new TcpClient();
			try
			{
				mTcpClient.Connect(mPopServer, mPort); 
			}
			catch
			{
				throw new System.Exception("�޷����ӵ������� " + mPopServer + ":" + mPort.ToString());
			}

			mNetStream = mTcpClient.GetStream();	// �ӷ�����ȡ�ûظ�
			if (mNetStream == null)
			{
				throw new System.Exception("�޷�ȡ�ûظ�");
			}
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ

			SendCommand("USER " + mUserName);	// �����û�����Ϣ
			strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ

			SendCommand("PASS " + mPassword);	// ����������Ϣ
			strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
		}

		public void Disconnect()
		{
			// �Ͽ�����
			mNetStream.Close();
			mTcpClient.Close();
		}

		public void Stat(ref int iCount, ref int iTotalSize)
		{
			// ����POP3��STAT���POP3������
			SendCommand("STAT");
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
				
			string[] strSplit = strRetMsg.Split(new char[] {' '});	// �����Ϣ
			iCount = Int32.Parse(strSplit[1]);
			iTotalSize = Int32.Parse(strSplit[2]);
		}

		public int List(int iIndex)
		{
			// LIST����
			SendCommand("LIST");
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
				
			string[] strSplit = strRetMsg.Split(new char[] {' '});	// �����Ϣ
			return Int32.Parse(strSplit[2]);
		}

		public int Retr(int iIndex, ref String strMailContent)
		{
			// RETR����
			SendCommand("RETR " + iIndex.ToString());
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
			
			string[] strSplit = strRetMsg.Split(new char[] {' '});
			strMailContent = ReadMultiFromNetStream();
			return Int32.Parse(strSplit[1]);
		}

		public int RetrSender(int iIndex, ref String strMailContent)
		{
			// RETR������ط����˵�ַ������
			SendCommand("RETR " + iIndex.ToString());
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
			
			string[] strSplit = strRetMsg.Split(new char[] {' '});
			strMailContent = ReadSenderFromNetStream();
			return Int32.Parse(strSplit[1]);
		}

		public bool Noop()
		{
			// NOOP����
			SendCommand("NOOP");
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
			return true;
		}

		public bool Dele(int Index)
		{
			// DELE����
			SendCommand("DELE");
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
			return true;
		}

		public bool Quit()
		{
			// QUIT����
			SendCommand("QUIT");
			String strRetMsg = ReadSingleFromNetStream();	// �ӷ�������������Ϣ
			CheckForError(strRetMsg);	// ��ⷵ����Ϣ
			return true;
		}

		private void SendCommand(string strCommand)
		{
			// ��ʽ�������͵�POP�����������������
			string strToSend = strCommand + "\r\n";	// POP3Ĭ�������Իس����н�β
			Byte[] arrToSend = Encoding.ASCII.GetBytes(strToSend.ToCharArray());
			mNetStream.Write(arrToSend, 0, arrToSend.Length);

		}

		private String ReadSingleFromNetStream()
		{
			// ���������ж�ȡһ����Ϣ
			StreamReader strReader = new StreamReader(mNetStream);
			String strLine = strReader.ReadLine();
			
			return strLine;
		}

		private String ReadSenderFromNetStream()
		{
			// ���������ж�ȡ��Ϣ����������������������
			StreamReader strReader = new StreamReader(mNetStream);
			String strLine = strReader.ReadLine();

			if(strLine[0] != '-')	// POP3�ж�һ���������Ӧ��-OK��-ERR��ͷ
			{
				while(strLine != "." && strLine.IndexOf("From:") == -1 && strLine.IndexOf("from:") == -1)	// POP3�з��صĶ�����Ϣ�Ե������е�"."��β
				{
					strLine = strReader.ReadLine();
				}
			}
			
			return strLine;
		}

		private String ReadMultiFromNetStream()
		{
			// ���������ж�ȡ������Ϣ����Ը�POP3������Ϣ��ʽ��д���������ʼ�����
			StreamReader strReader = new StreamReader(mNetStream);
			String strLine = strReader.ReadLine();
			String strReceiver = "";

			if(strLine[0] != '-')	// POP3�ж�һ���������Ӧ��-OK��-ERR��ͷ
			{
				while(strLine != ".")	// POP3�з��صĶ�����Ϣ�Ե������е�"."��β
				{
					strReceiver += strLine + "\r\n";
					strLine = strReader.ReadLine();
				}
			}
			
			return strReceiver;
		}

		private void CheckForError(String strMsg)
		{
			// ���POP3������������Ϣ�Ĵ�������Ϣ�����׳��쳣
			if (strMsg.IndexOf("+OK") == -1)
			{
				throw new System.Exception("�յ������ʼ��������Ĵ�����Ϣ�� " + strMsg);
			}
		}
	}
}
