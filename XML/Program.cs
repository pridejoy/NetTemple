using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XML
{
	class Program
	{
		static void Main(string[] args)
		{
			//xml文件生成
			XDocument employeeDoc =
			 new XDocument(
				 new XElement("Employees",
					 new XElement("Name", "Bob"),
					 new XElement("ISBN", "2020-2-311")
					 )
				 );
			Console.WriteLine(employeeDoc);
			System.IO.File.AppendAllText("employeeDoc.xml", employeeDoc.ToString());


			//读取
			XmlDocument doc = new XmlDocument();
			doc.Load(@"..\..\Book.xml");
			List<BookModel> bmlist = new List<BookModel>();

			XmlNode xn = doc.SelectSingleNode("bookstore");
			XmlNodeList xnl = xn.ChildNodes;
			foreach (XmlNode xn1 in xnl)
			{
				BookModel bm = new BookModel();
				XmlElement xe = (XmlElement)xn1;
				bm.BookISBN = xe.GetAttribute("ISBN").ToString();
				bm.BookType = xe.GetAttribute("Type").ToString();
				XmlNodeList xml0 = xe.ChildNodes;
				bm.BookName = xml0.Item(0).InnerText;
				bm.BookType = xml0.Item(1).InnerText;

				bm.BookPrice = Convert.ToDouble(xml0.Item(2).InnerText);

				bmlist.Add(bm);
				DataContractJsonSerializer json = new DataContractJsonSerializer(bmlist.GetType());

				string szJson = "";

				//序列化

				using (MemoryStream stream = new MemoryStream())
				{

					json.WriteObject(stream, bmlist);

					szJson = Encoding.UTF8.GetString(stream.ToArray());

				}
				Console.WriteLine(szJson);
				Console.ReadLine();
			}

		}


		public class BookModel
		{
			public BookModel()
			{ }
			/// <summary>
			/// 所对应的课程类型
			/// </summary>
			private string bookType;

			public string BookType
			{
				get { return bookType; }
				set { bookType = value; }
			}

			/// <summary>
			/// 书所对应的ISBN号
			/// </summary>
			private string bookISBN;

			public string BookISBN
			{
				get { return bookISBN; }
				set { bookISBN = value; }
			}

			/// <summary>
			/// 书名
			/// </summary>
			private string bookName;

			public string BookName
			{
				get { return bookName; }
				set { bookName = value; }
			}

			/// <summary>
			/// 作者
			/// </summary>
			private string bookAuthor;

			public string BookAuthor
			{
				get { return bookAuthor; }
				set { bookAuthor = value; }
			}

			/// <summary>
			/// 价格
			/// </summary>
			private double bookPrice;

			public double BookPrice
			{
				get { return bookPrice; }
				set { bookPrice = value; }
			}
		}
	}

}
