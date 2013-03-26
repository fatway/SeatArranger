using System;
using System.Collections.Generic;
using System.IO;

namespace SeatArranger
{
	/// <summary>
	/// Description of Project.
	/// </summary>
	public class Project
	{
		public Project()
		{
		}
		
		public static void Save(string prjPath, int deskRow, string deskColFormat, List<Student> listStudent)
		{
			FileStream fs = new FileStream(prjPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			BinaryWriter bw = new BinaryWriter(fs);
			
			
			bw.Write(deskRow);
			bw.Write(deskColFormat);
			
			
			bw.Write(listStudent.Count);
			
			foreach (Student std in listStudent)
			{
				bw.Write(std.id);
				bw.Write(std.name);
				
				if (std.sex == Student.Sex.male)
					bw.Write("男");
				else
					bw.Write("女");
				
				bw.Write(std.X);
				bw.Write(std.Y);
				
			}
			
			
			
			bw.Close();
			fs.Close();
		}
		
		public static bool Read(string prjPath, out int deskRow, out string deskColFormat, out List<Student> listStudent)
		{
			deskRow = 0;
			deskColFormat = "";
			listStudent = new List<Student>();
			
			
			FileStream fs = new FileStream(prjPath, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			
			
			try {
				
				br.BaseStream.Seek(0, SeekOrigin.Begin);
				
				deskRow = br.ReadInt32();
				deskColFormat = br.ReadString();
				
				
				int stdCount = br.ReadInt32();
				for (int i = 0; i < stdCount; i++) {
					
					int id = br.ReadInt32();
					string name = br.ReadString();	
					
					string sex = br.ReadString();
					Student.Sex stdSex = (sex == "男")? Student.Sex.male: Student.Sex.female;
                    				
					
					int x = br.ReadInt32();
					int y = br.ReadInt32();
					
					Student std = new Student(id, name, stdSex);
					std.X = x;
					std.Y = y;
					
					listStudent.Add(std);
				}
				
				
			} catch (Exception) {

				return false;
			}
			finally
			{
				br.Close();
				fs.Close();
			}
			
			
			return true;
		}
	}
}
